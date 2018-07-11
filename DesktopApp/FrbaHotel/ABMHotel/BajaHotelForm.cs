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
    }
}
