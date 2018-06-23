using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    class DatosSesion
    {
        public static int id_usuario { get; set; }
        public static string password { get; set; } //hasheada
        public static int id_rol { get; set; }
        public static int id_hotel = 0; //por default 0, para los guest
        public static BindingList<Funcionalidad> funcionalidades { get; set; }
        public static bool sesion_iniciada = false;


        public static void cerrar_sesion()
        {
            sesion_iniciada = false;
            id_hotel = 0;
            funcionalidades.Clear();
            password = "";
            id_rol = 0;
            id_usuario = 0;
        }

        public static void iniciar_sesion(int user, string pass, int idRol, int idHotel, BindingList<Funcionalidad> listaF)
        {
            id_usuario = user;
            password = pass;
            id_rol = idRol;
            id_hotel = idHotel;
            funcionalidades = listaF;
            sesion_iniciada = true;
        }

        public static bool esGuest()
        {
            return id_usuario == InfoGlobal.id_usuarioGUEST;
        }
    
    }
}
