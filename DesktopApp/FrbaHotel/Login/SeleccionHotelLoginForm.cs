using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class SeleccionHotelLoginForm : Form
    {
        public DataTable seleccionHoteles;
        public int id_hotelSeleccionado;

        public SeleccionHotelLoginForm(DataTable dataHotelesXUsuario){
            InitializeComponent();
            this.seleccionHoteles = dataHotelesXUsuario;
        }

        private void SeleccionHotelLoginForm_Load(object sender, EventArgs e)
        {
            
                comboHotelesValidos.DisplayMember = "nombre";
                comboHotelesValidos.ValueMember = "id_hotel";
                comboHotelesValidos.DataSource = seleccionHoteles;
            }

        private void button1_Click(object sender, EventArgs e)
            {

                id_hotelSeleccionado = Int32.Parse(comboHotelesValidos.SelectedValue.ToString());
            }

        }

   
}
