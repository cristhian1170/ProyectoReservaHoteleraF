using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormFiltrarReserva : Form
    {
        public FormFiltrarReserva()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            FormReportesReservas frm = new FormReportesReservas();
            frm.FechaInicio = Convert.ToDateTime(dtFechaInicio.Text);
            frm.FechaFin = Convert.ToDateTime(dtFechaFin.Text);


            frm.ShowDialog();
        }
    }
}
