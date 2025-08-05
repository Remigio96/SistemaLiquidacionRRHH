using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cmbFiltro.SelectedItem.ToString();
            var empleados = EmpleadoService.ObtenerTodos();
            List<EmpleadoDTO> empleadosFiltrados;

            // Función para obtener la primera letra del primer nombre
            Func<string, char> letraNombre = nombre =>
            {
                var partes = nombre.Split(' ');
                return char.ToUpper(partes[0][0]); // Letra inicial del primer nombre
            };

            switch (opcion)
            {
                case "TODOS":
                    empleadosFiltrados = empleados;
                    break;

                case "\"A - F\"":
                    empleadosFiltrados = empleados.Where(emp =>
                        letraNombre(emp.Nombre) >= 'A' && letraNombre(emp.Nombre) <= 'F').ToList();
                    break;

                case "\"G - L\"":
                    empleadosFiltrados = empleados.Where(emp =>
                        letraNombre(emp.Nombre) >= 'G' && letraNombre(emp.Nombre) <= 'L').ToList();
                    break;

                case "\"M - R\"":
                    empleadosFiltrados = empleados.Where(emp =>
                        letraNombre(emp.Nombre) >= 'M' && letraNombre(emp.Nombre) <= 'R').ToList();
                    break;

                case "\"S - Z\"":
                    empleadosFiltrados = empleados.Where(emp =>
                        letraNombre(emp.Nombre) >= 'S' && letraNombre(emp.Nombre) <= 'Z').ToList();
                    break;

                default:
                    empleadosFiltrados = empleados;
                    break;
            }

            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = empleadosFiltrados;
            dgvEmpleados.AutoResizeColumns();
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }


    }
}
