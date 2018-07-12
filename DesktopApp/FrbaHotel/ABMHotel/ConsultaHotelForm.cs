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

namespace FrbaHotel.ABMHotel
{
    public partial class ConsultaHotelForm : Form
    {
        Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
        int id_Usuario = DatosSesion.id_usuario;
        public ConsultaHotelForm()
        {
            InitializeComponent();
        }

        private void ConsultaHotelForm_Load(object sender, EventArgs e)
        {
            updateBtn.Enabled = false;
            deleteBtn.Enabled = false;
            List<string> lista_ciudades_hotel = hotelCtrl.getAllCiudadesDeHoteles(id_Usuario);
            foreach (string ciudad in lista_ciudades_hotel)
            {
                ciudadComboBox.Items.Add(ciudad.Trim());
            }
            List<string> lista_paises_hotel = hotelCtrl.getAllPaisesDeHoteles(id_Usuario);
            foreach (string pais in lista_paises_hotel)
            {
                paisComboBox.Items.Add(pais.Trim());
            }
        }

        private void filtrarBtn_Click(object sender, EventArgs e)
        {
            List<Hotel> hotelesEncontrados = hotelCtrl.getHotelesFiltrados(id_Usuario,ciudadComboBox.Text.ToString(), nombreBox.Text, (string)paisComboBox.Text.ToString(), (int)estrellasBox.Value);
            dataGridHoteles.DataSource = hotelesEncontrados;
            updateBtn.Enabled = true;
            deleteBtn.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridHoteles.DataSource != null && dataGridHoteles.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridHoteles.SelectedRows)
                {
                    Hotel hotel = (Hotel)row.DataBoundItem;
                    if (hotel.habilitado)
                    {
                        BajaHotelForm bajaForm = new BajaHotelForm(hotel.id_hotel);
                        bajaForm.ShowDialog();
                    }
                    else {
                        hotelCtrl.habInhHotel(hotel.id_hotel,null, 0, "");
                        MessageBox.Show("Se habilitó correctamente el hotel");
                    }
                    
                }
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se seleccionó hotel para la baja. Seleccione una fila de la tabla");
            }
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            AltaHotelForm newForm = new AltaHotelForm();
            newForm.ShowDialog();
            this.Dispose();
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dataGridHoteles.DataSource != null && dataGridHoteles.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridHoteles.SelectedRows)
                {
                    Hotel hotel = (Hotel)row.DataBoundItem;
                    AltaHotelForm editForm = new AltaHotelForm(hotel);
                    editForm.ShowDialog();
                }
                this.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("No se seleccionó hotel para modificar. Seleccione una fila de la tabla");
            }
        }

    }
}
