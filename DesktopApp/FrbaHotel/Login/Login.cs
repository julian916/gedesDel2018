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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void acceptLoginButton_Click(object sender, EventArgs e)
        {

            string connectionString = null;
            connectionString = "Data Source=LOCALHOST\\SQLSERVER2012;Initial Catalog=GD1C2018;User ID=gdHotel2018;Password=gd2018";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand spCommand = new SqlCommand("sp_login", con);
            spCommand.CommandType = CommandType.StoredProcedure;
            con.Open();
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@usuario", userLoginBox.Text));
            spCommand.Parameters.Add(new SqlParameter("@contras", textBox2.Text));
            SqlParameter paramCantInsert = new SqlParameter();
            paramCantInsert.ParameterName = "@usuario_encontrado";
            paramCantInsert.SqlDbType = SqlDbType.Bit;
            paramCantInsert.Direction = ParameterDirection.Output;
            bool se_Logueo = false; //paramCantInsert.Value; //TODO: terminar logica de si se logeo
        
            try
            {
                spCommand.ExecuteNonQuery();
                if (se_Logueo)//Login correcto
                {
                    //this.Close();
                    //SqlConnection con = new SqlConnection(connectionString);
                    //SqlCommand spCommandRol = new SqlCommand("sp_RolesAsignados", con);
                    //spCommand.CommandType = CommandType.StoredProcedure;
                    //spCommand.Parameters.Clear();
                    //spCommand.Parameters.Add(new SqlParameter("@usuario", userLoginBox.Text));
                    
                    //formAltaCliente.Show();
                }
                else
                {
                    userLoginBox.Clear();
                    throw new System.ArgumentException("Existe un usuario con el valor ingresado. Reingrese el username");
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
                con.Close();
            }	

        }

        private void cancelLogin_Click(object sender, EventArgs e)
        {
            Inicio obj = new Inicio();
            if (obj == null)
            {
                obj.Parent = this;
            }
            obj.Show();
            this.Hide();
        }
    }
}
