namespace CapaPresentacion
{
    partial class FormAdministradores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dataGridViewAdministradores = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEditarF2 = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdministradores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.eliminar_foto;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.Location = new System.Drawing.Point(315, 169);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(124, 37);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // dataGridViewAdministradores
            // 
            this.dataGridViewAdministradores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAdministradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAdministradores.Location = new System.Drawing.Point(39, 229);
            this.dataGridViewAdministradores.Name = "dataGridViewAdministradores";
            this.dataGridViewAdministradores.Size = new System.Drawing.Size(704, 282);
            this.dataGridViewAdministradores.TabIndex = 25;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtBuscar.Location = new System.Drawing.Point(269, 108);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(293, 21);
            this.txtBuscar.TabIndex = 26;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label4.Location = new System.Drawing.Point(210, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 27;
            this.label4.Text = "Buscar";
            // 
            // btnEditarF2
            // 
            this.btnEditarF2.BackColor = System.Drawing.Color.White;
            this.btnEditarF2.FlatAppearance.BorderSize = 0;
            this.btnEditarF2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarF2.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnEditarF2.Image = global::CapaPresentacion.Properties.Resources.editar;
            this.btnEditarF2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditarF2.Location = new System.Drawing.Point(150, 169);
            this.btnEditarF2.Name = "btnEditarF2";
            this.btnEditarF2.Size = new System.Drawing.Size(100, 37);
            this.btnEditarF2.TabIndex = 28;
            this.btnEditarF2.Text = "Editar ";
            this.btnEditarF2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarF2.UseVisualStyleBackColor = false;
            this.btnEditarF2.Click += new System.EventHandler(this.btnEditarF2_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources._002_floppy_disk;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.Location = new System.Drawing.Point(535, 169);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 37);
            this.btnNuevo.TabIndex = 29;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(265, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 21);
            this.label1.TabIndex = 30;
            this.label1.Text = "______________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(315, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 22);
            this.label2.TabIndex = 31;
            this.label2.Text = "ADMINISTRADORES";
            // 
            // FormAdministradores
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(783, 601);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnEditarF2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridViewAdministradores);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAdministradores";
            this.Text = "Administradores";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAdministradores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEditarF2;
        private System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.DataGridView dataGridViewAdministradores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}