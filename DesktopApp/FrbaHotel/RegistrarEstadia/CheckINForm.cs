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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class CheckINForm : Form
    {
        Reserva reservaSeleccionada;
        Reserva_Ctrl reservaCtrl = new Reserva_Ctrl();
        public CheckINForm()
        {
            InitializeComponent();
            panel1.Enabled = false;
            addHuespedBtn.Enabled = false;
            regCheckInBtn.Enabled = false;
        }

        private void buscarResBtn_Click(object sender, EventArgs e)
        {
            reservaSeleccionada = reservaCtrl.getReservaConID(Convert.ToInt32(codReservaBox.Text));
            if (reservaSeleccionada != null)
            {

            }
            else { 
                
            }
        }
    }
}
