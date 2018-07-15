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
using FrbaHotel.Entidades;

namespace FrbaHotel.Reservas
{
    public partial class GenerarModificarReserva : Form
    {
        private Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles();
        public GenerarModificarReserva()
        {
            InitializeComponent();
            fechaDesdeCalendar.MinDate = DateTime.Now;
            fechaHastaCalendar.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void CiudadesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("No se selecciono hotel" + comboCiudad.SelectedValue.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            comboCalles.DisplayMember = "calles";
            comboCalles.ValueMember = "id_Hotel";
            comboCalles.DataSource = repoHoteles.getCalles(comboCiudad.SelectedValue.ToString());
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            comboCiudad.DisplayMember = "ciudad";
            comboCiudad.ValueMember = "ciudad";
            comboCiudad.DataSource = repoHoteles.getCiudades();

            comoTipoHabitacion.DisplayMember = "descripcion";
            comoTipoHabitacion.ValueMember = "id_tipo_habitacion";
            comoTipoHabitacion.DataSource = repoHoteles.getTipoHabitaciones();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void FechaHastaCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void FechaDesdeCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            fechaHastaCalendar.MinDate = e.End;
        }

        private void buscarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (comboCalles.SelectedItem == null)
            {
                MessageBox.Show("No se selecciono hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DateTime fechaDesde = DateTime.Parse(fechaDesdeCalendar.Text.ToString());
                DateTime fechaHasta = DateTime.Parse(fechaHastaCalendar.Text.ToString());

                if (fechaDesde >= fechaHasta)
                {
                    MessageBox.Show("La fecha hasta debe ser mayor a la de inicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int idHotel = int.Parse(comboCalles.SelectedValue.ToString());

                    int idRegimen = 1;

                    try
                    {
                        var habitacionesDisponibles = repoHoteles.obtenerHabitacionesDisponibles(idHotel, fechaDesde, fechaHasta, idRegimen);
                        if (habitacionesDisponibles.Rows.Count > 0)
                        {
                            //Tiene registros

                            //RegimenYHabitaciones obj = new AltaPersonaForm(idUsuario, mailBox.Text);
                            //if (obj == null)
                            //{
                            //    obj.Parent = this;
                            //}
                            //obj.Show();
                            //this.Hide();
                        }
                        else
                        {
                            //No tiene registros
                            MessageBox.Show("La opcion seleccionada no tiene disponibilidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error comprobandoDisponibilidad: " + ex.Message);
                        MessageBox.Show("Error al comprobar la disponibilidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }

            }
        }

        private void comboCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            recargar_tipo_habitacion();
        }

        private void recargar_tipo_habitacion()
        {
            
        }

        private void button_SeleccionarFecha_Click(object sender, EventArgs e)
        {
            //Si el boton esta en estado seteado entonces como nombre tendra "Modificar Fecha"
            if (button_SeleccionarFecha.Text == "Modificar") 
            {
                limpiarHabitacionesSeleccionadas();
                panel_hotel_fecha.Enabled = true;
                button_SeleccionarFecha.Text = "Buscar Habitaciones";
            }
            else
            {
                DateTime fechaDesde = DateTime.Parse(fechaDesdeCalendar.Text.ToString());
                DateTime fechaHasta = DateTime.Parse(fechaHastaCalendar.Text.ToString());

                if (fechaDesde >= fechaHasta)
                {
                    MessageBox.Show("La fecha hasta debe ser mayor a la de inicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    panel_hotel_fecha.Enabled = false;
                    comoTipoHabitacion.Enabled = true;
                    button_SeleccionarFecha.Text = "Modificar";
                }
            }
        }

        private void limpiarHabitacionesSeleccionadas()
        {
            throw new NotImplementedException();
        }
    }
}
