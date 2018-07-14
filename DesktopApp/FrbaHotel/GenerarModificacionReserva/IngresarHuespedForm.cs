using FrbaHotel.AbmPersona;
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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class IngresarHuespedForm : Form
    {
        private Persona_Ctrl personaCtrl = new Persona_Ctrl();
        public Persona clienteSeleccionado = new Persona();
        public IngresarHuespedForm()
        {
            InitializeComponent();
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
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
                newClienteBtn.Enabled = true;
            }
            else
            {

                dataClientesEncontrados.DataSource = clientesEncontrados;
                seleccionarBtn.Enabled = true;
            }
        }

        private void newClienteBtn_Click(object sender, EventArgs e)
        {
            AltaPersonaForm altaPersona = new AltaPersonaForm(InfoGlobal.id_usuarioGUEST, "", "", "");
            altaPersona.ShowDialog();

        }

        private void seleccionarBtn_Click(object sender, EventArgs e)
        {
            if (dataClientesEncontrados.DataSource != null && dataClientesEncontrados.SelectedRows.Count > 0)
            {
                if (dataClientesEncontrados.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow row in dataClientesEncontrados.SelectedRows)
                    {
                        clienteSeleccionado = (Persona)row.DataBoundItem;
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else {
                    MessageBox.Show("Debe seleccionarse solo un cliente principal, encargado de la reserva");
                }

            }
            else
            {
                MessageBox.Show("No se selecciono cliente. Seleccione una fila de la tabla");
            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void IngresarHuespedForm_Load(object sender, EventArgs e)
        {
            comboTipoDNI.DataSource = new TiposDocumentos().getAll();
            seleccionarBtn.Enabled = false;
            newClienteBtn.Enabled = false;
        }
    }
}
