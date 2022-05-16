using System;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{  public class CD_Conexion
    {

        private SqlConnection conexion = new SqlConnection(@"Data Source = (local)\SQLEXPRESS;Initial Catalog =ReservasHotel; Integrated Security = True");

        public SqlConnection Conexion { get => conexion; set => conexion = value; }



        /// <summary>
        /// Metodo abre la conexion con la base de datos, en caso de que la conexion este cerrada.
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        /// <summary>
        /// Metodo cierra la conexion con la base de datos, en caso de que la conexion este abierta.
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
