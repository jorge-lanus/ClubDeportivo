namespace ClubDeportivo
{
    partial class frmComprobante
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtFicha = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(120, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Comprobante";
            //
            // txtFicha
            //
            this.txtFicha.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtFicha.Location = new System.Drawing.Point(20, 55);
            this.txtFicha.Multiline = true;
            this.txtFicha.Name = "txtFicha";
            this.txtFicha.ReadOnly = true;
            this.txtFicha.Size = new System.Drawing.Size(400, 240);
            this.txtFicha.TabIndex = 1;
            this.txtFicha.TabStop = false;
            //
            // btnCerrar
            //
            this.btnCerrar.Location = new System.Drawing.Point(160, 312);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(120, 34);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // frmComprobante
            //
            this.AcceptButton = this.btnCerrar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCerrar;
            this.ClientSize = new System.Drawing.Size(440, 365);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtFicha);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmComprobante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Carnet / Comprobante";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtFicha;
        private System.Windows.Forms.Button btnCerrar;
    }
}
