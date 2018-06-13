using FrbaHotel.AbmCliente;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaUsuarioForm : Form
    {
        public string connectionString;
        public AltaUsuarioForm()
        {
            //InitializeComponent();
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        }

        private void verificar_Contrasenias()
        {
            if (passTextBox.Text != pass2TextBox.Text)
            {
                passTextBox.Clear();
                pass2TextBox.Clear();
                throw new System.ArgumentException("Las contraseñas no coinciden. Verifique los datos ingresados");
            }
        }

        private void ingresar_NuevoUsuario()
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand spCommand = new SqlCommand("sp_altaUsuario", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@usuario", userTextBox.Text));
            spCommand.Parameters.Add(new SqlParameter("@contras", passTextBox.Text));
            spCommand.Parameters.Add(new SqlParameter("@idRol", comboRoles.SelectedValue));
            spCommand.Parameters.Add(new SqlParameter("@idHotel", comboHoteles.SelectedValue));
            /*SqlParameter paramCantInsert = new SqlParameter();
			paramCantInsert.ParameterName = "@cantRegistrosIns";
			paramCantInsert.DbType = DbType.Int32;
			paramCantInsert.Direction = ParameterDirection.Output;
		*/
            try
            {
                int sqlRows = spCommand.ExecuteNonQuery();
                if (sqlRows > 1)
                {
                    MessageBox.Show("Registrado ingresado correctamente. A continuciacion ingrese datos personales");
                    AltaClienteForm formAltaCliente = new AltaClienteForm();
                    formAltaCliente.Show();
                }
                else
                {
                    userTextBox.Clear();
                    throw new System.ArgumentException("Existe un usuario con el valor ingresado. Reingrese el username");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Cierro la Conexión.
                sqlConnection.Close();
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                //verificar_campos_obligatorios();
                verificar_Contrasenias();
                ingresar_NuevoUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            sqlConnection.Open();
            Repositorios.RepositorioRoles repoRoles = new Repositorios.RepositorioRoles(sqlConnection);
            Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles(sqlConnection);

            comboRoles.DisplayMember = "nombre";
            comboRoles.ValueMember = "id_rol";
            comboRoles.DataSource = repoRoles.getAll();

            comboHoteles.DisplayMember = "dir_Hotel";
            comboHoteles.ValueMember = "id_Hotel";
            comboHoteles.DataSource = repoHoteles.getAll();
        }

    }
}