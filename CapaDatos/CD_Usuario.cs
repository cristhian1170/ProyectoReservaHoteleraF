using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuario
    {

        private CD_Conexion conexion = new CD_Conexion();
        private SqlDataReader leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Metodo. Obtiene la lista de todos los usuarios registrados
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarUsuarios()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

        /// <summary>
        /// Metodo. permite insertar un nuevo registro en la tabla USUARIOS
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="nombre"></param>
        /// <param name="correo"></param>
        /// <param name="clave"></param>
        /// <param name="isActive"></param>
        /// <param name="isAdmin"></param>
        /// <param name="fechaCreacion"></param>

        public void Insertar(string usuario, string nombre, string correo, string clave, bool isActive, bool isAdmin, DateTime fechaCreacion)
        {


            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpInsertarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Nombres", nombre);
            comando.Parameters.AddWithValue("@Correo", correo);
            comando.Parameters.AddWithValue("@Clave", clave);
            comando.Parameters.AddWithValue("@IsActive", isActive);
            comando.Parameters.AddWithValue("@IsAdmin", isAdmin);
            comando.Parameters.AddWithValue("@FechaCreacion", fechaCreacion);


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        /// <summary>
        /// Metodo. permite editar un registro en la tabla Usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="nombre"></param>
        /// <param name="correo"></param>
        /// <param name="clave"></param>
        /// <param name="isActive"></param>
        /// <param name="isAdmin"></param>
        /// <param name="idUsuario"></param>
        public void Editar(string usuario, string nombre, string correo, string clave, bool isActive, bool isAdmin, int idUsuario)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEditarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Usuario", usuario);
            comando.Parameters.AddWithValue("@Nombres", nombre);
            comando.Parameters.AddWithValue("@Correo", correo);
            comando.Parameters.AddWithValue("@Clave", clave);
            comando.Parameters.AddWithValue("@IsActive", isActive);
            comando.Parameters.AddWithValue("@IsAdmin", isAdmin);
            comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        /// <summary>
        /// Metodo permite eliminar un registro por el Id
        /// </summary>
        /// <param name="idUsuario"></param>
        public void Eliminar(int idUsuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEliminarUsuarios";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

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


         
            sql = "SELECT Usuario AS USUARIO," +
                "nombres AS NOMBRES, correo AS CORREO,clave AS CLAVE, is_active AS ACTIVO," +
                "is_admin AS ADMINISTRADOR, fechacreacion AS FECHACREACION FROM Usuario WHERE " +
                "nombres LIKE('" + buscar + "%') or usuario LIKE('" + buscar + "%')";

           

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sql;
            Leerfilas = comando.ExecuteReader();
            dataEncontrada.Load(Leerfilas);


            conexion.CerrarConexion();
            return dataEncontrada;


        }

        /// <summary>
        /// Metodo permite colocar un usuario en estado false
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="estado"></param>
        public void Deshabilitar(int idUsuario, bool estado)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpCambiarEstadoUsuario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Id", idUsuario);
            comando.Parameters.AddWithValue("@EstadoUsuario", estado);


            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
