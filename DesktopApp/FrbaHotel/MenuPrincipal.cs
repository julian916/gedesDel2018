using FrbaHotel.AbmPersona;
using FrbaHotel.AbmUsuario;
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

namespace FrbaHotel
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
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

       
    }
}
