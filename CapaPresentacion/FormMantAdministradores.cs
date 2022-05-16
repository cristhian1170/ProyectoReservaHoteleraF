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
    public partial class FormMantAdministradores : Form
    {
        CN_Administradores objetoCN = new CN_Administradores();
        public string idAdministrador = null;
        public string Operacion = "";

        public bool estadoDisponibleArticulo = false;
        public FormMantAdministradores()
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

        private void FormMantArticulo_Load(object sender, EventArgs e)
        {
           // if (Program.Cargo != "Admin" && Program.Cargo != "Administrador") {

           //     estadoArticulo();

           // }

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
           

           // estadoArticulo();

            if (estadoCheckBox.Checked)
            {
                estadoDisponibleArticulo = true;
            }
            else
            {
                estadoDisponibleArticulo = false;
            }

            //INSERTAR
            if (Operacion.Equals("Insertar"))
            {
                try
                {
                    
                    objetoCN.InsertarAdministradores(txtNombre.Text, estadoDisponibleArticulo.ToString());
                    MessageBox.Show("Administrador Registrado Correctamente", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    objetoCN.EditarAdministradores(txtNombre.Text, estadoDisponibleArticulo.ToString(),idAdministrador);
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
            estadoCheckBox.Visible = false;
            estadoCheckBox.Checked = true;
        }
        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
