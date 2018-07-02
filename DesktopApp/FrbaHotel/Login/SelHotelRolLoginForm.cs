using FrbaHotel.Control;
using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class SelHotelRolLoginForm : Form
    {
        private int id_usuario;
        public int id_hotelSeleccionado;
        public int id_RolSeleccionado;
        public SelHotelRolLoginForm(int idUsuario) 
        {
            
            this.id_usuario = idUsuario;
            InitializeComponent();
            panelDireccion.Enabled = false;
            panelRol.Enabled = true;
            btnOK.Enabled = false;
      
        }

        private void SeleccionNuevoHotel_RolFormcs_Load(object sender, EventArgs e)
        {
            this.cargarRolesSesion();
        
        }

        private void cargarRolesSesion()
        {
            Rol_Ctrl rolCtrl = new Rol_Ctrl();
            List<Rol> rolesAsignados = rolCtrl.obtenerRolesPorID(id_usuario);
            if (rolesAsignados.Count == 1)
            {
                panelRol.Enabled = false;
                rolesComboBox.SelectedText = rolesAsignados.First().nombre;
                id_RolSeleccionado = rolesAsignados.First().id_rol;
                panelDireccion.Enabled = true;
                this.cargarHotelSesion();
            }
            else
            {
                this.completarComboRoles(rolesAsignados);
            }
        }

        private void completarComboRoles(List<Rol> rolesAsignados)
        {
            rolesComboBox.DisplayMember = "nombre";
            rolesComboBox.ValueMember = "id_rol";
            rolesComboBox.DataSource = rolesAsignados;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
       
        }

        private void selecRolButton_Click(object sender, EventArgs e)
        {
            id_RolSeleccionado = (int)rolesComboBox.SelectedValue;
            panelRol.Enabled = false;
            panelDireccion.Enabled = true;
            this.cargarHotelSesion();
        }

        private void cargarHotelSesion()
        {
            Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
            List<Hotel> hotelesAsignados = new List<Hotel>();
            hotelesAsignados = hotelCtrl.obtenerHotelesPorID_IDRol(id_usuario, id_RolSeleccionado);
            if (hotelesAsignados.Count == 1)
            {
                panelRol.Enabled = false;
                hotelesComboBox.SelectedText = hotelesAsignados.First().nombre;
                id_hotelSeleccionado = hotelesAsignados.First().id_hotel;
            }
            else
            {
                this.completarComboHoteles(hotelesAsignados);
            }
        }

        private void completarComboHoteles(List<Hotel> hotelesAsignados)
        {
            hotelesComboBox.DisplayMember = "nombre";
            hotelesComboBox.ValueMember = "id_hotel";
            hotelesComboBox.DataSource = hotelesAsignados;
        }

        private void selecHotelButton_Click(object sender, EventArgs e)
        {
            id_hotelSeleccionado = (int)hotelesComboBox.SelectedValue;
            panelDireccion.Enabled = false;
            btnOK.Enabled = true;
            btnOK.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
