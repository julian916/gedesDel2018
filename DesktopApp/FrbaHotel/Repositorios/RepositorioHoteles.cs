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
        public SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

        public RepositorioHoteles()
        {
            
        }

        public DataTable getAll()
        {
            if (this.sqlConnection.State != ConnectionState.Open)
            {
                try
                {
                    this.sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error open SqlConnection: " + ex.Message);
                }
            }

            SqlCommand scHoteles = new SqlCommand("sp_HotelesComboBox", sqlConnection);
            DataTable dtHotel = new DataTable();
            try
            {
                dtHotel.Load(scHoteles.ExecuteReader());
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("Error executingReader" + ex.Message);
            }
            sqlConnection.Close();
            return dtHotel;
        }
    }
}