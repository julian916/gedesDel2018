using FrbaHotel.Control;
using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class LoginForm : Form
    {
        Funcionalidad_Ctrl funcCtrl = new Funcionalidad_Ctrl();
        private int id_usuario;
        private string password;
        private string username;
        private int id_rol;
        private int id_hotel;
        private List<Funcionalidad> funcionalidades;

        public string connectionString;
        public LoginForm()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        }
        private void limpiarParametros()
        {
            userLoginBox.Clear();
            passTextBox.Clear();
        }

        private void acceptLoginButton_Click(object sender, EventArgs e)
        {
            //obtengo funcionalidades segun el rol
            funcionalidades = funcCtrl.funcionalidadesXRol(id_rol);
            //InicioSesion segun los datos ingresaados en una clase
            DatosSesion.iniciar_sesion(id_usuario, password, id_rol, id_hotel, funcionalidades, username);

            this.Dispose();
            this.Close();
        }

        private void buttonGuest_Click(object sender, EventArgs e)
        {
            panelSession.Enabled = false;
            iniciarButton.Enabled = true;
            iniciarButton.Focus();
            id_hotel = 0;
            id_rol = InfoGlobal.id_rolGUEST;
            id_usuario = InfoGlobal.id_usuarioGUEST;
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            panelSession.Enabled = true;
            iniciarButton.Enabled = false;
            loginButton.Focus();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
			try {
				if ( !(String.IsNullOrEmpty(userLoginBox.Text)) && !(String.IsNullOrEmpty(passTextBox.Text))) {
					Login_Ctrl loginCtrl = new Login_Ctrl();
					id_usuario = loginCtrl.iniciarLogin (userLoginBox.Text,passTextBox.Text);
					password = Encriptacion.getHashSha256(passTextBox.Text);
					username = userLoginBox.Text;
					//Abro ventana para seleccionar hotel y rol
                    SelHotelRolLoginForm seleccionForm = new SelHotelRolLoginForm(id_usuario);
					if (seleccionForm.ShowDialog(this) == DialogResult.OK)
					{
						id_rol = seleccionForm.id_RolSeleccionado;
						id_hotel = seleccionForm.id_hotelSeleccionado;
						panelSession.Enabled = false;
						iniciarButton.Enabled = true;
						iniciarButton.Focus();
					}
					else
					{
						MessageBox.Show("Operacion cancelada");
					}
					seleccionForm.Dispose();
				}
				else
				{
					MessageBox.Show("Ingrese todos los campos.");
				}
	
			} catch (Exception exc){
				MessageBox.Show(exc.Message);
			}
		}

        private void LoginForm_Load(object sender, EventArgs e)
        {
            panelSession.Enabled = false;
            iniciarButton.Enabled = false;

        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
