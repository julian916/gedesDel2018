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
    }
}
