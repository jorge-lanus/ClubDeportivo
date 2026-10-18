using ClubDeportivoForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class Frmcobro : Form
    {

        private Socio socioSeleccionado = null;

        public Frmcobro()
        {
            InitializeComponent();
        }
        // 1. EVENTO LOAD (Al abrir la ventana)
        private void cobro_Load(object sender, EventArgs e)
        {
            {
                // Aseguramos que el botón de pago empiece bloqueado
                btnProcederPago.Enabled = false;
                lblInfoSocio.ForeColor = Color.Gray;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();

            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Usamos el método Buscar que ya tenés en tu clase Persona
                // Asumimos que el tipo de documento es "DNI"
                Persona persona = Persona.Buscar("DNI", dni);

                if (persona == null)
                {
                    MessageBox.Show("No se encontró ninguna persona con ese DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimpiarFormulario();
                    return;
                }

                // Verificamos si es Socio o No Socio
                if (persona is Socio socio)
                {
                    socioSeleccionado = socio;
                    lblInfoSocio.Text = $"Socio: {socio.Apellido}, {socio.Nombre} (N° {socio.NumeroSocio})";
                    lblInfoSocio.ForeColor = Color.Green;

                    // Habilitamos el botón de pago
                    btnProcederPago.Enabled = true;
                }
                else
                {
                    MessageBox.Show("La persona existe pero es un No Socio. Para No Socios use 'Pase Diario'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnProcederPago_Click(object sender, EventArgs e)
        {
            if (socioSeleccionado == null)
            {
                MessageBox.Show("Primero debe buscar un socio válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validamos el monto
            if (!decimal.TryParse(txtMonto.Text.Trim(), out decimal montoACobrar) || montoACobrar <= 0)
            {
                MessageBox.Show("Ingrese un monto a cobrar válido (mayor a 0).", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamamos a la ventana de pago (FrmPago) pasándole el monto y el ID
            FrmPago ventanaPago = new FrmPago(montoACobrar, socioSeleccionado.Id);

            // ShowDialog pausa esta ventana hasta que FrmPago se cierre
            if (ventanaPago.ShowDialog() == DialogResult.OK)
            {
                // Si el pago fue exitoso...
                MessageBox.Show($"¡Cobro registrado con éxito para {socioSeleccionado.Nombre} {socioSeleccionado.Apellido}!\n\nEl carnet ya se encuentra habilitado.",
                                "Cobro Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ACÁ DEBERÍAS ACTUALIZAR LA BASE DE DATOS (Marcar cuota como paga)
                // Ejemplo: ActualizarCuotaEnBaseDeDatos(socioSeleccionado.Id, montoACobrar);

                // Limpiamos todo para el próximo cobro
                LimpiarFormulario();
            }

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Método auxiliar para limpiar la pantalla
        private void LimpiarFormulario()
        {
            txtDni.Clear();
            txtMonto.Text = "15000"; // Restaura el monto por defecto
            lblInfoSocio.Text = "Esperando DNI...";
            lblInfoSocio.ForeColor = Color.Gray;
            btnProcederPago.Enabled = false;
            socioSeleccionado = null;
            txtDni.Focus(); // Pone el cursor en el DNI para el siguiente
        }
    }
}
