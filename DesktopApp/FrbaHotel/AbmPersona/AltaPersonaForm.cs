using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmPersona
{
    public partial class AltaPersonaForm : Form
    {
        public int idUsuario;
        public string emailPersona;
        public AltaPersonaForm(int idUsuario, string email)
        {
            this.emailPersona = email;
            this.idUsuario = idUsuario;
            InitializeComponent();
        }


        private void Aceptar_Click(object sender, EventArgs e) {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
                        
            //creo un DataTable para obtener los datos de la persona y pasarlo como parametro al storedProcedure de alta
            DataTable dataPersonas = new DataTable("datosPersona");         

            dataPersonas.Columns.Add("tipo_documento", typeof(string));
            dataPersonas.Columns.Add("nro_documento", typeof(Int32));
            dataPersonas.Columns.Add("email", typeof(string));
            dataPersonas.Columns.Add("nombre", typeof(string));
            dataPersonas.Columns.Add("apellido", typeof(string));
            dataPersonas.Columns.Add("telefono", typeof(Int64));
            dataPersonas.Columns.Add("nacionalidad", typeof(string));
            dataPersonas.Columns.Add("calle", typeof(string));
            dataPersonas.Columns.Add("nro_calle", typeof(string));
            dataPersonas.Columns.Add("piso", typeof(string));
            dataPersonas.Columns.Add("departamento", typeof(string));
            dataPersonas.Columns.Add("localidad", typeof(string));
            dataPersonas.Columns.Add("pais", typeof(string));
            dataPersonas.Columns.Add("fecha_nacimiento", typeof(DateTime));
            dataPersonas.Columns.Add("id_usuario", typeof(Int32));

            //cargo las columnas con los datos ingresados
            dataPersonas.Rows.Add(comboTipoDni.SelectedValue, dniBox.Text, emailPersona, nombreBox.Text, apellidoBox.Text,
                telBox.Text, comboNacionalidad.SelectedValue,calleBox.Text,nroCalleBox.Text, pisoBox.Text,
                depBox.Text,localidadBox.Text,comboPais.Text,fechaBox.Value.Date,idUsuario);
           
          
            SqlCommand spCommand = new SqlCommand("sp_altaPersona", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            spCommand.Parameters.Clear();
            
            SqlParameter parametroDatosPersona = new SqlParameter();
            //The parameter for the SP must be of SqlDbType.Structured 
            parametroDatosPersona.ParameterName = "@datosPersona";
            parametroDatosPersona.SqlDbType = System.Data.SqlDbType.Structured;
            parametroDatosPersona.Value = dataPersonas;
            spCommand.Parameters.Add(parametroDatosPersona);

            try
            {
                int idPersona = spCommand.ExecuteNonQuery();
                if (idPersona != null) //Si es null ya existe mail y/o documento
                {
                    MessageBox.Show("Registrado ingresado correctamente.");
                    this.Hide();
                    
                }
                else
                {
                    emailBox.Clear();
                    dniBox.Clear();
                    throw new System.ArgumentException("Existe registro con igual Nro de documento y/o mail");
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

        private void AltaPersonaForm_Load(object sender, EventArgs e)
        {
            //Cargo combo de tipos de dni
            comboTipoDni.DataSource = new TiposDocumentos().getAll();
            comboNacionalidad.DataSource = new Paises().getAll();
            comboPais.DataSource = new Paises().getAll();
            emailBox.Text = emailPersona;
        }

  
    }
}
