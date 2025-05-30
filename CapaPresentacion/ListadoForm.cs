using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ListadoForm : Form
    {
        private Form menuForm;      // Referencia al menú principal
        private string rolUsuario;  // Rol del usuario actual

        public ListadoForm(Form menu, string rol)
        {
            InitializeComponent();
            menuForm = menu;
            rolUsuario = rol;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();         // Cierra el formulario actual
            menuForm.Show();      // Vuelve al menú principal
        }

        private void ListadoForm_Load(object sender, EventArgs e)
        {
            // Aquí podrías cargar empleados en el DataGridView si aún no lo haces
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (rolUsuario == "admin")
            {
                // Administrador: modificar datos del empleado
                RegistroEmpleadoForm form = new RegistroEmpleadoForm(menuForm);
                form.Show();
                this.Hide();
            }
            else
            {
                // Usuario: ver o calcular liquidación del empleado
                LiquidacionForm form = new LiquidacionForm(menuForm);
                form.Show();
                this.Hide();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (rolUsuario == "admin")
            {
                // Administrador: eliminar al empleado (simulado)
                MessageBox.Show("Empleado eliminado del sistema (simulado).", "Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Usuario: eliminar la liquidación (simulado)
                MessageBox.Show("Liquidación eliminada para el empleado (simulado).", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
