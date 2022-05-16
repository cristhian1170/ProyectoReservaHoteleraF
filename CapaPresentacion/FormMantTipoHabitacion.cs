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
    public partial class FormMantTipoHabitacion : Form
    {
        CN_TipoHabitacion objetoCN = new CN_TipoHabitacion();
        public string idTipoHabitacion = null;
        public string Operacion = "";

        public bool estadoDisponibleArticulo = false;
        public FormMantTipoHabitacion()
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

        private void FormMantTipoHabitacion_Load(object sender, EventArgs e)
        {
           
        }

        public void MostrarHoteles()
        {

            CN_TipoHabitacion objeto = new CN_TipoHabitacion();
           
            cmbHotel.DataSource = objeto.ListarNombresHoteles();
            cmbHotel.DisplayMember = "nombre";
            cmbHotel.ValueMember = "idhotel";
        }

        public void MostrarHabitaciones()
        {

            CN_TipoHabitacion objeto = new CN_TipoHabitacion();

            cmbHabitacion.DataSource = objeto.ListarNombresHabitaciones();
            cmbHabitacion.DisplayMember = "nombre";
            cmbHabitacion.ValueMember = "idhabitacion";
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
            if (this.txtDescripcion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese descripcion", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDescripcion.Select();
                return;
            }
            if (this.txtPrecio.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese precio ", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPrecio.Select();
                return;
            }
            if (this.txtNumeroHabitaciones.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese habitaciones", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNumeroHabitaciones.Select();
                return;
            }

           /* estadoArticulo();

            if (estadoCheckBox.Checked)
            {
                estadoDisponibleArticulo = true;
            }
            else
            {
                estadoDisponibleArticulo = false;
            }*/

            //INSERTAR
            if (Operacion.Equals("Insertar"))
            {
                try
                {
                    
                    objetoCN.InsertarTipoHabitaciones(cmbHotel.SelectedValue.ToString(),cmbHabitacion.SelectedValue.ToString(),txtDescripcion.Text,txtPrecio.Text, txtNumeroHabitaciones.Text);
                    MessageBox.Show("Tipo Habitacion Registrado Correctamente", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    objetoCN.EditarTipoHabitaciones(cmbHotel.SelectedValue.ToString(), cmbHabitacion.SelectedValue.ToString(), txtDescripcion.Text, txtPrecio.Text, txtNumeroHabitaciones.Text, idTipoHabitacion);
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
