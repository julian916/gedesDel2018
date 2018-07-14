using FrbaHotel.Control;
using FrbaHotel.Entidades;
using FrbaHotel.GenerarModificacionReserva;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarEstadia
{
    public partial class CheckINForm : Form
    {
        Reserva reservaSeleccionada;
        Persona_Ctrl personaCtrl = new Persona_Ctrl();
        Reserva_Ctrl reservaCtrl = new Reserva_Ctrl();
        TipoHabitacion_Ctrl tipoHabCtrl = new TipoHabitacion_Ctrl();
        Estadia_Ctrl estadiaCtrl = new Estadia_Ctrl();
        List<Persona> huespedes = new List<Persona>();
        int cant_huespedes_max;
        DateTime fechaInicio;
        public CheckINForm()
        {
            InitializeComponent();
            panel1.Enabled = false;
            panel2.Enabled = false;
            
            regCheckInBtn.Enabled = false;
            fechaInicioEstBox.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
        }

        private void completarDatos()
        {
            
            foreach ( Persona huesped in huespedes){
                for (int i = 0; i < dataGridHuesped.Rows.Count; i++) {
                    var row = this.dataGridHuesped.Rows[i];
                    row.Cells["Nombre Huesped"].Value = huesped.nombre;
                    row.Cells["Apellido"].Value = huesped.apellido;
                    row.Cells["Nro Documento"].Value = Convert.ToString(huesped.nro_documento);
                }
            }
            
        }

        private int getCantMaximaHuespedes()
        {
            int cant = 0;
            foreach (Habitacion habReserva in reservaSeleccionada.habitacionesReserva) {
                Tipo_Habitacion tipoHab = tipoHabCtrl.getTipoHabitacion_ConID(habReserva.id_tipo_habitacion);
                cant = cant + tipoHab.cant_Huespedes;
            }
            return cant;
        }

        private void addHuespedBtn_Click(object sender, EventArgs e)
        {
            if (this.huespedes.Count >= cant_huespedes_max)
            {
                MessageBox.Show("Se superó la cantidad de huespedes segun capacidad de habitaciones");
                addHuespedBtn.Enabled = false;
            }
            else {
                IngresarHuespedForm clienteForm = new IngresarHuespedForm();
                if (clienteForm.ShowDialog(this) == DialogResult.OK)
                {
                    Persona huesped = clienteForm.clienteSeleccionado;
                    huespedes.Add(huesped);
                }
                else
                {
                    MessageBox.Show("Operacion cancelada");
                }
            
            }
        }

        private void regCheckInBtn_Click(object sender, EventArgs e)
        {
            try{

                if (reservaSeleccionada.fecha_desde > fechaInicioEstBox.Value) {
                    throw new System.ArgumentException("La fecha de ingreso de estadía debe ser la misma a la fecha de inicio de la reserva");
                }
                if (huespedes.Count == 0) {
                    throw new System.ArgumentException("Debe ingresar al menos una habitación");
                }
                Estadia nuevaEstadia = new Estadia();
                nuevaEstadia.fecha_inicio = fechaInicioEstBox.Value;
                nuevaEstadia.id_usuario_checkIn=DatosSesion.id_usuario;
                nuevaEstadia.id_reserva=reservaSeleccionada.id_reserva;
                nuevaEstadia.huespedes = huespedes;
                estadiaCtrl.generarEstadia(nuevaEstadia);
                MessageBox.Show("Se generó correctamente el check IN");
            }
            catch(Exception exc){
                MessageBox.Show(exc.Message);
            
            }
            
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
            reservaSeleccionada = reservaCtrl.getReservaConID(Convert.ToInt32(codReservaBox.Text));
            List<Habitacion> habitacionesReserva = reservaCtrl.getHabitacionesDeReserva(Convert.ToInt32(codReservaBox.Text));
            reservaSeleccionada.habitacionesReserva = habitacionesReserva;
            if (reservaSeleccionada != null)
            {
                fechaInicioResBox.Value = reservaSeleccionada.fecha_desde;
                cant_huespedes_max = this.getCantMaximaHuespedes();
                cantNochesBox.Text = Convert.ToString(reservaSeleccionada.cantidad_noches);
                Persona titularReserva = personaCtrl.getPersona_IDPersona(reservaSeleccionada.id_persona);
                huespedes.Add(titularReserva);
                titularResBox.Text = titularReserva.apellido + ' ' + titularReserva.nombre;
                cantHuespMaxBox.Text = Convert.ToString(cant_huespedes_max);
                panel2.Enabled = true;
                regCheckInBtn.Enabled = true;
                this.completarDatos();

            }
            else
            {
                MessageBox.Show("El código de reserva ingresado no es válido");
            }
        }

    }
}
