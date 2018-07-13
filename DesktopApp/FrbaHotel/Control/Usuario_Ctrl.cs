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
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_Cambiar_Password", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_NuevoRegimenXHotel
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            spCommand.Parameters.Add(new SqlParameter("@newPassHash", newPassHash));
            spCommand.ExecuteNonQuery();
            connection.Close();
        }

        public List<Usuario> buscarUserPorUsername(string username, int id_hotel)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetUserPorUsername", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_GetUserPorUsername
            spCommand.Parameters.Add(new SqlParameter("@username", username));
            spCommand.Parameters.Add(new SqlParameter("@idHotel", id_hotel));
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

        public void ingresar_NuevoUsuario(Usuario userActual)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AltaUsuario", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Clear();
            //agrego parametros al SP_AltaUsuario
            spCommand.Parameters.Add(new SqlParameter("@usuario", userActual.username));
            spCommand.Parameters.Add(new SqlParameter("@password", userActual.password));
            connection.Open();
            int idUsuario = (int)spCommand.ExecuteScalar();     
            
            foreach(KeyValuePair<int, List<Hotel>> entrada in userActual.dicRolesXHoteles){
                foreach (Hotel hotelParaRol in entrada.Value){
                    spCommand = new SqlCommand("CUATROGDD2018.SP_AltaHotel_X_Rol_Usuario", connection);
                    spCommand.CommandType = CommandType.StoredProcedure;
                    spCommand.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
                    spCommand.Parameters.Add(new SqlParameter("@idRol", entrada.Key));
                    spCommand.Parameters.Add(new SqlParameter("@idHotel", hotelParaRol.id_hotel));
                    if (spCommand.ExecuteNonQuery()<=0) {
                        throw new System.ArgumentException("No se pudo registrar el usuario,intente nuevamente");
                    };     
                }
            }

            connection.Close();
        }

        public void modificar_Usuario(Usuario userActual,Usuario usuarioConCambios)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_ModificarUsuario", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_ModificarUsuario
            spCommand.Parameters.Add(new SqlParameter("@user", usuarioConCambios.username));
            spCommand.Parameters.Add(new SqlParameter("@pass", usuarioConCambios.password));
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", userActual.id_usuario));
            int filasAfectadas = spCommand.ExecuteNonQuery();
            if (filasAfectadas > 0) {

                //GESTIONO LOS ROLES Y HOTELES

                foreach( KeyValuePair<int, List<Hotel>> idRol_Hoteles in usuarioConCambios.dicRolesXHoteles){
                    //Si en ambos diccionario está el rol, entonces se modificaron los hoteles
                    if (userActual.dicRolesXHoteles.Keys.Contains(idRol_Hoteles.Key))
                    {
                        //verifico si se dieron baja en el permiso de hotel para un rol
                        List<Hotel> hotelesPrevios = new List<Hotel>();
                        if (userActual.dicRolesXHoteles.TryGetValue(idRol_Hoteles.Key, out hotelesPrevios))
                        {
                            foreach (Hotel hotelPrevio in hotelesPrevios)
                            {
                                if (!(idRol_Hoteles.Value.Contains(hotelPrevio)))
                                {
                                    this.bajaHotel_A_Rol_De_Usuario(userActual.id_usuario, hotelPrevio.id_hotel, idRol_Hoteles.Key);
                                }

                            }
                            foreach (Hotel hotelCambios in idRol_Hoteles.Value)
                            {
                                if (!(hotelesPrevios.Contains(hotelCambios)))
                                {
                                    this.altaHotel_A_Rol_De_Usuario(userActual.id_usuario, hotelCambios.id_hotel, idRol_Hoteles.Key);
                                }

                            }
                        }
                    }
                  
                }

            }
            
            connection.Close();
        }

        private void altaHotel_A_Rol_De_Usuario(int idUsuario, int idRol, int idHotel)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AltaHotel_X_Rol_Usuario", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            spCommand.Parameters.Add(new SqlParameter("@idRol", idRol));
            spCommand.Parameters.Add(new SqlParameter("@idHotel", idHotel));
            spCommand.ExecuteNonQuery();
            connection.Close();
        }

        private void bajaHotel_A_Rol_De_Usuario(int idUsuario, int idRol, int idHotel)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_BajaHotel_X_Rol_Usuario", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
            spCommand.Parameters.Add(new SqlParameter("@idRol", idRol));
            spCommand.Parameters.Add(new SqlParameter("@idHotel", idHotel));
            spCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void validarUsername(string username)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_VerificarUsuario", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_VerificarUsuario
            spCommand.Parameters.Add(new SqlParameter("@usuario", username));
            bool esValido =Convert.ToBoolean(spCommand.ExecuteScalar());
            connection.Close();
            if (!esValido) {
                throw new System.ArgumentException("Ya existe el usuario ingresado. Reingreselo");
            }
        }


        public void desasignarRolAUser(int id_rol,Usuario userConCambios)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_DesasignarRol_IDUsuario", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_DesasignarRol_IDUsuario
            spCommand.Parameters.Add(new SqlParameter("@idRol", id_rol));
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", userConCambios.id_usuario));
            spCommand.ExecuteNonQuery();
            connection.Close();
            
        }

        public List<Usuario> getAllUsers_IdHotel(int id_hotel)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetUsers_IdHotel", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Add(new SqlParameter("@idHotel", id_hotel));
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
    }
}
