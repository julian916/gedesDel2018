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
    public class Habitacion_Ctrl
    {

        public void altaHabitacion(Habitacion nuevaHabitacion)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AltaHabitacion", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@idTipoHabitacion", nuevaHabitacion.id_tipo_habitacion));
            spCommand.Parameters.Add(new SqlParameter("@idHotel", nuevaHabitacion.id_hotel));
            spCommand.Parameters.Add(new SqlParameter("@piso", nuevaHabitacion.piso));
            spCommand.Parameters.Add(new SqlParameter("@frente", nuevaHabitacion.frente));
            spCommand.Parameters.Add(new SqlParameter("@nroHab", nuevaHabitacion.nro_habitacion));
            spCommand.Parameters.Add(new SqlParameter("@comodidades", nuevaHabitacion.comodidades));
            
            spCommand.ExecuteNonQuery();
            
        }

        public string inhabilitarHabilitarHabitacion(Habitacion habSeleccionada)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_HabilitarDeshabilitarHab", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@idHabitacion", habSeleccionada.id_habitacion));
            string mensaje = (string)spCommand.ExecuteScalar();
            return mensaje;
        }

        public List<Habitacion> getHabitacionesDeHotel(int id_hotel)
        {
            SqlConnection sqlConnection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetAllHabitacion_PorHotel", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Add(new SqlParameter("@idHotel", id_hotel));
            sqlConnection.Open();
            var lista_Habitaciones = new List<Habitacion>();
            DataTable resultTable = new DataTable();
            resultTable.Load(spCommand.ExecuteReader());

            if (resultTable != null && resultTable.Rows != null)
            {
                foreach (DataRow row in resultTable.Rows)
                {
                    var habitacion = BuildHabitacion(row);
                    lista_Habitaciones.Add(habitacion);
                }
            }

            return lista_Habitaciones;
        }

        private Habitacion BuildHabitacion(DataRow row)
        {
            Habitacion habitacion = new Habitacion();
            habitacion.id_hotel = Convert.ToInt32(row["id_habitacion"]);
            habitacion.nro_habitacion = Convert.ToInt32(row["nro_habitacion"]);
            habitacion.piso = Convert.ToInt32(row["piso"]);
            habitacion.frente = Convert.ToString(row["frente"]);
            habitacion.comodidades = Convert.ToString(row["comodidades"]);
            habitacion.id_tipo_habitacion = Convert.ToInt32(row["id_tipo_habitacion"]);
            habitacion.id_hotel = Convert.ToInt32(row["id_hotel"]);
            habitacion.habilitado = Convert.ToBoolean(row["habilitado"]);
            return habitacion;
        }

        public string stringFrenteTo(bool frente)
        {
            string stringFrente;
            if (frente)
            {
                stringFrente = "S";
            }
            else
            {
                stringFrente = "N";
            }
            return stringFrente;
        }

        public void modificarHabitacion(Habitacion nuevaHabitacion)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AltaHabitacion", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@idHab", nuevaHabitacion.id_tipo_habitacion));
            spCommand.Parameters.Add(new SqlParameter("@piso", nuevaHabitacion.piso));
            spCommand.Parameters.Add(new SqlParameter("@nroHab", nuevaHabitacion.nro_habitacion));
            spCommand.Parameters.Add(new SqlParameter("@frente", nuevaHabitacion.frente));
            spCommand.Parameters.Add(new SqlParameter("@comodidades", nuevaHabitacion.comodidades));

            spCommand.ExecuteNonQuery();
        }
    }
}
