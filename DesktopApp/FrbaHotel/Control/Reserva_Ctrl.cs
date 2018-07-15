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
            spCommand.Parameters.Add(new SqlParameter("@idUsu", nuevaReserva.id_usuario_reserva));
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

        public void cancelarReserva(int id_reserva, string motivo, DateTime fechaInicio, int id_usuario)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_CancelarReserva", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_InsertarReservaXHabitacion
            spCommand.Parameters.Add(new SqlParameter("@idReserva", id_reserva));
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", id_usuario));
            spCommand.Parameters.Add(new SqlParameter("@fecha", fechaInicio));
            spCommand.Parameters.Add(new SqlParameter("@motivo", motivo));
            spCommand.ExecuteNonQuery();

            connection.Close();
        }

        public Reserva getReservaConID(int id_reserva)
        {
            Reserva reserva = new Reserva();
            
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_BuscaReservaPorId", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_BuscaReservaPorId
            spCommand.Parameters.Add(new SqlParameter("@idReserva", id_reserva));
            DataTable habTable = new DataTable();
            habTable.Load(spCommand.ExecuteReader());
            if (habTable != null && habTable.Rows != null)
            {
                foreach (DataRow row in habTable.Rows)
                {
                    
                    reserva.id_reserva = Convert.ToInt32(row["id_reserva"]);
                    reserva.id_persona = Convert.ToInt32(row["id_persona"]);
                    reserva.id_regimen = Convert.ToInt32(row["id_regimen"]);
                    reserva.id_estado_reserva = Convert.ToInt32(row["id_estado_reserva"]);
                    reserva.fecha_desde = Convert.ToDateTime(row["fecha_desde"]);
                    reserva.fecha_hasta = Convert.ToDateTime(row["fecha_hasta"]);
                    reserva.fecha_reserva = Convert.ToDateTime(row["fecha_reserva"]);
                    reserva.cantidad_noches = Convert.ToInt32(row["cantidad_noches"]);
                }
            }
            connection.Close();
            return reserva;
        }

        public List<Habitacion> getHabitacionesDeReserva(int cod_reserva)
        {
            List<Habitacion> habitacionesEncontrados = new List<Habitacion>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_BuscarHabitacionPorReserva", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_GetHabitacionesPorIDRes
            spCommand.Parameters.Add(new SqlParameter("@idReserva", cod_reserva));
            DataTable habTable = new DataTable();
            habTable.Load(spCommand.ExecuteReader());
            if (habTable != null && habTable.Rows != null)
            {
                foreach (DataRow row in habTable.Rows)
                {
                    Habitacion_Ctrl habCtrl = new Habitacion_Ctrl();
                    Habitacion habitacion = habCtrl.BuildHabitacion(row);                   
                    habitacionesEncontrados.Add(habitacion);
                }
            }
            connection.Close();
            return habitacionesEncontrados;
        }

        public void modificar_reserva(Reserva reservaConCambio, Reserva reservaPrevia)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_ModificarReserva", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_ModificarReserva


            spCommand.Parameters.Add(new SqlParameter("@idRegimen", reservaConCambio.id_regimen));
            spCommand.Parameters.Add(new SqlParameter("@fechaDesde", reservaConCambio.fecha_desde));
            spCommand.Parameters.Add(new SqlParameter("@fechaHasta", reservaConCambio.fecha_hasta));
            spCommand.Parameters.Add(new SqlParameter("@cantNoches", reservaConCambio.cantidad_noches));

            int filasAfectadas = (int)spCommand.ExecuteNonQuery();
            if (!(filasAfectadas > 0))
            {
                throw new System.ArgumentException("No se pudo modi la reserva, intente nuevamente");
            }
            //verifico las habitaciones de la reserva

            foreach (Habitacion nuevaHabitacion in reservaConCambio.habitacionesReserva)
            {
                if (!(reservaPrevia.habitacionesReserva.Exists(habPrevia => habPrevia.id_habitacion == nuevaHabitacion.id_habitacion)))
                {
                    this.nuevaHabitacion_X_Reserva(reservaConCambio.id_reserva, nuevaHabitacion.id_habitacion);

                }

            }
            foreach (Habitacion habPrevia in reservaPrevia.habitacionesReserva)
            {
                if (!(reservaConCambio.habitacionesReserva.Exists(habNueva => habNueva.id_habitacion == habPrevia.id_habitacion)))
                {
                    this.quitarHabitacion_X_Reserva(reservaConCambio.id_reserva, habPrevia.id_habitacion);
                }

            }
        }

        private void quitarHabitacion_X_Reserva(int id_reserva, int id_habitacion)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_QuitarReservaXHabitacion", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_InsertarReservaXHabitacion
            spCommand.Parameters.Add(new SqlParameter("@idReserva", id_reserva));
            spCommand.Parameters.Add(new SqlParameter("@idHabitacion", id_habitacion));
            spCommand.ExecuteNonQuery();

            connection.Close();
        }

        internal bool esReservaAptaParaCheckOut(Reserva reservaSeleccionada)
        {
            //Reserva con ingreso, en curso
            return reservaSeleccionada.id_estado_reserva == 7;
        }

        internal string getEstadoReserva(int id_estado_reserva)
        {

            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetEstadoReserva", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_BuscaReservaPorId
            spCommand.Parameters.Add(new SqlParameter("@idEstado", id_estado_reserva));
            string descripcionEstado = (string)spCommand.ExecuteScalar();
            connection.Close();
            return descripcionEstado;
        }

        internal int getIDHotelDeReserva(int id_reserva)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_DarIdHotelPorIdReserva", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_BuscaReservaPorId
            spCommand.Parameters.Add(new SqlParameter("@idReserva", id_reserva));
            int id_hotel = (int)spCommand.ExecuteScalar();
            connection.Close();
            return id_hotel;
        }
    }
}
