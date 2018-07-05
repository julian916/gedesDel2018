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

        public List<Usuario> buscarUserPorUsername(string username)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetUserPorUsername", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_GetUserPorUsername
            spCommand.Parameters.Add(new SqlParameter("@username", username));

            List<Usuario> usuariosEncontrados = new List<Usuario>();
            DataTable usuariosTable = new DataTable();
            usuariosTable.Load(spCommand.ExecuteReader());
            if (usuariosTable != null && usuariosTable.Rows != null)
            {
                foreach (DataRow row in usuariosTable.Rows)
                {
                    Usuario usuario = this.BuildUsuario(row);
                    usuariosEncontrados.Add(usuario);
                }
            }

            return usuariosEncontrados;
        }

        private Usuario BuildUsuario(DataRow row)
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.id_usuario = Convert.ToInt32(row["id_usuario"]);
            nuevoUsuario.username = Convert.ToString(row["username"]);
            nuevoUsuario.password = Convert.ToString(row["password"]);
            nuevoUsuario.habilitado = Convert.ToBoolean(row["habilitado"]);
            return nuevoUsuario;
        }

        public List<Usuario> getAllUsers()
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetAllUsers", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();

            List<Usuario> usuariosEncontrados = new List<Usuario>();
            DataTable usuariosTable = new DataTable();
            usuariosTable.Load(spCommand.ExecuteReader());
            if (usuariosTable != null && usuariosTable.Rows != null)
            {
                foreach (DataRow row in usuariosTable.Rows)
                {
                    Usuario usuario = this.BuildUsuario(row);
                    usuariosEncontrados.Add(usuario);
                }
            }

            return usuariosEncontrados;
        }

        public void nuevoRolYHoteles(int id_RolSeleccionado, List<Hotel> hotelesSeleccionados,Usuario usuario)
        {
            usuario.dicRolesXHoteles.Add(id_RolSeleccionado, hotelesSeleccionados);

        }

        internal void ingresar_NuevoUsuario(Usuario userActual)
        {
            throw new NotImplementedException();
        }
    }
}
