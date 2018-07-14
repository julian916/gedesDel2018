using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Estadia
    {
        public int id_estadia { get; set; }
        public DateTime fecha_inicio { get; set; }
        public int cant_noches { get; set; }
        public int id_usuario_checkIn { get; set; }
        public int id_usuario_checkOut { get; set; }
        public int id_habitacion { get; set; }
        public int id_reserva { get; set; }
        public List<Persona> huespedes { get; set; }

        public Estadia()
        {
            huespedes = new List<Persona>();
        }

    }
}
