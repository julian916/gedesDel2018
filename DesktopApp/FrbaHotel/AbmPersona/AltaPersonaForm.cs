using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmPersona
{
    public partial class AltaPersonaForm : Form
    {
        public AltaPersonaForm()
        {
            InitializeComponent();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable("datosPersona");
            //we create column names as per the type in DB 
            dataTable.Columns.Add("tipo_documento", typeof(string));
            dataTable.Columns.Add("nro_documento", typeof(Int32));
            dataTable.Columns.Add("email", typeof(string));
            dataTable.Columns.Add("nombre", typeof(string));
            dataTable.Columns.Add("apellido", typeof(string));
            dataTable.Columns.Add("telefono", typeof(Int32));
            dataTable.Columns.Add("nacionalidad", typeof(string));
            dataTable.Columns.Add("calle", typeof(string));
            dataTable.Columns.Add("nro_calle", typeof(string));
            dataTable.Columns.Add("piso", typeof(string));
            dataTable.Columns.Add("departamento", typeof(string));
            dataTable.Columns.Add("localidad", typeof(string));
            dataTable.Columns.Add("pais", typeof(string));
            dataTable.Columns.Add("fecha_nacimiento", typeof(DateTime));
            dataTable.Columns.Add("id_usuario", typeof(Int32));
            //and fill in some values 
            dataTable.Rows.Add("99", 99);

        }

    }
}
