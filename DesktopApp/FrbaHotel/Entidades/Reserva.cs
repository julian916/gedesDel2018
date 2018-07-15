using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Reserva
    {
        public int id_reserva { get; set; }
        public int id_persona { get; set; }
        public int id_regimen { get; set; }
        public int id_estado_reserva { get; set; }
        public DateTime fecha_reserva { get; set; }
        public DateTime fecha_desde { get; set; }
        public DateTime fecha_hasta { get; set; }
        public int cantidad_noches { get; set; }
        public int id_hotel { get; set; }
        public int id_usuario_reserva { get; set; }
        public List<Habitacion> habitacionesReserva { get; set; }

        public Reserva()
        {
            habitacionesReserva = new List<Habitacion>();
        }
    }
}
