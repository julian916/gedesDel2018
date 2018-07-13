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

namespace FrbaHotel.CancelarReserva
{
    public partial class CancelarReservaForm : Form
    {
        int id_reserva;
        public CancelarReservaForm()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void CancelarReservaForm_Load(object sender, EventArgs e)
        {
            try
            {
                Reserva_Ctrl reservaCtrl = new Reserva_Ctrl();
                Reserva reserva = reservaCtrl.buscaReserva_PorID(Convert.ToInt32(codResBox.Text));
                reservaCtrl.cancelarReserva(id_reserva, motivoBox.Text, fechaCancelacionBox.Value, DatosSesion.id_usuario);
                    
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);

            }
        }
    }
}
