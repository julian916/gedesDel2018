using FrbaHotel.Control;
using FrbaHotel.Entidades;
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

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class RegimenYHabitaciones : Form
    {
        public int id_reserva;
        int id_regimenSeleccionado;
        Persona cliente_reserva;
        int hotelReserva, cantidadDiasReserva;
        decimal costoPorDia, costoTotal;
        DateTime fecha_desde, fecha_hasta;
        List<Habitacion> habitacionesDisponibles = new List<Habitacion>();
        List<Habitacion> habitacionesSeleccionadas = new List<Habitacion>();
        Regimenes_Ctrl ctrlRegimenes = new Regimenes_Ctrl();
        Reserva_Ctrl reservaCtrl = new Reserva_Ctrl();
        Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
        
        public RegimenYHabitaciones(List<Habitacion> habitaciones, DateTime fechaDesde, DateTime fechaHasta)
        {
            InitializeComponent();
            fecha_desde = fechaDesde;
            fecha_hasta = fechaHasta;
            this.habitacionesDisponibles = habitaciones;
            dataGridHabDisp.DataSource = habitacionesDisponibles;
            panelRegimenes.Enabled = false;
            confirmResBtn.Enabled = false;
            cantidadDiasReserva = Convert.ToInt32((fechaHasta - fechaDesde).TotalDays);
        }

        private void confirmHab_Click(object sender, EventArgs e)
        {
            
            if (dataGridHabDisp.DataSource != null && dataGridHabDisp.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridHabDisp.SelectedRows)
                {
                    Habitacion habitSeleccionada = (Habitacion)row.DataBoundItem;
                    habitacionesSeleccionadas.Add(habitSeleccionada);
                    hotelReserva = habitSeleccionada.id_hotel;
                }
                panelRegimenes.Enabled = true;
                dataGridHabDisp.Enabled = false;
                
                this.cargarRegimenes();
            }
            else {
                MessageBox.Show("No se seleccionaron habitaciones.\nSeleccione una o más para continuar con la reserva"); 
            }
        }

        private void cargarRegimenes()
        {
            List<RegimenEstadia> regimenes = ctrlRegimenes.getRegimenes_IDHotel(hotelReserva);
            regimenComboBox.DisplayMember = "descripcion";
            regimenComboBox.ValueMember = "id_regimen";
            regimenComboBox.DataSource = regimenes;
            
        }

        private void modHabBtn_Click(object sender, EventArgs e)
        {
            dataGridHabDisp.Enabled = true;
            
            panelRegimenes.Enabled = false;
            this.resetPrecios();
        }

        private void resetPrecios()
        {
            precioPorDiaBox.Text = "";
            totalBox.Text = "";
        }

        private void confirmResBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //creo la reserva
                Reserva nuevaReserva = new Reserva();
                nuevaReserva.id_persona = cliente_reserva.id_persona;
                nuevaReserva.id_regimen = id_regimenSeleccionado;
                nuevaReserva.fecha_desde = fecha_desde;
                nuevaReserva.fecha_hasta = fecha_hasta;
                nuevaReserva.fecha_reserva = DateTime.Parse(ConfigurationManager.AppSettings["FechaSistema"].ToString());
                nuevaReserva.cantidad_noches = cantidadDiasReserva;
                id_reserva = reservaCtrl.nuevaReserva(nuevaReserva);

                //luego de la carga, genero ReservaXHabitacion
                foreach (Habitacion habSeleccionada in habitacionesSeleccionadas) {
                    reservaCtrl.nuevaHabitacion_X_Reserva(id_reserva, habSeleccionada.id_habitacion);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            
        }

        private void regimenComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            id_regimenSeleccionado =  (int)regimenComboBox.SelectedValue;
            costoPorDia = 0;
            costoTotal = 0;
            foreach (Habitacion habitSeleccionada in habitacionesSeleccionadas){
                costoPorDia = costoPorDia + hotelCtrl.getCostoPorDiaHabitacion(hotelReserva, id_regimenSeleccionado, habitSeleccionada.id_tipo_habitacion);
            }
            costoTotal = costoPorDia * cantidadDiasReserva;
            precioPorDiaBox.Text = costoPorDia.ToString("#.##");
            totalBox.Text = costoTotal.ToString("#.##");
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void clientePrincBtn_Click(object sender, EventArgs e)
        {
            IngresarHuespedForm clienteForm = new IngresarHuespedForm();
            if (clienteForm.ShowDialog(this) == DialogResult.OK)
            {
                cliente_reserva = clienteForm.clientePrincipal;
                confirmResBtn.Enabled = true;
                confirmResBtn.Focus();
            }
            else
            {
                MessageBox.Show("Operacion cancelada");
            }
        }

    }

}