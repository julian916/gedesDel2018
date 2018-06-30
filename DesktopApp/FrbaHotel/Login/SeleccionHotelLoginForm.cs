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
        public int id_RolSeleccionado;

        public SeleccionHotelLoginForm(DataTable dataHotelesXUsuario){
            InitializeComponent();
            this.seleccionHoteles = dataHotelesXUsuario;
        }

        private void SeleccionHotelLoginForm_Load(object sender, EventArgs e)
        {
            List<InfoRolXHotel> listaRoles_X_Hotel = seleccionHoteles.AsEnumerable().Select(m => new InfoRolXHotel()
            {
                id_hotel = m.Field<int>("id_hotel"),
                id_rol = m.Field<int>("id_rol"),
                InfoRol_Hotel = m.Field<string>("Rol-Hotel"),
            }).ToList();

            comboHotelesValidos.DisplayMember = "Rol-Hotel";
            comboHotelesValidos.DataSource = listaRoles_X_Hotel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoRolXHotel combinacionSeleccionada = (InfoRolXHotel)comboHotelesValidos.SelectedItem;

            id_hotelSeleccionado = (combinacionSeleccionada.id_hotel);
            id_RolSeleccionado = (combinacionSeleccionada.id_rol);
        }

    }
   
}
