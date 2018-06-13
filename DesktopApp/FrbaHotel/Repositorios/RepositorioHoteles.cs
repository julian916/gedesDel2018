using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaHotel.Repositorios
{
    public class RepositorioHoteles
    {
        public SqlConnection sqlConnection = null;

        public RepositorioHoteles(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
            if (this.sqlConnection.State != ConnectionState.Open)
            {
                this.sqlConnection.Open();
            }
        }

        public DataTable getAll()
        {
            SqlCommand scHoteles = new SqlCommand("sp_HotelesComboBox", sqlConnection);
            DataTable dtHotel = new DataTable();
            dtHotel.Load(scHoteles.ExecuteReader());
            return dtHotel;
        }
    }
}