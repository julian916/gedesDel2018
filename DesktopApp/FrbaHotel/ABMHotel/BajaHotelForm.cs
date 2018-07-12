using FrbaHotel.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.ABMHotel
{
    public partial class BajaHotelForm : Form
    {
        private int id_hotel_DarBaja;
        Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();

        public BajaHotelForm(int id_hotel)
        {
            InitializeComponent();
            this.id_hotel_DarBaja = id_hotel;
        }

        private void BajaHotelForm_Load(object sender, EventArgs e)
        {
            infoHotelBox.Text = hotelCtrl.obtenerNombreHotel(id_hotel_DarBaja);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void darDeBajaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                String mensaje = hotelCtrl.habInhHotel(id_hotel_DarBaja, fechaInicioBaja.Value, (int)cantidadDiasBox.Value, detalleBox.Text);
                if (mensaje == "")
                {
                    MessageBox.Show("El hotel se dió de baja correctamente");
                }
                else {
                    MessageBox.Show(mensaje);
                }
                this.Dispose();
                this.Close();
            }
            catch (Exception exc) {

                MessageBox.Show(exc.Message);
            }
        }

    }
}
