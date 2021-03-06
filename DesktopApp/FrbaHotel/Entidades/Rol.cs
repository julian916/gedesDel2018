﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class Rol
    {
        public int id_rol { get; set; }
        public string nombre { get; set; }
        public bool habilitado { get; set; }
        public List<Funcionalidad> lista_funcionalidades { get; set; }

        public Rol()
        {
            lista_funcionalidades = new List<Funcionalidad>();
        }
    }
}
