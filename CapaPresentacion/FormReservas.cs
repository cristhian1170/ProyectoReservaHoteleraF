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

    public partial class FormReservas : Form
    {
        #region
        //SqlConnection conexion = new SqlConnection("Data Source = YERLIN022\\SQLEXPRESS;Initial Catalog = REGISTRO_TUTORIAS_ACADEMICA; Integrated Security = True");
        #endregion

        CN_Reserva objetoCN = new CN_Reserva();
        public string idReserva = "";
        public bool estado=false;
        public string Operacion = "Insertar";


        public FormReservas()
        {
            InitializeComponent();
        }

        private void FormArticulos_Load(object sender, EventArgs e)
        {
            MostrarReservas();
        }


        private void MostrarReservas()
        {

            CN_Reserva objeto = new CN_Reserva();
            dataGridViewReservas.DataSource = objeto.ListarReservas();
            this.dataGridViewReservas.Columns["idreserva"].Visible = false;
            this.dataGridViewReservas.Columns["CLIENTEID"].Visible = false;
            this.dataGridViewReservas.Columns["USUARIOID"].Visible = false;
            this.dataGridViewReservas.Columns["HOTELID"].Visible = false;
            this.dataGridViewReservas.Columns["HABITACIONID"].Visible = false;
          
        }
       
       
       
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
             CN_Reserva objetobusqueda = new CN_Reserva();
             dataGridViewReservas.DataSource =objetobusqueda.BuscarReservas(txtBuscar.Text);

        }

       
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FormMantReserva frm = new FormMantReserva();
            frm.Operacion = "Insertar";
            frm.MostrarClientes();
            frm.MostrarUsuarios();
            frm.MostrarHoteles();
            frm.MostrarHabitaciones();
            frm.ShowDialog();
            MostrarReservas();

        }

        private void btnEditarF2_Click(object sender, EventArgs e)
        {

           
            
            if (dataGridViewReservas.SelectedRows.Count > 0)
            {


                FormMantReserva frm = new FormMantReserva();


                //EDITAR
              
                 frm.Operacion = "Editar";
                 frm.MostrarClientes();
                 frm.MostrarUsuarios();
                 frm.MostrarHoteles();
                 frm.MostrarHabitaciones();


                 frm.idReserva = dataGridViewReservas.CurrentRow.Cells["idreserva"].Value.ToString();
                 frm.dtFechaInicio.Text = dataGridViewReservas.CurrentRow.Cells["FECHAINICIO"].Value.ToString();
                 frm.dtFechaFin.Text = dataGridViewReservas.CurrentRow.Cells["FECHAFIN"].Value.ToString();
                 frm.txtPrecio.Text = dataGridViewReservas.CurrentRow.Cells["PRECIO"].Value.ToString();
                 frm.ocupacion.Text = dataGridViewReservas.CurrentRow.Cells["OCUPACION"].Value.ToString();
                 frm.txtNombreTomador.Text = dataGridViewReservas.CurrentRow.Cells["NOMBRETOMADOR"].Value.ToString();
                 frm.cantidad.Text = dataGridViewReservas.CurrentRow.Cells["CANTIDAD"].Value.ToString();

                 frm.cmbCliente.SelectedValue = dataGridViewReservas.CurrentRow.Cells["CLIENTEID"].Value;
                 frm.cmbUsuario.SelectedValue = dataGridViewReservas.CurrentRow.Cells["USUARIOID"].Value;
                 frm.cmbHotel.SelectedValue = dataGridViewReservas.CurrentRow.Cells["HOTELID"].Value;
                 frm.cmbHabitacion.SelectedValue = dataGridViewReservas.CurrentRow.Cells["HABITACIONID"].Value;



                 frm.ShowDialog();
                 MostrarReservas();

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewReservas.SelectedRows.Count > 0)
            {
                DialogResult resultoAccion = MessageBox.Show("¿Desea eliminar la reserva?",
                "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultoAccion == DialogResult.Yes)
                {

                    idReserva = dataGridViewReservas.CurrentRow.Cells["idreserva"].Value.ToString();

                    objetoCN.EliminarReservas(idReserva);
                    MostrarReservas();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            using (FormFiltrarReserva frmFiltrarReportes = new FormFiltrarReserva())
            {
                frmFiltrarReportes.ShowDialog();
            }
        }
    }
}


        

 

