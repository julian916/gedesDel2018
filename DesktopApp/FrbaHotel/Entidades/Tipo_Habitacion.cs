using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Tipo_Habitacion
    {
        public int id_tipo_habitacion { get; set; }
        public string descripcion { get; set; }
        public decimal porcentual { get; set; }
        public int cant_Huespedes { get; set; }
    }
}
