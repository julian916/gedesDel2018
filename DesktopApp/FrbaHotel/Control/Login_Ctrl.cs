using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Control
{
    class Login_Ctrl
    {

        public int iniciarLogin(string username, string pass)
        {
            string passHash = Encriptacion.getHashSha256(pass);
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_login", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_Login
            spCommand.Parameters.Add(new SqlParameter("@usuario", username));
            spCommand.Parameters.Add(new SqlParameter("@contras", passHash));
            spCommand.Parameters.Add("@loginCorrecto", SqlDbType.Bit).Direction = ParameterDirection.Output;
            spCommand.Parameters.Add("@idUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
            spCommand.Parameters.Add("@estaHabilitado", SqlDbType.Bit).Direction = ParameterDirection.Output;
            int idUsuario;
            spCommand.ExecuteNonQuery();
            Boolean loginCorrecto = Convert.ToBoolean(spCommand.Parameters["@loginCorrecto"].Value);
            Boolean estaHabilitado = Convert.ToBoolean(spCommand.Parameters["@estaHabilitado"].Value);

            if (spCommand.Parameters["@idUsuario"].Value == System.DBNull.Value)
            {
                throw new System.ArgumentException("No existe username ingresado. Comuniquese con el administrador para crear usuario");
            }
            else
            {
                idUsuario = (int)spCommand.Parameters["@idUsuario"].Value;
            }
            if (loginCorrecto)
            {
                //reinicio contador de intentos de login
                DatosSesion.reiniciarIntentosLogin();
            }
            else
            {
                if (estaHabilitado)
                {
                    DatosSesion.incrementarIntentoLogin();
                    if (DatosSesion.seSuperoIntentosLogin())
                    {
                        //Se bloquea el usuario
                        SqlCommand commandBloquear = new SqlCommand("CUATROGDD2018.SP_BloquerUsuario", connection);
                        commandBloquear.CommandType = CommandType.StoredProcedure;
                        commandBloquear.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                        commandBloquear.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Se superaron los intentos para iniciar sesion. Usuario bloqueado. Contacte con su Administrador para desbloquear la cuenta");
                    }
                    else
                    {
                        connection.Close();
                        throw new System.ArgumentException("Contraseña incorrecta. Reingrese contraseña");
                    }
                }
                else
                {
                    connection.Close();
                    throw new System.ArgumentException("Usuario bloqueado. Contacte con su Administrador para desbloquear la cuenta");
                }
            }
            return idUsuario;
        }
    }
}
