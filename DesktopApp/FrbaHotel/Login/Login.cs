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
        public string connectionString;
        public LoginForm()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        }

        private void acceptLoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_login", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_Login
            spCommand.Parameters.Add(new SqlParameter("@usuario", userLoginBox.Text));
            spCommand.Parameters.Add(new SqlParameter("@contras", textBox2.Text));
            Nullable<int> idUsuario = (Nullable<int>)spCommand.ExecuteScalar();
            
            try

            {
                if (idUsuario != null ) //Si es null se ingresaron datos incorrectos
                {
                    //seteo la variable global de usuarioLogueado
                    InfoGlobal.Setid_usuarioSeleccionado((int)idUsuario);
                    //Creo una dataTable para generar combo box con roles y hoteles para login
                    DataTable dtHotelesRolesDeUsuario = new DataTable();
                    SqlCommand spCommandHotelRol = new SqlCommand("CUATROGDD2018.SP_RolesXHotel", connection);
                    spCommandHotelRol.CommandType = CommandType.StoredProcedure;
                    spCommandHotelRol.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                    dtHotelesRolesDeUsuario.Load(spCommandHotelRol.ExecuteReader());
                    if (dtHotelesRolesDeUsuario.Rows.Count > 1) //Si la cantidad de filas es mayor a 1 tengo mas de un rol_X_Hotel
                    {
                        //abro ventana de seleccion de rol y hotel para la sesion
                        SeleccionHotelLoginForm seleccionHotel = new SeleccionHotelLoginForm(dtHotelesRolesDeUsuario);
                        if (seleccionHotel.ShowDialog(this) == DialogResult.OK)
                        {
                            InfoGlobal.Setid_rolSeleccionado(seleccionHotel.id_RolSeleccionado);
                            InfoGlobal.Setid_HotelSeleccionado(seleccionHotel.id_hotelSeleccionado);
                        }
                        else
                        {
                            MessageBox.Show("Operacion cancelada");
                        }
                        seleccionHotel.Dispose();

                    }
                    else {
                        //dtHotelesRolesDeUsuario.Rows[0][1] tiene el unico rol asignado
                        InfoGlobal.Setid_rolSeleccionado((int)dtHotelesRolesDeUsuario.Rows[0][1]);
                        if ((dtHotelesRolesDeUsuario.Rows[0][0]) == System.DBNull.Value)
                        {
                            //Si es null el usuario no tiene Hotel asignado. Es un Admin Gral.Para hotel no asignado se usa 0
                            InfoGlobal.Setid_HotelSeleccionado(0);
                        }
                        else {
                            InfoGlobal.Setid_HotelSeleccionado((int)dtHotelesRolesDeUsuario.Rows[0][0]);
                        }
                        
                    }                   
                }
                else
                {
                    userLoginBox.Clear();
                    throw new System.ArgumentException("Existe un usuario con el valor ingresado. Reingrese el username");
                }
                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();
                this.Hide();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error al logearse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            finally
            {
                // Cierro la Conexión.
                connection.Close();
            }

        }

        private void cancelLogin_Click(object sender, EventArgs e)
        {

            this.Hide();
        }
    }
}
