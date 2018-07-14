using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Factura
    {
        public int nro_factura { get; set; }
        public DateTime fecha { get; set; }
        public decimal precio_total { get; set; }
        public int puntosObtenidos { get; set; }
        public int id_estadia { get; set; }
        public int id_persona { get; set; }
        public int id_forma_depago { get; set; }
        List<Item_Factura> itemFacturas { get; set; }

        public Factura() { 
        
        }
    }
}
