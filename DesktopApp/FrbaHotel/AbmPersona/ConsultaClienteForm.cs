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

namespace FrbaHotel.AbmPersona
{
    public partial class ConsultaClienteForm : Form
    {
        public ConsultaClienteForm()
        {
            InitializeComponent();
        }

        private void ConsultaClienteForm_Load(object sender, EventArgs e)
        {
            comboTipoDNI.DataSource = new TiposDocumentos().getAll();
            modificarBtn.Enabled = false;
            newClienteBtn.Enabled = false;
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
            Persona_Ctrl personaCtrl = new Persona_Ctrl();
            Persona clienteABuscar = new Persona();
            clienteABuscar.apellido = apellidoBox.Text;
            clienteABuscar.nombre = nombreBox.Text;
            if (string.IsNullOrEmpty(nroDNIBox.Text))
            {
                clienteABuscar.nro_documento = 0;
            }
            else
            {
                clienteABuscar.nro_documento = Int32.Parse(nroDNIBox.Text);
            }
            clienteABuscar.tipo_documento = comboTipoDNI.SelectedValue.ToString();
            clienteABuscar.email = emailBox.Text;
            List<Persona> clientesEncontrados = new List<Persona>();
            clientesEncontrados = personaCtrl.buscarCliente(clienteABuscar);
            if (clientesEncontrados.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados.");
            }
            else
            {
                dataClientesEncontrados.DataSource = clientesEncontrados;
                newClienteBtn.Enabled = true;
                modificarBtn.Enabled = true;
            }

        }

        private void newClienteBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            AltaPersonaForm altaPersona = new AltaPersonaForm(InfoGlobal.id_usuarioGUEST, "", "", "");
            altaPersona.Show();
        }

        private void modificarBtn_Click(object sender, EventArgs e)
        {
            if (dataClientesEncontrados.DataSource != null && dataClientesEncontrados.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataClientesEncontrados.SelectedRows)
                {
                    AltaPersonaForm editForm = new AltaPersonaForm((Persona)row.DataBoundItem);
                    editForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("No se selecciono cliente. Seleccione una fila de la tabla");
            }
        }

    }
}
