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

namespace FrbaHotel.Login
{
    public partial class CambioPassForm : Form
    {

        public CambioPassForm()
        {
            InitializeComponent();
        }

        private void CambioPassForm_Load(object sender, EventArgs e)
        {
            userLabel.Text = DatosSesion.username;
        }

        private void confirmarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (tieneCamposObligatorios()) {
                    this.verificarPassActual();
                    this.verificarNuevaPass();
                    this.cambiarPass();
                    MessageBox.Show("Se modificó correctamente la contraseña");
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cambiarPass()
        {
            string newPassHash = Encriptacion.getHashSha256(newPassBox.Text);
            Usuario_Ctrl userCtrl = new Usuario_Ctrl();
            userCtrl.cambiarPassword(newPassHash,DatosSesion.id_usuario);
        }

        private void verificarNuevaPass()
        {
            if (newPassBox.Text != verifyPassBox.Text) {
                throw new System.ArgumentException("No coinciden las contraseñas. Reingreselo");
            }
        }

        private bool tieneCamposObligatorios()
        {
            return passActualBox.SelectedText != null && newPassBox.SelectedText != null && verifyPassBox.SelectedText != null;
        }

        private void verificarPassActual()
        {
            string passActualHash = Encriptacion.getHashSha256(passActualBox.Text);
            if (passActualHash != DatosSesion.password) {

                throw new System.ArgumentException("Contraseña actual incorrecta. Reingreselo");
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
