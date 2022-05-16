using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
   public class CD_Administrador {

        private CD_Conexion conexion = new CD_Conexion();
        private SqlDataReader leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Metodo. Obtiene la lista de todos los Administradores registrados
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarAdministradores()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarAdministradores";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

      
        /// <summary>
        /// Metodo. permite insertar un nuevo registro en la tabla Administrador
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="isActive"></param>

        public void Insertar(string nombre, bool isActive)
        {


            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpInsertarAdministradores";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@IsActive", isActive);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        /// <summary>
        /// Metodo. permite editar un registro en la tabla Administrador
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="isActive"></param>
        /// <param name="idAdministrador"></param>
        public void Editar(string nombre, bool isActive, int idAdministrador)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEditarAdministradores";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@IsActive", isActive);
            comando.Parameters.AddWithValue("@idAdministrador", idAdministrador);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        /// <summary>
        /// Metodo permite eliminar un registro por el idAdministrador
        /// </summary>
        /// <param name="idAdministrador"></param>
        public void Eliminar(int idAdministrador)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEliminarAdministradores";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdAdministrador", idAdministrador);

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



            sql = "SELECT nombre AS NOMBRE, is_active AS ACTIVO FROM Administrador WHERE nombre LIKE('" + buscar + "%')";



            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sql;
            Leerfilas = comando.ExecuteReader();
            dataEncontrada.Load(Leerfilas);


            conexion.CerrarConexion();
            return dataEncontrada;


        }

       
    }

}

