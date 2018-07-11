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
    public partial class InfoUsuariosForm : Form
    {
        public InfoUsuariosForm()
        {
            InitializeComponent();
        }

        private void ModBajaUsuarioForm_Load(object sender, EventArgs e)
        {
            panelUsername.Enabled = false;
        }

        private void buscarUsernameBtn_Click(object sender, EventArgs e)
        {
            panelUsername.Enabled = true;
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userBox.Text)){
               MessageBox.Show("Debe ingresar username"); 
            }
            else
            {
                Usuario_Ctrl usuarioCtrl = new Usuario_Ctrl();
                List<Usuario> usuariosEncontrados = new List<Usuario>();
                usuariosEncontrados = usuarioCtrl.buscarUserPorUsername(userBox.Text);
                if (usuariosEncontrados.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                    newUserBtn.Enabled = true;
                    panelUsername.Enabled = false;
                }
                else
                {

                    dataGridUsers.DataSource = usuariosEncontrados;
                    updateUserBtn.Enabled = true;
                    newUserBtn.Enabled = false;
                }
            }
            
        }

        private void allUserBtn_Click(object sender, EventArgs e)
        {
            Usuario_Ctrl usuarioCtrl = new Usuario_Ctrl();
            List<Usuario> usuariosEncontrados = new List<Usuario>();
            usuariosEncontrados = usuarioCtrl.getAllUsers_IdHotel(DatosSesion.id_hotel);
            if (usuariosEncontrados.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados.");
                newUserBtn.Enabled = true;
            }
            else
            {

                dataGridUsers.DataSource = usuariosEncontrados;
                //oculto la columna de Contraseña
                dataGridUsers.Columns[2].Visible = false;
                dataGridUsers.Columns[4].Visible = false;
                updateUserBtn.Enabled = true;
                newUserBtn.Enabled = false;
            }
        }

        private void updateUserBtn_Click(object sender, EventArgs e)
        {
            if (dataGridUsers.DataSource != null && dataGridUsers.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridUsers.SelectedRows)
                {
                    Usuario usuarioSeleccionado = (Usuario)row.DataBoundItem;
                    Usuario_Ctrl usuarioCtrl = new Usuario_Ctrl();
                    AltaModUsuarioForm editForm = new AltaModUsuarioForm(usuarioSeleccionado);
                    editForm.ShowDialog();
                }
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se selecciono cliente. Seleccione una fila de la tabla");
            }
        }

        private void newUserBtn_Click(object sender, EventArgs e)
        {
            AltaModUsuarioForm usuarioAlta = new AltaModUsuarioForm(null);
            usuarioAlta.Show();
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
