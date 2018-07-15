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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class ModificarReservaForm : Form
    {
        public Reserva reservaPrevia= new Reserva();
        int id_regimen_seleccionado;
        Regimenes_Ctrl ctrlRegimenes = new Regimenes_Ctrl();
        Reserva_Ctrl reservaCtrl = new Reserva_Ctrl();
        Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
        Reserva reservaConCambio = new Reserva();
        TipoHabitacion_Ctrl tipoHabCtrl = new TipoHabitacion_Ctrl();
        public ModificarReservaForm()
        {
            InitializeComponent();
            CodReservaForm codReservaForm = new CodReservaForm();
            if (codReservaForm.ShowDialog(this) == DialogResult.OK)
            {
                reservaPrevia= codReservaForm.reservaEncontrada;
            }
           
        }

        private void ModificarReservaForm_Load(object sender, EventArgs e)
        {
            this.cargarRegimenesDeHotel();
            fechaInicioBox.Value = reservaPrevia.fecha_desde;
            fechaFinBox.Value = reservaPrevia.fecha_hasta;
            regimenComboBox.SelectedValue = reservaPrevia.id_regimen;
            panelRegimenes.Enabled = false;
            reservaConCambio.habitacionesReserva = reservaPrevia.habitacionesReserva;
            this.cargarTiposHabitacion();
            this.cargarHabitacionesActuales();
            this.cargarHabitacionesDisponibles();
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

        private void cargarHabitacionesDisponibles()
        {
 
            dataGridHabDispon.DataSource = hotelCtrl.obtenerHabitacionesDisponibles(reservaPrevia.id_hotel, fechaInicioBox.Value, fechaFinBox.Value, 0);
        }

        private void cargarHabitacionesActuales()
        {
            reservaPrevia.habitacionesReserva = reservaCtrl.getHabitacionesDeReserva(reservaPrevia.id_reserva);
            dataGridHabActuales.DataSource = reservaPrevia.habitacionesReserva;
        }

        private void cargarRegimenesDeHotel()
        {
            List<RegimenEstadia> regimenes = ctrlRegimenes.getRegimenes_IDHotel(reservaPrevia.id_hotel);
            regimenComboBox.DisplayMember = "descripcion";
            regimenComboBox.ValueMember = "id_regimen";
            regimenComboBox.DataSource = regimenes;
        }

        private void cambiarFechasBtn_Click(object sender, EventArgs e)
        {
            reservaConCambio.fecha_desde = fechaInicioBox.Value;
            reservaConCambio.fecha_hasta = fechaFinBox.Value;
            reservaConCambio.cantidad_noches = Convert.ToInt32((reservaConCambio.fecha_hasta - reservaConCambio.fecha_desde).TotalDays);
            this.cargarHabitacionesDisponibles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridHabDispon.DataSource = hotelCtrl.obtenerHabitacionesDisponibles(reservaPrevia.id_hotel, fechaInicioBox.Value, fechaFinBox.Value, (int)tipoHabBox.SelectedValue);
        }

        private void agregarHabBtn_Click(object sender, EventArgs e)
        {
            if (dataGridHabDispon.DataSource != null && dataGridHabDispon.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridHabDispon.SelectedRows)
                {
                    Habitacion habitacion = (Habitacion)row.DataBoundItem;
                    reservaConCambio.habitacionesReserva.Add(habitacion);
                    this.actualizarHabitacionesActuales();
                }

            }
            else
            {
                MessageBox.Show("No se seleccionó habitacion para agregar");
            }
        }

        private void actualizarHabitacionesActuales()
        {
            dataGridHabActuales.DataSource = reservaConCambio.habitacionesReserva;
        }

        private void quitarHabBtn_Click(object sender, EventArgs e)
        {
            if (dataGridHabActuales.DataSource != null && dataGridHabDispon.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridHabDispon.SelectedRows)
                {
                    Habitacion habitacion = (Habitacion)row.DataBoundItem;
                    reservaConCambio.habitacionesReserva.Remove(habitacion);
                    this.actualizarHabitacionesActuales();
                }

            }
            else
            {
                MessageBox.Show("No se seleccionó habitacion para agregar");
            }
        }

        private void confirmarHab_Click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            cambiarRegBtn.Enabled = true;
            cambiarRegBtn.Focus();
            panelRegimenes.Enabled = true;
            panel1.Enabled = false;
            panel4.Enabled = false;

        }

        private void regimenComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            id_regimen_seleccionado = (int)regimenComboBox.SelectedValue;
            decimal costoPorDia = 0;
            decimal costoTotal = 0;
            foreach (Habitacion habitSeleccionada in reservaConCambio.habitacionesReserva)
            {
                costoPorDia = costoPorDia + hotelCtrl.getCostoPorDiaHabitacion(habitSeleccionada.id_hotel, id_regimen_seleccionado, habitSeleccionada.id_tipo_habitacion);
            }
            costoTotal = costoPorDia * reservaConCambio.cantidad_noches;
            precioPorDiaBox.Text = costoPorDia.ToString("#.##");
            totalBox.Text = costoTotal.ToString("#.##");

        }

        private void confirmCambiosBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridHabActuales.Rows.Count==0){
                    throw new System.ArgumentException("Debe ingresar al menos una habitación a la reserva");
                }
                reservaConCambio.id_reserva = reservaPrevia.id_reserva;
                reservaCtrl.modificar_reserva(reservaConCambio, reservaPrevia);
                MessageBox.Show("Se modificó correctamente el hotel.");
            }
            catch (Exception exc) {

                MessageBox.Show(exc.Message); 
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
