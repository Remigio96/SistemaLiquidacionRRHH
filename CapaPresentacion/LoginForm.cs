using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Debe ingresar usuario y contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if ((usuario == "admin" && password == "admin123") ||
                    (usuario == "usuario" && password == "usuario123"))
                {
                    string rol = (usuario == "admin") ? "admin" : "usuario";

                    // 🔹 Precargar empleados si aún no están cargados
                    EmpleadoService.PrecargarEmpleados();

                    MenuForm menu = new MenuForm(rol); // ← le pasamos el rol
                    menu.Show();
                    this.Hide(); // Oculta el login
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
