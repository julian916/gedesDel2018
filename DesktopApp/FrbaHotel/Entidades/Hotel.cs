using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Hotel
    {
        public int id_hotel { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        public string pais { get; set; }
        public string calle { get; set; }
        public int nro_calle { get; set; }
        public int cant_estrellas { get; set; }
        public decimal recarga_estrella { get; set; }
        public int telefono { get; set; }
        public string email { get; set; }
        public DateTime fecha_creacion { get; set; }
        public List<RegimenEstadia> lista_Regimenes { get; set; }

        public Hotel()
        {
            lista_Regimenes = new List<RegimenEstadia>();
        }


    }
}
