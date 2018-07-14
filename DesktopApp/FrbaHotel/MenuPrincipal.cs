using FrbaHotel.AbmHabitacion;
using FrbaHotel.ABMHotel;
using FrbaHotel.AbmPersona;
using FrbaHotel.AbmRol;
using FrbaHotel.AbmUsuario;
using FrbaHotel.CancelarReserva;
using FrbaHotel.Entidades;
using FrbaHotel.GenerarModificacionReserva;
using FrbaHotel.GenerarModificarReserva;
using FrbaHotel.ListadoEstadistico;
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

                //linkLabel_Login.Visible = false;
            }
        }
        public void habilitar_func_x_rol()
        {
            if (DatosSesion.esGuest())
            {
                menuStrip1.Visible = false;
                panelSession.Visible = false;
                inicioSesionLink.Visible = true;
                inicioSesionLink.Enabled = true;
                closeSessionLink.Visible = false;
                passLinkLabel.Visible = false;
            }
            else {

                closeSessionLink.Enabled = true;
                passLinkLabel.Enabled = true;
                inicioSesionLink.Visible = false;
            }
            
            panelReservas.Enabled = true;

            menuStrip1.Enabled = true;
            List<Funcionalidad> f = DatosSesion.funcionalidades;
            newReservaButton.Enabled = f.Any(func => func.descripcion_funcionalidad == "Generar Reserva");
            updateReservaButton.Enabled = f.Any(func => func.descripcion_funcionalidad == "Generar Reserva");
            cancelReservaButton.Enabled = f.Any(func => func.descripcion_funcionalidad == "Cancelar Reserva");

            ToolStripItemCollection itemsMenu = menuStrip1.Items;

            ToolStripItem menu_habUsu = itemsMenu.Find("habilitarUsuarioToolStripMenuItem", true)[0];
            menu_habUsu.Visible = f.Any(func => func.descripcion_funcionalidad == "Habilitar Usuario");

            ToolStripItem menu_usuario = itemsMenu.Find("usuariosToolStripMenuItem", true)[0];
            menu_usuario.Enabled = f.Any(func => func.descripcion_funcionalidad == "ABM Usuario");


            ToolStripItem menu_Hotel = itemsMenu.Find("aBMHotelToolStripMenuItem", true)[0];
            menu_Hotel.Enabled = f.Any(func => func.descripcion_funcionalidad == "ABM Hotel");

            ToolStripItem menu_Habitacion = itemsMenu.Find("aBMHabitacionToolStripMenuItem", true)[0];
            menu_Habitacion.Enabled = f.Any(func => func.descripcion_funcionalidad == "ABM Habitacion");

            ToolStripItem menu_cliente = itemsMenu.Find("clientesToolStripMenuItem", true)[0];
            menu_cliente.Enabled = f.Any(func => func.descripcion_funcionalidad == "ABM Clientes");

            
            ToolStripItem menu_rol = itemsMenu.Find("rolToolStripMenuItem", true)[0];
            menu_rol.Enabled = f.Any(func => func.descripcion_funcionalidad == "ABM Rol");

            ToolStripItem menu_estadias = itemsMenu.Find("estadíasToolStripMenuItem", true)[0];
            menu_rol.Enabled = f.Any(func => func.descripcion_funcionalidad == "Registrar Estadia");


            ToolStripItem menu_estadisticas = itemsMenu.Find("listaEstadisticasToolStripMenuItem", true)[0];
            menu_estadisticas.Enabled = f.Any(func => func.descripcion_funcionalidad == "Listado Estadistico");
                

            

        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //El alta de la persona es de tipo usuario GUEST, que previamente no completo mail, tipo, ni dni
            AltaPersonaForm altaPersona = new AltaPersonaForm(InfoGlobal.id_usuarioGUEST,"","","");
            altaPersona.Show();
        }

        private void nuevoUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaModUsuario usuarioAlta = new AltaModUsuario();
            if (usuarioAlta.continuarAltaMod) {
                usuarioAlta.Show();
            }
            
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
            this.iniciar_sesion();
        }

        private void altaHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaHotelForm hotelForm = new AltaHotelForm();
            hotelForm.ShowDialog();
        }

        private void nuevaHabitaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaEditHabForm habForm = new AltaEditHabForm();
            habForm.ShowDialog();
        }

        private void passLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CambioPassForm cambioPass = new CambioPassForm();
            cambioPass.ShowDialog();
        }


        private void closeSessionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DatosSesion.cerrar_sesion();
            inicioSesionLink.Visible = true;
            closeSessionLink.Visible = false;
            passLinkLabel.Visible = false;
            menuStrip1.Visible = false;
            this.panelReservas.Enabled = false;
        }
        
        private void nuevoRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaEditRolForm rolForm = new AltaEditRolForm();
            rolForm.ShowDialog();
        }

        private void consultarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaClienteForm consultaPersona = new ConsultaClienteForm();
            consultaPersona.ShowDialog();
        }

        private void modificacionBajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfoUsuariosForm modUsuario = new InfoUsuariosForm();
            modUsuario.ShowDialog();

        }

        private void modificacionBajaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ConsultaHabitaciones consultaHab = new ConsultaHabitaciones();
            consultaHab.ShowDialog();
        }

        private void modificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaHotelForm consultaHoteles = new ConsultaHotelForm();
            consultaHoteles.ShowDialog();
        }

        private void listaEstadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoEstadisticoForm estadisticas = new ListadoEstadisticoForm();
            estadisticas.ShowDialog();
        }

        private void updateReservaButton_Click(object sender, EventArgs e)
        {
            ModificarReservaForm modReserva = new ModificarReservaForm();
            if (modReserva.reservaPrevia != null)
            {
                modReserva.Show();
            }
            else {
                MessageBox.Show("No existe reserva con el código ingresado");
            }
          
        }

        private void cancelReservaButton_Click(object sender, EventArgs e)
        {
            CancelarReservaForm cancelRes = new CancelarReservaForm();
            cancelRes.ShowDialog();
        }

        private void newReservaButton_Click(object sender, EventArgs e)
        {
            GenerarReserva reservas = new GenerarReserva();
            reservas.ShowDialog();
        }

        private void nuevaEstadíaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaRolForm consultaRol = new ConsultaRolForm();
            consultaRol.ShowDialog();
        }

        private void habilitarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      
    }
}
