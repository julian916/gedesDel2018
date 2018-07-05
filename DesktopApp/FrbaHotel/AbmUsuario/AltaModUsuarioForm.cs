using FrbaHotel.AbmPersona;
using FrbaHotel.Control;
using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class AltaModUsuarioForm : Form
    {
        int nro_documento;
        string email;
        string tipo_documento;
        Usuario userActual = new Usuario();
        int id_RolSeleccionado;
        List<Hotel> hotelesDeUsuario_Rol = new List<Hotel>();
        List<Hotel> todosLosHoteles = new List<Hotel>();
        Usuario_Ctrl usuarioCtrl = new Usuario_Ctrl();
        Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();

        public AltaModUsuarioForm(Usuario user)
        {
            userActual = user;
            InitializeComponent();
            this.validarDatosPrincipalesPersona();
            hotelPanel.Enabled = false;
        }

        private void getAllRoles()
        {
            Rol_Ctrl rolCtrl = new Rol_Ctrl();

            comboRoles.DisplayMember = "nombre";
            comboRoles.ValueMember = "id_rol";
            comboRoles.DataSource = rolCtrl.getAllValidos();
        }


        private void validarDatosPrincipalesPersona()
        {
            ValidacionPersonaUserForm validarForm = new ValidacionPersonaUserForm();
            validarForm.ShowDialog();
            if (validarForm.ShowDialog(this) == DialogResult.OK)
            {
                nro_documento = validarForm.nro_documento;
                email = validarForm.email;
                tipo_documento = validarForm.tipo_documento;
                
            }
            else
            {
                MessageBox.Show("Operacion cancelada");
                this.Close();
            }
        }

        private void verificar_Contrasenias()
        {
            if (passTextBox.Text != pass2TextBox.Text)
            {
                passTextBox.Clear();
                pass2TextBox.Clear();
                throw new System.ArgumentException("Las contraseñas no coinciden. Verifique los datos ingresados");
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                verificar_campos_obligatorios();
                usuarioCtrl.ingresar_NuevoUsuario(userActual);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

        }

        private void verificar_campos_obligatorios()
        {
           //TODO
        }

        private void selectRolBtn_Click(object sender, EventArgs e)
        {
            id_RolSeleccionado = (int)comboRoles.SelectedValue;
            rolPanel.Enabled = false;
            hotelPanel.Enabled = true;
            this.cargarHoteles();
        }

        private void cargarHoteles()
        {

            todosLosHoteles = hotelCtrl.getAllHoteles();
            foreach (Hotel hotel in todosLosHoteles)
            {
                hotelListBox.Items.Add(hotel.nombre);

            }
            if (userActual != null)
            {
               
                List<string> nombresHoteles = new List<string>();
                hotelesDeUsuario_Rol = hotelCtrl.obtenerHotelesPorID_IDRol(userActual.id_usuario,id_RolSeleccionado);
                foreach (Hotel hotelUsuario in hotelesDeUsuario_Rol){
                    nombresHoteles.Add(hotelUsuario.nombre);
                }
                //mostrar los hoteles del usuario
                for (int count = 0; count < hotelListBox.Items.Count; count++)
                {
                    if (nombresHoteles.Contains(hotelListBox.Items[count].ToString()))
                    {
                        hotelListBox.SetItemChecked(count, true);
                    }
                }
                

            }
         
        }

        private void confirmRol_Click(object sender, EventArgs e)
        {
            List<Hotel>hotelesSeleccionados = this.getHotelesSeleccionados(hotelListBox.CheckedItems.Cast<string>().ToList());
            usuarioCtrl.nuevoRolYHoteles(id_RolSeleccionado, hotelesSeleccionados,userActual);
            const string message = "¿Desea agregar un nuevo rol al usuario?";
            const string caption = "Continuar gestión roles";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                hotelPanel.Enabled = false;
                rolPanel.Enabled = true;
            }
            else {
                hotelPanel.Enabled = false;
                rolPanel.Enabled = false;
                acceptButton.Focus();
                acceptButton.Enabled = true;
            }
        }

        private List<Hotel> getHotelesSeleccionados(List<string> nombresHoteles)
        {
            return (List<Hotel>)todosLosHoteles.Where(hotel => nombresHoteles.Contains(hotel.nombre));
        }

        private void AltaModUsuarioForm_Load(object sender, EventArgs e)
        {
            if (userActual == null)
            {
                newRolBtn.Visible = false;
                updateRolBtn.Visible = false;
                deleteRolBtn.Visible = false;
                this.getAllRoles();
            }
            else {
                userTextBox.ReadOnly = true;
                rolPanel.Enabled = false;
                userTextBox.Text = userActual.username;
                passTextBox.Text = userActual.password;
            }
        }

       
    }
}