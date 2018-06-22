using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    static class InfoGlobal
    {
          // informacion importante para la sesion, variables globales
          public static int id_HotelSeleccionado { get; private set; }
          public static int id_usuarioSeleccionado { get; private set; }
          public static int id_rolSeleccionado { get; private set; }
          public static int id_usuarioGUEST = 2;
          public static int intentos_Login { get; private set; }

          public static void Setid_HotelSeleccionado( int newInt)
          {
              id_HotelSeleccionado = newInt;
          }
          public static void Setid_usuarioSeleccionado(int newInt)
          {
              id_usuarioSeleccionado = newInt;
          }

          public static void Setid_rolSeleccionado(int newInt)
          {
              id_rolSeleccionado = newInt;
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
