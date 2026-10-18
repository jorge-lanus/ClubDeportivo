namespace ClubDeportivo
{
    partial class Frmcobro
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
            this.lblDNISocio = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblInfoSocio = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnProcederPago = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDNISocio
            // 
            this.lblDNISocio.AutoSize = true;
            this.lblDNISocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNISocio.Location = new System.Drawing.Point(195, 28);
            this.lblDNISocio.Name = "lblDNISocio";
            this.lblDNISocio.Size = new System.Drawing.Size(149, 25);
            this.lblDNISocio.TabIndex = 0;
            this.lblDNISocio.Text = "DNI de Socio";
            this.lblDNISocio.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(202, 74);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(141, 20);
            this.txtDni.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(213, 116);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(129, 45);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblInfoSocio
            // 
            this.lblInfoSocio.AutoSize = true;
            this.lblInfoSocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoSocio.Location = new System.Drawing.Point(205, 187);
            this.lblInfoSocio.Name = "lblInfoSocio";
            this.lblInfoSocio.Size = new System.Drawing.Size(129, 16);
            this.lblInfoSocio.TabIndex = 3;
            this.lblInfoSocio.Text = "Esperando DNI....";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(74, 232);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(80, 13);
            this.lblMonto.TabIndex = 4;
            this.lblMonto.Text = "Monto a Cobrar";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(215, 225);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(127, 20);
            this.txtMonto.TabIndex = 5;
            // 
            // btnProcederPago
            // 
            this.btnProcederPago.Enabled = false;
            this.btnProcederPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcederPago.Location = new System.Drawing.Point(420, 122);
            this.btnProcederPago.Name = "btnProcederPago";
            this.btnProcederPago.Size = new System.Drawing.Size(101, 39);
            this.btnProcederPago.TabIndex = 6;
            this.btnProcederPago.Text = "Pagar";
            this.btnProcederPago.UseVisualStyleBackColor = true;
            this.btnProcederPago.Click += new System.EventHandler(this.btnProcederPago_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(215, 290);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(128, 33);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnProcederPago);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblInfoSocio);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblDNISocio);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "cobro";
            this.Text = "Frmcobro";
            this.Load += new System.EventHandler(this.cobro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDNISocio;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblInfoSocio;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnProcederPago;
        private System.Windows.Forms.Button btnVolver;
    }
}