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
    public partial class AltaRolForm : Form
    {
        public AltaRolForm()
        {
            InitializeComponent();
        }

        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
 
        private void AceptarBtn_Click(object sender, EventArgs e)
        {
            Rol_Ctrl rolCtrl = new Rol_Ctrl();
            Rol nuevoRol= new Rol();
            
            nuevoRol.nombre = nombreRolBox.Text;
            nuevoRol.lista_funcionalidades = this.getFuncSeleccionadas(funcListBox.CheckedItems.Cast<string>().ToList());
            try
            {
                rolCtrl.altaRol(nuevoRol);
                MessageBox.Show("Se generó correctamente el nuevo rol");
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }
            
            
        }

        private List<Funcionalidad> getFuncSeleccionadas(List<string> descripciones)
        {
            return (List<Funcionalidad>)funcionalidades.Where(func => descripciones.Contains(func.descripcion_funcionalidad));
        }

        private void RolForm_Load(object sender, EventArgs e)
        {
            this.cargarFuncionalidades();
        }

        private void cargarFuncionalidades()
        {
            Funcionalidad_Ctrl funcionCtrl = new Funcionalidad_Ctrl();
            funcionalidades = funcionCtrl.getAllFuncionalidades();
            foreach (Funcionalidad func in funcionalidades)
            {
                funcListBox.Items.Add(func.descripcion_funcionalidad);
                
            }
        }

        private void CancelarBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
