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
    public partial class FormMantUser : Form
    {
        CN_Usuario objetoCN = new CN_Usuario();
        public string idUsuario = null;
        public string Operacion = "";
        
        public FormMantUser()
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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (this.txtUser.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Usuario", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUser.Select();
                return;
            }
            if (this.txtNombre.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese Nombres", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombre.Select();
                return;
            }
            if (this.txtCorreo.Text.Length == 0)
            {
                MessageBox.Show("Ingrese Correo", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCorreo.Select();
                return;
            }

            if (!this.txtCorreo.Text.Contains("@") && !this.txtCorreo.Text.Contains("."))
            {
                MessageBox.Show("Ingrese Correo Valido", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCorreo.Select();
                return;
            }
            if (this.txtClave.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese Clave", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtClave.Select();
                return;
            }
         

            if (Operacion.Equals("Insertar"))
            {

                try
                {
                    objetoCN.InsertarUsuarios(txtUser.Text, txtNombre.Text, txtCorreo.Text, txtClave.Text, ckEstado.Checked.ToString(), ckAdministrador.Checked.ToString(), DateTime.Now.ToString());
                    MessageBox.Show("Usuario ingresado correctamente!", "Mensaje exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    objetoCN.EditarUsuarios(txtUser.Text, txtNombre.Text, txtCorreo.Text, txtClave.Text, ckEstado.Checked.ToString(), ckAdministrador.Checked.ToString(), idUsuario);
                    MessageBox.Show("Usuario editado correctamente!", "Mensaje exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }
        }

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
