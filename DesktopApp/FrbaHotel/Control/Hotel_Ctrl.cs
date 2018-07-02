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
    public class Hotel_Ctrl
    {
       public int insertar_Hotel(Hotel nuevoHotel,int id_usuarioParaHotel,int id_rol, List<String> descripcionesRegimenes){
           
           SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AltaHotel", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_altaHotel
           spCommand.Parameters.Add(new SqlParameter("@idUsuario", id_usuarioParaHotel));
           spCommand.Parameters.Add(new SqlParameter("@idRol", id_rol));
           spCommand.Parameters.Add(new SqlParameter("@nombre", nuevoHotel.nombre));
           spCommand.Parameters.Add(new SqlParameter("@calle", nuevoHotel.calle));
           spCommand.Parameters.Add(new SqlParameter("@recarga_estrellas", nuevoHotel.recarga_estrella));
           spCommand.Parameters.Add(new SqlParameter("@telefono", nuevoHotel.telefono));
           spCommand.Parameters.Add(new SqlParameter("@email", nuevoHotel.email));
           spCommand.Parameters.Add(new SqlParameter("@nrocalle", nuevoHotel.nro_calle));
           spCommand.Parameters.Add(new SqlParameter("@cant_estrellas", nuevoHotel.cant_estrellas));
           spCommand.Parameters.Add(new SqlParameter("@ciudad", nuevoHotel.ciudad));
           spCommand.Parameters.Add(new SqlParameter("@pais", nuevoHotel.pais));
           spCommand.Parameters.Add(new SqlParameter("@fecha_creacion", nuevoHotel.fecha_creacion));
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
           int id_nuevoHotel = 0;
           if (resultTable != null && resultTable.Rows != null)
           {
               foreach (DataRow row in resultTable.Rows)
               {
                   id_nuevoHotel = int.Parse(row["id_hotel"].ToString());        
               }
           }
           connection.Close();
           this.agregarRegimenes(id_nuevoHotel, descripcionesRegimenes);
           return id_nuevoHotel;
       }

       private void agregarRegimenes(int id_nuevoHotel, List<string> descripcionesRegimenes)
       {
           SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_NuevoRegimenXHotel", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();

           foreach (string descripcion in descripcionesRegimenes) {
               spCommand.Parameters.Clear();
               //agrego parametros al SP_NuevoRegimenXHotel
               spCommand.Parameters.Add(new SqlParameter("@idHotel", id_nuevoHotel));
               spCommand.Parameters.Add(new SqlParameter("@descripcion", descripcion));
               spCommand.ExecuteNonQuery();
           }

           connection.Close();
       }


       public Hotel getHotelPorID(int id_hotel_logueado)
       {
           Hotel hotelEncontrado = new Hotel();
           SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetHotelPorID", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           spCommand.Parameters.Add(new SqlParameter("@idHotel", id_hotel_logueado));
           connection.Open();
           DataTable dtHotel = new DataTable();
           dtHotel.Load(spCommand.ExecuteReader());
           if (dtHotel != null && dtHotel.Rows != null)
           {
               foreach (DataRow row in dtHotel.Rows)
               {

                   hotelEncontrado.id_hotel = int.Parse(row["id_hotel"].ToString());
                   hotelEncontrado.nombre = Convert.ToString(row["nombre"]);
                   hotelEncontrado.ciudad = Convert.ToString(row["ciudad"]);
                   hotelEncontrado.calle = Convert.ToString(row["calle"]);
                   hotelEncontrado.nro_calle = int.Parse(row["nro_calle"].ToString());
                   hotelEncontrado.cant_estrellas = int.Parse(row["cant_estrellas"].ToString());
                   hotelEncontrado.recarga_estrella = decimal.Parse(row["recarga_estrellas"].ToString());
                   hotelEncontrado.email = Convert.ToString(row["email"]);
                   hotelEncontrado.telefono = Convert.ToString(row["telefono"]);
                   hotelEncontrado.pais = Convert.ToString(row["pais"]);
                   if (row["fecha_creacion"] != DBNull.Value) {
                       hotelEncontrado.fecha_creacion = Convert.ToDateTime(row["fecha_creacion"]);
                   }

               }
           }
           
           connection.Close();
           return hotelEncontrado;
       }

       internal List<Hotel> obtenerHotelesPorID_IDRol(int id_usuario, int id_RolSeleccionado)
       {
           var hotelesAsignados = new List<Hotel>();
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetHotelesPorID_IDRol", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_GetHotelesPorID_IDRol
           spCommand.Parameters.Add(new SqlParameter("@idUsuario", id_usuario));
           spCommand.Parameters.Add(new SqlParameter("@idRol", id_RolSeleccionado));

           DataTable hotelesTable = new DataTable();
           hotelesTable.Load(spCommand.ExecuteReader());
           if (hotelesTable != null && hotelesTable.Rows != null)
           {
               foreach (DataRow row in hotelesTable.Rows)
               {
                   Hotel hotelAsignado = new Hotel();
                   hotelAsignado.id_hotel = int.Parse(row["id_hotel"].ToString());
                   hotelAsignado.nombre = Convert.ToString(row["nombre"]);
                   hotelesAsignados.Add(hotelAsignado);
               }
           }

           return hotelesAsignados;
       }
    }
}
