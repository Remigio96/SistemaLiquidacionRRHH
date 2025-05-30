using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class MenuForm : Form
    {
        private string rolUsuario; // ← Aquí se guarda el rol que viene desde el Login

        // Constructor que recibe el rol
        public MenuForm(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;

            if (rolUsuario != "admin")
            {
                btnRegistroEmpleado.Visible = false; // Oculta el botón solo para usuarios normales
            }
        }

        private void btnRegistroEmpleado_Click(object sender, EventArgs e)
        {
            RegistroEmpleadoForm form = new RegistroEmpleadoForm(this);
            form.Show();
            this.Hide();
        }

        private void btnLiquidacion_Click(object sender, EventArgs e)
        {
            LiquidacionForm form = new LiquidacionForm(this);
            form.Show();
            this.Hide();
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            // 🔸 Aquí pasamos el rol al ListadoForm correctamente
            ListadoForm form = new ListadoForm(this, rolUsuario);
            form.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide(); // o this.Close() si quieres liberar memoria
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void tlpMenuForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
