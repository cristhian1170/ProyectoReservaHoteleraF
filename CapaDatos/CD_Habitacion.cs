using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class CD_Habitacion
    {

        private CD_Conexion conexion = new CD_Conexion();
        private SqlDataReader leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Metodo. Obtiene la lista de todos las habitaciones registradas
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarHabitaciones()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarHabitacion";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

        /// <summary>
        /// Metodo. permite insertar un nuevo registro en la tabla Habitacion
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="capacidad"></param>

        public void Insertar(string nombre, int capacidad)
        {


            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpInsertarHabitaciones";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Capacidad", capacidad);
     
            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        /// <summary>
        /// Metodo. permite editar un registro en la tabla Habitacion
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="capacidad"></param>
        /// <param name="idHabitacion"></param>
        public void Editar(string nombre, int capacidad, int idHabitacion)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEditarHabitaciones";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Capacidad", capacidad);
            comando.Parameters.AddWithValue("@IdHabitacion", idHabitacion);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        /// <summary>
        /// Metodo permite eliminar un registro por el idhabitacion
        /// </summary>
        /// <param name="idHabitacion"></param>
        public void Eliminar(int idHabitacion)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEliminarHabitaciones";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdHabitacion", idHabitacion);

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



            sql = "SELECT * FROM Habitacion WHERE nombre LIKE('" + buscar + "%') or capacidad LIKE('" + buscar + "%')";



            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sql;
            Leerfilas = comando.ExecuteReader();
            dataEncontrada.Load(Leerfilas);


            conexion.CerrarConexion();
            return dataEncontrada;


        }

       
    }

}
