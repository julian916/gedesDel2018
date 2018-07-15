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
    public class Estadia_Ctrl
    {
        internal void generarEstadia(Estadia nuevaEstadia)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_CheckInOutEstadia", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_NuevaReserva

            spCommand.Parameters.Add(new SqlParameter("@id", nuevaEstadia.id_reserva));
            spCommand.Parameters.Add(new SqlParameter("@idUsu", nuevaEstadia.id_usuario_checkIn));
            spCommand.Parameters.Add(new SqlParameter("@fecha", nuevaEstadia.fecha_inicio));
            

            int id_nuevaEstadia = (int)spCommand.ExecuteScalar();
            if (!(id_nuevaEstadia > 0))
            {
                throw new System.ArgumentException("No se pudo registrar la estadía, intente nuevamente");
            }
            foreach (Persona huesped in nuevaEstadia.huespedes) {
                SqlCommand spCom = new SqlCommand("CUATROGDD2018.SP_InsertEstadiaXPersona", connection);
                spCom.CommandType = CommandType.StoredProcedure;
                connection.Open();
                spCom.Parameters.Clear();
                //agrego parametros al SP_InsertEstadiaXPersona

                spCom.Parameters.Add(new SqlParameter("@idEstadia", id_nuevaEstadia));
                spCom.Parameters.Add(new SqlParameter("@idPersona", huesped.id_persona));
                spCom.ExecuteNonQuery();
            }

            connection.Close();
        }

        public Estadia getEstadia_IDReserva(int id_reserva)
        {
            Estadia estadia = new Estadia();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_DarEstadiaPorCodReserva", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Add(new SqlParameter("@idReserva", id_reserva));
            connection.Open();
            DataTable dtHotel = new DataTable();
            dtHotel.Load(spCommand.ExecuteReader());
            if (dtHotel != null && dtHotel.Rows != null)
            {
                foreach (DataRow row in dtHotel.Rows)
                {

                    estadia = this.BuildEstadia(row);
                }
            }

            connection.Close();
            return estadia;
        }

        private Estadia BuildEstadia(DataRow row)
        {
            Estadia estadia = new Estadia();
            estadia.id_estadia = Convert.ToInt32(row["id_estadia"].ToString());
            estadia.fecha_inicio = Convert.ToDateTime(row["fecha_inicio"]);
            estadia.cant_noches = Convert.ToInt32(row["cant_noches"]);
            estadia.id_usuario_checkIn=Convert.ToInt32(row["id_usuario_checkIn"]);
            estadia.id_usuario_checkOut=Convert.ToInt32(row["id_usuario_checkOut"]);
            estadia.id_reserva = Convert.ToInt32(row["id_reserva"]);

            return estadia;
        }

       
        public void cerrarEstadia(Estadia estadiaCheckOUT)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_CheckInOutEstadia", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_NuevaReserva

            spCommand.Parameters.Add(new SqlParameter("@id", estadiaCheckOUT.id_estadia));
            spCommand.Parameters.Add(new SqlParameter("@idUsu", estadiaCheckOUT.id_usuario_checkOut));
            DateTime fechaHasta = estadiaCheckOUT.fecha_inicio.AddDays(estadiaCheckOUT.cant_noches);
            spCommand.Parameters.Add(new SqlParameter("@fecha", fechaHasta));


            int filasAfectadas = spCommand.ExecuteNonQuery();
            if (!(filasAfectadas > 0))
            {
                throw new System.ArgumentException("No se pudo realizar el check out de estadía, intente nuevamente");
            }
            foreach (Consumible consumible in estadiaCheckOUT.consumibles)
            {
                SqlCommand spCom = new SqlCommand("CUATROGDD2018.SP_InsertarConsubleXEstadia", connection);
                spCom.CommandType = CommandType.StoredProcedure;
                connection.Open();
                spCom.Parameters.Clear();
                //agrego parametros al SP_InsertarConsumibleXEstadia

                spCom.Parameters.Add(new SqlParameter("@idEstadia", estadiaCheckOUT.id_estadia));
                spCom.Parameters.Add(new SqlParameter("@idConsumible", consumible.id_consumible));
                spCom.Parameters.Add(new SqlParameter("@cantidad", consumible.cantidad));
                spCom.ExecuteNonQuery();
            }

            connection.Close();
        }

        internal List<Forma_de_Pago> getAllMetodosPagos()
        {
            var metodosPago = new List<Forma_de_Pago>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetAllMediosDePagos", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_GetAllHoteles

            DataTable metodosTable = new DataTable();
            metodosTable.Load(spCommand.ExecuteReader());
            if (metodosTable != null && metodosTable.Rows != null)
            {
                foreach (DataRow row in metodosTable.Rows)
                {
                    Forma_de_Pago forma = new Forma_de_Pago();
                    forma.id_forma_depago = Convert.ToInt32(row["id_forma_depago"].ToString());
                    forma.descripcion = Convert.ToString(row["descripcion"]);
                    metodosPago.Add(forma);
                }
            }
            connection.Close();
            return metodosPago;
        }

        internal decimal getMontoTotalEstadia(int id_estadia)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.CalcularMontoTotalFactura", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_NuevaReserva

            spCommand.Parameters.Add(new SqlParameter("@idEstadia", id_estadia));
            decimal montoTotal = (decimal)spCommand.ExecuteScalar();

            connection.Close();

            return montoTotal;

        }

        internal int facturarEstadia(Factura facturaFinal)
        {
            throw new NotImplementedException();
        }

        internal int getPuntosObtenidos(int id_estadia)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetPuntosObtenidos", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_GetPuntosObtenidos

            spCommand.Parameters.Add(new SqlParameter("@idEstadia", id_estadia));
            int puntos = (int)spCommand.ExecuteScalar();

            connection.Close();

            return puntos;
        }
    }
}
