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

namespace CapaPresentacion
{
    public partial class FormUsuario : Form
    {
        private CN_Usuario objetoCN = new CN_Usuario();
        private string idUsuario = null;



        public FormUsuario()
        {
            InitializeComponent();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            ListarDatosUsuarios();
        }

        /// <summary>
        /// Metodo carga los datos de la tabla usuarios a el objeto dataGridView
        /// </summary>
        private void ListarDatosUsuarios()
        {
            CN_Usuario objeto = new CN_Usuario();
            dataGridViewUsuarios.DataSource = objeto.ListarUsuarios();
            this.dataGridViewUsuarios.Columns["idusuario"].Visible = false;


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMantUser frm = new FormMantUser();
            frm.Operacion = "Insertar";
            frm.ShowDialog();
            ListarDatosUsuarios();

        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            int cantidadFilas = dataGridViewUsuarios.SelectedRows.Count;

            if (cantidadFilas > 0)
            {
                FormMantUser frm = new FormMantUser();
                frm.Operacion = "Editar";

                frm.txtUser.Text = dataGridViewUsuarios.CurrentRow.Cells["USUARIO"].Value.ToString();
                frm.txtNombre.Text = dataGridViewUsuarios.CurrentRow.Cells["NOMBRES"].Value.ToString();
                frm.txtCorreo.Text = dataGridViewUsuarios.CurrentRow.Cells["CORREO"].Value.ToString();
                frm.txtClave.Text = dataGridViewUsuarios.CurrentRow.Cells["CLAVE"].Value.ToString();
                frm.ckEstado.Checked = Convert.ToBoolean(dataGridViewUsuarios.CurrentRow.Cells["ACTIVO"].Value.ToString());
                frm.ckAdministrador.Checked = Convert.ToBoolean(dataGridViewUsuarios.CurrentRow.Cells["ADMINISTRADOR"].Value.ToString());
                frm.idUsuario = dataGridViewUsuarios.CurrentRow.Cells["idusuario"].Value.ToString();
                frm.ShowDialog();
                ListarDatosUsuarios();
            }

            else  {
                MessageBox.Show("Seleccione una fila por favor");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           // bool estado = false;
            if (dataGridViewUsuarios.SelectedRows.Count > 0)
            {
                DialogResult resultAccion = MessageBox.Show("¿Desea eliminar el usuario?",
                  "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultAccion == DialogResult.Yes)
                {
                    idUsuario = dataGridViewUsuarios.CurrentRow.Cells["idusuario"].Value.ToString();
                    //estado = Convert.ToBoolean(dataGridViewUsuarios.CurrentRow.Cells["EstadoUsuario"].Value.ToString());

                   
                    objetoCN.EliminarUsuarios(idUsuario);
                    ListarDatosUsuarios();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor");
            }
        }

      
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            Buscar();
        }

        /// <summary>
        /// Metodo carga los datos encontrados por termino de busqueda de la tabla usuarios, en el dataGridView.
        /// </summary>
        private void Buscar()
        {
            CN_Usuario objetobusqueda = new CN_Usuario();
            dataGridViewUsuarios.DataSource = objetobusqueda.BuscarUsuarios(txtBuscar.Text);
        }

        
    }
    }

    


