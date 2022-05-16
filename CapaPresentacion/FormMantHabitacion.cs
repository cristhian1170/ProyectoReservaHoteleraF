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
    public partial class FormMantHabitacion : Form
    {
        CN_Habitacion objetoCN = new CN_Habitacion();
        public string idHabitacion = null;
        public string Operacion = "";

        public bool estadoDisponibleArticulo = false;
        public FormMantHabitacion()
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

               // estadoArticulo();

          //  }

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
            if (this.txtCapacidad.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese capacidad", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCapacidad.Select();
                return;
            }

            estadoArticulo();

            

            //INSERTAR
            if (Operacion.Equals("Insertar"))
            {
                try
                {
                    
                    objetoCN.InsertarHabitaciones(txtNombre.Text, txtCapacidad.Text);
                    MessageBox.Show("Habitacion Registrada Correctamente", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    objetoCN.EditarHabitaciones(txtNombre.Text, txtCapacidad.Text, idHabitacion);
                    MessageBox.Show("La habitacion se edito correctamente", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
           // estadoCheckBox.Visible = false;
           // estadoCheckBox.Checked = true;
        }
        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
