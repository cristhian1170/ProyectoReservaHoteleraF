using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FormMantHotel : Form
    {
        CN_Hotel objetoCN = new CN_Hotel();
        public string idHotel = null;
        public string Operacion = "";

        public bool estadoDisponibleArticulo = false;
        public FormMantHotel()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormMantHotel_Load(object sender, EventArgs e)
        {
           
        }

        public void ListarNombresAdministradores()
        {
            cmbAdministrador.DataSource = objetoCN.ListarNombresAdministradores();
            cmbAdministrador.DisplayMember = "nombre";
            cmbAdministrador.ValueMember = "administrador_id";
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese nombre", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Select();
                return;
            }
            if (this.txtDescripcion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese descripcion ", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDescripcion.Select();
                return;
            }
            if (this.txtCategoria.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese categoria", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCategoria.Select();
                return;
            }

            if (this.txtDomicilio.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese domicilio", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDomicilio.Select();
                return;
            }
            if (this.txtLocalidad.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese localidad ", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtLocalidad.Select();
                return;
            }
            if (this.txtProvincia.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese provincia", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtProvincia.Select();
                return;
            }
            if (this.txtCodPostal.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese CodPostal ", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCodPostal.Select();
                return;
            }
            if (this.mskTelefono.Text.Trim() == "(   )    -")
            {
                MessageBox.Show("Ingrese telefono en formato correcto", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.mskTelefono.Select();
                return;
            }



            //INSERTAR
            if (Operacion.Equals("Insertar"))
            {
                try
                {
                    
                    objetoCN.InsertarHoteles(txtNombre.Text,txtDescripcion.Text,txtCategoria.Text, txtDomicilio.Text, txtLocalidad.Text, txtProvincia.Text, txtCodPostal.Text, mskTelefono.Text,cmbAdministrador.SelectedValue.ToString());
                    MessageBox.Show("Hotel Registrado Correctamente", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos por: " + ex);
                }
            }
            else if (Operacion.Equals("Editar"))
            {

                try
                {
                    objetoCN.EditarHoteles(txtNombre.Text, txtDescripcion.Text,txtCategoria.Text,txtDomicilio.Text,txtLocalidad.Text, txtProvincia.Text,
                        txtCodPostal.Text, mskTelefono.Text,cmbAdministrador.SelectedValue.ToString(),idHotel);

                    MessageBox.Show("Se edito correctamente", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }

        }

        private void estadoArticulo()
        {
            //estadoCheckBox.Visible = false;
           // estadoCheckBox.Checked = true;
        }
        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
