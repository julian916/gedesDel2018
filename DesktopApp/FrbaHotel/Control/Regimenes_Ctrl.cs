using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Control
{
    public partial class Regimenes_Ctrl
    {
        public List<RegimenEstadia> getAllRegimenes()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_getAllRegimenes", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            var lista_regimenes = new List<RegimenEstadia>();
            DataTable regimenesTable = new DataTable();
           regimenesTable.Load(spCommand.ExecuteReader());
           if (regimenesTable != null && regimenesTable.Rows != null)
           {
               foreach (DataRow row in regimenesTable.Rows)
                {
                    var regimen = BuildRegimen(row);
                    lista_regimenes.Add(regimen);
                }
            }

            return lista_regimenes;
        }

        private RegimenEstadia BuildRegimen(DataRow row)
        {
            RegimenEstadia regimen = new RegimenEstadia();
            regimen.id_regimen = int.Parse(row["id_regimen"].ToString());
            regimen.descripcion = Convert.ToString(row["descripcion"]);
            regimen.precio_base = decimal.Parse(row["precio_base"].ToString());
            return regimen;
        }


        public List<RegimenEstadia> getRegimenes_IDHotel(int id_hotel)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetRegimenPorHotel_DeIdHotel", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            spCommand.Parameters.Add(new SqlParameter("@idHotel", id_hotel));
            var lista_regimenes = new List<RegimenEstadia>();
            DataTable regimenesTable = new DataTable();
            regimenesTable.Load(spCommand.ExecuteReader());
            if (regimenesTable != null && regimenesTable.Rows != null)
            {
                foreach (DataRow row in regimenesTable.Rows)
                {
                    var regimen = BuildRegimen(row);
                    lista_regimenes.Add(regimen);
                }
            }

            return lista_regimenes;
        }
    }
}
