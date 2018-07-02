using FrbaHotel.Control;
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
        public string emailPersona="";
        public string tipoDNI;
        public string nroDocumento;

        public AltaPersonaForm(int  idUsuario, string email, string tipoDNI, string nroString)
        {
            this.emailPersona = email;
            this.idUsuario = idUsuario;
            this.tipoDNI = tipoDNI;
            this.nroDocumento = nroString;
            InitializeComponent();
        }

        public AltaPersonaForm(Persona persona,int id_usuarioCambio)
        {
            InitializeComponent();
            idUsuario = id_usuarioCambio;
            //se modifican los datos, se carga el formulario con los datos de persona
            comboTipoDni.SelectedText = persona.tipo_documento;
            dniBox.Text = persona.nro_documento.ToString();
            nombreBox.Text = persona.nombre;
            apellidoBox.Text = persona.apellido;
            emailBox.Text = persona.email;
            telBox.Text = persona.telefono.ToString();
            comboNacionalidad.SelectedText = persona.nacionalidad;
            calleBox.Text = persona.direccion;
            nroCalleBox.Value = persona.nro_calle;
            pisoBox.Value = persona.piso;
            depBox.Text = persona.departamento;
            localidadBox.Text = persona.localidad;
            fechaBox.Value = persona.fecha_nacimiento;
 
        }

        private void Aceptar_Click(object sender, EventArgs e) {

            Persona_Ctrl personaCtrl = new Persona_Ctrl();
            Persona nuevaPersona = new Persona();
            nuevaPersona.tipo_documento = (string)comboTipoDni.SelectedValue;
            nuevaPersona.nro_documento = Convert.ToInt32(dniBox.Text);
            nuevaPersona.email = emailBox.Text;
            nuevaPersona.nombre = nombreBox.Text;
            nuevaPersona.apellido = apellidoBox.Text;
            nuevaPersona.telefono = Int32.Parse(telBox.Text);
            nuevaPersona.nacionalidad = (string)comboNacionalidad.SelectedValue;
            nuevaPersona.direccion = calleBox.Text;
            nuevaPersona.nro_calle = (int)nroCalleBox.Value;
            nuevaPersona.piso = (int)pisoBox.Value;
            nuevaPersona.departamento = depBox.Text;
            nuevaPersona.localidad = localidadBox.Text;
            nuevaPersona.pais = (string)comboPais.SelectedValue;
            nuevaPersona.fecha_nacimiento = fechaBox.Value;  

            try
            {
                int filasAfectadas= personaCtrl.altaPersona(nuevaPersona, idUsuario);
                if (filasAfectadas == 1) // ExecuteNonQuery devuelve el numero de filas afectadas, si se agregó el registro, devuelve 1
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
            }
        }

        private void AltaPersonaForm_Load(object sender, EventArgs e)
        {
            //Cargo combo de tipos de dni
            comboTipoDni.DataSource = new TiposDocumentos().getAll();
            comboNacionalidad.DataSource = new Paises().getAll();
            comboPais.DataSource = new Paises().getAll();
            if (idUsuario!=InfoGlobal.id_usuarioGUEST)
            { //Se trata de un usuario NO Guest, los campos dni, tipo y email son no editables 
                emailBox.ReadOnly=true;
                comboTipoDni.DropDownStyle = ComboBoxStyle.DropDownList;
                dniBox.ReadOnly = true;
                emailBox.Text = emailPersona;
                comboTipoDni.SelectedIndex = comboTipoDni.FindString(tipoDNI);
                dniBox.Text= nroDocumento;

            };
        }
    }
}
