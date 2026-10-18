using System;
using System.Windows.Forms;

namespace ClubDeportivo
{
    // Entrega del carnet (socio) o del comprobante de pase diario (no socio).
    // Recibe una Persona: el texto lo arma cada clase con su propio ObtenerFicha().
    public partial class frmComprobante : Form
    {
        public frmComprobante(Persona p)
        {
            InitializeComponent();

            string[] lineas = p.ObtenerFicha().Split('\n');

            // La primera línea es el título (CARNET DE SOCIO / COMPROBANTE DE PASE DIARIO)
            lblTitulo.Text = lineas[0];
            txtFicha.Text = string.Join("\r\n", lineas, 1, lineas.Length - 1);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
