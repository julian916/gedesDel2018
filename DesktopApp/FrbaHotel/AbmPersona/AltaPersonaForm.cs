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
        int idUsuario;
        string emailPersona="";
        string tipoDNI;
        string nroDocumento;
        bool esModificacion=false;
        int id_persona;
        
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
            comboTipoDni.DataSource = new TiposDocumentos().getAll();
            if (persona.id_persona != 0)
            {
                //se carga el formulario con los datos de persona
                esModificacion = true;
                id_persona = persona.id_persona;
                nombreBox.Text = persona.nombre;
                apellidoBox.Text = persona.apellido;
                telBox.Text = persona.telefono.ToString();
                comboNacionalidad.SelectedText = persona.nacionalidad;
                calleBox.Text = persona.direccion;
                nroCalleBox.Value = persona.nro_calle;
                pisoBox.Value = persona.piso;
                depBox.Text = persona.departamento;
                localidadBox.Text = persona.localidad;
                fechaBox.Value = persona.fecha_nacimiento;
            }
            else {
                esModificacion = false;
                
            }      
            idUsuario = id_usuarioCambio;
            comboTipoDni.Text = persona.tipo_documento;
            dniBox.Text = persona.nro_documento.ToString();
            emailBox.Text = persona.email;
         
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
                if (esModificacion)
                {
                    nuevaPersona.id_persona = id_persona;
                    personaCtrl.modificarPersona(nuevaPersona, idUsuario);
                    MessageBox.Show("Se modificaron correctamente los datos.");
                }
                else {
                    personaCtrl.altaPersona(nuevaPersona, idUsuario);
                    MessageBox.Show("Registro ingresado correctamente.");
                }
                this.Dispose();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AltaPersonaForm_Load(object sender, EventArgs e)
        {
            //Cargo combo de tipos de dni
            comboNacionalidad.DataSource = new Paises().getAll();
            comboPais.DataSource = new Paises().getAll();
            if (idUsuario!=InfoGlobal.id_usuarioGUEST)
            { //Se trata de un usuario NO Guest, los campos dni, tipo y email son no editables 
                emailBox.ReadOnly=true;
                comboTipoDni.Enabled = false ;
                dniBox.ReadOnly = true;
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
