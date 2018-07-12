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

        internal DataTable getTopHotelesMasReservasCanceladas()
        {
            throw new NotImplementedException();
        }

        internal DataTable getTopHotelesMasConsumiblesFact()
        {
            throw new NotImplementedException();
        }

        internal DataTable getTopHotelesMasDiasSinServ()
        {
            throw new NotImplementedException();
        }

        internal DataTable getTopHabitacionSolicitadas()
        {
            throw new NotImplementedException();
        }

        internal DataTable getTopClientesConMasPuntos()
        {
            throw new NotImplementedException();
        }
    }
}
