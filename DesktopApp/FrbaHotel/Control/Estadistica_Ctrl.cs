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
    class Estadistica_Ctrl
    {
        public int getMenorAnioActividad()
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetMenorAnioActividad", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            int menorAnio = (int)spCommand.ExecuteScalar();
            connection.Close();
            return menorAnio;
        }

        internal DataTable getTopHotelesMasReservasCanceladas(int anio, int trimestre)
        {
            var todosLosHoteles = new List<Hotel>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_TopHotelesConReservasCanceladas", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_TopHotelesConReservasCanceladas
            spCommand.Parameters.Add(new SqlParameter("@anio", anio));
            spCommand.Parameters.Add(new SqlParameter("@trimestre", trimestre));
            DataTable resultTable = new DataTable();
            resultTable.Load(spCommand.ExecuteReader());
            return resultTable;
        }

        internal DataTable getTopHotelesMasConsumiblesFact(int anio, int trimestre)
        {
            var todosLosHoteles = new List<Hotel>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_TopHotelesConsumiblesFacturados", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_TopHotelesConsumiblesFacturados
            spCommand.Parameters.Add(new SqlParameter("@anio", anio));
            spCommand.Parameters.Add(new SqlParameter("@trimestre", trimestre));

            DataTable resultTable = new DataTable();
            resultTable.Load(spCommand.ExecuteReader());
            return resultTable;
        }

        internal DataTable getTopHotelesMasDiasSinServ(int anio, int trimestre)
        {
            var todosLosHoteles = new List<Hotel>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_TopHotelesDiasSinServ", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_TopHotelesDiasSinServ
            spCommand.Parameters.Add(new SqlParameter("@anio", anio));
            spCommand.Parameters.Add(new SqlParameter("@trimestre", trimestre));

            DataTable resultTable = new DataTable();
            resultTable.Load(spCommand.ExecuteReader());
            return resultTable;
        }

        internal DataTable getTopHabitacionSolicitadas(int anio, int trimestre)
        {
            var todosLosHoteles = new List<Hotel>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_TopHabitacionOcupadas", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_TopHabitacionOcupadas
            spCommand.Parameters.Add(new SqlParameter("@anio", anio));
            spCommand.Parameters.Add(new SqlParameter("@trimestre", trimestre));
            DataTable resultTable = new DataTable();
            resultTable.Load(spCommand.ExecuteReader());
            return resultTable;
        }

        internal DataTable getTopClientesConMasPuntos(int anio, int trimestre)
        {
            var todosLosHoteles = new List<Hotel>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_TopClientesConMasPuntos", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_TopClientesConMasPuntos
            spCommand.Parameters.Add(new SqlParameter("@anio", anio));
            spCommand.Parameters.Add(new SqlParameter("@trimestre", trimestre));
            DataTable resultTable = new DataTable();
            resultTable.Load(spCommand.ExecuteReader());
            return resultTable;
        }
    }
}
