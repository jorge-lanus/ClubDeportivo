// =====================================================
// Club Deportivo - Modelo de clases (según UML) - SQL Server
// VERSION 2
// Usa System.Data.SqlClient (incluido en .NET Framework, sin NuGet).
// Si el proyecto es .NET 6 o superior: instalar el paquete NuGet
// "Microsoft.Data.SqlClient" y cambiar el using por Microsoft.Data.SqlClient.
// =====================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ClubDeportivoForms
{
    // -------------------------------------------------
    // Acceso a datos (conexión compartida)
    // -------------------------------------------------
    public static class Conexion
    {
        // Ajustar el nombre del servidor según tu instalación:
        //   SQL Server Express : localhost\SQLEXPRESS
        //   LocalDB            : (localdb)\MSSQLLocalDB
        private const string Cadena =
            @"Server=localhost;Database=club_deportivo;Trusted_Connection=True;";

        public static SqlConnection Obtener()
        {
            return new SqlConnection(Cadena);
        }
    }

    // -------------------------------------------------
    // ABSTRACCIÓN + ENCAPSULAMIENTO: clase base abstracta
    // -------------------------------------------------
    public abstract class Persona
    {
        // Atributos protegidos: las subclases pueden usarlos, el exterior no
        protected int id;
        protected string tipoDocumento;
        protected string dni;
        protected string nombre;
        protected string apellido;
        protected string telefono;
        protected bool aptoFisico;   // lo necesitan socios Y no socios
        protected string sexo;       // "Varón" o "Mujer"
        protected string redSocial;  // opcional, formato @usuario

        // Propiedades públicas con validación
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string TipoDocumento
        {
            get { return tipoDocumento; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Seleccione el tipo de documento.");
                tipoDocumento = value.Trim();
            }
        }

        public string Dni
        {
            get { return dni; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El número de documento no puede estar vacío.");
                dni = value.Trim();
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value.Trim();
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El apellido no puede estar vacío.");
                apellido = value.Trim();
            }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public bool AptoFisico
        {
            get { return aptoFisico; }
            set { aptoFisico = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set
            {
                if (value != "Varón" && value != "Mujer")
                    throw new ArgumentException("Seleccione el sexo.");
                sexo = value;
            }
        }

        // Opcional; si se completa, debe empezar con @ (ej: @juan.perez)
        public string RedSocial
        {
            get { return redSocial; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    redSocial = "";
                    return;
                }
                string v = value.Trim();
                if (!Regex.IsMatch(v, @"^@[A-Za-z0-9._]{2,30}$"))
                    throw new ArgumentException(
                        "La red social debe empezar con @ y tener entre 2 y 30 letras, números, puntos o guiones bajos.\nEjemplo: @juan.perez");
                redSocial = v;
            }
        }

        // POLIMORFISMO: cada subclase lo implementa a su manera
        public abstract string ObtenerFicha();
        public abstract bool Registrar();

        // Tipos de documento cargados en la base (para el desplegable)
        public static List<string> ObtenerTiposDocumento()
        {
            List<string> tipos = new List<string>();

            using (SqlConnection cn = Conexion.Obtener())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ListarTiposDocumento", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                            tipos.Add(rd.GetString(0));
                    }
                }
            }
            return tipos;
        }

        // Busca por TIPO de documento + NÚMERO.
        // Devuelve un Socio o un NoSocio (según corresponda), o null si no existe.
        public static Persona Buscar(string tipoDocumento, string dni)
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_BuscarPersona", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo_documento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@dni", dni);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                            return null;

                        Persona p;
                        if (rd.GetString(rd.GetOrdinal("tipo")) == "Socio")
                        {
                            Socio s = new Socio();
                            s.NumeroSocio = rd.GetInt32(rd.GetOrdinal("numero_socio"));
                            s.FechaAlta = rd.GetDateTime(rd.GetOrdinal("fecha_alta"));
                            p = s;
                        }
                        else
                        {
                            NoSocio n = new NoSocio();
                            n.TarifaPase = rd.GetDecimal(rd.GetOrdinal("tarifa_pase"));
                            p = n;
                        }

                        // Datos comunes (se cargan una sola vez, en Persona)
                        p.id = rd.GetInt32(rd.GetOrdinal("id"));
                        p.tipoDocumento = rd.GetString(rd.GetOrdinal("tipo_documento"));
                        p.dni = rd.GetString(rd.GetOrdinal("dni"));
                        p.nombre = rd.GetString(rd.GetOrdinal("nombre"));
                        p.apellido = rd.GetString(rd.GetOrdinal("apellido"));
                        int posTel = rd.GetOrdinal("telefono");
                        p.telefono = rd.IsDBNull(posTel) ? "" : rd.GetString(posTel);
                        int posSexo = rd.GetOrdinal("sexo");
                        p.sexo = rd.IsDBNull(posSexo) ? null : rd.GetString(posSexo);
                        int posRed = rd.GetOrdinal("red_social");
                        p.redSocial = rd.IsDBNull(posRed) ? "" : rd.GetString(posRed);
                        p.aptoFisico = rd.GetBoolean(rd.GetOrdinal("apto_fisico"));
                        return p;
                    }
                }
            }
        }
    }

    // -------------------------------------------------
    // HERENCIA: Socio hereda de Persona
    // -------------------------------------------------
    public class Socio : Persona
    {
        private int numeroSocio;
        private DateTime fechaAlta;
        private decimal montoCuota;

        // Relaciones del UML
        private List<Cuota> cuotas = new List<Cuota>();
        private List<Actividad> actividades = new List<Actividad>();

        public int NumeroSocio
        {
            get { return numeroSocio; }
            set { numeroSocio = value; }
        }

        public DateTime FechaAlta
        {
            get { return fechaAlta; }
            set { fechaAlta = value; }
        }

        // Importe de la cuota mensual que se cobra al inscribirse
        public decimal MontoCuota
        {
            get { return montoCuota; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La cuota mensual debe ser mayor que cero.");
                montoCuota = value;
            }
        }

        public List<Cuota> Cuotas { get { return cuotas; } }
        public List<Actividad> Actividades { get { return actividades; } }

        // Llama al stored procedure sp_NuevoSocio.
        //   true  -> registrado; NumeroSocio queda cargado y se genera la primera cuota.
        //   false -> error inesperado en la base.
        //   Lanza InvalidOperationException si el documento ya existe.
        public override bool Registrar()
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_NuevoSocio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo_documento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@telefono", (object)telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@apto_fisico", aptoFisico);
                    cmd.Parameters.AddWithValue("@sexo", (object)sexo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@red_social", string.IsNullOrEmpty(redSocial) ? (object)DBNull.Value : redSocial);
                    cmd.Parameters.AddWithValue("@monto_cuota", montoCuota);

                    SqlParameter salida = new SqlParameter("@numero_socio", SqlDbType.Int);
                    salida.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(salida);

                    cmd.ExecuteNonQuery();

                    int resultado = Convert.ToInt32(salida.Value);
                    if (resultado == -1)
                        throw new InvalidOperationException("Ya existe una persona registrada con ese tipo y número de documento.");
                    if (resultado < 0)
                        return false;

                    numeroSocio = resultado;
                    fechaAlta = DateTime.Today;

                    // Primera cuota: cobrada hoy, vence dentro de un mes
                    Cuota c = new Cuota();
                    c.Monto = montoCuota;
                    c.FechaVencimiento = fechaAlta.AddMonths(1);
                    c.Pagado = true;
                    cuotas.Add(c);

                    return true;
                }
            }
        }

        // POLIMORFISMO: implementación propia para Socio (carnet)
        public override string ObtenerFicha()
        {
            string ficha = string.Format(
                "CARNET DE SOCIO\nN° de socio: {0}\nNombre: {1} {2}\nDocumento: {3} {4}\nTeléfono: {5}\nApto físico: {6}\nFecha de alta: {7:dd/MM/yyyy}\nSexo: {8}\nRed social: {9}",
                numeroSocio, nombre, apellido, tipoDocumento, dni, telefono,
                aptoFisico ? "Sí" : "No", fechaAlta,
                sexo ?? "-", string.IsNullOrEmpty(redSocial) ? "-" : redSocial);

            if (cuotas.Count > 0)
            {
                ficha += string.Format("\nCuota mensual: ${0:N2}\nPróximo vencimiento: {1:dd/MM/yyyy}",
                    cuotas[0].Monto, cuotas[0].FechaVencimiento);
            }
            return ficha;
        }
    }

    // -------------------------------------------------
    // HERENCIA: NoSocio hereda de Persona
    // -------------------------------------------------
    public class NoSocio : Persona
    {
        private decimal tarifaPase;
        private List<PaseDiario> pases = new List<PaseDiario>();

        public decimal TarifaPase
        {
            get { return tarifaPase; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("La tarifa de pase debe ser mayor que cero.");
                tarifaPase = value;
            }
        }

        public List<PaseDiario> Pases { get { return pases; } }

        // Llama al stored procedure sp_NuevoNoSocio (misma convención que Socio.Registrar)
        public override bool Registrar()
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_NuevoNoSocio", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tipo_documento", tipoDocumento);
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@telefono", (object)telefono ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@apto_fisico", aptoFisico);
                    cmd.Parameters.AddWithValue("@sexo", (object)sexo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@red_social", string.IsNullOrEmpty(redSocial) ? (object)DBNull.Value : redSocial);
                    cmd.Parameters.AddWithValue("@tarifa_pase", tarifaPase);

                    SqlParameter salida = new SqlParameter("@id_persona", SqlDbType.Int);
                    salida.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(salida);

                    cmd.ExecuteNonQuery();

                    int resultado = Convert.ToInt32(salida.Value);
                    if (resultado == -1)
                        throw new InvalidOperationException("Ya existe una persona registrada con ese tipo y número de documento.");
                    if (resultado < 0)
                        return false;

                    id = resultado;

                    // Pase diario emitido hoy
                    PaseDiario pase = new PaseDiario();
                    pase.FechaEmision = DateTime.Now;
                    pase.Monto = tarifaPase;
                    pases.Add(pase);

                    return true;
                }
            }
        }

        // POLIMORFISMO: implementación propia para NoSocio (comprobante)
        public override string ObtenerFicha()
        {
            string ficha = string.Format(
                "COMPROBANTE DE PASE DIARIO\nNombre: {0} {1}\nDocumento: {2} {3}\nTeléfono: {4}\nApto físico: {5}\nTarifa de pase: ${6:N2}\nSexo: {7}\nRed social: {8}",
                nombre, apellido, tipoDocumento, dni, telefono,
                aptoFisico ? "Sí" : "No", tarifaPase,
                sexo ?? "-", string.IsNullOrEmpty(redSocial) ? "-" : redSocial);

            if (pases.Count > 0)
            {
                ficha += string.Format("\nPase emitido: {0:dd/MM/yyyy HH:mm}", pases[0].FechaEmision);
            }
            return ficha;
        }
    }

    // -------------------------------------------------
    // Usuario (operador del sistema)
    // -------------------------------------------------
    public class Usuario
    {
        private int id;
        private string usuario;
        private string claveHash;
        private string rol;

        public int Id { get { return id; } set { id = value; } }
        public string UsuarioNombre { get { return usuario; } set { usuario = value; } }
        public string ClaveHash { get { return claveHash; } set { claveHash = value; } }
        public string Rol { get { return rol; } set { rol = value; } }

        // Recibe la clave en texto plano y guarda solo el hash
        public void EstablecerClave(string clavePlana)
        {
            claveHash = CalcularHash(clavePlana);
        }

        // SHA-256 en hexadecimal minúscula (coincide con el hash guardado en la base)
        public static string CalcularHash(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // Llama al stored procedure sp_ValidarIngreso
        public bool ValidarIngreso()
        {
            using (SqlConnection cn = Conexion.Obtener())
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ValidarIngreso", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@clave_hash", claveHash);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            id = rd.GetInt32(rd.GetOrdinal("id"));
                            rol = rd.GetString(rd.GetOrdinal("rol"));
                            return true;
                        }
                        return false;
                    }
                }
            }
        }
    }

    // -------------------------------------------------
    // Actividad
    // -------------------------------------------------
    public class Actividad
    {
        private int id;
        private string nombre;
        private decimal costo;
        private int cupoMaximo;

        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public decimal Costo { get { return costo; } set { costo = value; } }
        public int CupoMaximo { get { return cupoMaximo; } set { cupoMaximo = value; } }
    }

    // -------------------------------------------------
    // Cuota (composición con Socio)
    // -------------------------------------------------
    public class Cuota
    {
        private int id;
        private DateTime fechaVencimiento;
        private decimal monto;
        private bool pagado;

        public int Id { get { return id; } set { id = value; } }
        public DateTime FechaVencimiento { get { return fechaVencimiento; } set { fechaVencimiento = value; } }
        public decimal Monto { get { return monto; } set { monto = value; } }
        public bool Pagado { get { return pagado; } set { pagado = value; } }

        // La cuota es quien registra su propio pago
        public void RegistrarPago()
        {
            if (pagado)
                throw new InvalidOperationException("La cuota ya está pagada.");
            pagado = true;
        }

        // Cuotas por cobrar: socios cuya última cuota ya venció o vence en la fecha
        // y todavía no renovaron. La columna "Estado" la calcula el procedimiento.
        public static DataTable ListarVencimientos(DateTime fecha)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection cn = Conexion.Obtener())
            using (SqlCommand cmd = new SqlCommand("sp_VencimientosDelDia", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecha", fecha.Date);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                {
                    adaptador.Fill(tabla);   // abre y cierra la conexión por sí solo
                }
            }
            return tabla;
        }
    }

    // -------------------------------------------------
    // PaseDiario (composición con NoSocio)
    // -------------------------------------------------
    public class PaseDiario
    {
        private int id;
        private DateTime fechaEmision;
        private decimal monto;

        public int Id { get { return id; } set { id = value; } }
        public DateTime FechaEmision { get { return fechaEmision; } set { fechaEmision = value; } }
        public decimal Monto { get { return monto; } set { monto = value; } }
    }
}

