using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class CN_Reserva
    {
        private CD_Reserva objetoCD = new CD_Reserva();

        /// <summary>
        /// Metodo. Retorna los datos obtenidos del metodo ListarReservas() de la capa de datos. 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarReservas()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarReservas();
            return tabla;
        }

        /// <summary>
        /// Metodo. Permite insertar, al pasar los valores como parametros en el metodo Insertar() de la capa de datos. 
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

        public void InsertarReservas(string fechaInicio, string fechaFin, string precio, string ocupacion, string nombreTomador, string cantidad, string idCliente, string idUsuario, string idHotel, string idHabitacion)
        {

            objetoCD.Insertar(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin),Convert.ToDecimal(precio),Convert.ToInt32(ocupacion),nombreTomador,Convert.ToInt32(cantidad), Convert.ToInt32(idCliente), Convert.ToInt32(idUsuario), Convert.ToInt32(idHotel), Convert.ToInt32(idHabitacion));


        }
        /// <summary>
        /// Metodo. Permite editar, al pasar los valores como parametros en el metodo Editar() de la capa de datos. 
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

        public void EditarReservas(string fechaInicio, string fechaFin, string precio, string ocupacion, string nombreTomador, string cantidad, string idCliente, string idUsuario, string idHotel, string idHabitacion, string idReserva)
        {
            objetoCD.Editar(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin), Convert.ToDecimal(precio), Convert.ToInt32(ocupacion), nombreTomador, Convert.ToInt32(cantidad), Convert.ToInt32(idCliente), Convert.ToInt32(idUsuario), Convert.ToInt32(idHotel), Convert.ToInt32(idHabitacion), Convert.ToInt32(idReserva));
        }

        /// <summary>
        /// Metodo elimina un registro, al pasar un parametro a el metodo Eliminar() de la capa de datos
        /// </summary>
        /// <param name="idReserva"></param>
        public void EliminarReservas(string idReserva)
        {

            objetoCD.Eliminar(Convert.ToInt32(idReserva));
        }
        /// <summary>
        /// Metodo. Permite buscar un determinado registro, al pasar un valor como parametro en el metodo Buscar() de la capa de datos.
        /// </summary>
        /// <param name="buscar"></param>
        /// <returns>DataTable</returns>

        public DataTable BuscarReservas(string buscar)
        {

            DataTable dt = new DataTable();
            dt = objetoCD.Buscar(buscar);
            return dt;
        }

      
    }
}
