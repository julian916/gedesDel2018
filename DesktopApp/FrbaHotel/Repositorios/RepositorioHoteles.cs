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
        public SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString();

        public RepositorioHoteles()
        {
            if (this.sqlConnection.State != ConnectionState.Open)
            {
                try
                {
                    this.sqlConnection.Open();
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error open SqlConnection: "+ ex.Message);
                }
            }
        }

        public DataTable getAll()
        {
            SqlCommand scHoteles = new SqlCommand("sp_HotelesComboBox", sqlConnection);
            DataTable dtHotel = new DataTable();
            try
            {
                dtHotel.Load(scHoteles.ExecuteReader());
            }
            catch (System.IO.IOException ex) {
                System.Diagnostics.Debug.WriteLine("Error executingReader" + ex.Message);
            }
            return dtHotel;
        }
    }
}