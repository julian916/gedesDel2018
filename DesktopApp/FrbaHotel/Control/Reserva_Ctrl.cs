using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Control
{
    public class Reserva_Ctrl
    {

        internal int nuevaReserva(Reserva nuevaReserva)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_NuevaReserva", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_NuevaReserva
            
            spCommand.Parameters.Add(new SqlParameter("@idPersona", nuevaReserva.id_persona));
            spCommand.Parameters.Add(new SqlParameter("@idRegimen", nuevaReserva.id_regimen));
            spCommand.Parameters.Add(new SqlParameter("@fechaReserva", nuevaReserva.fecha_reserva));
            spCommand.Parameters.Add(new SqlParameter("@fechaDesde", nuevaReserva.fecha_desde));
            spCommand.Parameters.Add(new SqlParameter("@fechaHasta", nuevaReserva.fecha_hasta));
            spCommand.Parameters.Add(new SqlParameter("@cantNoches", nuevaReserva.cantidad_noches));
         
            int id_nuevaReserva = (int)spCommand.ExecuteScalar();
            if (!(id_nuevaReserva > 0))
            {
                throw new System.ArgumentException("No se pudo registrar la reserva, intente nuevamente");
            }
            return id_nuevaReserva;
        }

        internal void nuevaHabitacion_X_Reserva(int id_reserva, int id_habitacion)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_InsertarReservaXHabitacion", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_InsertarReservaXHabitacion
            spCommand.Parameters.Add(new SqlParameter("@idReserva", id_reserva));
            spCommand.Parameters.Add(new SqlParameter("@idHab", id_habitacion));
            spCommand.ExecuteNonQuery();
            
            connection.Close();
        }

        internal int validarIDReserva(int p)
        {
            throw new NotImplementedException();
        }

        internal void cancelarReserva(int id_reserva, string p1, DateTime dateTime, int p2)
        {
            throw new NotImplementedException();
        }

        internal Reserva buscaReserva_PorID(int p)
        {
            throw new NotImplementedException();
        }
    }
}
