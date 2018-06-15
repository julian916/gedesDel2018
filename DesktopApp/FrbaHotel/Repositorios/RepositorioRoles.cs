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
        public SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());

        public RepositorioRoles()
        {

        }

        public DataTable getAll()
        {
            SqlCommand scRol = new SqlCommand("sp_RolesComboBox", sqlConnection);
            DataTable dtRol = new DataTable();
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

            try
            {
                dtRol.Load(scRol.ExecuteReader());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error executingReader" + ex.Message);
            }
            this.sqlConnection.Close();
            return dtRol;
        }
    }
}
