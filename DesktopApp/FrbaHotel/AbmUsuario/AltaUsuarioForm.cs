using FrbaHotel.AbmCliente;
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

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaUsuarioForm : Form
    {
        public AltaUsuarioForm()
        {
            //InitializeComponent();
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

        private void ingresar_NuevoUsuario() {

            string connectionString = null;
            connectionString = "Data Source=LOCALHOST\\SQLSERVER2012;Initial Catalog=GD1C2018;User ID=gdHotel2018;Password=gd2018";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand spCommand = new SqlCommand("sp_altaUsuario", con);
			spCommand.CommandType = CommandType.StoredProcedure; 
			con.Open();
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
                    int	sqlRows = spCommand.ExecuteNonQuery();
                    if (sqlRows > 1)
						{
							MessageBox.Show ("Registrado ingresado correctamente. A continuciacion ingrese datos personales");
                            AltaClienteForm formAltaCliente =new AltaClienteForm();
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
					con.Close();
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
            string connectionString = null;
            connectionString = "Data Source=LOCALHOST\\SQLSERVER2012;Initial Catalog=GD1C2018;User ID=gdHotel2018;Password=gd2018";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand scRol = new SqlCommand("sp_RolesComboBox", con);
            SqlCommand scHoteles = new SqlCommand("sp_HotelesComboBox", con);
            DataTable dtRol = new DataTable();
            DataTable dtHotel = new DataTable();
            dtRol.Load(scRol.ExecuteReader());
            dtHotel.Load(scHoteles.ExecuteReader());
            comboRoles.DisplayMember = "nombre";
            comboRoles.ValueMember = "id_rol";
            comboRoles.DataSource = dtRol;

            comboHoteles.DisplayMember = "dir_Hotel";
            comboHoteles.ValueMember = "id_Hotel";
            comboHoteles.DataSource = dtHotel;    
        }

      }
}