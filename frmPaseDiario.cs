using ClubDeportivo;
using System;
using System.Windows.Forms;

namespace ClubDeportivoForms
{
    // PASE DIARIO (NO SOCIO): sin cuotas ni número de socio; se emite un comprobante válido por hoy.
    public partial class frmPaseDiario : Form
    {
        public frmPaseDiario()
        {
            InitializeComponent();
        }

        private void frmPaseDiario_Load(object sender, EventArgs e)
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

        // PASO 2: emitir el pase
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tarifa;
                if (!decimal.TryParse(txtMonto.Text, out tarifa) || tarifa <= 0)
                    throw new ArgumentException("Ingrese una tarifa de pase válida, mayor que cero.");

                NoSocio n = new NoSocio();
                n.TipoDocumento = cmbTipoDoc.Text;
                n.Dni = txtDni.Text;
                n.Nombre = txtNombre.Text;
                n.Apellido = txtApellido.Text;
                n.Telefono = txtTelefono.Text;   // opcional
                n.AptoFisico = chkAptoFisico.Checked;
                n.Sexo = cmbSexo.Text;               // valida: debe elegir Varón o Mujer
                n.RedSocial = txtRedSocial.Text;     // opcional; si se completa, debe empezar con @
                n.TarifaPase = tarifa;

                Persona p = n;   // polimorfismo: se usa como Persona

                if (p.Registrar())
                {
                    new frmComprobante(p).ShowDialog();   // comprobante de pase diario
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo emitir el pase.", "Error",
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
            lblInfo.Text = "Pase válido solo hoy, " + DateTime.Today.ToString("dd/MM/yyyy")
                + ". No genera cuotas ni número de socio.";
            grpDatos.Enabled = false;
            btnGuardar.Enabled = false;

            this.AcceptButton = btnVerificar;
            txtDni.Focus();
        }

        private void grpDocumento_Enter(object sender, EventArgs e)
        {

        }


    }
}
