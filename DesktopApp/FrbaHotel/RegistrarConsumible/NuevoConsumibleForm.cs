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

namespace FrbaHotel.RegistrarConsumible
{
    public partial class NuevoConsumibleForm : Form
    {
        List<Consumible> consumibles;
        Estadia_Ctrl estadiaCtrl = new Estadia_Ctrl();
        Consumible_Ctrl consumibleCtrl = new Consumible_Ctrl();
        public Estadia estadia = new Estadia();
        public NuevoConsumibleForm(Estadia estadiaSeleccionada)
        {
            InitializeComponent();
            estadia = estadiaSeleccionada;
            idEstadiaBox.Text = Convert.ToString(estadiaSeleccionada.id_estadia);
            this.cargarConsumibles();
        }
        private void consumiblesBox_SelectedValueChanged(object sender, EventArgs e)
        {
            int id_consumible= (int)consumiblesBox.SelectedValue;
            Consumible consumibleSeleccionado = consumibles.Find(consumible => consumible.id_consumible == id_consumible);
            precioBox.Text = Convert.ToString(consumibleSeleccionado.precio);
        
        }

        private void cargarConsumibles()
        {
            consumibles = consumibleCtrl.getAllConsumibles();
            consumiblesBox.DisplayMember = "descripcion";
            consumiblesBox.ValueMember = "id_consumible";
            consumiblesBox.DataSource = consumibles;
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Cancel;
            this.Close();
        }

        private void addConsumBtn_Click(object sender, EventArgs e)
        {
            Consumible nuevoConsumible = new Consumible();
            nuevoConsumible.cantidad = Convert.ToInt32(cantBox.Value);
            estadia.consumibles.Add(nuevoConsumible);
            this.CompletarTabla(estadia.consumibles);
        }

        private void CompletarTabla(List<Consumible> listaConsumibles)
        {
            foreach (Consumible consumible in listaConsumibles)
            {
                for (int i = 0; i < dataGridConsumibles.Rows.Count; i++)
                {
                    var row = this.dataGridConsumibles.Rows[i];
                    row.Cells["Consumible"].Value = consumible.descripcion;
                    row.Cells["Cantidad"].Value = consumible.cantidad;
                    row.Cells["Precio Acumulado"].Value = consumible.cantidad*consumible.precio;
                }
            }
        }

        private void deleteConsBtn_Click(object sender, EventArgs e)
        {
            if (dataGridConsumibles.DataSource != null && dataGridConsumibles.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridConsumibles.SelectedRows)
                {
                    Consumible consumSeleccionado = (Consumible)row.DataBoundItem;
                    this.estadia.consumibles.Remove(consumSeleccionado);
                    this.CompletarTabla(estadia.consumibles);
                }
            }
            else
            {
                MessageBox.Show("No se seleccionaron habitaciones.\nSeleccione una o más para continuar con la reserva");
            }
        }

        private void confirmarBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
