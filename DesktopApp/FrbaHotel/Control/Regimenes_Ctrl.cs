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
    public partial class Regimenes_Ctrl
    {
        public BindingList<RegimenEstadia> getAllRegimenes()
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_getAllRegimenes", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            var lista_regimenes = new BindingList<RegimenEstadia>();
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
                    var regimen = BuildRegimen(row);
                    lista_regimenes.Add(regimen);
                }
            }

            return lista_regimenes;
        }

        private RegimenEstadia BuildRegimen(DataRow row)
        {
            RegimenEstadia regimen = new RegimenEstadia();
            regimen.id_regimen = int.Parse(row["id_regimen"].ToString());
            regimen.descripcion = Convert.ToString(row["descripcion"]);
            regimen.precio_base = decimal.Parse(row["precio_base"].ToString());
            return regimen;
        }

    }
}
