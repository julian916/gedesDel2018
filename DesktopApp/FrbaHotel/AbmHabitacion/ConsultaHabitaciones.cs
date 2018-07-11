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
    public partial class ConsultaHabitaciones : Form
    {
        Habitacion_Ctrl habitacionCtrl = new Habitacion_Ctrl();
        int id_hotel_sesion = DatosSesion.id_hotel;
        public ConsultaHabitaciones()
        {
            InitializeComponent();
        }

        private void newHabBtn_Click(object sender, EventArgs e)
        {
            AltaEditHabForm altaHab = new AltaEditHabForm();
            altaHab.ShowDialog();
            this.Close();
        }

        private void ConsultaHabitaciones_Load(object sender, EventArgs e)
        {
            
            infoHabBox.Text = this.obtenerNombreHotel(id_hotel_sesion);
            List<Habitacion> habitacionesDeHotel = habitacionCtrl.getHabitacionesDeHotel(id_hotel_sesion);
            foreach ( Habitacion hab in habitacionesDeHotel){
                dataGridHabitaciones.Rows.Add(hab.id_habitacion,hab.nro_habitacion,hab.piso, hab.frente, hab.id_tipo_habitacion,hab.habilitado,hab.comodidades,hab.id_hotel);
            }
        }

        private string obtenerNombreHotel(int id_hotel_logueado)
        {
            Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
            Hotel hotel = hotelCtrl.getHotelPorID(id_hotel_logueado);
            return hotel.nombre;
        }

        private void modificarBtn_Click(object sender, EventArgs e)
        {
            if (dataGridHabitaciones.DataSource != null && dataGridHabitaciones.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridHabitaciones.SelectedRows)
                {
                    Habitacion habitacionSeleccionada = (Habitacion)row.DataBoundItem;
                    AltaEditHabForm editForm = new AltaEditHabForm(habitacionSeleccionada);
                    editForm.ShowDialog();
                }
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se selecciono habitacion. Seleccione una fila de la tabla");
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void dataGridHabitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridHabitaciones.Columns[5].Index)
                {
                    //obtengo la fila del cliente a deshabilitar
                    Habitacion habSeleccionada = (Habitacion)dataGridHabitaciones.Rows[e.RowIndex].DataBoundItem;
                    Habitacion_Ctrl habCtrl = new Habitacion_Ctrl();
                    string mensaje = habCtrl.inhabilitarHabilitarHabitacion(habSeleccionada);
                    if (mensaje == "")
                    {
                        MessageBox.Show("Se realizó el cambio");
                    }
                    else {
                        MessageBox.Show(mensaje);
                    }
                }
            }
            catch (Exception exc){
                MessageBox.Show(exc.Message);
            }
        }
    }
}
