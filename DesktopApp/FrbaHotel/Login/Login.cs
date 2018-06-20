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
            //agredo parametros al SP_Login
            spCommand.Parameters.Add(new SqlParameter("@usuario", userLoginBox.Text));
            spCommand.Parameters.Add(new SqlParameter("@contras", textBox2.Text));
            spCommand.Parameters.Add("@idUsuario", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
            //Creo una dataTable para generar combo box
            DataTable dtHotelesDeUsuario = new DataTable();
            dtHotelesDeUsuario.Load(spCommand.ExecuteReader());
            int idUsuario = Int32.Parse(spCommand.Parameters["@idUsuario"].Value.ToString());
            try

            {
                if (idUsuario >0 ) //Si es null se ingresaron datos incorrectos
                {

                    if (dtHotelesDeUsuario.Rows.Count > 1) //Si la cantidad de filas es mayor a 1 tengo mas de un rol_X_Hotel
                    {
                        SeleccionHotelLoginForm seleccionHotel = new SeleccionHotelLoginForm(dtHotelesDeUsuario);
                        if (seleccionHotel.ShowDialog(this) == DialogResult.OK)
                        {
                         
                            InfoGlobal.Setid_HotelSeleccionado(seleccionHotel.id_hotelSeleccionado);
                        }
                        else
                        {
                            MessageBox.Show("Operacion cancelada");
                        }
                        seleccionHotel.Dispose();

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
