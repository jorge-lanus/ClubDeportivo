using System;
using System.Windows.Forms;

namespace ClubDeportivo
{
    public partial class frmInscripcion : Form
    {
        public frmInscripcion()
        {
            InitializeComponent();
        }

        private void frmInscripcion_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTipoDoc.Items.Clear();
                foreach (string tipo in Persona.ObtenerTiposDocumento())
                    cmbTipoDoc.Items.Add(tipo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los tipos de documento:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Limpiar();
        }

        // PASO 1: buscar por TIPO de documento + NÚMERO
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (cmbTipoDoc.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione el tipo de documento.", "Verificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingrese el número de documento.", "Verificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            try
            {
                Persona existente = Persona.Buscar(cmbTipoDoc.Text, txtDni.Text.Trim());

                if (existente != null)
                {
                    // FLUJO ALTERNATIVO: la persona ya está registrada.
                    // El sistema rechaza la inscripción y muestra un mensaje.
                    MessageBox.Show(
                        "La persona ya está registrada. Se rechaza la inscripción.\n\n" + existente.ObtenerFicha(),
                        "Inscripción rechazada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    lblEstado.Text = "Documento ya registrado. Ingrese otro para continuar.";
                    txtDni.SelectAll();
                    txtDni.Focus();
                    return;
                }

                // FLUJO NORMAL: no existe, se habilita la carga de datos.
                cmbTipoDoc.Enabled = false;
                txtDni.Enabled = false;
                btnVerificar.Enabled = false;

                grpDatos.Enabled = true;
                btnGuardar.Enabled = true;
                this.AcceptButton = btnGuardar;

                lblEstado.Text = "Documento no registrado. Complete los datos de la persona.";
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // La etiqueta del importe cambia según el tipo de persona
        private void rbTipo_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEtiquetaMonto();
        }

        private void ActualizarEtiquetaMonto()
        {
            lblMonto.Text = rbSocio.Checked ? "Cuota mensual ($)" : "Tarifa de pase ($)";
        }

        // PASO 2: guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal monto;
                if (!decimal.TryParse(txtMonto.Text, out monto) || monto <= 0)
                    throw new ArgumentException("Ingrese un importe válido, mayor que cero.");

                Persona p;   // variable del tipo base: puede ser Socio o NoSocio

                if (rbSocio.Checked)
                {
                    Socio s = new Socio();
                    s.MontoCuota = monto;
                    p = s;
                }
                else
                {
                    NoSocio n = new NoSocio();
                    n.TarifaPase = monto;
                    p = n;
                }

                // Datos comunes: están definidos una sola vez, en Persona
                p.TipoDocumento = cmbTipoDoc.Text;
                p.Dni = txtDni.Text;
                p.Nombre = txtNombre.Text;
                p.Apellido = txtApellido.Text;
                p.Telefono = txtTelefono.Text;
                p.AptoFisico = chkAptoFisico.Checked;   // vale para socios y no socios

                if (p.Registrar())   // cada clase ejecuta su propia versión
                {
                    // Entrega del carnet (socio) o del comprobante (no socio)
                    frmComprobante f = new frmComprobante(p);
                    f.ShowDialog();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar a la persona.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)          // dato vacío o inválido
            {
                MessageBox.Show(ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)  // documento duplicado
            {
                MessageBox.Show(ex.Message, "Documento duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Deja el formulario como al abrirlo: vuelve al paso 1 (verificar documento)
        private void Limpiar()
        {
            // Paso 1
            cmbTipoDoc.Enabled = true;
            if (cmbTipoDoc.Items.Count > 0)
                cmbTipoDoc.SelectedIndex = 0;
            txtDni.Enabled = true;
            txtDni.Clear();
            btnVerificar.Enabled = true;
            lblEstado.Text = "Ingrese el tipo y número de documento y presione Verificar.";

            // Paso 2
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtMonto.Clear();
            chkAptoFisico.Checked = false;
            rbSocio.Checked = true;
            ActualizarEtiquetaMonto();
            grpDatos.Enabled = false;
            btnGuardar.Enabled = false;

            this.AcceptButton = btnVerificar;
            txtDni.Focus();
        }
    }
}
