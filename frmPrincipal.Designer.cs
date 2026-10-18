namespace ClubDeportivoForms
{
    partial class frmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuInscripcion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNuevoSocio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaseDiario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnNuevoSocio = new System.Windows.Forms.Button();
            this.btnPaseDiario = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.dgvVencimientos = new System.Windows.Forms.DataGridView();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.btnCobro = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInscripcion,
            this.menuSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(960, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuInscripcion
            // 
            this.menuInscripcion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNuevoSocio,
            this.menuPaseDiario});
            this.menuInscripcion.Name = "menuInscripcion";
            this.menuInscripcion.Size = new System.Drawing.Size(77, 20);
            this.menuInscripcion.Text = "Inscripción";
            // 
            // menuNuevoSocio
            // 
            this.menuNuevoSocio.Name = "menuNuevoSocio";
            this.menuNuevoSocio.Size = new System.Drawing.Size(187, 22);
            this.menuNuevoSocio.Text = "Nuevo socio";
            this.menuNuevoSocio.Click += new System.EventHandler(this.NuevoSocio_Click);
            // 
            // menuPaseDiario
            // 
            this.menuPaseDiario.Name = "menuPaseDiario";
            this.menuPaseDiario.Size = new System.Drawing.Size(187, 22);
            this.menuPaseDiario.Text = "Pase diario (no socio)";
            this.menuPaseDiario.Click += new System.EventHandler(this.PaseDiario_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(41, 20);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBienvenida.Location = new System.Drawing.Point(20, 38);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(97, 20);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido/a";
            // 
            // btnNuevoSocio
            // 
            this.btnNuevoSocio.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNuevoSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoSocio.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNuevoSocio.ForeColor = System.Drawing.Color.White;
            this.btnNuevoSocio.Location = new System.Drawing.Point(20, 72);
            this.btnNuevoSocio.Name = "btnNuevoSocio";
            this.btnNuevoSocio.Size = new System.Drawing.Size(220, 46);
            this.btnNuevoSocio.TabIndex = 2;
            this.btnNuevoSocio.Text = "Nuevo socio";
            this.btnNuevoSocio.UseVisualStyleBackColor = false;
            this.btnNuevoSocio.Click += new System.EventHandler(this.NuevoSocio_Click);
            // 
            // btnPaseDiario
            // 
            this.btnPaseDiario.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPaseDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaseDiario.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPaseDiario.ForeColor = System.Drawing.Color.White;
            this.btnPaseDiario.Location = new System.Drawing.Point(255, 72);
            this.btnPaseDiario.Name = "btnPaseDiario";
            this.btnPaseDiario.Size = new System.Drawing.Size(220, 46);
            this.btnPaseDiario.TabIndex = 3;
            this.btnPaseDiario.Text = "Pase diario (no socio)";
            this.btnPaseDiario.UseVisualStyleBackColor = false;
            this.btnPaseDiario.Click += new System.EventHandler(this.PaseDiario_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 140);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(174, 25);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Cuotas por cobrar";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(20, 182);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(58, 13);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "A la fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(90, 178);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 20);
            this.dtpFecha.TabIndex = 6;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(215, 173);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(100, 30);
            this.btnConsultar.TabIndex = 7;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(335, 182);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(0, 13);
            this.lblCantidad.TabIndex = 8;
            // 
            // dgvVencimientos
            // 
            this.dgvVencimientos.AllowUserToAddRows = false;
            this.dgvVencimientos.AllowUserToDeleteRows = false;
            this.dgvVencimientos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVencimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVencimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvVencimientos.Location = new System.Drawing.Point(20, 215);
            this.dgvVencimientos.MultiSelect = false;
            this.dgvVencimientos.Name = "dgvVencimientos";
            this.dgvVencimientos.ReadOnly = true;
            this.dgvVencimientos.RowHeadersVisible = false;
            this.dgvVencimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVencimientos.Size = new System.Drawing.Size(920, 300);
            this.dgvVencimientos.TabIndex = 9;
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.ForeColor = System.Drawing.Color.DimGray;
            this.lblLeyenda.Location = new System.Drawing.Point(20, 525);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(597, 13);
            this.lblLeyenda.TabIndex = 10;
            this.lblLeyenda.Text = "Rojo: cuota vencida sin renovar   |   Amarillo: vence en la fecha elegida   |   A" +
    "l pagar una cuota nueva, el socio sale de la lista";
            // 
            // btnCobro
            // 
            this.btnCobro.Location = new System.Drawing.Point(497, 72);
            this.btnCobro.Name = "btnCobro";
            this.btnCobro.Size = new System.Drawing.Size(174, 46);
            this.btnCobro.TabIndex = 11;
            this.btnCobro.Text = "Pagar";
            this.btnCobro.UseVisualStyleBackColor = true;
            this.btnCobro.Click += new System.EventHandler(this.btnCobro_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 555);
            this.Controls.Add(this.btnCobro);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.dgvVencimientos);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnPaseDiario);
            this.Controls.Add(this.btnNuevoSocio);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Club Deportivo";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVencimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuInscripcion;
        private System.Windows.Forms.ToolStripMenuItem menuNuevoSocio;
        private System.Windows.Forms.ToolStripMenuItem menuPaseDiario;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnNuevoSocio;
        private System.Windows.Forms.Button btnPaseDiario;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.DataGridView dgvVencimientos;
        private System.Windows.Forms.Label lblLeyenda;
        private System.Windows.Forms.Button btnCobro;
    }
}
