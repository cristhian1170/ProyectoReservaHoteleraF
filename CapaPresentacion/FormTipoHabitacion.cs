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

    public partial class FormTipoHabitaciones : Form
    {
        #region
        //SqlConnection conexion = new SqlConnection("Data Source = YERLIN022\\SQLEXPRESS;Initial Catalog = REGISTRO_TUTORIAS_ACADEMICA; Integrated Security = True");
        #endregion

        CN_TipoHabitacion objetoCN = new CN_TipoHabitacion();
        public string idTipoHabitacion = "";
        public bool estado=false;
        public string Operacion = "Insertar";


        public FormTipoHabitaciones()
        {
            InitializeComponent();
        }

        private void FormTipoHabitaciones_Load(object sender, EventArgs e)
        {
            MostrarTiposHabitaciones();
        }


        private void MostrarTiposHabitaciones()
        {

            CN_TipoHabitacion objeto = new CN_TipoHabitacion();
            dataGridViewTipoHabitaciones.DataSource = objeto.ListarTipoHabitaciones();
            this.dataGridViewTipoHabitaciones.Columns["tipoHabitacion_id"].Visible = false;
            this.dataGridViewTipoHabitaciones.Columns["HOTELID"].Visible = false;
            this.dataGridViewTipoHabitaciones.Columns["HABITACIONID"].Visible = false;

        }



        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            CN_TipoHabitacion objetobusqueda = new CN_TipoHabitacion();
            dataGridViewTipoHabitaciones.DataSource =objetobusqueda.BuscarTipoHabitaciones(txtBuscar.Text);

        }

       
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FormMantTipoHabitacion frm = new FormMantTipoHabitacion();
            frm.Operacion = "Insertar";
            frm.MostrarHoteles();
            frm.MostrarHabitaciones();
            frm.ShowDialog();
            MostrarTiposHabitaciones();

        }

        private void btnEditarF2_Click(object sender, EventArgs e)
        {

           
            
            if (dataGridViewTipoHabitaciones.SelectedRows.Count > 0)
            {


                FormMantTipoHabitacion frm = new FormMantTipoHabitacion();


                //EDITAR
              
                 frm.Operacion = "Editar";
                 frm.MostrarHoteles();
                 frm.MostrarHabitaciones();

               
                 frm.idTipoHabitacion = dataGridViewTipoHabitaciones.CurrentRow.Cells["tipoHabitacion_id"].Value.ToString();
                 frm.cmbHotel.SelectedValue = dataGridViewTipoHabitaciones.CurrentRow.Cells["HOTELID"].Value;
                 frm.cmbHabitacion.SelectedValue = dataGridViewTipoHabitaciones.CurrentRow.Cells["HABITACIONID"].Value;
                 frm.txtDescripcion.Text = dataGridViewTipoHabitaciones.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                 frm.txtPrecio.Text = dataGridViewTipoHabitaciones.CurrentRow.Cells["PRECIO"].Value.ToString();
                 frm.txtNumeroHabitaciones.Text = dataGridViewTipoHabitaciones.CurrentRow.Cells["NUMHABITACIONES"].Value.ToString();

                 frm.ShowDialog();
                 MostrarTiposHabitaciones();

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewTipoHabitaciones.SelectedRows.Count > 0)
            {
                DialogResult resultoAccion = MessageBox.Show("¿Desea eliminar el tipo de habitacion?",
                "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultoAccion == DialogResult.Yes)
                {

                    idTipoHabitacion = dataGridViewTipoHabitaciones.CurrentRow.Cells["tipoHabitacion_id"].Value.ToString();

                    objetoCN.EliminarTipoHabitaciones(idTipoHabitacion);
                    MostrarTiposHabitaciones();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}


        

 

