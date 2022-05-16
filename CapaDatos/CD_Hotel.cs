using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Hotel
    {
        private CD_Conexion conexion = new CD_Conexion();
        private SqlDataReader leer;
        private DataTable tabla = new DataTable();
        private SqlCommand comando = new SqlCommand();

        /// <summary>
        /// Metodo. Obtiene la lista de todos los hoteles registrados
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarHoteles()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarHoteles";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

        /// <summary>
        /// Metodo. Obtiene la lista de todos los nombre de los Administradores registrados
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarNombresAdministradores()
        {

            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "SpListarNombreAdministradores";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);

            conexion.CerrarConexion();
            return tabla;

        }

        /// <summary>
        /// Metodo. permite insertar un nuevo registro en la tabla Hotel
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="categoria"></param>
        /// <param name="domicilio"></param>
        /// <param name="localidad"></param>
        /// <param name="provincia"></param>
        /// <param name="codPostal"></param>
        /// <param name="telefono"></param>
        /// <param name="idAdministrador"></param>
    

        public void Insertar(string nombre, string descripcion, int categoria, string domicilio, string localidad, string provincia, string codPostal, string telefono, int idAdministrador)
        {


            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpInsertarHoteles";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.Parameters.AddWithValue("@Categoria", categoria);
            comando.Parameters.AddWithValue("@Domicilio", domicilio);
            comando.Parameters.AddWithValue("@Localidad", localidad);
            comando.Parameters.AddWithValue("@Provincia", provincia);
            comando.Parameters.AddWithValue("@CodPostal", codPostal);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@AdministradorId", idAdministrador);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

        }
        /// <summary>
        /// Metodo. permite editar un registro en la tabla Hotel
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="categoria"></param>
        /// <param name="domicilio"></param>
        /// <param name="localidad"></param>
        /// <param name="provincia"></param>
        /// <param name="codPostal"></param>
        /// <param name="telefono"></param>
        /// <param name="idAdministrador"></param>
        /// <param name="idHotel"></param>
        /// 
        public void Editar(string nombre, string descripcion, int categoria, string domicilio, string localidad, string provincia, string codPostal, string telefono, int idAdministrador, int idHotel)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEditarHoteles";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Descripcion", descripcion);
            comando.Parameters.AddWithValue("@Categoria", categoria);
            comando.Parameters.AddWithValue("@Domicilio", domicilio);
            comando.Parameters.AddWithValue("@Localidad", localidad);
            comando.Parameters.AddWithValue("@Provincia", provincia);
            comando.Parameters.AddWithValue("@CodPostal", codPostal);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@AdministradorId", idAdministrador);
            comando.Parameters.AddWithValue("@IdHotel", idHotel);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }

        /// <summary>
        /// Metodo permite eliminar un registro por el Id
        /// </summary>
        /// <param name="idHotel"></param>
        public void Eliminar(int idHotel)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SpEliminarHoteles";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@IdHotel", idHotel);

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



            sql = "SELECT idhotel, H.nombre AS NOMBRE, descripcion AS DESCRIPCION, categoria AS CATEGORIA, domicilio AS DOMICILIO, " +
                "localidad AS LOCALIDAD, provincia AS PROVINCIA,codpostal AS CODPOSTAL, telefono AS TELEFONO, A.nombre AS ADMINISTRADOR, H.administrador_id AS ADMINISTRADORID FROM Hotel AS H " +
                "INNER JOIN Administrador AS A on A.administrador_id = H.administrador_id WHERE H.nombre LIKE('" + buscar + "%') or descripcion LIKE('" + buscar + "%')";

            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = sql;
            Leerfilas = comando.ExecuteReader();
            dataEncontrada.Load(Leerfilas);


            conexion.CerrarConexion();
            return dataEncontrada;


        }

       
    }
}
