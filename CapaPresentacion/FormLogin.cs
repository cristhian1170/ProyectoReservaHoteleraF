using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                CN_Empleado objEmpleado = new CN_Empleado();


                objEmpleado.Usuario = txtUsuario.Text;
                objEmpleado.Contraseña = txtClave.Text;
                SqlDataReader logueado = objEmpleado.IniciarSesion();

                if (objEmpleado.Usuario.ToString().Length > 0 && objEmpleado.Contraseña.ToString().Length > 0)
                {

                    if (logueado.Read() == true)
                    {

                        FormCafeteriaMarte frmMenu = new FormCafeteriaMarte();
                        Program.Usuario= logueado["usuario"].ToString();
                        Program.Nombres = logueado["nombres"].ToString();
                        Program.TipoUsuario = Convert.ToBoolean(logueado["is_admin"]);

                        frmMenu.Show();

                        this.Hide();

                    }
                    else
                    {

                        MessageBox.Show("Usuario o Clave incorrectos, favor intentar nuevamente", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {

                    MessageBox.Show("Usuario y Clave Requeridos", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }





            }
            catch (SqlException E)
            {

                MessageBox.Show("Error" + E.Message);
            }
        }

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelLogin_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
