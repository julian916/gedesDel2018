using FrbaHotel.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.ListadoEstadistico
{
    public partial class ListadoEstadisticoForm : Form
    {
        Estadistica_Ctrl estadisticaCtrl = new Estadistica_Ctrl();
        public ListadoEstadisticoForm()
        {
            InitializeComponent();
            this.cargarAniosConsulta();
        }

        private void cargarAniosConsulta()
        {

            int anio = estadisticaCtrl.getMenorAnioActividad();
            for (int i = anio; i <= DateTime.Today.Year; i++) {
                anioComboBox.Items.Add(i);
            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void linkHotelResCanc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable resultTable = estadisticaCtrl.getTopHotelesMasReservasCanceladas();
            dataGridEstadistica.DataSource = resultTable;
        }

        private void linkMayorConsum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable resultTable = estadisticaCtrl.getTopHotelesMasConsumiblesFact();
            dataGridEstadistica.DataSource = resultTable;
        }

        private void linkHotelDiasSinServ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable resultTable = estadisticaCtrl.getTopHotelesMasDiasSinServ();
            dataGridEstadistica.DataSource = resultTable;
        }

        private void linkHabSolicitadas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable resultTable = estadisticaCtrl.getTopHabitacionSolicitadas();
            dataGridEstadistica.DataSource = resultTable;
        }

        private void linkClientePuntos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable resultTable = estadisticaCtrl.getTopClientesConMasPuntos();
            dataGridEstadistica.DataSource = resultTable;
        }
    }
}
