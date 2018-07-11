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
    public partial class AltaEditRolForm : Form
    {
        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
        private Rol rolAModificar;
        Boolean esModificacion;

        public AltaEditRolForm()
        {
            InitializeComponent();
            esModificacion = false;
        }

        public AltaEditRolForm(Rol rolSeleccionado)
        {
            InitializeComponent();
            esModificacion = true;
            this.rolAModificar = rolSeleccionado;
        }

        private void checkFuncionalidadesRol(Rol rolSeleccionado)
        {
            List<string> nombresFunc = new List<string>();
            
            foreach (Funcionalidad funcRol in rolSeleccionado.lista_funcionalidades)
            {
                nombresFunc.Add(funcRol.descripcion_funcionalidad);
            }
            //mostrar las funcionalidades del rol
            for (int count = 0; count < funcListBox.Items.Count; count++)
            {
                if (nombresFunc.Contains(funcListBox.Items[count].ToString()))
                {
                    funcListBox.SetItemChecked(count, true);
                }
            }
        }

        
 
        private void AceptarBtn_Click(object sender, EventArgs e)
        {
            Rol_Ctrl rolCtrl = new Rol_Ctrl();
            Rol nuevoRol = new Rol();
            nuevoRol.nombre = nombreRolBox.Text;
            nuevoRol.lista_funcionalidades = this.getFuncSeleccionadas(funcListBox.CheckedItems.Cast<string>().ToList());
                    
            try {
                if (esModificacion)
                {
                    rolCtrl.modificarRol(nuevoRol,rolAModificar);
                    MessageBox.Show("Se modificó correctamente el rol");
                }
                else
                {
                    rolCtrl.altaRol(nuevoRol);
                    MessageBox.Show("Se generó correctamente el nuevo rol");
                }
            } 
            catch (Exception exc){
                MessageBox.Show(exc.Message);
            }
        }

        private List<Funcionalidad> getFuncSeleccionadas(List<string> descripciones)
        {
            return (funcionalidades.Where(func => descripciones.Contains(func.descripcion_funcionalidad))).ToList();
        }

        private void RolForm_Load(object sender, EventArgs e)
        {
            this.cargarFuncionalidades();
            if (esModificacion)
            {
                nombreRolBox.Text = rolAModificar.nombre;
                this.checkFuncionalidadesRol(rolAModificar);
                habilitadoBox.Checked = rolAModificar.habilitado;
            }
            else {
                habilitadoBox.Checked = true;
            }
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
