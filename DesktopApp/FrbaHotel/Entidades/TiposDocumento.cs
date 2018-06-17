using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Entidades
{
    public class TiposDocumentos
    {
        List<string> listTiposDocumentos = new List<string>();
        
        public TiposDocumentos()
        {
            listTiposDocumentos.Add("DNI");
            listTiposDocumentos.Add("LE");
            listTiposDocumentos.Add("Carnet Ext");
            listTiposDocumentos.Add("Pasaporte");
            listTiposDocumentos.Add("Otros");
          
        }

        public List<string> getAll(){
            
          return listTiposDocumentos;
        }
    }
}
