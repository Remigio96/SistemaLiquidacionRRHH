using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaNegocio;

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

        private void ListadoForm_Load(object sender, EventArgs e)
        {
            CargarEmpleados(); // 🔹 Carga inicial de empleados al abrir el formulario
        }

        private void CargarEmpleados()
        {
            dgvEmpleados.Rows.Clear(); // Limpia el DataGridView

            List<EmpleadoDTO> lista = EmpleadoService.ObtenerTodos();

            foreach (var emp in lista)
            {
                dgvEmpleados.Rows.Add(emp.Rut, emp.Nombre, emp.Direccion, "—"); // Sueldo líquido como placeholder
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();         // Cierra el formulario actual
            menuForm.Show();      // Vuelve al menú principal
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (rolUsuario == "admin")
            {
                RegistroEmpleadoForm form = new RegistroEmpleadoForm(menuForm);
                form.Show();
                this.Hide();
            }
            else
            {
                LiquidacionForm form = new LiquidacionForm(menuForm);
                form.Show();
                this.Hide();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (rolUsuario == "admin")
            {
                MessageBox.Show("Empleado eliminado del sistema (simulado).", "Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Liquidación eliminada para el empleado (simulado).", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
