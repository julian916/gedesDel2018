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

namespace FrbaHotel.AbmHabitacion
{
    public partial class AltaEditHabForm : Form
    {
        private int id_hotel_logueado=DatosSesion.id_hotel;

        private Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
        private Habitacion_Ctrl habCtrl = new Habitacion_Ctrl();
        private Habitacion habitacionAModificar;

        public AltaEditHabForm()
        {
            InitializeComponent();
            infoHotelBox.Text = this.obtenerNombreHotel(id_hotel_logueado);
            this.cargarTiposHabitaciones();
        }

        public AltaEditHabForm(Habitacion habitacionSeleccionada)
        {
            InitializeComponent();
            infoHotelBox.Text = this.obtenerNombreHotel(id_hotel_logueado);
            this.cargarTiposHabitaciones();
            this.habitacionAModificar = habitacionSeleccionada;
            pisoNumericBox.Value = habitacionSeleccionada.piso;
            numHabBox.Value = habitacionSeleccionada.nro_habitacion;
            frenteBox.Checked = habCtrl.getBoolForStringFrente(habitacionSeleccionada.frente);
            comodidadesBox.Text = habitacionSeleccionada.comodidades;
            tipoHabitacionCombo.SelectedValue = habitacionSeleccionada.id_tipo_habitacion;
  
        }

        private void cargarTiposHabitaciones()
        {
            TipoHabitacion_Ctrl tipoCtrl = new TipoHabitacion_Ctrl();
            tipoHabitacionCombo.DisplayMember = "descripcion";
            tipoHabitacionCombo.ValueMember = "id_tipo_habitacion";
            tipoHabitacionCombo.DataSource = tipoCtrl.getAll();
        }

        private string obtenerNombreHotel(int id_hotel_logueado)
        {
            Hotel hotel = hotelCtrl.getHotelPorID(id_hotel_logueado);
            return hotel.nombre;
        }

        private void confirmarButton_Click(object sender, EventArgs e)
        {
            if (this.tieneCamposObligatorios())
            {
                var nuevaHabitacion = new Habitacion();
                nuevaHabitacion.piso = (int)pisoNumericBox.Value;
                nuevaHabitacion.nro_habitacion = (int)numHabBox.Value;
                nuevaHabitacion.frente = habCtrl.stringFrenteTo(frenteBox.Checked);
                nuevaHabitacion.comodidades = comodidadesBox.Text;
                nuevaHabitacion.id_hotel = id_hotel_logueado;
                nuevaHabitacion.id_tipo_habitacion = (int)tipoHabitacionCombo.SelectedValue;

                try
                {
                    if (this.esModificacion())
                    {

                        tipoHabitacionCombo.Enabled = true ;
                        nuevaHabitacion.id_habitacion = habitacionAModificar.id_habitacion;
                        habCtrl.modificarHabitacion(nuevaHabitacion);
                        MessageBox.Show("Se modificó correctamente la habitación");
                    }
                    else
                    {
                        habCtrl.altaHabitacion(nuevaHabitacion);
                        MessageBox.Show("Se agregó correctamente la habitación");
                    }
                    this.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }                
            }
            else
            {
                MessageBox.Show("Falta completar datos.");

            }
            
        }

        private bool esModificacion()
        {
            return habitacionAModificar != null;
        }

        private bool tieneCamposObligatorios()
        {
            return pisoNumericBox.Value != 0 && tipoHabitacionCombo.SelectedValue != null;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            
        }
    }
}
