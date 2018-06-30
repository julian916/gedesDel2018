using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class RegimenEstadia
    {
        public int id_regimen { get; set; }
        public string descripcion { get; set; }
        public decimal precio_base { get; set; }
        public bool habilitado { get; set; }
    }
}
