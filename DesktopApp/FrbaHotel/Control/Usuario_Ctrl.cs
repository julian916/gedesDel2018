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
    public class Usuario_Ctrl
    {

        public void cambiarPassword(string newPassHash, int idUsuario)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_Cambiar_Password ", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_NuevoRegimenXHotel
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            spCommand.Parameters.Add(new SqlParameter("@newPassHash", newPassHash));
            spCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
