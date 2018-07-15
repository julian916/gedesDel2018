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
    public class Rol_Ctrl
    {
        Funcionalidad_Ctrl funcCtrl= new Funcionalidad_Ctrl();
        public List<Rol> obtenerRolesPorID(int id_usuario)
        {
            var rolesAsignados = new List<Rol>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetRolesPorID", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_GetRolesPorID
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", id_usuario)); 
 
            DataTable rolesTable = new DataTable();
            rolesTable.Load(spCommand.ExecuteReader());
            if (rolesTable != null && rolesTable.Rows != null)
            {
                foreach (DataRow row in rolesTable.Rows)
                {
                    Rol rolAsignado = new Rol();
                    rolAsignado.id_rol = int.Parse(row["id_rol"].ToString());
                    rolAsignado.nombre = Convert.ToString(row["nombre"]);
                    rolAsignado.habilitado = (bool)(row["habilitado"]);
                    rolesAsignados.Add(rolAsignado);
                }
            }

            return rolesAsignados;
        }

        public void altaRol(Rol nuevoRol)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AltaRol", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_AltaRol
            spCommand.Parameters.Add(new SqlParameter("@nombre", nuevoRol.nombre));
            int idRol = (int)spCommand.ExecuteScalar();
            if (idRol==-1){
                connection.Close();
                throw new System.ArgumentException("Existe un rol con el mismo nombre. Ingrese uno nuevo");
            }
            connection.Close();
            this.agregarFuncionalidesARol(idRol, nuevoRol.lista_funcionalidades);
            
        }

        private void agregarFuncionalidesARol(int id_nuevoRol, List<Funcionalidad> funcionalidades)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AgregarFuncionalidadRol", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();

            foreach (Funcionalidad func in funcionalidades)
            {
                spCommand.Parameters.Clear();
                //agrego parametros al SP_AgregarFuncionalidadRol
                spCommand.Parameters.Add(new SqlParameter("@idRol", id_nuevoRol));
                spCommand.Parameters.Add(new SqlParameter("@idFun", func.id_funcionalidad));
                spCommand.ExecuteNonQuery();
            }

            connection.Close();
        }

        public List<Rol> getAllValidos()
        {
            SqlConnection sqlConnection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetAllRolesValidos", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            var lista_Roles = new List<Rol>();
            DataTable resultTable = new DataTable();
            resultTable.Load(spCommand.ExecuteReader());

            if (resultTable != null && resultTable.Rows != null)
            {
                foreach (DataRow row in resultTable.Rows)
                {
                    var funcionalidad = BuildRol(row);
                    lista_Roles.Add(funcionalidad);
                }
            }

            return lista_Roles;
        }

        private Rol BuildRol(DataRow row)
        {
            Rol nuevoRol = new Rol();
            nuevoRol.id_rol = Convert.ToInt32(row["id_rol"]);
            nuevoRol.nombre = Convert.ToString(row["nombre"]);
            nuevoRol.habilitado = Convert.ToBoolean(row["habilitado"]);

            return nuevoRol;
        }



        public List<Rol> getNuevosRoles_User(Usuario userConCambios)
        {
            List<Rol> todosRoles = this.getAllValidos();
            List<int> idrolesUsuarios = userConCambios.dicRolesXHoteles.Keys.ToList();

           //retorno los roles que no tiene asignado el usuario,
            return (todosRoles.Where(rol => !(idrolesUsuarios.Contains(rol.id_rol))).ToList());
            
        }

        internal List<Rol> getAllRoles()
        {
            SqlConnection sqlConnection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetAllRoles", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            var lista_Roles = new List<Rol>();
            DataTable resultTable = new DataTable();
            resultTable.Load(spCommand.ExecuteReader());

            if (resultTable != null && resultTable.Rows != null)
            {
                foreach (DataRow row in resultTable.Rows)
                {
                    var rol = BuildRol(row);
                    List<Funcionalidad>funcRol = funcCtrl.funcionalidadesXRol(rol.id_rol);
                    rol.lista_funcionalidades = funcRol;
                    lista_Roles.Add(rol);

                }
            }

            return lista_Roles;
        }

        public void modificarRol(Rol nuevoRol, Rol rolAModificar)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_ModificarRol", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_ModificarUsuario
            spCommand.Parameters.Add(new SqlParameter("@idRol", rolAModificar.id_rol));
            spCommand.Parameters.Add(new SqlParameter("@nombre", nuevoRol.nombre));
            spCommand.Parameters.Add(new SqlParameter("@habilitado", nuevoRol.habilitado));
            int filasAfectadas = spCommand.ExecuteNonQuery();
            if (filasAfectadas > 0)
            {
                foreach (Funcionalidad funcPrevia in rolAModificar.lista_funcionalidades)
                {
                    if (!(nuevoRol.lista_funcionalidades.Contains(funcPrevia)))
                    {
                        this.quitarFuncARol(rolAModificar.id_rol, funcPrevia.id_funcionalidad);
                    }

                }
                foreach (Funcionalidad nuevaFunc in nuevoRol.lista_funcionalidades)
                {
                    if (!(rolAModificar.lista_funcionalidades.Contains(nuevaFunc)))
                    {
                        this.agregarFuncARol(rolAModificar.id_rol, nuevaFunc.id_funcionalidad);
                    }

                }
            }
            connection.Close();
        }

        private void agregarFuncARol(int id_rol, int id_func)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AgregarFuncionalidadRol", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Add(new SqlParameter("@idRol", id_rol));
            spCommand.Parameters.Add(new SqlParameter("@idFun", id_func));            
            spCommand.ExecuteNonQuery();
            connection.Close();
        }

        private void quitarFuncARol(int id_rol, int id_func)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_EliminarFuncionalidadXRol", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Add(new SqlParameter("@idRol", id_rol));
            spCommand.Parameters.Add(new SqlParameter("@idFuncionalidad", id_func));
            spCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
