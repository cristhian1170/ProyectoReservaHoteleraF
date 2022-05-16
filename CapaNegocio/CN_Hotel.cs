using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Hotel
    {
        private CD_Hotel objetoCD = new CD_Hotel();


        /// <summary>
        /// Metodo. Retorna los datos obtenidos del metodo ListarHoteles() de la capa de datos. 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarHoteles()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarHoteles();
            return tabla;
        }

        /// <summary>
        /// Metodo. Retorna los datos obtenidos del metodo ListarNombresAdministradores() de la capa de datos. 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarNombresAdministradores()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarNombresAdministradores();
            return tabla;
        }
        /// <summary>
        /// Metodo. Permite insertar, al pasar los valores como parametros en el metodo Insertar() de la capa de datos. 
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


        public void InsertarHoteles(string nombre, string descripcion, string categoria, string domicilio, string localidad, string provincia, string codPostal, string telefono, string idAdministrador)
        
        {

            objetoCD.Insertar(nombre, descripcion, Convert.ToInt32(categoria), domicilio, localidad, provincia, codPostal,telefono, Convert.ToInt32(idAdministrador));


        }
        /// <summary>
        /// Metodo. Permite editar, al pasar los valores como parametros en el metodo Editar() de la capa de datos. 
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
        
        public void EditarHoteles(string nombre, string descripcion, string categoria, string domicilio, string localidad, string provincia, string codPostal, string telefono, string idAdministrador, string idHotel)
        {
            objetoCD.Editar(nombre, descripcion, Convert.ToInt32(categoria), domicilio, localidad, provincia, codPostal, telefono, Convert.ToInt32(idAdministrador), Convert.ToInt32(idHotel));
        }

        /// <summary>
        /// Metodo elimina un registro, al pasar un parametro a el metodo Eliminar() de la capa de datos
        /// </summary>
        /// <param name="idHotel"></param>
        public void EliminarHoteles(string idHotel)
        {

            objetoCD.Eliminar(Convert.ToInt32(idHotel));
        }
        /// <summary>
        /// Metodo. Permite buscar un determinado registro, al pasar un valor como parametro en el metodo Buscar() de la capa de datos.
        /// </summary>
        /// <param name="buscar"></param>
        /// <returns>DataTable</returns>

        public DataTable BuscarHoteles(string buscar)
        {

            DataTable dt = new DataTable();
            dt = objetoCD.Buscar(buscar);
            return dt;
        }

       
    }
}
