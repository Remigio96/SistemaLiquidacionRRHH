using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class ListadoForm : Form
    {
        private Form menuForm;
        private string rolUsuario;

        public ListadoForm(Form menu, string rol)
        {
            InitializeComponent();
            menuForm = menu;
            rolUsuario = rol;
        }

        private void ListadoForm_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            dgvEmpleados.Rows.Clear();

            List<EmpleadoDTO> lista = EmpleadoService.ObtenerTodos();

            foreach (var emp in lista)
            {
                dgvEmpleados.Rows.Add(emp.Rut, emp.Nombre, emp.Direccion, "—");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            menuForm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null) return;

            string rutSeleccionado = dgvEmpleados.CurrentRow.Cells[0].Value?.ToString();

            if (string.IsNullOrWhiteSpace(rutSeleccionado))
            {
                MessageBox.Show("Debes seleccionar un empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rolUsuario == "admin")
            {
                // Usar método nuevo que retorna un DTO completo
                EmpleadoDTO empleado = EmpleadoService.ObtenerDTOporRut(rutSeleccionado);

                if (empleado != null)
                {
                    RegistroEmpleadoForm form = new RegistroEmpleadoForm(menuForm, empleado); // Form debe aceptar DTO
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            if (dgvEmpleados.CurrentRow == null) return;

            string rutSeleccionado = dgvEmpleados.CurrentRow.Cells[0].Value?.ToString();

            if (string.IsNullOrWhiteSpace(rutSeleccionado))
            {
                MessageBox.Show("Debes seleccionar un empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rolUsuario == "admin")
            {
                DialogResult confirm = MessageBox.Show("¿Estás seguro que deseas eliminar este empleado?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    bool eliminado = EmpleadoService.EliminarEmpleado(rutSeleccionado);

                    if (eliminado)
                    {
                        MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Liquidación eliminada para el empleado (simulado).", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
