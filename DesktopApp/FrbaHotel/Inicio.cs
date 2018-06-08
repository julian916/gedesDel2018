using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaHotel.Login;

namespace FrbaHotel
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void buscarHoteles_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void login_Click(object sender, EventArgs e)
        {
            LoginForm obj = new LoginForm();
            if (obj == null)
            {
                obj.Parent = this;
            }
            obj.Show();
            this.Hide();
        }
    }
}



