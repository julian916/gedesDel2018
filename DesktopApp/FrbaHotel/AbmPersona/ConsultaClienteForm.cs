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
        private Persona_Ctrl personaCtrl = new Persona_Ctrl();
        public ConsultaClienteForm()
        {
            InitializeComponent();
        }

        private void ConsultaClienteForm_Load(object sender, EventArgs e)
        {
            comboTipoDNI.DataSource = new TiposDocumentos().getAll();
            button1.Enabled = false;
            newClienteBtn.Enabled = false;
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
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
                button1.Enabled = true;
                
            }

        }

        private void newClienteBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            AltaPersonaForm altaPersona = new AltaPersonaForm(InfoGlobal.id_usuarioGUEST, "", "", "");
            altaPersona.Show();
        }

        private void dataClientesEncontrados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataClientesEncontrados.Columns[7].Index)
                {
                    //obtengo la fila del cliente a deshabilitar
                    Persona cliente = (Persona)dataClientesEncontrados.Rows[e.RowIndex].DataBoundItem;
                    if (cliente.estado != "Inconsistente")
                    {
                        personaCtrl.habilitarDeshabilitarCliente(cliente);

                    }
                    else
                    {
                        MessageBox.Show("El cliente se encuentra en un estado Inconsistente.\n No se puede habilitar ni desahabilitar.");
                    }
                    
                }
            }
            catch (Exception exc){
                MessageBox.Show(exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataClientesEncontrados.DataSource != null && dataClientesEncontrados.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataClientesEncontrados.SelectedRows)
                {
                    Persona personaSeleccionada = (Persona)row.DataBoundItem;
                    if (personaSeleccionada.estado == "Inconsistente")
                    {
                        MessageBox.Show("El cliente se encuentra en un estado Inconsistente.\nModifique Tipo Documento, Nro Documento y/o Email para habilitarlo");
                    }

                    AltaPersonaForm editForm = new AltaPersonaForm(personaSeleccionada, InfoGlobal.id_usuarioGUEST);
                    editForm.ShowDialog();
                    this.Dispose();
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show("No se selecciono cliente. Seleccione una fila de la tabla");
            }
        }

        private void inhHabPersonaBtn_Click(object sender, EventArgs e)
        {
            if (dataClientesEncontrados.DataSource != null && dataClientesEncontrados.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataClientesEncontrados.SelectedRows)
                {
                    Persona personaSeleccionada = (Persona)row.DataBoundItem;
                    if (personaSeleccionada.estado != "Inconsistente")
                    {
                        personaCtrl.habilitarDeshabilitarCliente(personaSeleccionada);
                        MessageBox.Show("Se inhabilito/habilito correctamente");
                        this.Dispose();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("El cliente se encuentra en un estado Inconsistente.\n No se puede habilitar ni desahabilitar.");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("No se selecciono cliente. Seleccione una fila de la tabla");
            }

        }

    }
}
