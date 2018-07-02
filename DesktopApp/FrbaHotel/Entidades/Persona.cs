using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Persona
    {
        public int id_persona { get; set; }
        public string tipo_documento { get; set; }
        public int nro_documento { get; set; }
        public string email { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int telefono { get; set; }
        public string nacionalidad { get; set; }
        public string direccion { get; set; }
        public int nro_calle { get; set; }
        public int piso { get; set; }
        public string departamento { get; set; }
        public string localidad { get; set; }
        public string pais { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string estado { get; set; }
        public int id_usuario { get; set; }
    }
}
