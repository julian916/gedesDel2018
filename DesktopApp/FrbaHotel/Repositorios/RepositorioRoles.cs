using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                    MessageBox.Show("Error al conectarse con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            try
            {
                dtRol.Load(scRol.ExecuteReader());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error executingReader" + ex.Message);
                MessageBox.Show("Error al obtener los roles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.sqlConnection.Close();
            return dtRol;
        }
    }
}
