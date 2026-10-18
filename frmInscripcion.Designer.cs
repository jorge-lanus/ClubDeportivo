namespace ClubDeportivo
{
    partial class frmInscripcion
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
            this.grpDocumento = new System.Windows.Forms.GroupBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.rbSocio = new System.Windows.Forms.RadioButton();
            this.rbNoSocio = new System.Windows.Forms.RadioButton();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.chkAptoFisico = new System.Windows.Forms.CheckBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.grpDocumento.SuspendLayout();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();
            //
            // grpDocumento
            //
            this.grpDocumento.Controls.Add(this.lblTipoDoc);
            this.grpDocumento.Controls.Add(this.cmbTipoDoc);
            this.grpDocumento.Controls.Add(this.lblDni);
            this.grpDocumento.Controls.Add(this.txtDni);
            this.grpDocumento.Controls.Add(this.btnVerificar);
            this.grpDocumento.Location = new System.Drawing.Point(20, 15);
            this.grpDocumento.Name = "grpDocumento";
            this.grpDocumento.Size = new System.Drawing.Size(500, 115);
            this.grpDocumento.TabIndex = 0;
            this.grpDocumento.TabStop = false;
            this.grpDocumento.Text = "1. Verificar si la persona ya está registrada";
            //
            // lblTipoDoc
            //
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Location = new System.Drawing.Point(20, 35);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(98, 13);
            this.lblTipoDoc.TabIndex = 0;
            this.lblTipoDoc.Text = "Tipo de documento";
            //
            // cmbTipoDoc
            //
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(150, 31);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(150, 21);
            this.cmbTipoDoc.TabIndex = 1;
            //
            // lblDni
            //
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(20, 72);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(44, 13);
            this.lblDni.TabIndex = 2;
            this.lblDni.Text = "Número";
            //
            // txtDni
            //
            this.txtDni.Location = new System.Drawing.Point(150, 68);
            this.txtDni.MaxLength = 15;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(150, 20);
            this.txtDni.TabIndex = 3;
            //
            // btnVerificar
            //
            this.btnVerificar.Location = new System.Drawing.Point(335, 62);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(140, 30);
            this.btnVerificar.TabIndex = 4;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            //
            // lblEstado
            //
            this.lblEstado.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblEstado.Location = new System.Drawing.Point(20, 137);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(500, 36);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Ingrese el tipo y número de documento y presione Verificar.";
            //
            // grpDatos
            //
            this.grpDatos.Controls.Add(this.rbSocio);
            this.grpDatos.Controls.Add(this.rbNoSocio);
            this.grpDatos.Controls.Add(this.lblNombre);
            this.grpDatos.Controls.Add(this.txtNombre);
            this.grpDatos.Controls.Add(this.lblApellido);
            this.grpDatos.Controls.Add(this.txtApellido);
            this.grpDatos.Controls.Add(this.lblTelefono);
            this.grpDatos.Controls.Add(this.txtTelefono);
            this.grpDatos.Controls.Add(this.chkAptoFisico);
            this.grpDatos.Controls.Add(this.lblMonto);
            this.grpDatos.Controls.Add(this.txtMonto);
            this.grpDatos.Enabled = false;
            this.grpDatos.Location = new System.Drawing.Point(20, 180);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(500, 295);
            this.grpDatos.TabIndex = 2;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "2. Datos de la persona";
            //
            // rbSocio
            //
            this.rbSocio.AutoSize = true;
            this.rbSocio.Checked = true;
            this.rbSocio.Location = new System.Drawing.Point(20, 30);
            this.rbSocio.Name = "rbSocio";
            this.rbSocio.Size = new System.Drawing.Size(52, 17);
            this.rbSocio.TabIndex = 0;
            this.rbSocio.TabStop = true;
            this.rbSocio.Text = "Socio";
            this.rbSocio.UseVisualStyleBackColor = true;
            this.rbSocio.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            //
            // rbNoSocio
            //
            this.rbNoSocio.AutoSize = true;
            this.rbNoSocio.Location = new System.Drawing.Point(150, 30);
            this.rbNoSocio.Name = "rbNoSocio";
            this.rbNoSocio.Size = new System.Drawing.Size(137, 17);
            this.rbNoSocio.TabIndex = 1;
            this.rbNoSocio.Text = "No socio (pase diario)";
            this.rbNoSocio.UseVisualStyleBackColor = true;
            this.rbNoSocio.CheckedChanged += new System.EventHandler(this.rbTipo_CheckedChanged);
            //
            // lblNombre
            //
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 75);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            //
            // txtNombre
            //
            this.txtNombre.Location = new System.Drawing.Point(150, 71);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(320, 20);
            this.txtNombre.TabIndex = 3;
            //
            // lblApellido
            //
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(20, 112);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(49, 13);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "Apellido";
            //
            // txtApellido
            //
            this.txtApellido.Location = new System.Drawing.Point(150, 108);
            this.txtApellido.MaxLength = 50;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(320, 20);
            this.txtApellido.TabIndex = 5;
            //
            // lblTelefono
            //
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(20, 149);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(49, 13);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono";
            //
            // txtTelefono
            //
            this.txtTelefono.Location = new System.Drawing.Point(150, 145);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(320, 20);
            this.txtTelefono.TabIndex = 7;
            //
            // chkAptoFisico
            //
            this.chkAptoFisico.AutoSize = true;
            this.chkAptoFisico.Location = new System.Drawing.Point(150, 187);
            this.chkAptoFisico.Name = "chkAptoFisico";
            this.chkAptoFisico.Size = new System.Drawing.Size(149, 17);
            this.chkAptoFisico.TabIndex = 8;
            this.chkAptoFisico.Text = "Apto físico presentado";
            this.chkAptoFisico.UseVisualStyleBackColor = true;
            //
            // lblMonto
            //
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(20, 228);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(93, 13);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "Cuota mensual ($)";
            //
            // txtMonto
            //
            this.txtMonto.Location = new System.Drawing.Point(150, 224);
            this.txtMonto.MaxLength = 10;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(150, 20);
            this.txtMonto.TabIndex = 10;
            //
            // btnGuardar
            //
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(20, 490);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 36);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.Location = new System.Drawing.Point(195, 490);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 36);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // btnCerrar
            //
            this.btnCerrar.Location = new System.Drawing.Point(370, 490);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(150, 36);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // frmInscripcion
            //
            this.AcceptButton = this.btnVerificar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(540, 545);
            this.Controls.Add(this.grpDocumento);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.grpDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInscripcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inscripción (socio / no socio)";
            this.Load += new System.EventHandler(this.frmInscripcion_Load);
            this.grpDocumento.ResumeLayout(false);
            this.grpDocumento.PerformLayout();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpDocumento;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.RadioButton rbSocio;
        private System.Windows.Forms.RadioButton rbNoSocio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.CheckBox chkAptoFisico;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