// =====================================================
// Formulario de carnet (socio) / comprobante de pase (no socio).
// Está en este mismo archivo para que no haya que agregarlo aparte al proyecto.
// =====================================================
namespace ClubDeportivoForms
{
    using System.Drawing;
    using System.Windows.Forms;

    // Imagen de perfil dibujada por código (no requiere archivos): azul = varón, rosa = mujer
    public static class Avatar
    {
        public static Bitmap Crear(string sexo, int tam)
        {
            Color fondo = Color.Gray;
            Color pelo = Color.DimGray;
            if (sexo == "Varón") { fondo = Color.FromArgb(100, 149, 237); pelo = Color.FromArgb(40, 60, 110); }
            if (sexo == "Mujer") { fondo = Color.FromArgb(244, 143, 177); pelo = Color.FromArgb(150, 30, 90); }

            Bitmap bmp = new Bitmap(tam, tam);
            using (Graphics g = Graphics.FromImage(bmp))
            using (System.Drawing.Drawing2D.GraphicsPath circulo = new System.Drawing.Drawing2D.GraphicsPath())
            using (Brush bFondo = new SolidBrush(fondo))
            using (Brush bBlanco = new SolidBrush(Color.White))
            using (Brush bPelo = new SolidBrush(pelo))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                circulo.AddEllipse(0, 0, tam - 1, tam - 1);
                g.FillPath(bFondo, circulo);
                g.SetClip(circulo);

                float c = tam * 0.22f;                       // radio de la cabeza
                if (sexo == "Mujer")                         // pelo largo detrás de la cabeza
                    g.FillEllipse(bPelo, tam * 0.5f - c * 1.4f, tam * 0.12f, c * 2.8f, c * 3.4f);

                g.FillEllipse(bBlanco, tam * 0.15f, tam * 0.62f, tam * 0.70f, tam * 0.70f);   // hombros
                g.FillEllipse(bBlanco, tam * 0.5f - c, tam * 0.18f, c * 2, c * 2);            // cabeza

                if (sexo == "Varón")                         // pelo corto arriba
                    g.FillPie(bPelo, tam * 0.5f - c, tam * 0.18f, c * 2, c * 2, 180, 180);
            }
            return bmp;
        }
    }

    public class frmComprobante : Form
    {
        public frmComprobante(Persona p)
        {
            // El texto lo arma cada clase con su propio ObtenerFicha() (polimorfismo)
            string[] lineas = p.ObtenerFicha().Split('\n');

            Label lblTitulo = new Label();
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Text = lineas[0];   // CARNET DE SOCIO / COMPROBANTE DE PASE DIARIO

            TextBox txtFicha = new TextBox();
            txtFicha.Font = new Font("Consolas", 10F);
            txtFicha.Location = new Point(20, 55);
            txtFicha.Multiline = true;
            txtFicha.ReadOnly = true;
            txtFicha.Size = new Size(400, 240);
            txtFicha.TabStop = false;
            txtFicha.Text = string.Join("\r\n", lineas, 1, lineas.Length - 1);

            PictureBox picAvatar = new PictureBox();
            picAvatar.Location = new Point(440, 55);
            picAvatar.Size = new Size(130, 130);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.Image = Avatar.Crear(p.Sexo, 130);   // varón / mujer según corresponda

            Button btnCerrar = new Button();
            btnCerrar.Location = new Point(240, 312);
            btnCerrar.Size = new Size(120, 34);
            btnCerrar.Text = "Cerrar";
            btnCerrar.Click += delegate { this.Close(); };

            this.Text = "Carnet / Comprobante";
            this.ClientSize = new Size(600, 365);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.AcceptButton = btnCerrar;
            this.CancelButton = btnCerrar;

            this.Controls.Add(lblTitulo);
            this.Controls.Add(txtFicha);
            this.Controls.Add(picAvatar);
            this.Controls.Add(btnCerrar);
        }
    }
}
