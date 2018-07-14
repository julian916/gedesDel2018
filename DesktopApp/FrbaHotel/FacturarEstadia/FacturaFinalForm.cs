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
    public partial class FacturaFinalForm : Form
    {
        public bool seGeneroFactura=false;
        public Factura facturaFinal = new Factura();
        Estadia_Ctrl estadiaCtrl =  new Estadia_Ctrl();
        Estadia estadiaFinal = new Estadia();
        Reserva reservaFinal = new Reserva();
        public FacturaFinalForm(Estadia estadia, Reserva reserva)
        {
            InitializeComponent();
            estadiaFinal = estadia;
            reservaFinal = reserva;
            this.seleccionarMetodoPago();
            if (this.seGeneroFactura) {
                this.facturarEstadia();    
            }
        }

        private void seleccionarMetodoPago()
        {
            MetodoPagoForm metodoPagoForm = new MetodoPagoForm(estadiaFinal,reservaFinal);
            if (metodoPagoForm.ShowDialog(this) == DialogResult.OK)
            {
                facturaFinal.precio_total = metodoPagoForm.facturaIniciada.precio_total;
                facturaFinal.id_forma_depago = metodoPagoForm.facturaIniciada.id_forma_depago;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show("Operacion cancelada");
            }
        }

        private void facturarEstadia()
        {
            try
            {
                facturaFinal.fecha = estadiaFinal.fecha_inicio;
                facturaFinal.id_estadia = estadiaFinal.id_estadia;
                facturaFinal.id_persona = reservaFinal.id_persona;
                int id_factura = estadiaCtrl.facturarEstadia(facturaFinal);
                facturaFinal.nro_factura = id_factura;
                facturaFinal.puntosObtenidos = estadiaCtrl.getPuntosObtenidos(facturaFinal.nro_factura);
                MessageBox.Show("Se facturó correctamente la estadía. A continuación se detalla la informacion");
            }
            catch (Exception exc) {
                this.DialogResult=DialogResult.Cancel;
                MessageBox.Show(exc.Message);
            }
        }

        private void FacturaFinalForm_Load(object sender, EventArgs e)
        {
            Persona_Ctrl personaCtrl = new Persona_Ctrl();
            Persona persona = personaCtrl.getPersona_IDPersona(reservaFinal.id_persona); 
            nroFactBox.Text = Convert.ToString(facturaFinal.nro_factura);
            titularBox.Text = persona.apellido + ' ' + persona.nombre;
            fechaFactBox.Value = facturaFinal.fecha;
            montoTotalBox.Text = Convert.ToString(facturaFinal.precio_total);

            estadiaFinal.consumibles = estadiaFinal.consumibles;
            foreach (Consumible consumible in estadiaFinal.consumibles)
            {
                for (int i = 0; i < dataGridFactura.Rows.Count; i++)
                {
                    var row = this.dataGridFactura.Rows[i];
                    row.Cells["Nro_Item"].Value = i;
                    row.Cells["Consumible"].Value = consumible.descripcion;
                    row.Cells["Cantidad"].Value = consumible.cantidad;
                    row.Cells["Precio Acumulado"].Value = consumible.cantidad * consumible.precio;
                }
            }
        }

        private void aceptarBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        
    }
}
