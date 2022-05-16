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

    public partial class FormAdministradores : Form
    {
        #region
        //SqlConnection conexion = new SqlConnection("Data Source = YERLIN022\\SQLEXPRESS;Initial Catalog = REGISTRO_TUTORIAS_ACADEMICA; Integrated Security = True");
        #endregion

        CN_Administradores objetoCN = new CN_Administradores();
        public string idAdministrador = "";
        public bool estado=false;
        public string Operacion = "Insertar";


        public FormAdministradores()
        {
            InitializeComponent();
        }

        private void FormArticulos_Load(object sender, EventArgs e)
        {
            MostrarAdministradores();
        }


        private void MostrarAdministradores()
        {

            CN_Administradores objeto = new CN_Administradores();
            dataGridViewAdministradores.DataSource = objeto.ListarAdministradores();
            this.dataGridViewAdministradores.Columns["administrador_id"].Visible = false;
        }
        private void MostrarCarreras()
        {

            //CN_Estudiantes objeto = new CN_Estudiantes();
            //FormMantEstudiantes frm = new FormMantEstudiantes();
            //frm.cbmCarrera.DataSource = objeto.MostrarCarr();
            //frm.cbmCarrera.DisplayMember = "Nombre_Carrera";
            //frm.cbmCarrera.ValueMember = "Id_Carrera";
        }
        private void MostrarMaterias()
        {
            //CN_Estudiantes objeto = new CN_Estudiantes();
            //FormMantEstudiantes frm = new FormMantEstudiantes();

            //frm.cmbMateria.DataSource = objeto.MostrarMate();
            //frm.cmbMateria.DisplayMember = "Nombre_Materia";
            //frm.cmbMateria.ValueMember = "Id_Materia";

        }

       
        private void LimpiarForm()
        {
            //txtMatricula.Clear();
            //txtNombre.Clear();
            //txtApellido.Clear();
            //cbmCarrera.Text = "Carrera";
            //txtEstado.Clear();
        }

       

     
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            //CN_Empleado objbe = new CN_Empleado();
            //dataGridView2.DataSource = objetoCN.BuscarEst(txtBuscar.Text);
            //objetoCN.BuscarEst(txtMatricula.Text, txtNombre.Text);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
             CN_Administradores objetobusqueda = new CN_Administradores();
             dataGridViewAdministradores.DataSource =objetobusqueda.BuscarHabitaciones(txtBuscar.Text);

        }

       
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FormMantAdministradores frm = new FormMantAdministradores();
            frm.Operacion = "Insertar";
            frm.ShowDialog();
            MostrarAdministradores();

        }

        private void btnEditarF2_Click(object sender, EventArgs e)
        {

           
            
            if (dataGridViewAdministradores.SelectedRows.Count > 0)
            {


                FormMantAdministradores frm = new FormMantAdministradores();


                //EDITAR
              
                 frm.Operacion = "Editar";
               
                
                 frm.idAdministrador = dataGridViewAdministradores.CurrentRow.Cells["administrador_id"].Value.ToString();

                 frm.txtNombre.Text = dataGridViewAdministradores.CurrentRow.Cells["NOMBRE"].Value.ToString();
                 //frm.precio.Text = dataGridViewAdministradores.CurrentRow.Cells["Precio"].Value.ToString();
                 //frm.stock.Text = dataGridViewAdministradores.CurrentRow.Cells["Stock"].Value.ToString();
                 frm.estadoCheckBox.Checked= Convert.ToBoolean(dataGridViewAdministradores.CurrentRow.Cells["ACTIVO"].Value);

                 frm.ShowDialog();
                 MostrarAdministradores();

            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAdministradores.SelectedRows.Count > 0)
            {
                DialogResult resultAccion = MessageBox.Show("¿Desea eliminar el administrador?",
                "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultAccion == DialogResult.Yes)
                {

                    idAdministrador = dataGridViewAdministradores.CurrentRow.Cells["administrador_id"].Value.ToString();
                    //estado = Convert.ToBoolean(dataGridViewAdministradores.CurrentRow.Cells["Estado"].Value.ToString());
                    //estado = estado ? false : true;
                    objetoCN.EliminarAdministradores(idAdministrador);
                    MostrarAdministradores();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }
    }
}


        

 

