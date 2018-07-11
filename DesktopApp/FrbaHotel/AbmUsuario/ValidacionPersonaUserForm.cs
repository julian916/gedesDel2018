using FrbaHotel.Control;
using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class ValidacionPersonaUserForm : Form
    {
        public int nro_documento;
        public string email;
        public string tipo_documento;
        public ValidacionPersonaUserForm()
        {
            InitializeComponent();
        }

        private void ValidacionPersonaUserForm_Load(object sender, EventArgs e)
        {
            comboTipoDni.DataSource = new TiposDocumentos().getAll();
        }

        private void validarBtn_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(dniBox.Text)) || (string.IsNullOrEmpty(mailBox.Text)) || (string.IsNullOrEmpty((string)comboTipoDni.SelectedValue)))
            {
                MessageBox.Show("Debe ingresar todos los campos");
            }
            else {
                Persona_Ctrl personaCtrl = new Persona_Ctrl();
                try
                {
                    personaCtrl.validarDatosPersona((string)comboTipoDni.SelectedValue, Convert.ToInt32(dniBox.Text), mailBox.Text);
                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    this.Close();
                }
                catch (Exception exc) {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
