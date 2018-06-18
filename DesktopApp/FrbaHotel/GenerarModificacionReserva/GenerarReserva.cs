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

namespace FrbaHotel.GenerarModificarReserva
{
    public partial class GenerarReserva : Form
    {

        public GenerarReserva()
        {
            InitializeComponent();
            fechaDesdeCalendar.MinDate = DateTime.Now;
            fechaHastaCalendar.MinDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void HotelesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            Repositorios.RepositorioHoteles repoHoteles = new Repositorios.RepositorioHoteles();

            comboHoteles.DisplayMember = "dir_Hotel";
            comboHoteles.ValueMember = "id_Hotel";
            comboHoteles.DataSource = repoHoteles.getAll();
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

        private void comprobarDisponibilidad_Click(object sender, EventArgs e)
        {
            if (comboHoteles.SelectedItem == null)
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
                    int idHotel = int.Parse(comboHoteles.SelectedValue.ToString());
                    DateTime ahora = DateTime.Now;
                    DateTime fechaDesde = fechaDesdeCalendar.SelectionEnd;
                    DateTime fechaHasta = fechaHastaCalendar.SelectionEnd;
                    int tipo_habitacion = -1; //TODO: Pendiente definir como se van a pasar las habitaciones
                    int tipo_regimen = -1; //TODO: pendiente sacar el id de tipo de regimen

                    try
                    {
                        if (Repositorios.RepositorioHoteles.comprobarDisponibilidad(idHotel, ahora, fechaDesde, fechaHasta, tipo_habitacion, tipo_regimen))
                        {
                            MessageBox.Show("La opcion seleccionada se encuentra disponible. ¿Continuar con la reserva?", "Mensaje", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
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
