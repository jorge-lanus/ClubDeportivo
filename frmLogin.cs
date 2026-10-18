using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivoForms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
    string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Complete usuario y clave.", "Ingreso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Usuario u = new Usuario();
                u.UsuarioNombre = txtUsuario.Text.Trim();
                u.EstablecerClave(txtClave.Text);

                if (u.ValidarIngreso())
                {
                    frmPrincipal principal = new frmPrincipal(u);
                    principal.FormClosed += (s, a) => this.Close();
                    this.Hide();
                    principal.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o clave incorrectos.", "Ingreso",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClave.Clear();
                    txtClave.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con la base de datos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
