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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class CodReservaForm : Form
    {
        public Reserva reservaEncontrada;
        public Reserva_Ctrl reservaCtrl = new Reserva_Ctrl();
        public CodReservaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reservaEncontrada = reservaCtrl.getReservaConID(Convert.ToInt32(codReservaBox.Text));
            reservaEncontrada.id_hotel = reservaCtrl.getIDHotelDeReserva(reservaEncontrada.id_reserva);
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
            this.Close();
        }
    }
}
