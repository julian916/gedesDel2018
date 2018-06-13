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
    public class RepositorioRoles
    {
        public RepositorioRoles()
        {
        }

        public DataTable ObtenerRoles() {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand scRol = new SqlCommand("sp_RolesComboBox", con);
            SqlCommand scHoteles = new SqlCommand("sp_HotelesComboBox", con);
            DataTable dtRol = new DataTable();
            DataTable dtHotel = new DataTable();
            dtRol.Load(scRol.ExecuteReader());
            
            return dtRol;
        }
    }
}
