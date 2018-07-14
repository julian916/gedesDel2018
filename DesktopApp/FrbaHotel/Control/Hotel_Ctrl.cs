using FrbaHotel.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Control
{
    public class Hotel_Ctrl
    {
        int id_usuarioParaHotel = DatosSesion.id_usuario;
        int id_rol = DatosSesion.id_rol;
        Regimenes_Ctrl regimenCtrl = new Regimenes_Ctrl();
        Habitacion_Ctrl habCtrl = new Habitacion_Ctrl();
       public void insertar_Hotel(Hotel nuevoHotel){
           
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_Alta_Hotel", connection);
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

           spCommand.Parameters.Add(new SqlParameter("@fecha_creacion", Convert.ToDateTime(ConfigurationManager.AppSettings["FechaSistema"])));
           
           int id_nuevoHotel = (int)spCommand.ExecuteScalar();
           if (id_nuevoHotel>0)
           {
               foreach (RegimenEstadia regimen in nuevoHotel.lista_Regimenes)
               {
                   this.agregarRegimenAHotel(id_nuevoHotel, regimen.id_regimen);
               }
           }
           else {
               throw new System.ArgumentException("No se pudo registrar el hotel, intente nuevamente");
           }
           
       }

       public Hotel getHotelPorID(int id_hotel_logueado)
       {
           Hotel hotelEncontrado = new Hotel();
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
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

                   hotelEncontrado = this.BuidHotel(row);
               }
           }
           
           connection.Close();
           return hotelEncontrado;
       }

       public List<Hotel> obtenerHotelesPorID_IDRol(int id_usuario, int id_RolSeleccionado)
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
           connection.Close();
           return hotelesAsignados;
       }

       public List<Hotel> getAllHoteles()
       {
           var todosLosHoteles = new List<Hotel>();
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetAllHoteles", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_GetAllHoteles

           DataTable hotelesTable = new DataTable();
           hotelesTable.Load(spCommand.ExecuteReader());
           if (hotelesTable != null && hotelesTable.Rows != null)
           {
               foreach (DataRow row in hotelesTable.Rows)
               {
                   Hotel hotel = this.BuidHotel(row);
                   todosLosHoteles.Add(hotel);
               }
           }
           connection.Close();
           return todosLosHoteles;
       }

       private Hotel BuidHotel(DataRow row)
       {
           Hotel hotel = new Hotel();
           hotel.id_hotel = Convert.ToInt32(row["id_hotel"].ToString());
           hotel.nombre = Convert.ToString(row["nombre"]);
           hotel.calle = Convert.ToString(row["calle"]);
           hotel.cant_estrellas = Convert.ToInt32(row["cant_estrellas"]);
           hotel.ciudad = Convert.ToString(row["ciudad"]);
           hotel.email = Convert.ToString(row["email"]);
           hotel.nro_calle = Convert.ToInt32(row["nro_calle"]);
           hotel.pais = Convert.ToString(row["pais"]);
           hotel.recarga_estrella = Convert.ToInt32(row["recarga_estrellas"]);
           hotel.telefono = Convert.ToInt32(row["telefono"]);
           if (row["fecha_creacion"] != DBNull.Value)
           {
               hotel.fecha_creacion = Convert.ToDateTime(row["fecha_creacion"]);
           }

           return hotel;
       }

       public string obtenerNombreHotel(int id_hotel_logueado)
       {
           Hotel hotel = this.getHotelPorID(id_hotel_logueado);
           return hotel.nombre;
       }

       public List<string> getAllCiudadesDeHoteles(int id_Usuario)
       {
           List<string> stringCiudades = new List<string>();
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_DarHotelesCiudades", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_DarHotelesCiudades
           spCommand.Parameters.Add(new SqlParameter("@idUsu", id_Usuario));
           DataTable hotelesTable = new DataTable();
           hotelesTable.Load(spCommand.ExecuteReader());
           if (hotelesTable != null && hotelesTable.Rows != null)
           {
               foreach (DataRow row in hotelesTable.Rows)
               {
                   stringCiudades.Add(Convert.ToString(row["ciudad"]));
               }
           }
           connection.Close();
           return stringCiudades;
       }

       internal List<string> getAllPaisesDeHoteles(int id_Usuario)
       {
           List<string> stringPaises = new List<string>();
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_DarHotelesPaises", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_DarHotelesPaises
           spCommand.Parameters.Add(new SqlParameter("@idUsu", id_Usuario));
           DataTable hotelesTable = new DataTable();
           hotelesTable.Load(spCommand.ExecuteReader());
           if (hotelesTable != null && hotelesTable.Rows != null)
           {
               foreach (DataRow row in hotelesTable.Rows)
               {
                   stringPaises.Add(Convert.ToString(row["pais"]));
               }
           }
           connection.Close();
           return stringPaises;
       }

       internal List<Hotel> getHotelesFiltrados(int id_Usuario, string ciudad, string nombre, string pais, int cantidadDias)
       {
           var hotelesFiltrados = new List<Hotel>();
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_FiltrarHotelesPorCampos", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_FiltrarHotelesPorCampos
           spCommand.Parameters.Add(new SqlParameter("@idUsu", id_Usuario));
           spCommand.Parameters.Add(new SqlParameter("@cantEstrellas", cantidadDias));
           spCommand.Parameters.Add(new SqlParameter("@ciudad", ciudad));
           spCommand.Parameters.Add(new SqlParameter("@pais", pais));
           spCommand.Parameters.Add(new SqlParameter("@nombre", nombre));
           DataTable hotelesTable = new DataTable();
           hotelesTable.Load(spCommand.ExecuteReader());
           if (hotelesTable != null && hotelesTable.Rows != null)
           {
               foreach (DataRow row in hotelesTable.Rows)
               {
                   Hotel hotel = this.BuidHotel(row);
                   List<RegimenEstadia> regimenesDeHotel = regimenCtrl.getRegimenes_IDHotel(hotel.id_hotel);
                   hotel.lista_Regimenes = regimenesDeHotel;
                   hotelesFiltrados.Add(hotel);
               }
           }
           connection.Close();
           return hotelesFiltrados;
       }

       public string habInhHotel(int id_hotel_DarBaja, Nullable<System.DateTime> fechaInicio, int diasCierre, string comentarios)
       {
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_CierreTempHotel", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           spCommand.Parameters.Clear();
           spCommand.Parameters.Add(new SqlParameter("@id_hotel", id_hotel_DarBaja));
           spCommand.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
           spCommand.Parameters.Add(new SqlParameter("@diasCierre", diasCierre));
           spCommand.Parameters.Add(new SqlParameter("@comentario", comentarios));
           connection.Open();
           string mensaje = (string)spCommand.ExecuteScalar();
           connection.Close();
           return mensaje;
       }

       public void modificar_Hotel(Hotel nuevoHotel, Hotel hotelPrevio)
       {
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_ModificarHotel", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_ModificarHotel
           spCommand.Parameters.Add(new SqlParameter("@id_hotel", nuevoHotel.id_hotel));
           spCommand.Parameters.Add(new SqlParameter("@nombre", nuevoHotel.nombre));
           spCommand.Parameters.Add(new SqlParameter("@pais", nuevoHotel.pais));
           spCommand.Parameters.Add(new SqlParameter("@ciudad", nuevoHotel.ciudad));
           spCommand.Parameters.Add(new SqlParameter("@calle", nuevoHotel.calle));
           spCommand.Parameters.Add(new SqlParameter("@nro_calle", nuevoHotel.nro_calle));
           spCommand.Parameters.Add(new SqlParameter("@cant_estrellas", nuevoHotel.cant_estrellas));
           spCommand.Parameters.Add(new SqlParameter("@recarga_estrellas", nuevoHotel.recarga_estrella));
           spCommand.Parameters.Add(new SqlParameter("@email", nuevoHotel.email));
           spCommand.Parameters.Add(new SqlParameter("@telefono", nuevoHotel.telefono));
           if (spCommand.ExecuteNonQuery() >= 1) { 
                //modifico los regimenes asociados al hotel
               foreach (RegimenEstadia nuevoRegimen in nuevoHotel.lista_Regimenes)
               {
                   if (!(hotelPrevio.lista_Regimenes.Exists(regPrevio => regPrevio.id_regimen == nuevoRegimen.id_regimen)))
                   {
                       this.agregarRegimenAHotel(hotelPrevio.id_hotel, nuevoRegimen.id_regimen);
                       
                   }

               }
               foreach (RegimenEstadia regimenPrevio in hotelPrevio.lista_Regimenes)
               {
                   if (!(nuevoHotel.lista_Regimenes.Exists(nuevoReg => nuevoReg.id_regimen == regimenPrevio.id_regimen)))
                   {
                       this.quitarRegimenAHotel(hotelPrevio.id_hotel, regimenPrevio.id_regimen);
                   }

               }
           
           }
       }

       private void quitarRegimenAHotel(int id_hotel, int id_regimen)
       {
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_QuitarRegimenDeHotel", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_QuitarRegimenDeHotel
           spCommand.Parameters.Add(new SqlParameter("@idHotel", id_hotel));
           spCommand.Parameters.Add(new SqlParameter("@idRegimen", id_regimen));
           spCommand.ExecuteNonQuery();
           connection.Close();
       }

       private void agregarRegimenAHotel(int id_hotel, int id_regimen)
       {
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_InsertarNuevoRegimenXHotel", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
            //agrego parametros al SP_NuevoRegimenXHotel
           spCommand.Parameters.Add(new SqlParameter("@idHotel", id_hotel));
           spCommand.Parameters.Add(new SqlParameter("@idRegimen", id_regimen));
            spCommand.ExecuteNonQuery();
           connection.Close();
       }

       public List<Habitacion> obtenerHabitacionesDisponibles(int idHotel, DateTime fechaDesde, DateTime fechaHasta, int id_tipoHab)
       {
           List<Habitacion> habitacionesEncontrados = new List<Habitacion>();
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_DarHabitacionesDisponibles", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_NuevoRegimenXHotel
           spCommand.Parameters.Add(new SqlParameter("@idhotel", idHotel));
           spCommand.Parameters.Add(new SqlParameter("@idTipoHab", id_tipoHab));
           spCommand.Parameters.Add(new SqlParameter("@fechaInicio", fechaDesde));
           spCommand.Parameters.Add(new SqlParameter("@fechaFin", fechaHasta));
           DataTable habTable = new DataTable();
           habTable.Load(spCommand.ExecuteReader());
           if (habTable != null && habTable.Rows != null)
           {
               foreach (DataRow row in habTable.Rows)
               {
                   Habitacion habitacion = new Habitacion();
                   habitacion.id_habitacion = Convert.ToInt32(row["id_habitacion"]);
                   habitacion.nro_habitacion = Convert.ToInt32(row["nro_habitacion"]);
                   habitacion.piso = Convert.ToInt32(row["piso"]);
                   habitacion.frente = Convert.ToString(row["ubicacion"]);
                   habitacion.comodidades = Convert.ToString(row["comodidades"]);
                   habitacion.id_tipo_habitacion = Convert.ToInt32(row["id_tipo_habitacion"]);
                   habitacion.desc_tipo_habitacion = Convert.ToString(row["tipo_habitacion"]);
                   habitacion.id_hotel = idHotel;
                   habitacionesEncontrados.Add(habitacion);
               }
           }
           connection.Close();
           return habitacionesEncontrados;
       }

       public decimal getCostoPorDiaHabitacion(int hotelReserva, int id_regimenSeleccionado, int id_tipoHab)
       {
           SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
           SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_DarCostoHabitacion", connection);
           spCommand.CommandType = CommandType.StoredProcedure;
           connection.Open();
           spCommand.Parameters.Clear();
           //agrego parametros al SP_DarCostoHabitacion
           spCommand.Parameters.Add(new SqlParameter("@idHotel", hotelReserva));
           spCommand.Parameters.Add(new SqlParameter("@idTipoHab", id_tipoHab));
           spCommand.Parameters.Add(new SqlParameter("@idRegimen", id_regimenSeleccionado));
           decimal costoPorDia = (decimal)spCommand.ExecuteScalar();

           connection.Close();
           return costoPorDia;
       }
    }
}
