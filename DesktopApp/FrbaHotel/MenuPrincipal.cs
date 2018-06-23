using FrbaHotel.AbmPersona;
using FrbaHotel.AbmUsuario;
using FrbaHotel.Entidades;
using FrbaHotel.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            this.passLinkLabel.Enabled=false;
            this.closeSessionLink.Enabled=false;
            this.menuStrip1.Enabled=false;
            this.panelReservas.Enabled=false;
            this.iniciar_sesion();
      
        }
        private void iniciar_sesion() {
            LoginForm login_scr = new LoginForm();
            login_scr.ShowDialog();
            if (DatosSesion.sesion_iniciada)
            {
                //ActualizarStatusStrip();
                //habilitar_segun_rol();
                closeSessionLink.Visible = true;
                //linkLabel_Login.Visible = false;
                if (DatosSesion.esGuest())
                    passLinkLabel.Visible = true;
            }
        
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //El alta de la persona es de tipo usuario GUEST, que previamente no completo mail, tipo, ni dni
            AltaPersonaForm altaPersona = new AltaPersonaForm(InfoGlobal.id_usuarioGUEST,"","","");
            altaPersona.Show();
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaUsuarioForm usuarioAlta = new AltaUsuarioForm();
            usuarioAlta.Show();
        }

        private void modicarDatosPersonalesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
          
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

       
    }
}
