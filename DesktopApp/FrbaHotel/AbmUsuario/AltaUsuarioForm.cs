using FrbaHotel.AbmPersona;
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

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaUsuarioForm : Form
    {
        public string connectionString;
        public AltaUsuarioForm()
        {
            InitializeComponent();
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
            spCommand.Parameters.Add(new SqlParameter("@emailUsu", mailBox.Text));
            spCommand.Parameters.Add(new SqlParameter("@idRol", comboRoles.SelectedValue));
            spCommand.Parameters.Add(new SqlParameter("@idHotel", comboHoteles.SelectedValue));
            
            try
            {
                int idUsuario = spCommand.ExecuteNonQuery();
                if (idUsuario != null) //Si es null ya existia
                {
                    MessageBox.Show("Registro ingresado correctamente. A continuación ingrese datos personales");
                    AltaPersonaForm obj = new AltaPersonaForm(idUsuario, mailBox.Text);
                    if (obj == null)
                    {
                        obj.Parent = this;
                    }
                    obj.Show();
                    this.Hide();
                   
                }
                else
                {
                    userTextBox.Clear();
                    mailBox.Clear();
                    throw new System.ArgumentException("Existe un usuario con username y/o email ingresados. Reingrese los datos mencionados");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error al ingresar nuevo usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                MessageBox.Show("Ocurrio un error en el ingreso de nuevo usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            sqlConnection.Open();
            Repositorios.RepositorioRoles repoRoles = new Repositorios.RepositorioRoles();
            Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles();

            comboRoles.DisplayMember = "nombre";
            comboRoles.ValueMember = "id_rol";
            comboRoles.DataSource = repoRoles.getAll();

            comboHoteles.DisplayMember = "dir_Hotel";
            comboHoteles.ValueMember = "id_Hotel";
            comboHoteles.DataSource = repoHoteles.getAll();
            sqlConnection.Close();
        }

       
    }
}