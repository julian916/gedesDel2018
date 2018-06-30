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

        public int altaHabitacion(Entidades.Habitacion nuevaHabitacion)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AltaHabitacion", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@idTipoHabitacion", nuevaHabitacion.id_tipo_habitacion));
            spCommand.Parameters.Add(new SqlParameter("@idHotel", nuevaHabitacion.id_hotel));
            spCommand.Parameters.Add(new SqlParameter("@piso", nuevaHabitacion.piso));
            spCommand.Parameters.Add(new SqlParameter("@frente", this.asStringFrente(nuevaHabitacion.frente)));
            spCommand.Parameters.Add(new SqlParameter("@nroHab", nuevaHabitacion.nro_habitacion));
            spCommand.Parameters.Add(new SqlParameter("@comodidades", nuevaHabitacion.comodidades));
            
            int filasAfectadas = spCommand.ExecuteNonQuery();
            return filasAfectadas;
        }

        private string asStringFrente(bool frente)
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
    }
}
