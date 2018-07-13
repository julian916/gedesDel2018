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
        List<RegimenEstadia> todosLosRegimenes = new List<RegimenEstadia>();
        private int id_usuarioParaHotel=DatosSesion.id_usuario;
        private int id_rolDeUsuario=DatosSesion.id_rol;
        private Hotel_Ctrl hotelCtrl = new Hotel_Ctrl();
        private Hotel hotelPrevio;
        private bool esModificacion=false;
        public AltaHotelForm()
        {
            InitializeComponent();
        }

        public AltaHotelForm(Hotel hotel)
        {
            InitializeComponent();
            this.hotelPrevio = hotel;
            esModificacion = true;
        }

        private void AltaHotelForm_Load(object sender, EventArgs e)
        {
            this.cargarRegimenesEstadia();
            this.cargarCantidadEstrellas();
            paisCombo.DataSource = new Paises().getAll();
            if (esModificacion) {
                nombreBox.Text = hotelPrevio.nombre;
                calleBox.Text = hotelPrevio.calle;
                nroCalleBoxNumeric.Value = hotelPrevio.nro_calle;
                ciudadBox.Text = hotelPrevio.ciudad;
                paisCombo.Text = hotelPrevio.pais;
                cantidadEstreBox.Text = hotelPrevio.cant_estrellas.ToString();
                recargaEstrellaBox.Value = hotelPrevio.cant_estrellas;
                telBox.Text = hotelPrevio.telefono;
                emailBox.Text = hotelPrevio.email;
            }
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
            todosLosRegimenes = ctrlRegimenes.getAllRegimenes();
            foreach (RegimenEstadia reg in todosLosRegimenes)
            {
                regimenesCheckList.Items.Add(reg.descripcion);
            }
        }

        private void crearHotelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.tieneCamposObligatorios()) {
                    throw new System.ArgumentException("Faltan campos obligatorios");
                }
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
                nuevoHotel.lista_Regimenes=this.getRegimenesSeleccionados(regimenesCheckList.CheckedItems.Cast<string>().ToList());
                if (esModificacion)
                {
                    hotelCtrl.modificar_Hotel(nuevoHotel, hotelPrevio);
                    MessageBox.Show("Se modificó correctamente el hotel.");
                }
                else
                {
                    hotelCtrl.insertar_Hotel(nuevoHotel);
                    MessageBox.Show("Se creó correctamente el nuevo hotel.");
                    
                }

            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }
        }

        private List<RegimenEstadia> getRegimenesSeleccionados(List<string> descripciones)
        {
            
            return (todosLosRegimenes.Where(reg => descripciones.Contains(reg.descripcion))).ToList();
        }

        private bool tieneCamposObligatorios()
        {
            return nombreBox.SelectedText != null && calleBox.SelectedText != null && ciudadBox.SelectedText != null && nroCalleBoxNumeric.Value != 0
                && cantidadEstreBox.SelectedItem != null && recargaEstrellaBox.Value !=0 && emailBox.SelectedText !=null 
                && regimenesCheckList.CheckedItems.Count != 0;
        }
        

    }
}
