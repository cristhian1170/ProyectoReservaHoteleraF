using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class CN_TipoHabitacion
    {
        private CD_TipoHabitacion objetoCD = new CD_TipoHabitacion();

        /// <summary>
        /// Metodo. Retorna los datos obtenidos del metodo ListarTipoHabitaciones() de la capa de datos. 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarTipoHabitaciones()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarTiposHabitaciones();
            return tabla;
        }
        /// <summary>
        /// Metodo. Retorna los datos obtenidos del metodo ListarNombresHoteles() de la capa de datos. 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarNombresHoteles()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarNombresHoteles();
            return tabla;
        }

        /// <summary>
        /// Metodo. Retorna los datos obtenidos del metodo ListarNombresHabitaciones() de la capa de datos. 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarNombresHabitaciones()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarNombresHabitaciones();
            return tabla;
        }
        /// <summary>
        /// Metodo. Permite insertar, al pasar los valores como parametros en el metodo Insertar() de la capa de datos. 
        /// </summary>
        /// <param name="idHotel"></param>
        /// <param name="idHabitacion"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="numHabitaciones"></param>

        public void InsertarTipoHabitaciones(string idHotel, string idHabitacion, string descripcion, string precio, string numHabitaciones)
        {

            objetoCD.Insertar(Convert.ToInt32(idHotel),Convert.ToInt32(idHabitacion),descripcion, Convert.ToDecimal(precio), Convert.ToInt32(numHabitaciones));


        }
        /// <summary>
        /// Metodo. Permite editar, al pasar los valores como parametros en el metodo Editar() de la capa de datos. 
        /// </summary>
        /// <param name="idHotel"></param>
        /// <param name="idHabitacion"></param>
        /// <param name="descripcion"></param>
        /// <param name="precio"></param>
        /// <param name="numHabitaciones"></param>
        /// <param name="idTipoHabitacion"></param>

        public void EditarTipoHabitaciones(string idHotel, string idHabitacion, string descripcion, string precio, string numHabitaciones, string idTipoHabitacion)
        {
            objetoCD.Editar(Convert.ToInt32(idHotel), Convert.ToInt32(idHabitacion), descripcion, Convert.ToDecimal(precio), Convert.ToInt32(numHabitaciones), Convert.ToInt32(idTipoHabitacion));
        }

        /// <summary>
        /// Metodo elimina un registro, al pasar un parametro a el metodo Eliminar() de la capa de datos
        /// </summary>
        /// <param name="idTipoHabitacion"></param>
        public void EliminarTipoHabitaciones(string idTipoHabitacion)
        {

            objetoCD.Eliminar(Convert.ToInt32(idTipoHabitacion));
        }
        /// <summary>
        /// Metodo. Permite buscar un determinado registro, al pasar un valor como parametro en el metodo Buscar() de la capa de datos.
        /// </summary>
        /// <param name="buscar"></param>
        /// <returns>DataTable</returns>

        public DataTable BuscarTipoHabitaciones(string buscar)
        {

            DataTable dt = new DataTable();
            dt = objetoCD.Buscar(buscar);
            return dt;
        }

        
    }
}
