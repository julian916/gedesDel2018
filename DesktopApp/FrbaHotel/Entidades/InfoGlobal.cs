﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    static class InfoGlobal
    {
          //string de conexion
          public static string connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();

          // informacion importante para la sesion, variables globales
          public static int id_HotelSeleccionado { get; private set; }
          public static int id_usuarioSeleccionado { get; private set; }
          public static int id_rolSeleccionado { get; private set; }
          public static int id_usuarioGUEST = 2;
          public static int id_rolGUEST = 1;
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

    }
}
