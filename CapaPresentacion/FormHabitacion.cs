using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Data.SqlClient;



namespace CapaPresentacion
{

    public partial class FormHabitaciones : Form
    {
        #region
        //SqlConnection conexion = new SqlConnection("Data Source = YERLIN022\\SQLEXPRESS;Initial Catalog = REGISTRO_TUTORIAS_ACADEMICA; Integrated Security = True");
        #endregion

        CN_Habitacion objetoCN = new CN_Habitacion();
        public string idHabitacion = "";
        public bool estado=false;
        public string Operacion = "Insertar";


        public FormHabitaciones()
        {
            InitializeComponent();
        }

        private void FormHabitaciones_Load(object sender, EventArgs e)
        {
            MostrarHabitaciones();
        }

        private void MostrarHabitaciones()
        {

           CN_Habitacion objeto = new CN_Habitacion();
           dataGridViewHabitaciones.DataSource = objeto.ListarHabitaciones();
           this.dataGridViewHabitaciones.Columns["idhabitacion"].Visible = false;
        }
     
       

     
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            //CN_Empleado objbe = new CN_Empleado();
            //dataGridView2.DataSource = objetoCN.BuscarEst(txtBuscar.Text);
            //objetoCN.BuscarEst(txtMatricula.Text, txtNombre.Text);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
             CN_Habitacion objetobusqueda = new CN_Habitacion();
             dataGridViewHabitaciones.DataSource =objetobusqueda.BuscarHabitaciones(txtBuscar.Text);

        }

       
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FormMantHabitacion frm = new FormMantHabitacion();
            frm.Operacion = "Insertar";
            frm.ShowDialog();
            MostrarHabitaciones();

        }

        private void btnEditarF2_Click(object sender, EventArgs e)
        {

           
            
            if (dataGridViewHabitaciones.SelectedRows.Count > 0)
            {


                FormMantHabitacion frm = new FormMantHabitacion();


                //EDITAR
              
                 frm.Operacion = "Editar";
               
                
                 frm.idHabitacion = dataGridViewHabitaciones.CurrentRow.Cells["idhabitacion"].Value.ToString();

                 frm.txtNombre.Text = dataGridViewHabitaciones.CurrentRow.Cells["nombre"].Value.ToString();
                 frm.txtCapacidad.Text = dataGridViewHabitaciones.CurrentRow.Cells["capacidad"].Value.ToString();
                
                 frm.ShowDialog();
                 MostrarHabitaciones();

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridViewHabitaciones.SelectedRows.Count > 0)
            {
                DialogResult resultAccion = MessageBox.Show("¿Desea eliminar la habitacion?",
                "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultAccion == DialogResult.Yes)
                {

                    idHabitacion = dataGridViewHabitaciones.CurrentRow.Cells["idhabitacion"].Value.ToString();
                   /* estado = Convert.ToBoolean(dataGridViewHabitaciones.CurrentRow.Cells["Estado"].Value.ToString());
                    estado = estado ? false : true;
                   */
                    objetoCN.EliminarHabitaciones(idHabitacion);
                    MostrarHabitaciones();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

      
    }
}


        

 

