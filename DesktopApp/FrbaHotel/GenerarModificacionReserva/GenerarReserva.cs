using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaHotel.GenerarModificarReserva
{
    public partial class GenerarReserva : Form
    {
        public GenerarReserva()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void HotelesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles();

            comboHoteles.DisplayMember = "dir_Hotel";
            comboHoteles.ValueMember = "id_Hotel";
            comboHoteles.DataSource = repoHoteles.getAll();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void FechaHastaCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void FechaDesdeCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
