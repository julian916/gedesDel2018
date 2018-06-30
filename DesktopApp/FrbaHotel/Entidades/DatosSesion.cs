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
        public static string username { get; set; }
        public static string password { get; set; } //encriptada
        public static int id_rol { get; set; }
        public static int id_hotel = 0; //, para los guest
        public static BindingList<Funcionalidad> funcionalidades { get; set; }
        public static bool sesion_iniciada = false;
        public static int intentos_Login { get; private set; }

        public static void cerrar_sesion()
        {
            sesion_iniciada = false;
            id_hotel = 0;
            funcionalidades.Clear();
            password = "";
            id_rol = 0;
            id_usuario = 0;
        }

        public static void iniciar_sesion(int iduser, string pass, int idRol, int idHotel, BindingList<Funcionalidad> listaF,string user)
        {
            id_usuario = iduser;
            password = pass;
            id_rol = idRol;
            id_hotel = idHotel;
            funcionalidades = listaF;
            sesion_iniciada = true;
            username = user;
        }

        public static bool esGuest()
        {
            return id_usuario == InfoGlobal.id_usuarioGUEST;
        }

        public static void reiniciarIntentosLogin()
        {
            intentos_Login = 0;
        }

        public static void incrementarIntentoLogin()
        {
            intentos_Login = intentos_Login + 1;
        }

        public static bool seSuperoIntentosLogin()
        {
            return intentos_Login == 3;
        }
    }
}
