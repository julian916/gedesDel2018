using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using FrbaHotel.GenerarModificacionReserva;
using FrbaHotel.Control;
using FrbaHotel.Entidades;

namespace FrbaHotel.GenerarModificarReserva
{
    public partial class GenerarReserva : Form
    {
        
        TipoHabitacion_Ctrl tipoHabCtrl = new TipoHabitacion_Ctrl();
        Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
        int codigoReserva;
        public GenerarReserva()
        {
            InitializeComponent();
            this.cargarTiposHabitacion();
            this.cargarHoteles();
            fechaDesdeCalendar.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
            fechaHastaCalendar.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]).AddDays(1) ;
        }

        private void cargarHoteles()
        {
            comboHoteles.DisplayMember = "nombre";
            comboHoteles.ValueMember = "id_hotel";
            if (DatosSesion.esGuest())
            {
                comboHoteles.DataSource = hotelCtrl.getAllHoteles();
            }
            else {
                List<Hotel> listHotel = new List<Hotel>();
                listHotel.Add(hotelCtrl.getHotelPorID(DatosSesion.id_hotel));
                comboHoteles.DataSource = listHotel;
                comboHoteles.Enabled = false;
                comboHoteles.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            
        }

        private void cargarTiposHabitacion()
        {
            Tipo_Habitacion tipoDefault = new Tipo_Habitacion();
            tipoDefault.id_tipo_habitacion = 0;
            tipoDefault.descripcion = "Todos";
            List<Tipo_Habitacion> tiposHabitacion= tipoHabCtrl.getAll();
            tiposHabitacion.Add(tipoDefault);
            tipoHabBox.DisplayMember = "descripcion";
            tipoHabBox.ValueMember = "id_tipo_habitacion";
            tipoHabBox.DataSource = tiposHabitacion;
        }

        private void FechaDesdeCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            fechaHastaCalendar.MinDate = e.End;
        }

        private void buscarDisponibilidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboHoteles.SelectedItem == null)
                {
                    throw new System.ArgumentException("No se seleccionó hotel");
                }
                if (fechaDesdeCalendar.SelectionEnd >= fechaHastaCalendar.SelectionEnd)
                {
                    throw new System.ArgumentException("La fecha hasta debe ser mayor a la de inicio");
                }

                int idHotel = (int)comboHoteles.SelectedValue;
                DateTime fechaDesde = fechaDesdeCalendar.SelectionEnd;
                DateTime fechaHasta = fechaHastaCalendar.SelectionEnd;
                List<Habitacion> habitacionesDisponibles = hotelCtrl.obtenerHabitacionesDisponibles(idHotel, fechaDesde, fechaHasta,(int)tipoHabBox.SelectedValue);
                if(habitacionesDisponibles.Count>0) {
                    //abrir ventana de habitaciones disponibles
                    RegimenYHabitaciones regHabForm = new RegimenYHabitaciones(habitacionesDisponibles, fechaDesde, fechaHasta);
                    if (regHabForm.ShowDialog(this) == DialogResult.OK)
					{
                        codigoReserva = regHabForm.id_reserva;
                        MessageBox.Show("Se generó correctamente la reserva./n El número de reserva es " + codigoReserva.ToString());

					}
					else
					{
						MessageBox.Show("Operacion cancelada");
					}
                
                }else{
                    MessageBox.Show("La opcion seleccionada no tiene disponibilidad");
                }

            } catch (Exception exc) {
                MessageBox.Show(exc.Message); 
            }
        }

    }
}
