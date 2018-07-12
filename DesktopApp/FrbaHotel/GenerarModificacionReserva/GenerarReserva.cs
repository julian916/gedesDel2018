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

namespace FrbaHotel.GenerarModificarReserva
{
    public partial class GenerarReserva : Form
    {
        private Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles();
        TipoHabitacion_Ctrl tipoHabCtrl = new TipoHabitacion_Ctrl();
        public GenerarReserva()
        {
            InitializeComponent();
            this.cargarTiposHabitacion();
            fechaDesdeCalendar.MinDate = DateTime.Now;
            fechaHastaCalendar.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
        }

        private void cargarTiposHabitacion()
        {
            
            tipoHabBox.DisplayMember = "descripcion";
            tipoHabBox.ValueMember = "id_tipo_habitacion";
            tipoHabBox.DataSource = tipoHabCtrl.getAll();
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
                if (fechaDesdeCalendar.SelectionEnd >= fechaHastaCalendar.SelectionEnd)
                {
                    MessageBox.Show("La fecha hasta debe ser mayor a la de inicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int idHotel = int.Parse(comboCalles.SelectedValue.ToString());
                    DateTime fechaDesde = fechaDesdeCalendar.SelectionEnd;
                    DateTime fechaHasta = fechaHastaCalendar.SelectionEnd;
                    int idRegimen = 1;

                    try
                    {
                        var habitacionesDisponibles = repoHoteles.obtenerHabitacionesDisponibles(idHotel, fechaDesde, fechaHasta,idRegimen);
                        if(habitacionesDisponibles.Rows.Count > 0)
                        {
                            //Tiene registros

                            //RegimenYHabitaciones obj = new AltaPersonaForm(idUsuario, mailBox.Text);
                            //if (obj == null)
                            //{
                            //    obj.Parent = this;
                            //}
                            //obj.Show();
                            //this.Hide();
                        } else
                        {
                            //No tiene registros
                            MessageBox.Show("La opcion seleccionada no tiene disponibilidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        
                    } catch(Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error comprobandoDisponibilidad: " + ex.Message);
                        MessageBox.Show("Error al comprobar la disponibilidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }

            }
        }
    }
}
