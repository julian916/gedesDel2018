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
    public partial class AltaHotelForm : Form
    {
        private int id_nuevoHotel;
        private int id_usuarioParaHotel;
        private int id_rolDeUsuario;
        private Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();

        public AltaHotelForm(int idUsuario, int idRol)
        {
            InitializeComponent();
            id_usuarioParaHotel = idUsuario;
            id_rolDeUsuario = idRol;
        }

        private void AltaHotelForm_Load(object sender, EventArgs e)
        {
            this.cargarRegimenesEstadia();
            this.cargarCantidadEstrellas();
            paisCombo.DataSource = new Paises().getAll();
        }

        private void cargarCantidadEstrellas()
        {
            cantidadEstreBox.Items.Add("1");
            cantidadEstreBox.Items.Add("2");
            cantidadEstreBox.Items.Add("3");
            cantidadEstreBox.Items.Add("4");
            cantidadEstreBox.Items.Add("5");
        }

        private void cargarRegimenesEstadia()
        {
            Regimenes_Ctrl ctrlRegimenes = new Regimenes_Ctrl();
            foreach (RegimenEstadia reg in ctrlRegimenes.getAllRegimenes())
            {
                regimenesCheckList.Items.Add(reg.descripcion);
            }
        }

        private void crearHotelButton_Click(object sender, EventArgs e)
        {
            if (this.tieneCamposObligatorios())
            {
                var nuevoHotel = new Hotel();
                nuevoHotel.nombre = nombreBox.Text;
                nuevoHotel.calle = calleBox.Text;
                nuevoHotel.nro_calle = int.Parse(nroCalleBoxNumeric.Value.ToString());
                nuevoHotel.ciudad = ciudadBox.Text;
                nuevoHotel.pais = paisCombo.SelectedText;
                nuevoHotel.cant_estrellas = int.Parse(cantidadEstreBox.Text.ToString());
                nuevoHotel.recarga_estrella = decimal.Parse(recargaEstrellaBox.Value.ToString());
                nuevoHotel.telefono = telBox.Text;
                nuevoHotel.email = emailBox.Text;
                id_nuevoHotel = hotelCtrl.insertar_Hotel(nuevoHotel, id_usuarioParaHotel, id_rolDeUsuario, regimenesCheckList.CheckedItems.Cast<string>().ToList());
            }
            else
            {
                MessageBox.Show("Falta completar datos.");

            }

        }

        private bool tieneCamposObligatorios()
        {
            return nombreBox.SelectedText != null && calleBox.SelectedText != null && ciudadBox.SelectedText != null && nroCalleBoxNumeric.Value != 0
                && cantidadEstreBox.SelectedItem != null && recargaEstrellaBox.Value !=0 && emailBox.SelectedText !=null 
                && regimenesCheckList.CheckedItems.Count != 0;
        }
        

    }
}
