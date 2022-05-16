using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public class CN_Habitacion
    {
        private CD_Habitacion objetoCD = new CD_Habitacion();

        /// <summary>
        /// Metodo. Retorna los datos obtenidos del metodo ListarHabitaciones() de la capa de datos. 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarHabitaciones()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarHabitaciones();
            return tabla;
        }
        /// <summary>
        /// Metodo. Permite insertar, al pasar los valores como parametros en el metodo Insertar() de la capa de datos. 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="capacidad"></param>
         
        public void InsertarHabitaciones(string nombre, string capacidad)
        {

            objetoCD.Insertar(nombre, Convert.ToInt32(capacidad));


        }
        /// <summary>
        /// Metodo. Permite editar, al pasar los valores como parametros en el metodo Editar() de la capa de datos. 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="capacidad"></param>
        /// <param name="idHabitacion"></param>
        public void EditarHabitaciones(string nombre, string capacidad, string idHabitacion)
        {
            objetoCD.Editar(nombre, Convert.ToInt32(capacidad), Convert.ToInt32(idHabitacion));
        }

        /// <summary>
        /// Metodo elimina un registro, al pasar un parametro a el metodo Eliminar() de la capa de datos
        /// </summary>
        /// <param name="idHabitacion"></param>
        public void EliminarHabitaciones(string idHabitacion)
        {

            objetoCD.Eliminar(Convert.ToInt32(idHabitacion));
        }
        /// <summary>
        /// Metodo. Permite buscar un determinado registro, al pasar un valor como parametro en el metodo Buscar() de la capa de datos.
        /// </summary>
        /// <param name="buscar"></param>
        /// <returns>DataTable</returns>

        public DataTable BuscarHabitaciones(string buscar)
        {

            DataTable dt = new DataTable();
            dt = objetoCD.Buscar(buscar);
            return dt;
        }

        
    }
}
