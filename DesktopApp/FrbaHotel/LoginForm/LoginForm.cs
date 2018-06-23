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
        /*LoginManager _loginMan = new LoginManager();
        UsuarioManager _userMan = new UsuarioManager();
        RolManager _rolMan = new RolManager();
        HotelManager _hotelMan = new HotelManager();
        FuncionalidadManager _funcMan = new FuncionalidadManager();*/
        private int id_usuario;
        private string password;
        private int id_rol;
        private int id_hotel;
        private BindingList<Funcionalidad> funcionalidades;

        public string connectionString;
        public LoginForm()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        }
        private void limpiarParametros() {
            userLoginBox.Clear();
            passTextBox.Clear();
        }

        private void acceptLoginButton_Click(object sender, EventArgs e)
        {
            //obtengo funcionalidades segun el rol
            funcionalidades = _funcMan.GetPorRol(_rolMan.GetIdPorNombre(rol));
            //InicioSesion segun los datos ingresaados en una clase
            DatosSesion.iniciar_sesion(id_usuario, password, id_rol, id_hotel, funcionalidades);

            this.Dispose(); //TODO: ver si esto no borra nada
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
            loginButton.Focus();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_login", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_Login
            spCommand.Parameters.Add(new SqlParameter("@usuario", userLoginBox.Text));
            spCommand.Parameters.Add(new SqlParameter("@contras", passTextBox.Text));
            spCommand.Parameters.Add("@loginCorrecto", SqlDbType.Bit).Direction = ParameterDirection.Output;
            spCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            spCommand.Parameters.Add("@estaHabilitado", SqlDbType.Bit).Direction = ParameterDirection.Output;

            try
            {
                int idUsuario;
                spCommand.ExecuteNonQuery();
                Boolean loginCorrecto = Convert.ToBoolean(spCommand.Parameters["@loginCorrecto"].Value);
                Boolean estaHabilitado = Convert.ToBoolean(spCommand.Parameters["@estaHabilitado"].Value);

                if (spCommand.Parameters["@idUsuario"].Value == System.DBNull.Value)
                {
                    limpiarParametros();
                    throw new System.ArgumentException("No existe username ingresado. Comuniquese con el administrador para crear usuario");
                }
                else
                {
                    idUsuario = (int)spCommand.Parameters["@idUsuario"].Value;
                }
                if (loginCorrecto)
                {
                    //reinicio contador de intentos de login
                    InfoGlobal.reiniciarIntentosLogin();

                    //seteo la variable global de usuarioLogueado
                    InfoGlobal.Setid_usuarioSeleccionado(idUsuario);
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
                    else
                    {
                        //dtHotelesRolesDeUsuario.Rows[0][1] tiene el unico rol asignado
                        InfoGlobal.Setid_rolSeleccionado((int)dtHotelesRolesDeUsuario.Rows[0][1]);
                        if ((dtHotelesRolesDeUsuario.Rows[0][0]) == System.DBNull.Value)
                        {
                            //Si es null el usuario no tiene Hotel asignado. Es un Admin Gral.Para hotel no asignado se usa 0
                            InfoGlobal.Setid_HotelSeleccionado(0);
                        }
                        else
                        {
                            InfoGlobal.Setid_HotelSeleccionado((int)dtHotelesRolesDeUsuario.Rows[0][0]);
                        }

                    }
                    MenuPrincipal menu = new MenuPrincipal();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    if (estaHabilitado)
                    {
                        passTextBox.Clear();
                        InfoGlobal.incrementarIntentoLogin();
                        if (InfoGlobal.seSuperoIntentosLogin())
                        {
                            SqlCommand commandBloquear = new SqlCommand("CUATROGDD2018.SP_bloquerUsuario", connection);
                            commandBloquear.CommandType = CommandType.StoredProcedure;
                            commandBloquear.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                            commandBloquear.ExecuteNonQuery();
                            MessageBox.Show("Se superaron los intentos para iniciar sesion. Usuario bloqueado. Contacte con su Administrador para desbloquear la cuenta");

                        }
                        else
                        {
                            throw new System.ArgumentException("Contraseña incorrecta. Reingrese contraseña");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario bloqueado. Contacte con su Administrador para desbloquear la cuenta");
                    }
                }
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

    }
}
