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
                    MessageBox.Show("Error al conectase con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            SqlCommand scHoteles = new SqlCommand("CUATROGDD2018.sp_HotelesComboBox", sqlConnection);
            DataTable dtHotel = new DataTable();
            try
            {
                dtHotel.Load(scHoteles.ExecuteReader());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error executingReader: " + ex.Message);
                MessageBox.Show("Error al obtener los hoteles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            sqlConnection.Close();
            return dtHotel;
        }

        public DataTable getCalles(string ciudad)
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
                    MessageBox.Show("Error al conectase con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            SqlCommand sqlCommand = new SqlCommand("sp_ObtenerCallesAPartirDeCiudad", this.sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@ciudad", ciudad));
            DataTable dtCalles = new DataTable();

            try
            {
                dtCalles.Load(sqlCommand.ExecuteReader());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error executingReader: " + ex.Message);
                MessageBox.Show("Error al obtener las calles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            sqlConnection.Close();
            return dtCalles;
        }

        public DataTable getCiudades()
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
                    MessageBox.Show("Error al conectase con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }

            SqlCommand scCiudades = new SqlCommand("sp_ObtenerCiudades", sqlConnection);
            DataTable dtCiudades = new DataTable();
            try
            {
                dtCiudades.Load(scCiudades.ExecuteReader());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error executingReader: " + ex.Message);
                MessageBox.Show("Error al obtener las ciudades", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            sqlConnection.Close();
            return dtCiudades;
        }

        public DataTable obtenerHabitacionesDisponibles(int idHotel, DateTime fechaDesde, DateTime fechaHasta, int idRegimen)
        {

            try
            {
                this.sqlConnection.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error open SqlConnection: " + ex.Message);
                MessageBox.Show("Error al conectase con la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            SqlCommand sqlCommand = new SqlCommand("CUATROGDD2018.SP_DarHabitacionesDisponibles", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add(new SqlParameter("@id_hotel", idHotel));
            sqlCommand.Parameters.Add(new SqlParameter("@fechaDesde", fechaDesde));
            sqlCommand.Parameters.Add(new SqlParameter("@fechaHasta", fechaHasta));
            sqlCommand.Parameters.Add(new SqlParameter("@idRegimen", idRegimen));
            
            DataTable dtHabitaciones = new DataTable();
            try
            {
                dtHabitaciones.Load(sqlCommand.ExecuteReader());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error executingReader: " + ex.Message);
                MessageBox.Show("Error al obtener las ciudades", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            sqlConnection.Close();

            return dtHabitaciones;
            //throw new NotImplementedException();
            //TODO: Hacer consulta de disponibilidad
            //Devolver booleano que indique si esta disponible el pedido de reserva

        }

    }
}