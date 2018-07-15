using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrbaHotel.Entidades;
using System.ComponentModel;

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

            SqlCommand sqlCommand = new SqlCommand("CUATROGDD2018.sp_ObtenerCallesAPartirDeCiudad", this.sqlConnection);
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

        public DataTable getTipoHabitaciones()
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

            SqlCommand scCiudades = new SqlCommand("CUATROGDD2018.SP_ObtenerTipoHabitaciones", sqlConnection);
            DataTable dtTipoHabitaciones = new DataTable();
            try
            {
                dtTipoHabitaciones.Load(scCiudades.ExecuteReader());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error executingReader: " + ex.Message);
                MessageBox.Show("Error al obtener las ciudades", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            sqlConnection.Close();
            return dtTipoHabitaciones;
        }

        public DataTable obtenerHabitacionesDisponibles(int idHotel, DateTime fechaDesde, DateTime fechaHasta, int idRegimen)
        {
            throw new NotImplementedException();
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

            SqlCommand scCiudades = new SqlCommand("CUATROGDD2018.sp_ObtenerCiudades", sqlConnection);
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

        internal BindingList<Habitacion> GetAllHabitacionDisponiblesEnFechaYCantidad(object iD_Hotel_global, object codigo_tipo, DateTime dateTime1, DateTime dateTime2)
        {
            throw new NotImplementedException();
        }

        public BindingList<Habitacion> ObtenerHabitacionesDisponibles(int ID_Hotel_Habitaciones, int tipo_hab, DateTime fecha_ini, DateTime fecha_fin)
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
            SqlCommand scHabitaciones = new SqlCommand("CUATROGDD2018.sp_ObtenerCiudades", sqlConnection);
            DataTable dtCiudades = new DataTable();
            
            //var resultado = SqlDataAccess.ExecuteDataTableQuery(ConfigurationManager.ConnectionStrings["StringConexion"].ToString(),
            //    "LOS_NULL.GETALLHABITACIONPORHOTELPORFECHAYCANTIDAD", SqlDataAccessArgs.CreateWith("@ID_HOTEL", ID_Hotel_Habitaciones)
            //    .And("@ID_TIPO_HAB", tipo_hab).And("@FECHA_INI", fecha_ini).And("@FECHA_FIN", fecha_fin).Arguments);
            var lista_habitaciones = new BindingList<Habitacion>();
            DataTable resultado = null;
            if (resultado != null && resultado.Rows != null)
            {
                foreach (DataRow row in resultado.Rows)
                {
                    var habitacion = new Habitacion();
                    habitacion.id_habitacion = int.Parse(row["ID_Habitacion"].ToString());
                    habitacion.id_hotel = int.Parse(row["ID_Hotel"].ToString());
                    habitacion.id_tipo_habitacion = int.Parse(row["Codigo_Tipo"].ToString());
                    habitacion.nro_habitacion = int.Parse(row["Numero"].ToString());
                    habitacion.piso = int.Parse(row["Piso"].ToString());
                    habitacion.habilitado = Boolean.Parse(row["Baja_Logica"].ToString());
                    habitacion.frente = (row["Frente"].ToString());

                    lista_habitaciones.Add(habitacion);
                }
            }
            return lista_habitaciones;
        }



    }
}