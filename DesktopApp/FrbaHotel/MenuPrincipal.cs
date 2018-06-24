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
                habilitar_func_x_rol();
                closeSessionLink.Visible = true;
                //linkLabel_Login.Visible = false;
            }
        
        }
        public void habilitar_func_x_rol()
        {
            if (DatosSesion.esGuest())
            {
                menuStrip1.Visible = false;
                panelSession.Visible = false;
            }
            panelReservas.Enabled = true;

            menuStrip1.Enabled = true;
            BindingList<Funcionalidad> f = DatosSesion.funcionalidades;
            newReservaButton.Enabled = f.Any(func => func.descripcion_funcionalidad == "Generar Reserva");
            updateReservaButton.Enabled = f.Any(func => func.descripcion_funcionalidad == "Generar Reserva");
            cancelReservaButton.Enabled = f.Any(func => func.descripcion_funcionalidad == "Cancelar Reserva");

            ToolStripItemCollection itemsMenu = menuStrip1.Items;

            ToolStripItem menu_Hotel = itemsMenu.Find("aBMHotelToolStripMenuItem", true)[0];
            menu_Hotel.Enabled = f.Any(func => func.descripcion_funcionalidad == "ABM Hotel");

            ToolStripItem menu_Habitacion = itemsMenu.Find("aBMHabitacionToolStripMenuItem", true)[0];
            menu_Habitacion.Enabled = f.Any(func => func.descripcion_funcionalidad == "ABM Habitacion");

            ToolStripItem menu_cliente = itemsMenu.Find("clientesToolStripMenuItem", true)[0];
            menu_cliente.Enabled = f.Any(func => func.descripcion_funcionalidad == "ABM Clientes");

            ToolStripItem menu_usuario = itemsMenu.Find("usuariosToolStripMenuItem", true)[0];
            menu_usuario.Enabled = f.Any(func => func.descripcion_funcionalidad == "abmRegimenEstadia");

            ToolStripItem menu_rol = itemsMenu.Find("rolToolStripMenuItem", true)[0];
            menu_rol.Enabled = f.Any(func => func.descripcion_funcionalidad == "abmHotel");

            ToolStripItem menu_estadisticas = itemsMenu.Find("estadísticasToolStripMenuItem", true)[0];
            menu_estadisticas.Enabled = f.Any(func => func.descripcion_funcionalidad == "abmHotel");
                

            

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

        private void inicioSesionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

       
    }
}
