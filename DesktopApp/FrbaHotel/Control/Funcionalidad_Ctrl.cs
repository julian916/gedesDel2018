using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Control
{
    public partial class Funcionalidad_Ctrl
    {
        public BindingList<Funcionalidad> funcionalidadesXRol(int id_rol)
        {
            var funcionalidades = new BindingList<Funcionalidad>();
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_Funcionalidad_X_Rol", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_Login
            spCommand.Parameters.Add(new SqlParameter("@idRol", id_rol));

            SqlDataReader dataReader = spCommand.ExecuteReader();
            DataTable resultTable = new DataTable();
            if (dataReader.HasRows)
            {
                int count = 0;
                while (dataReader.Read())
                {
                    DataRow row = resultTable.NewRow();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (count == 0)
                            resultTable.Columns.Add(dataReader.GetName(i));

                        row[i] = dataReader[i];
                    }
                    resultTable.Rows.Add(row);
                    count++;
                }
            }
            dataReader.Close();

            if (resultTable != null && resultTable.Rows != null)
            {
                foreach (DataRow row in resultTable.Rows)
                {
                    var func = BuildFuncionalidad(row);
                    funcionalidades.Add(func);
                }
            }

            return funcionalidades;
        }

        public Funcionalidad BuildFuncionalidad(DataRow row)
        {
            Funcionalidad func = new Funcionalidad();
            func.id_funcionalidad = Convert.ToInt32(row["id_funcionalidad"]);
            func.descripcion_funcionalidad = Convert.ToString(row["descripcion"]);
            return func;
        }
    }
}
