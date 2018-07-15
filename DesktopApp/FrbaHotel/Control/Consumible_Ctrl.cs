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
    public class Consumible_Ctrl
    {
        public List<Consumible> getAllConsumibles()
        {
            var todosLosConsumibles = new List<Consumible>();
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetAllConsumibles", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_GetAllConsumibles

            DataTable hotelesTable = new DataTable();
            hotelesTable.Load(spCommand.ExecuteReader());
            if (hotelesTable != null && hotelesTable.Rows != null)
            {
                foreach (DataRow row in hotelesTable.Rows)
                {
                    Consumible consum = this.BuildConsumible(row);
                    todosLosConsumibles.Add(consum);
                }
            }
            connection.Close();
            return todosLosConsumibles;
        }

        private Consumible BuildConsumible(DataRow row)
        {
            Consumible consumible = new Consumible();
            consumible.id_consumible = Convert.ToInt32(row["id_consumible"].ToString());
            consumible.descripcion = Convert.ToString(row["descripcion"]);
            consumible.precio = Convert.ToInt32(row["precio"]);
            
            return consumible;
        }
    }
}
