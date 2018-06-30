using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Control
{
    public class TipoHabitacion_Ctrl
    {

        public DataTable getAll()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand scTipos = new SqlCommand("CUATROGDD2018.SP_getAll_TiposHabitaciones", sqlConnection);
            DataTable dtTipos = new DataTable();
            sqlConnection.Open();
            dtTipos.Load(scTipos.ExecuteReader());
            sqlConnection.Close();
            return dtTipos;
        }
    }
}
