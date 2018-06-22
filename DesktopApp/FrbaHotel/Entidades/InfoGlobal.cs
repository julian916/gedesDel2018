using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    static class InfoGlobal
    {
          // public get, and private set for strict access control
          public static int id_HotelSeleccionado { get; private set; }
          public static int id_usuarioSeleccionado { get; private set; }
          public static int id_rolSeleccionado { get; private set; }
          public static int id_usuarioGUEST = 2;

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

    }
}
