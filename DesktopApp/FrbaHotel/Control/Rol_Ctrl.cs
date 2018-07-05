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
            DataTable nuevoRolTable = new DataTable();
            nuevoRolTable.Load(spCommand.ExecuteReader());
            int id_nuevoRol = 0;
            if (nuevoRolTable != null && nuevoRolTable.Rows != null)
            {
                foreach (DataRow row in nuevoRolTable.Rows)
                {
                    id_nuevoRol = int.Parse(row["id_rol"].ToString());
                }
            }
            if (id_nuevoRol!=0){
                connection.Close();
                throw new System.ArgumentException("Error al crear nuevo Rol. Reintentelo");
            }
            connection.Close();
            this.agregarFuncionalidesARol(id_nuevoRol, nuevoRol.lista_funcionalidades);
            
        }

        private void agregarFuncionalidesARol(int id_nuevoRol, List<Funcionalidad> funcionalidades)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_NuevoFuncionalidadXRol", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();

            foreach (Funcionalidad func in funcionalidades)
            {
                spCommand.Parameters.Clear();
                //agrego parametros al SP_NuevoFuncionalidadXRol
                spCommand.Parameters.Add(new SqlParameter("@idHotel", id_nuevoRol));
                spCommand.Parameters.Add(new SqlParameter("@idFuncionalidad", func.id_funcionalidad));
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
            nuevoRol.nombre = Convert.ToString(row["nonbre"]);
            nuevoRol.habilitado = Convert.ToBoolean(row["habilitado"]);

            return nuevoRol;
        }
    }
}
