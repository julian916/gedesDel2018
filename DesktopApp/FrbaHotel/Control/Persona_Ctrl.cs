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
    public class Persona_Ctrl
    {
        public int altaPersona(Persona nuevaPersona, int idUsuario)
        {
            this.validarDatosPersona(nuevaPersona.tipo_documento,nuevaPersona.nro_documento,nuevaPersona.email,0);      
            SqlConnection sqlConnection = new SqlConnection(InfoGlobal.connectionString);
            DataTable dataPersonas = this.generarTablaDatosPersona(nuevaPersona, idUsuario);
           

            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_AltaPersona", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            spCommand.Parameters.Clear();

            SqlParameter parametroDatosPersona = new SqlParameter();
            parametroDatosPersona.ParameterName = "@datosIngresadosPersona";
            parametroDatosPersona.SqlDbType = System.Data.SqlDbType.Structured;
            parametroDatosPersona.Value = dataPersonas;
            spCommand.Parameters.Add(parametroDatosPersona);

            int filasAfectadas = spCommand.ExecuteNonQuery();
            return filasAfectadas;
        }

        private DataTable generarTablaDatosPersona(Persona nuevaPersona, int idUsuario)
        {
            DataTable dataPersonas = new DataTable("datosPersona");

            dataPersonas.Columns.Add("tipo_documento", typeof(string));
            dataPersonas.Columns.Add("nro_documento", typeof(Int32));
            dataPersonas.Columns.Add("email", typeof(string));
            dataPersonas.Columns.Add("nombre", typeof(string));
            dataPersonas.Columns.Add("apellido", typeof(string));
            dataPersonas.Columns.Add("telefono", typeof(Int64));
            dataPersonas.Columns.Add("nacionalidad", typeof(string));
            dataPersonas.Columns.Add("calle", typeof(string));
            dataPersonas.Columns.Add("nro_calle", typeof(string));
            dataPersonas.Columns.Add("piso", typeof(string));
            dataPersonas.Columns.Add("departamento", typeof(string));
            dataPersonas.Columns.Add("localidad", typeof(string));
            dataPersonas.Columns.Add("pais", typeof(string));
            dataPersonas.Columns.Add("fecha_nacimiento", typeof(DateTime));
            dataPersonas.Columns.Add("id_usuario", typeof(Int32));

            //cargo las columnas con los datos ingresados
            dataPersonas.Rows.Add(nuevaPersona.tipo_documento, nuevaPersona.nro_documento, nuevaPersona.email, nuevaPersona.nombre,
                                    nuevaPersona.apellido, nuevaPersona.telefono, nuevaPersona.nacionalidad, nuevaPersona.direccion,
                                    nuevaPersona.nro_calle, nuevaPersona.piso, nuevaPersona.departamento, nuevaPersona.localidad, nuevaPersona.pais,
                                    nuevaPersona.fecha_nacimiento, idUsuario);

            return dataPersonas;
        }

        public void validarDatosPersona(string tipo, int dni, string emailPer,int idPersona)
        {
            SqlConnection sqlConnection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_ValidarDatosPersona", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@tipoDNI", tipo));
            spCommand.Parameters.Add(new SqlParameter("@nroDNI", dni));
            spCommand.Parameters.Add(new SqlParameter("@emailPer", emailPer));
            spCommand.Parameters.Add(new SqlParameter("@idPersona", idPersona));
            sqlConnection.Open();

            bool esValido = (bool)spCommand.ExecuteScalar(); // es valido si es 1
            if (!esValido)
            {
                sqlConnection.Close();
                throw new System.ArgumentException("Existe un cliente con la misma identificacion. Reingrese los campos en blanco");
            }

            sqlConnection.Close();
        }

        public List<Persona> buscarCliente(Persona clienteABuscar)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_BuscarCliente", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_BuscarCliente
            spCommand.Parameters.Add(new SqlParameter("@tipoDNI", clienteABuscar.tipo_documento));
            if (clienteABuscar.nro_documento == 0)
            {
                spCommand.Parameters.Add(new SqlParameter("@nroDocumento", DBNull.Value));
            }
            else {
                spCommand.Parameters.Add(new SqlParameter("@nroDocumento", clienteABuscar.nro_documento));
            }
            
            spCommand.Parameters.Add(new SqlParameter("@nombre", clienteABuscar.nombre));
            spCommand.Parameters.Add(new SqlParameter("@apellido", clienteABuscar.apellido));
            spCommand.Parameters.Add(new SqlParameter("@email", clienteABuscar.email));

            List<Persona> clientesEncontrados = new List<Persona>();
            DataTable clientesTable = new DataTable();
            clientesTable.Load(spCommand.ExecuteReader());
            if (clientesTable != null && clientesTable.Rows != null)
            {
                foreach (DataRow row in clientesTable.Rows)
                {
                    Persona personaEncontrado = this.BuildPersona(row);
                    clientesEncontrados.Add(personaEncontrado);
                }
            }

            return clientesEncontrados;
        }

        private Persona BuildPersona(DataRow row)
        {
            Persona persona = new Persona();
            persona.id_persona = int.Parse(row["id_persona"].ToString());
            persona.tipo_documento = row["tipo_documento"].ToString();
            persona.email = row["email"].ToString();
            persona.nro_documento = int.Parse(row["nro_documento"].ToString());
            persona.nombre = row["nombre"].ToString();
            persona.apellido = row["apellido"].ToString();
            persona.telefono = int.Parse(row["telefono"].ToString());
            persona.nacionalidad = row["nacionalidad"].ToString();
            persona.direccion = row["direccion"].ToString();
            persona.nro_calle = int.Parse(row["nro_calle"].ToString());
            persona.piso = int.Parse(row["piso"].ToString());
            persona.departamento = row["departamento"].ToString();
            persona.localidad = row["localidad"].ToString();
            persona.pais = row["pais"].ToString();
            persona.fecha_nacimiento = Convert.ToDateTime(row["fecha_nacimiento"]);
            persona.estado = row["estado"].ToString();
            persona.id_usuario = int.Parse(row["id_usuario"].ToString());
            return persona;
        }

        public void habilitarDeshabilitarCliente(Persona cliente)
        {
            SqlConnection sqlConnection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_HabilitarDeshabilitarCliente", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            spCommand.Parameters.Clear();
            spCommand.Parameters.Add(new SqlParameter("@idPersona", cliente.id_persona));

            sqlConnection.Open();

            int filasAfectadas = spCommand.ExecuteNonQuery();
            if (filasAfectadas==0){
                sqlConnection.Close();
                throw new System.ArgumentException("No se pudo cambiar estado del cliente. Reintentelo");
            }
            sqlConnection.Close();
        }

        public int modificarPersona(Persona nuevaPersona, int idUsuario)
        {
            this.validarDatosPersona(nuevaPersona.tipo_documento, nuevaPersona.nro_documento, nuevaPersona.email,nuevaPersona.id_persona);
            SqlConnection sqlConnection = new SqlConnection(InfoGlobal.connectionString);
            DataTable dataPersonas = this.generarTablaDatosPersona(nuevaPersona, idUsuario);


            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_ModificarPersona", sqlConnection);
            spCommand.CommandType = CommandType.StoredProcedure;
            sqlConnection.Open();
            spCommand.Parameters.Clear();

            SqlParameter parametroDatosPersona = new SqlParameter();
            parametroDatosPersona.ParameterName = "@datosIngresadosPersona";
            parametroDatosPersona.SqlDbType = System.Data.SqlDbType.Structured;
            parametroDatosPersona.Value = dataPersonas;
            spCommand.Parameters.Add(parametroDatosPersona);
            spCommand.Parameters.Add(new SqlParameter("@idPersona", nuevaPersona.id_persona));

            int filasAfectadas = spCommand.ExecuteNonQuery();
            return filasAfectadas;
        }

        public Persona getPersona_ConIDUser(int id_usuario)
        {
            SqlConnection connection = new SqlConnection(InfoGlobal.connectionString);
            SqlCommand spCommand = new SqlCommand("CUATROGDD2018.SP_GetPersona_IDUsuario", connection);
            spCommand.CommandType = CommandType.StoredProcedure;
            connection.Open();
            spCommand.Parameters.Clear();
            //agrego parametros al SP_BuscarCliente
            spCommand.Parameters.Add(new SqlParameter("@idUsuario", id_usuario));

            List<Persona> usuariosEncontrado = new List<Persona>();
            DataTable clientesTable = new DataTable();
            clientesTable.Load(spCommand.ExecuteReader());
            if (clientesTable != null && clientesTable.Rows != null)
            {
                foreach (DataRow row in clientesTable.Rows)
                {
                    Persona personaEncontrado = this.BuildPersona(row);
                    usuariosEncontrado.Add(personaEncontrado);
                }
            }

            return usuariosEncontrado.ElementAt(0);
        }
    }
}
