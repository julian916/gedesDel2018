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
    public partial class AltaHabitacionForm : Form
    {
        private int id_hotel_logueado;
        private Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
        private Habitacion_Ctrl habCtrl = new Habitacion_Ctrl();

        public AltaHabitacionForm(int id_hotel)
        {
            InitializeComponent();
            id_hotel_logueado = id_hotel;
        }

        private void AltaHabitacionForm_Load(object sender, EventArgs e)
        {
            infoHotelBox.Text=this.obtenerNombreHotel(id_hotel_logueado);
            this.cargarTiposHabitaciones();
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
                nuevaHabitacion.piso=(int)pisoNumericBox.Value;
                nuevaHabitacion.nro_habitacion=(int)numHabBox.Value;
                nuevaHabitacion.frente=frenteBox.Checked;
                nuevaHabitacion.comodidades=comodidadesBox.Text;
                nuevaHabitacion.id_hotel=id_hotel_logueado;
                nuevaHabitacion.id_tipo_habitacion=(int)tipoHabitacionCombo.SelectedValue;

                if (habCtrl.altaHabitacion(nuevaHabitacion) == 1)
                {
                    MessageBox.Show("Se registró correctamente");
                    this.Close();
                }
                else {
                    MessageBox.Show("Error. No se registró");
                };
            }
            else
            {
                MessageBox.Show("Falta completar datos.");

            }
            
        }

        private bool tieneCamposObligatorios()
        {
            return pisoNumericBox.Value != 0 && numHabBox.Value != 0 && tipoHabitacionCombo.SelectedValue != null;
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            
        }
    }
}
