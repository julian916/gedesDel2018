using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Habitacion
    {
        public int id_habitacion { get; set; }
        public int nro_habitacion { get; set; }
        public int piso { get; set; }
        public string frente { get; set; }
        public int id_tipo_habitacion { get; set; }
        public bool habilitado { get; set; }
        public string comodidades { get; set; }
        public decimal id_hotel { get; set; }

    }
}
