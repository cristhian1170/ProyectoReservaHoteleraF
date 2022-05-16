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
    public partial class FormMantReserva : Form
    {
        CN_Reserva objetoCN = new CN_Reserva();
        public string idReserva= null;
        public string Operacion = "";

        public bool estadoDisponibleArticulo = false;
        public FormMantReserva()
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
        private void FormMantReserva_Load(object sender, EventArgs e)
        {
           


        }

        public void MostrarUsuarios()
        {
            CN_Usuario objeto = new CN_Usuario();

            cmbUsuario.DataSource = objeto.ListarUsuarios();
            cmbUsuario.DisplayMember = "nombres";
            cmbUsuario.ValueMember = "idusuario";
        }

        public void MostrarClientes()
        {
            CN_Cliente objeto = new CN_Cliente();

            cmbCliente.DataSource = objeto.ListarClientes();
            cmbCliente.DisplayMember = "NombreCompleto";
            cmbCliente.ValueMember = "IdCliente";
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


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.txtPrecio.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese precio", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPrecio.Select();
                return;
            }
            if (this.ocupacion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese ocupacion ", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ocupacion.Select();
                return;
            }
            if (this.txtNombreTomador.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese nombre tomador", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtNombreTomador.Select();
                return;
            }
            if (this.cantidad.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese cantidad", "Mensaje de Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cantidad.Select();
                return;
            }




            //INSERTAR
            if (Operacion.Equals("Insertar"))
            {
                try
                {
                    
                    objetoCN.InsertarReservas(dtFechaInicio.Text,dtFechaFin.Text,txtPrecio.Text,ocupacion.Text,txtNombreTomador.Text,cantidad.Text,cmbCliente.SelectedValue.ToString(),cmbUsuario.SelectedValue.ToString(),cmbHotel.SelectedValue.ToString(),cmbHabitacion.SelectedValue.ToString());
                    MessageBox.Show("Reserva Registrada Correctamente", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    objetoCN.EditarReservas(dtFechaInicio.Text, dtFechaFin.Text, txtPrecio.Text, ocupacion.Text, txtNombreTomador.Text, cantidad.Text, cmbCliente.SelectedValue.ToString(), cmbUsuario.SelectedValue.ToString(), cmbHotel.SelectedValue.ToString(), cmbHabitacion.SelectedValue.ToString(), idReserva);
                    MessageBox.Show("Se edito correctamente", "Mensaje Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
