using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Administradores
    {
        private CD_Administrador objetoCD = new CD_Administrador();

        /// <summary>
        /// Metodo. Retorna los datos obtenidos del metodo ListarAdministradores() de la capa de datos. 
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable ListarAdministradores()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ListarAdministradores();
            return tabla;
        }

       
        /// <summary>
        /// Metodo. Permite insertar, al pasar los valores como parametros en el metodo Insertar() de la capa de datos. 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="isActive"></param>

        public void InsertarAdministradores(string nombre, string isActive)
        {

            objetoCD.Insertar(nombre, Convert.ToBoolean(isActive));


        }
        /// <summary>
        /// Metodo. Permite editar, al pasar los valores como parametros en el metodo Editar() de la capa de datos. 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="isActive"></param>
        /// <param name="idAdministrador"></param>
        public void EditarAdministradores(string nombre, string isActive, string idAdministrador)
        {
            objetoCD.Editar(nombre, Convert.ToBoolean(isActive), Convert.ToInt32(idAdministrador));
        }

        /// <summary>
        /// Metodo elimina un registro, al pasar un parametro a el metodo Eliminar() de la capa de datos
        /// </summary>
        /// <param name="idAdministrador"></param>
        public void EliminarAdministradores(string idAdministrador)
        {

            objetoCD.Eliminar(Convert.ToInt32(idAdministrador));
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

