using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string username{ get; set; }
        public string password { get; set; }
        public bool habilitado { get; set; }
        //un diccionario para los rolesXHotel, id_rol->lista de hoteles
        public Dictionary<int, List<Hotel>> dicRolesXHoteles { get; set; }

        public Usuario(){
            dicRolesXHoteles = new Dictionary<int, List<Hotel>>();
        }
    }
}
