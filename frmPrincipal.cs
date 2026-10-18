using ClubDeportivo;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClubDeportivoForms
{
    public partial class frmPrincipal : Form
    {
        private Usuario usuarioActual;

        public frmPrincipal(Usuario u)
        {
            InitializeComponent();
            usuarioActual = u;
            lblBienvenida.Text = "Bienvenido/a, " + u.UsuarioNombre + " (" + u.Rol + ")";
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Today;
            CargarVencimientos();
        }

        // Muestra los socios con la última cuota vencida o que vence en la fecha elegida
        private void CargarVencimientos()
        {
            try
            {
                DataTable tabla = Cuota.ListarVencimientos(dtpFecha.Value);
                dgvVencimientos.DataSource = tabla;

                dgvVencimientos.Columns["Estado"].DisplayIndex = 0;          // Estado primero
                dgvVencimientos.Columns["Vencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvVencimientos.Columns["Monto"].DefaultCellStyle.Format = "N2";

                // Rojo = vencida sin renovar | Amarillo = vence en la fecha elegida
                int vencidas = 0;
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    bool vencida = Convert.ToString(tabla.Rows[i]["Estado"]).StartsWith("Vencida");
                    if (vencida) vencidas++;
                    dgvVencimientos.Rows[i].DefaultCellStyle.BackColor =
                        vencida ? Color.FromArgb(255, 218, 218) : Color.FromArgb(255, 243, 205);
                }
                dgvVencimientos.ClearSelection();

                if (tabla.Rows.Count == 0)
                    lblCantidad.Text = "Sin cuotas pendientes a esa fecha. Todo al día.";
                else
                    lblCantidad.Text = tabla.Rows.Count + " socio(s) con cuota pendiente: "
                        + vencidas + " vencida(s) y " + (tabla.Rows.Count - vencidas) + " que vence(n) en la fecha.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los vencimientos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarVencimientos();
        }

        // Dos procesos distintos, cada uno con su propia pantalla
        private void NuevoSocio_Click(object sender, EventArgs e)
        {
            new frmNuevoSocio().ShowDialog();
            CargarVencimientos();   // el socio nuevo queda al día
        }

        private void PaseDiario_Click(object sender, EventArgs e)
        {
            new frmPaseDiario().ShowDialog();
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCobro_Click(object sender, EventArgs e)
        
        {
            // 1. Instanciamos (creamos) el formulario de cobro
            Frmcobro ventanaCobro = new Frmcobro();

            // 2. Lo mostramos en pantalla
            ventanaCobro.ShowDialog();
        }
    }
}
