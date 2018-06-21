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

namespace FrbaHotel.GenerarModificarReserva
{
    public partial class GenerarReserva : Form
    {
        private Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles();
        public GenerarReserva()
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
            comboCalles.ValueMember = "idHotel";
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
                    int idHotel = int.Parse(comboCiudad.SelectedValue.ToString());
                    DateTime fechaDesde = fechaDesdeCalendar.SelectionEnd;
                    DateTime fechaHasta = fechaHastaCalendar.SelectionEnd;
                    
                    try
                    {
                        if (Repositorios.RepositorioHoteles.comprobarDisponibilidad(idHotel, fechaDesde, fechaHasta))
                        {
                            //RegimenYHabitaciones obj = new AltaPersonaForm(idUsuario, mailBox.Text);
                            //if (obj == null)
                            //{
                            //    obj.Parent = this;
                            //}
                            //obj.Show();
                            //this.Hide();
                        } else
                        {
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
