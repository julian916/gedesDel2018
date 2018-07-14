using FrbaHotel.Control;
using FrbaHotel.Entidades;
using FrbaHotel.FacturarEstadia;
using FrbaHotel.RegistrarConsumible;
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
    public partial class CheckOUTForm : Form
    {
        Reserva reservaSeleccionada;
        Reserva_Ctrl reservaCtrl = new Reserva_Ctrl();
        Estadia_Ctrl estadiaCtrl = new Estadia_Ctrl();
        Persona_Ctrl personaCtrl = new Persona_Ctrl(); 
        TipoHabitacion_Ctrl tipoHabCtrl = new TipoHabitacion_Ctrl();
        Estadia estadiaRelacionada;
        public CheckOUTForm()
        {
            InitializeComponent();
            panel1.Enabled = false;
            panel2.Enabled = false;
            cerrarEstadiaBtn.Enabled = false;
            facturarBtn.Enabled = false;
            fechaCheckOutBox.MinDate = Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"]);
        }

        private void buscarBtn_Click(object sender, EventArgs e)
        {
            reservaSeleccionada = reservaCtrl.getReservaConID(Convert.ToInt32(codReservaBox.Text));
            //verifico si para la reserva ya se realizó un checkIn, de ser asi, existe una estadia
            if (reservaCtrl.esReservaAptaParaCheckOut(reservaSeleccionada))
            {
                panel1.Enabled = false;
                panel2.Enabled = true;
                cerrarEstadiaBtn.Enabled = true;
                estadiaRelacionada = estadiaCtrl.getEstadia_IDReserva(reservaSeleccionada.id_reserva);
                cargarInfoReserva();
                estadiaRelacionada.id_reserva = reservaSeleccionada.id_reserva ;
                fechaInicioEstBox.Value = estadiaRelacionada.fecha_inicio;
                fechaInicioEstBox.Enabled = false;
                buscarBtn.Enabled = false;
            }
            else {
                MessageBox.Show("La reserva ingresada no es apta para CheckOUT.\nSu estado actual es: " + reservaCtrl.getEstadoReserva(reservaSeleccionada.id_estado_reserva));
            }
        }

        private void cargarInfoReserva()
        {
            fechaInicioRes.Value = reservaSeleccionada.fecha_desde;
            int huespedesMax = this.getCantMaximaHuespedes();
            cantNochesBox.Text = Convert.ToString(reservaSeleccionada.cantidad_noches);
            Persona titularReserva = personaCtrl.getPersona_IDPersona(reservaSeleccionada.id_persona);
            titularBox.Text = titularReserva.apellido + ' ' + titularReserva.nombre;
            huespedesMaxBox.Text = Convert.ToString(huespedesMax);
        }

        private int getCantMaximaHuespedes()
        {
            int cant = 0;
            foreach (Habitacion habReserva in reservaSeleccionada.habitacionesReserva)
            {
                Tipo_Habitacion tipoHab = tipoHabCtrl.getTipoHabitacion_ConID(habReserva.id_tipo_habitacion);
                cant = cant + tipoHab.cant_Huespedes;
            }
            return cant;
        }

        private void newConsumBtn_Click(object sender, EventArgs e)
        {
            NuevoConsumibleForm consumForm = new NuevoConsumibleForm(estadiaRelacionada);
            if (consumForm.ShowDialog(this) == DialogResult.OK)
            {
                estadiaRelacionada.consumibles = consumForm.estadia.consumibles;
                foreach (Consumible consumible in estadiaRelacionada.consumibles)
                {
                    for (int i = 0; i < dataGridConsumibles.Rows.Count; i++)
                    {
                        var row = this.dataGridConsumibles.Rows[i];
                        row.Cells["Consumible"].Value = consumible.descripcion;
                        row.Cells["Cantidad"].Value = consumible.cantidad;
                        row.Cells["Precio Acumulado"].Value = consumible.cantidad*consumible.precio;
                    }
                }
            }
            else
            {
                MessageBox.Show("Operacion cancelada");
            }
        }

        private void facturarBtn_Click(object sender, EventArgs e)
        {
            FacturaFinalForm facturaFinal = new FacturaFinalForm(estadiaRelacionada,reservaSeleccionada);
            if (facturaFinal.seGeneroFactura)
            {
                facturaFinal.Show();
            }
        }

        private void cerrarEstadiaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaHasta = fechaCheckOutBox.Value;
                estadiaRelacionada.cant_noches = Convert.ToInt32((fechaHasta - estadiaRelacionada.fecha_inicio).TotalDays);
                estadiaRelacionada.id_usuario_checkOut = DatosSesion.id_usuario;
                estadiaCtrl.cerrarEstadia(estadiaRelacionada);
                MessageBox.Show("Se realizó correctamente el checkOUT");
                panel2.Enabled = false;
                facturarBtn.Enabled = true;
                facturarBtn.Focus();
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }

        }

    }
}
