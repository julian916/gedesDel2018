﻿using FrbaHotel.AbmPersona;
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
    public partial class AltaModUsuario : Form
    {
        int nro_documento;
        string email;
        string tipo_documento;
        Usuario userPrevio;
        Usuario userConCambios=new Usuario();
        Rol_Ctrl rolCtrl = new Rol_Ctrl();
        int id_RolSeleccionado;
        List<Hotel> hotelesDeUsuario_Rol = new List<Hotel>();
        List<Hotel> todosLosHoteles = new List<Hotel>();
        Usuario_Ctrl usuarioCtrl = new Usuario_Ctrl();
        Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
        Persona_Ctrl personaCtrl = new Persona_Ctrl();
        public Boolean continuarAltaMod;
        public Boolean esModificacion = false;
        public AltaModUsuario() {

            InitializeComponent();
            modificarPassBtn.Visible = false;
            panelRolXHotel.Enabled = false;
            continuarAltaMod = this.validarDatosPrincipalesPersona();
            newRolBtn.Visible = false;
            deleteRolBtn.Visible = false;
        }

        public AltaModUsuario(Usuario user)
        {
            InitializeComponent();  
            userPrevio = user;
            esModificacion = true;
            panelRolXHotel.Enabled = false;
            acceptButton.Enabled = false;
            panel1.Enabled = false;
            userTextBox.Text = userPrevio.username;

        }

        private void getAllRoles()
        {

            comboRoles.DisplayMember = "nombre";
            comboRoles.ValueMember = "id_rol";
            comboRoles.DataSource = rolCtrl.getAllValidos();
        }

        private Boolean validarDatosPrincipalesPersona()
        {
            Boolean esValido;

            ValidacionPersonaUserForm validarForm = new ValidacionPersonaUserForm();
            if (validarForm.ShowDialog(this) == DialogResult.OK)
            {
                nro_documento = validarForm.nro_documento;
                email = validarForm.email;
                tipo_documento = validarForm.tipo_documento;
                esValido = true;
                
            }
            else
            {
                MessageBox.Show("Operacion cancelada");
                esValido = false;
            }
            return esValido;
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
                if (esModificacion)
                {
                    usuarioCtrl.modificar_Usuario(userPrevio,userConCambios);
                    MessageBox.Show("Se modificó el usuario correctamente");
                    var confirmResult = MessageBox.Show("¿Desea modificar datos personales del usuario?",
                                     "Cambios datos personales",
                                     MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        Persona datosPersona= personaCtrl.getPersona_ConIDUser(userPrevio.id_usuario);
                        AltaPersonaForm formEditPersona = new AltaPersonaForm(datosPersona, userPrevio.id_usuario);  
                    }
                    this.Dispose();
                    this.Close();

                }
                else
                {
                    int idNuevoUsuario = usuarioCtrl.ingresar_NuevoUsuario(userConCambios);
                    MessageBox.Show("Se ingresó el usuario correctamente. A continuacion se ingresaran los datos personales");
                    Persona nuevaPersonaPrevio = new Persona();
                    nuevaPersonaPrevio.tipo_documento = tipo_documento;
                    nuevaPersonaPrevio.nro_documento = nro_documento;
                    nuevaPersonaPrevio.email = email;
                    this.Visible = false;

                    AltaPersonaForm formNewPersona = new AltaPersonaForm(nuevaPersonaPrevio, idNuevoUsuario);
                    formNewPersona.ShowDialog();
                    this.Dispose();
                    this.Close();
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

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
            if (userPrevio != null)
            {
               
                List<string> nombresHoteles = new List<string>();
                hotelesDeUsuario_Rol = hotelCtrl.obtenerHotelesPorID_IDRol(userPrevio.id_usuario,id_RolSeleccionado);
                usuarioCtrl.nuevoRolYHoteles(id_RolSeleccionado,hotelesDeUsuario_Rol,userPrevio);
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
            usuarioCtrl.nuevoRolYHoteles(id_RolSeleccionado, hotelesSeleccionados, userConCambios);
            panelRolXHotel.Enabled = false;
            acceptButton.Enabled = true;
            acceptButton.Focus();
        }

        private List<Hotel> getHotelesSeleccionados(List<string> nombresHoteles)
        {
            return (todosLosHoteles.Where(hotel => nombresHoteles.Contains(hotel.nombre))).ToList();
        }

        private void AltaModUsuarioForm_Load(object sender, EventArgs e)
        {
            if (esModificacion)
            {
                var confirmResult = MessageBox.Show("¿Desea modificar la username/contraseña del usuario?",
                                     "Cambio contraseña",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    panel1.Enabled = true;
                }
                else
                {
                    panel1.Enabled = false;
                    modificarPassBtn.Enabled = false;
                    continuarRolBtn.Enabled = true;
                    //el usuario con cambios tiene el username y el pass sin cambiar
                    userConCambios.username = userPrevio.username;
                    userConCambios.password = userPrevio.password;

                }
            }
        }

        private void getRolesParaUsuario(int idUsuario)
        {
            comboRoles.DisplayMember = "nombre";
            comboRoles.ValueMember = "id_rol";
            comboRoles.DataSource = rolCtrl.obtenerRolesPorID(idUsuario);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void continuarRolBtn_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (esModificacion)
                {
                    newRolBtn.Visible = true;
                    deleteRolBtn.Visible = true;
                    //updateRolBtn.Visible=true;
                    this.getRolesParaUsuario(userPrevio.id_usuario);
                }
                else {
                    this.verificarCamposObligatorios();
                    this.verificar_Contrasenias();
                    //validacion de un alta
                    usuarioCtrl.validarUsername(userTextBox.Text,0);
                    userConCambios.username = userTextBox.Text;
                    userConCambios.password = Encriptacion.getHashSha256(passTextBox.Text);
                    this.getAllRoles();
                }
                panelRolXHotel.Enabled = true;
                panel1.Enabled = false;
                
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }
            
            
        }

        private void verificarCamposObligatorios()
        {
            if (string.IsNullOrEmpty(userTextBox.Text) || string.IsNullOrEmpty(passTextBox.Text)) {
                throw new System.ArgumentException("Debe ingresar usuario y contraseña");
            }
        }

        private void newRolBtn_Click(object sender, EventArgs e)
        {
            this.cargarNuevosRolesParaUser(userConCambios);
            this.selectRolBtn.Visible= true;
            newRolBtn.Enabled = false;
            deleteRolBtn.Enabled = false;
            //TODO : que me carguen los roles validos que todavia no tenga asignado el usuario
            //bloquean los botones

        }

        private void cargarNuevosRolesParaUser(Usuario userConCambios)
        {
            comboRoles.DisplayMember = "nombre";
            comboRoles.ValueMember = "id_rol";
            comboRoles.DataSource = rolCtrl.getNuevosRoles_User(userConCambios);
        }

    
        private void deleteRolBtn_Click(object sender, EventArgs e)
        {
            //tODO: se selecciona el rol qe se desea designar. no se habilita el de hoteles, se da solo a aceptar o cancelar
            //bloquean los botones
            id_RolSeleccionado = (int)comboRoles.SelectedValue;
            usuarioCtrl.desasignarRolAUser(id_RolSeleccionado,userConCambios);
            panelRolXHotel.Enabled = false;
            acceptButton.Enabled = true;
        }

        private void updateRolBtn_Click(object sender, EventArgs e)
        {
            //TODO: se selecciona el rol que se desea modificar: se habilitan los hoteles., se habilita el confirmar.
            //bloquean botones
        }

        private void modificarPassBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.verificar_Contrasenias();
                usuarioCtrl.validarUsername(userTextBox.Text, userPrevio.id_usuario);
                userConCambios.username = userTextBox.Text;
                
                panel1.Enabled = false;
                userConCambios.password = Encriptacion.getHashSha256(passTextBox.Text);
                continuarRolBtn.Enabled = true ;
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            
            }
        }

    }
}