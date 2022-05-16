using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class CD_Reserva
    {

        private CD_Conexion conexion = new CD_Conexion();
        private SqlDataReader leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Metodo. Obtiene la lista de todos las reversas registradas
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarReservas()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarReserva";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

        
        /// <summary>
        /// Metodo. permite insertar un nuevo registro en la tabla Reserva
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="precio"></param>
        /// <param name="ocupacion"></param>
        /// <param name="nombreTomador"></param>
        /// <param name="cantidad"></param>
        /// <param name="idCliente"></param>
        /// <param name="idUsuario"></param>
        /// <param name="idHotel"></param>
        /// <param name="idHabitacion"></param>
        
        public void Insertar(DateTime fechaInicio, DateTime fechaFin, decimal precio,int ocupacion,string nombreTomador, int cantidad, int idCliente,int idUsuario, int idHotel, int idHabitacion)
        {


            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpInsertarReserva";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fechainicio", fechaInicio);
            comando.Parameters.AddWithValue("@FechaFin", fechaFin);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Ocupacion", ocupacion);
            comando.Parameters.AddWithValue("@NombreTomador", nombreTomador);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            comando.Parameters.AddWithValue("@IdCliente", idCliente);
            comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
            comando.Parameters.AddWithValue("@IdHotel", idHotel);
            comando.Parameters.AddWithValue("@IdHabitacion", idHabitacion);
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        /// <summary>
        /// Metodo. permite editar un registro en la tabla Reserva
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="precio"></param>
        /// <param name="ocupacion"></param>
        /// <param name="nombreTomador"></param>
        /// <param name="cantidad"></param>
        /// <param name="idCliente"></param>
        /// <param name="idUsuario"></param>
        /// <param name="idHotel"></param>
        /// <param name="idHabitacion"></param>
        /// <param name="idReserva"></param>

        public void Editar(DateTime fechaInicio, DateTime fechaFin, decimal precio, int ocupacion, string nombreTomador, int cantidad, int idCliente, int idUsuario, int idHotel, int idHabitacion, int idReserva)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEditarReserva";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Fechainicio", fechaInicio);
            comando.Parameters.AddWithValue("@FechaFin", fechaFin);
            comando.Parameters.AddWithValue("@Precio", precio);
            comando.Parameters.AddWithValue("@Ocupacion", ocupacion);
            comando.Parameters.AddWithValue("@NombreTomador", nombreTomador);
            comando.Parameters.AddWithValue("@Cantidad", cantidad);
            comando.Parameters.AddWithValue("@IdCliente", idCliente);
            comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
            comando.Parameters.AddWithValue("@IdHotel", idHotel);
            comando.Parameters.AddWithValue("@IdHabitacion", idHabitacion);
            comando.Parameters.AddWithValue("@IdReserva", idReserva);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        /// <summary>
        /// Metodo permite eliminar un registro por el idReserva
        /// </summary>
        /// <param name="idReserva"></param>
        public void Eliminar(int idReserva)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEliminarReserva";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdReserva", idReserva);

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
            string sql = "";



            sql = "SELECT idreserva, fechainicio AS FECHAINICIO, fechafin AS FECHAFIN, precio AS PRECIO,ocupacion AS OCUPACION, nombretomador AS NOMBRETOMADOR, " +
                "cantidad AS CANTIDAD,C.NombreCompleto AS CLIENTE,R.cliente_id AS CLIENTEID, U.nombres AS USUARIO,R.usuario_id AS USUARIOID,H.nombre AS HOTEL,R.hotel_id AS HOTELID,HA.nombre AS HABITACION,R.habitacion_id AS HABITACIONID FROM Reserva AS R " +
                "INNER JOIN Cliente AS C ON C.IdCliente = R.cliente_id " +
                "INNER JOIN Usuario AS U ON U.idusuario = R.usuario_id " +
                "INNER JOIN Hotel AS H ON H.idhotel = R.hotel_id " +
                "INNER JOIN Habitacion AS HA ON HA.idhabitacion = R.habitacion_id " +
                "WHERE C.NombreCompleto LIKE('" + buscar + "%') or U.nombres LIKE('" + buscar + "%') or H.nombre LIKE('" + buscar + "%')";

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sql;
            Leerfilas = comando.ExecuteReader();
            dataEncontrada.Load(Leerfilas);


            conexion.CerrarConexion();
            return dataEncontrada;


        }

       
    }
}
