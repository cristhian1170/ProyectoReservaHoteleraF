using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class CD_TipoHabitacion
    {
        private CD_Conexion conexion = new CD_Conexion();
        private SqlDataReader leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Metodo. Obtiene la lista de todos los tipos de habitaciones registradas
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarTiposHabitaciones()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarTipoHabitacion";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

        /// <summary>
        /// Metodo. Obtiene la lista de todos los nombres de hoteles registrados
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarNombresHoteles()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarNombresHoteles";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

        /// <summary>
        /// Metodo. Obtiene la lista de todos los nombres de habitaciones registradas
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarNombresHabitaciones()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarNombresHabitaciones";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

        /// <summary>
        /// Metodo. permite insertar un nuevo registro en la tabla TipoHabitacion
        /// </summary>
        /// <param name="idHotel"></param>
        /// <param name="idHabitacion"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="numHabitaciones"></param>

        public void Insertar(int idHotel, int idHabitacion, string descripcion,decimal precio,int numHabitaciones)
        {


            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpInsertarTipoHabitaciones";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdHotel", idHotel);
            comando.Parameters.AddWithValue("@IdHabitacion", idHabitacion);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@NumHabitaciones", numHabitaciones);
            
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        /// <summary>
        /// Metodo. permite editar un registro en la tabla TipoHabitacion
        /// </summary>
        /// <param name="idHotel"></param>
        /// <param name="idHabitacion"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="numHabitaciones"></param>
        /// <param name="idTipoHabitacion"></param>
        
        public void Editar(int idHotel, int idHabitacion, string descripcion, decimal precio, int numHabitaciones, int idTipoHabitacion)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEditarTipoHabitaciones";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdHotel", idHotel);
            comando.Parameters.AddWithValue("@IdHabitacion", idHabitacion);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@NumHabitaciones", numHabitaciones);
            comando.Parameters.AddWithValue("@IdTipoHabitacion", idTipoHabitacion);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        /// <summary>
        /// Metodo permite eliminar un registro por el idTipoHabitacion
        /// </summary>
        /// <param name="idTipoHabitacion"></param>
        public void Eliminar(int idTipoHabitacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEliminarTipoHabitaciones";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdTipoHabitacion", idTipoHabitacion);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        /// <summary>
        /// Metodo. Obtiene un determinado registro, segun un criterio de busqueda
        /// </summary>
        /// <param name="buscar"></param>
        /// <returns>DataTable</returns>

        public DataTable Buscar(string buscar)
        {
            DataTable dataEncontrada = new DataTable();
            SqlDataReader Leerfilas;
            string filtroInactivo = buscar;
            string sql = "";



            sql = "SELECT tipoHabitacion_id,H.nombre AS HOTEL,H.idhotel AS HOTELID, HA.nombre AS HABITACION,HA.idhabitacion AS HABITACIONID, T.descripcion AS DESCRIPCION, precio AS PRECIO, numhabitaciones AS NUMHABITACIONES FROM TipoHabitacion AS T " +
                "INNER JOIN Hotel AS H ON H.idhotel = T.hotel_id " +
                "INNER JOIN Habitacion AS HA ON HA.idhabitacion = T.habitacion_id " +
                "WHERE H.nombre LIKE('" + buscar + "%') or HA.nombre LIKE('" + buscar + "%') or precio LIKE('" + buscar + "%')";



            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sql;
            Leerfilas = comando.ExecuteReader();
            dataEncontrada.Load(Leerfilas);


            conexion.CerrarConexion();
            return dataEncontrada;


        }

       
    }
}
