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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void hotelesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles();

            comboHoteles.DisplayMember = "dir_Hotel";
            comboHoteles.ValueMember = "id_Hotel";
            comboHoteles.DataSource = repoHoteles.getAll();
        }
    }
}
