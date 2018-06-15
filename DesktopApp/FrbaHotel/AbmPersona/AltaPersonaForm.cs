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
        public AltaPersonaForm(int idUsuario)
        {
            this.idUsuario = idUsuario;
            InitializeComponent();
        }


        private void Aceptar_Click(object sender, EventArgs e) {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            comboTipoDni.DataSource = Enum.GetValues(typeof(EnumTiposDocumento)).Cast<EnumTiposDocumento>();
            //comboTipoDni.
            //Cargo combo de tipos de dni
            
            //creo un DataTable para obtener los datos de la persona y pasarlo como parametro al storedProcedure de alta
            DataTable dataPersonas = new DataTable("datosPersona");         

            dataPersonas.Columns.Add("tipo_documento", typeof(string));
            dataPersonas.Columns.Add("tipo_documento", typeof(string));
            dataPersonas.Columns.Add("nro_documento", typeof(Int32));
            dataPersonas.Columns.Add("email", typeof(string));
            dataPersonas.Columns.Add("nombre", typeof(string));
            dataPersonas.Columns.Add("apellido", typeof(string));
            dataPersonas.Columns.Add("telefono", typeof(Int32));
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
            dataPersonas.Rows.Add(comboTipoDni.SelectedValue,dniBox.Text,emailBox.Text,nombreBox.Text, apellidoBox.Text,
                telBox.Text, comboNacionalidad.SelectedValue,calleBox.Text,nroCalleBox.Text, pisoBox.Text,
                depBox.Text,localidadBox.Text,paisBox.Text,fechaBox.Value.Date);
           
          
            SqlCommand spCommand = new SqlCommand("sp_altaPersona", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            spCommand.Parameters.Clear();
            
            SqlParameter parameter = new SqlParameter();
            //The parameter for the SP must be of SqlDbType.Structured 
            parameter.ParameterName = "@Sample";
            parameter.SqlDbType = System.Data.SqlDbType.Structured;
            parameter.Value = dataPersonas;
            spCommand.Parameters.Add(parameter);
        }

    }
}
