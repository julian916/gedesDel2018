using FrbaHotel.Control;
using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.FacturarEstadia
{
    public partial class MetodoPagoForm : Form
    {
        Estadia estadiaFactura = new Estadia();
        Reserva reservaFactura = new Reserva();
        public Factura facturaIniciada = new Factura();
        decimal monto_total;
        Estadia_Ctrl estadiaCtrl = new Estadia_Ctrl();
        public MetodoPagoForm(Estadia estadia, Reserva reserva)
        {
            InitializeComponent();
            reservaFactura = reserva;
            estadiaFactura = estadia;
            this.cargarMetodosPago();
            this.cargarInfoEstadia();

        }

        private void cargarInfoEstadia()
        {
            monto_total = estadiaCtrl.getMontoTotalEstadia(estadiaFactura.id_estadia);
            idEstadiaBox.Text = Convert.ToString(estadiaFactura.id_estadia);
            diasAlojBox.Text = Convert.ToString(estadiaFactura.cant_noches);
            diasNoEfectBox.Text = Convert.ToString(reservaFactura.cantidad_noches - estadiaFactura.cant_noches);
            montoTotalBox.Text = Convert.ToString(monto_total);
        }

        private void cargarMetodosPago()
        {
            List<Forma_de_Pago> formasDePago = estadiaCtrl.getAllMetodosPagos();
            metodoPagoBox.DisplayMember = "descripcion";
            metodoPagoBox.ValueMember = "id_forma_de_pago";
            metodoPagoBox.DataSource = formasDePago;
        }

        private void finalizarBtn_Click(object sender, EventArgs e)
        {
            facturaIniciada.precio_total = monto_total;
            facturaIniciada.id_forma_depago = (int) metodoPagoBox.SelectedValue;
        }

    }
}
