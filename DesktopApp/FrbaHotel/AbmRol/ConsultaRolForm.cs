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

namespace FrbaHotel.AbmRol
{
    public partial class ConsultaRolForm : Form
    {
        Rol_Ctrl rolCtrl = new Rol_Ctrl();
        public ConsultaRolForm()
        {
            InitializeComponent();
        }

        private void ConsultaRolForm_Load(object sender, EventArgs e)
        {
            List<Rol> todosLosRoles = new List<Rol>();
            todosLosRoles = rolCtrl.getAllRoles();
            dataGridRoles.Columns[3].Visible = false;
            
        }

        private void nuevoRolBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            AltaEditRolForm altaRol = new AltaEditRolForm();
            altaRol.Show();
        }

        private void updateRolBtn_Click(object sender, EventArgs e)
        {
            if (dataGridRoles.DataSource != null && dataGridRoles.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridRoles.SelectedRows)
                {
                    Rol rolSeleccionado = (Rol)row.DataBoundItem;
                    AltaEditRolForm editForm = new AltaEditRolForm(rolSeleccionado);
                    editForm.ShowDialog();
                }
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se selecciono rol. Seleccione una fila de la tabla");
            }
        }
    }
}
