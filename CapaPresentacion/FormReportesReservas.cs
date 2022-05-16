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
    public partial class FormReportesReservas : Form
    {
        public FormReportesReservas()
        {
            InitializeComponent();
        }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }


        private void FormReportesReservas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.SpReportesReserva' table. You can move, or remove it, as needed.
            this.SpReportesReservaTableAdapter.Fill(this.DataSet1.SpReportesReserva, FechaInicio, FechaFin);

            this.reportViewer1.RefreshReport();
        }
    }
}
