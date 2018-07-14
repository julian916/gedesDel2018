using FrbaHotel.Entidades;
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

        public List<Tipo_Habitacion> getAll()
        {

            var todosLosTiposHab = new List<Tipo_Habitacion>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetAll_TiposHabitaciones", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_GetAll_TiposHabitaciones

            DataTable tiposTable = new DataTable();
            tiposTable.Load(spCommand.ExecuteReader());
            if (tiposTable != null && tiposTable.Rows != null)
            {
                foreach (DataRow row in tiposTable.Rows)
                {
                    Tipo_Habitacion tipo = this.Build_TipoHabitacion(row);
                    todosLosTiposHab.Add(tipo);
                }
            }
            connection.Close();
            return todosLosTiposHab;

        }

        private Tipo_Habitacion Build_TipoHabitacion(DataRow row)
        {
            Tipo_Habitacion tipo = new Tipo_Habitacion();
            tipo.id_tipo_habitacion = Convert.ToInt32(row["id_tipo_habitacion"]);
            tipo.descripcion = Convert.ToString(row["descripcion"]);
            tipo.porcentual = Convert.ToInt32(row["porcentual"]);
            tipo.cant_Huespedes = Convert.ToInt32(row["cant_huespedes"]);
            return tipo;
        }

        internal Tipo_Habitacion getTipoHabitacion_ConID(int id_tipo)
        {
            Tipo_Habitacion tipoEncontrado = new Tipo_Habitacion();
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetTipoHabitacion_PorID", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Add(new SqlParameter("@idTipo", id_tipo));
            connection.Open();
            DataTable dtHotel = new DataTable();
            dtHotel.Load(spCommand.ExecuteReader());
            if (dtHotel != null && dtHotel.Rows != null)
            {
                foreach (DataRow row in dtHotel.Rows)
                {

                    tipoEncontrado = this.Build_TipoHabitacion(row);
                }
            }

            connection.Close();
            return tipoEncontrado;
        }
    }
}
