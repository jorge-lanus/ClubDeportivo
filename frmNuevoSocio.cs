using System;
using System.Windows.Forms;

namespace ClubDeportivoForms
{
    // INSCRIPCIÓN DE SOCIO: genera número de socio, primera cuota y carnet.
    public partial class frmNuevoSocio : Form
    {
        public frmNuevoSocio()
        {
            InitializeComponent();
        }

        private void frmNuevoSocio_Load(object sender, EventArgs e)
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

            cmbSexo.Items.Clear();
            cmbSexo.Items.Add("Varón");
            cmbSexo.Items.Add("Mujer");

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
                    // FLUJO ALTERNATIVO: ya está registrada -> se rechaza
                    MessageBox.Show(
                        "La persona ya está registrada. Se rechaza la inscripción.\n\n" + existente.ObtenerFicha(),
                        "Inscripción rechazada", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    lblEstado.Text = "Documento ya registrado. Ingrese otro para continuar.";
                    txtDni.SelectAll();
                    txtDni.Focus();
                    return;
                }

                // FLUJO NORMAL: no existe -> se habilita el paso 2
                cmbTipoDoc.Enabled = false;
                txtDni.Enabled = false;
                btnVerificar.Enabled = false;

                grpDatos.Enabled = true;
                btnGuardar.Enabled = true;
                this.AcceptButton = btnGuardar;

                lblEstado.Text = "Documento no registrado. Complete los datos.";
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de base de datos:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Vista previa de la imagen según el sexo elegido
        private void cmbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            picAvatar.Image = cmbSexo.SelectedIndex < 0 ? null : Avatar.Crear(cmbSexo.Text, 34);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // PASO 2: guardar el socio
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal cuota;
                if (!decimal.TryParse(txtMonto.Text, out cuota) || cuota <= 0)
                    throw new ArgumentException("Ingrese una cuota mensual válida, mayor que cero.");

                Socio s = new Socio();
                s.TipoDocumento = cmbTipoDoc.Text;
                s.Dni = txtDni.Text;
                s.Nombre = txtNombre.Text;
                s.Apellido = txtApellido.Text;
                s.Telefono = txtTelefono.Text;
                s.AptoFisico = chkAptoFisico.Checked;
                s.Sexo = cmbSexo.Text;               // valida: debe elegir Varón o Mujer
                s.RedSocial = txtRedSocial.Text;     // opcional; si se completa, debe empezar con @
                s.MontoCuota = cuota;

                Persona p = s;   // polimorfismo: se usa como Persona

                if (p.Registrar())
                {
                    new frmComprobante(p).ShowDialog();   // carnet de socio
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar al socio.", "Error",
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

        // Vuelve al paso 1
        private void Limpiar()
        {
            cmbTipoDoc.Enabled = true;
            if (cmbTipoDoc.Items.Count > 0)
                cmbTipoDoc.SelectedIndex = 0;
            txtDni.Enabled = true;
            txtDni.Clear();
            btnVerificar.Enabled = true;
            lblEstado.Text = "Ingrese el tipo y número de documento y presione Verificar.";

            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtMonto.Clear();
            chkAptoFisico.Checked = false;
            cmbSexo.SelectedIndex = -1;
            txtRedSocial.Clear();
            lblInfo.Text = "Al inscribirse se cobra la primera cuota hoy y vence el "
                + DateTime.Today.AddMonths(1).ToString("dd/MM/yyyy") + ". Se entrega el carnet de socio.";
            grpDatos.Enabled = false;
            btnGuardar.Enabled = false;

            this.AcceptButton = btnVerificar;
            txtDni.Focus();
        }
    }
}
