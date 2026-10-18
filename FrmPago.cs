using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class FrmPago : Form
    {
        private decimal _montoTotal;
        private int _socioId;

        public FrmPago(decimal montoTotal, int socioId)
        {
            InitializeComponent();
            _montoTotal = montoTotal;
            _socioId = socioId;
        }

        private void FrmPago_Load(object sender, EventArgs e)
        {
            lblMonto.Text = $"Total a pagar: ${_montoTotal:N2}";

            cmbCuotas.Items.AddRange(new object[] {
                "1 Cuota (Sin interés)",
                "3 Cuotas (Sin interés)",
                "6 Cuotas (Sin interés)",
                "12 Cuotas (Sin interés)"
            });

            cmbCuotas.SelectedIndex = 0; // Esto dispara el evento de abajo

            GenerarQR();
        }

        private void cmbCuotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuotas.SelectedItem == null) return;

            int cantidadCuotas = 1;
            string textoSeleccionado = cmbCuotas.SelectedItem.ToString();

            if (textoSeleccionado.StartsWith("3")) cantidadCuotas = 3;
            else if (textoSeleccionado.StartsWith("6")) cantidadCuotas = 6;
            else if (textoSeleccionado.StartsWith("12")) cantidadCuotas = 12;

            decimal valorPorCuota = _montoTotal / cantidadCuotas;

            if (cantidadCuotas == 1)
                lblValorCuotas.Text = "Pago único en 1 cuota.";
            else
                lblValorCuotas.Text = $"{cantidadCuotas} cuotas de ${valorPorCuota:N2} por mes.";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Pago aprobado con éxito!\nEl carnet del socio ya se encuentra habilitado.",
                          "Pago Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void GenerarQR()
        {
            string textoQR = $"Pago Club Deportivo - Socio: {_socioId} - Total: ${_montoTotal}";
            string urlQR = $"https://api.qrserver.com/v1/create-qr-code/?size=200x200&data={Uri.EscapeDataString(textoQR)}";

            try
            {
                using (WebClient wc = new WebClient())
                {
                    picQR.Image = Image.FromStream(wc.OpenRead(urlQR));
                }
            }
            catch
            {
                MessageBox.Show("No se pudo cargar la imagen del QR. Verifique su conexión a internet.",
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
} // <-- Acá termina FrmPago, sin llaves de más
