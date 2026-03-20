using System;
using System.Linq;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class LiquidacionForm : Form
    {
        private Form menuForm;

        public LiquidacionForm(Form menu)
        {
            InitializeComponent();
            menuForm = menu;
            ConfigurarValidacionesTiempo();
        }

        // Validaciones en tiempo real: solo números en campos de horas
        private void ConfigurarValidacionesTiempo()
        {
            txtHorasTrabajadas.KeyPress += (s, ev) =>
            {
                if (!char.IsDigit(ev.KeyChar) && !char.IsControl(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };

            txtHorasExtras.KeyPress += (s, ev) =>
            {
                if (!char.IsDigit(ev.KeyChar) && !char.IsControl(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };

            // Campos de resultado son de solo lectura
            txtSueldoBruto.ReadOnly = true;
            txtSueldoLiquido.ReadOnly = true;
        }

        private void lblTitulo_Click(object sender, EventArgs e) { }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbEmpleados.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener directamente el DTO seleccionado
                EmpleadoDTO dto = cmbEmpleados.SelectedItem as EmpleadoDTO;

                if (dto == null)
                {
                    MessageBox.Show("Empleado no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!ValidacionService.EsEnteroValido(txtHorasTrabajadas.Text.Trim()) ||
                    !ValidacionService.EsEnteroValido(txtHorasExtras.Text.Trim()))
                {
                    MessageBox.Show("Ingrese valores numéricos válidos para horas trabajadas y extras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int horasTrabajadas = int.Parse(txtHorasTrabajadas.Text.Trim());
                int horasExtras = int.Parse(txtHorasExtras.Text.Trim());

                string afp = cmbAFP.SelectedItem?.ToString();
                string salud = cmbSalud.SelectedItem?.ToString();

                if (!ValidacionService.SeleccionValida(afp) || !ValidacionService.SeleccionValida(salud))
                {
                    MessageBox.Show("Seleccione AFP y Salud.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var service = new LiquidacionService();
                LiquidacionDTO liquidacion = service.CalcularLiquidacionDesdeDTO(dto, horasTrabajadas, horasExtras, afp, salud);

                txtSueldoBruto.Text = liquidacion.SueldoBruto.ToString("N0");
                txtSueldoLiquido.Text = liquidacion.SueldoLiquido.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnVolverLiquidaciones_Click(object sender, EventArgs e)
        {
            this.Close();
            menuForm.Show();
        }

        private void LiquidacionForm_Load(object sender, EventArgs e)
        {
            EmpleadoService.PrecargarEmpleados();

            var lista = EmpleadoService.ObtenerTodos();
            cmbEmpleados.Items.Clear();
            cmbEmpleados.DisplayMember = "Nombre";
            cmbEmpleados.ValueMember = "Rut";

            foreach (var emp in lista)
            {
                cmbEmpleados.Items.Add(emp);
            }

            // Al seleccionar un empleado, cargar su liquidación si existe
            cmbEmpleados.SelectedIndexChanged += (s, ev) =>
            {
                EmpleadoDTO dto = cmbEmpleados.SelectedItem as EmpleadoDTO;
                if (dto == null) return;

                var liquidacionExistente = RepositorioLiquidaciones.ObtenerTodas()
                    .Where(l => l.RutEmpleado == dto.Rut)
                    .OrderByDescending(l => l.SueldoLiquido)
                    .FirstOrDefault();

                if (liquidacionExistente != null)
                {
                    txtHorasTrabajadas.Text = liquidacionExistente.HorasTrabajadas.ToString();
                    txtHorasExtras.Text = liquidacionExistente.HorasExtras.ToString();
                    txtSueldoBruto.Text = liquidacionExistente.SueldoBruto.ToString("N0");
                    txtSueldoLiquido.Text = liquidacionExistente.SueldoLiquido.ToString("N0");

                    // Seleccionar AFP y Salud correspondientes
                    cmbAFP.SelectedItem = liquidacionExistente.AFP;
                    cmbSalud.SelectedItem = liquidacionExistente.Salud;
                }
                else
                {
                    txtHorasTrabajadas.Clear();
                    txtHorasExtras.Clear();
                    txtSueldoBruto.Clear();
                    txtSueldoLiquido.Clear();
                    cmbAFP.SelectedIndex = -1;
                    cmbSalud.SelectedIndex = -1;
                }
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbEmpleados.SelectedItem == null || string.IsNullOrWhiteSpace(txtSueldoBruto.Text))
            {
                MessageBox.Show("Debe calcular la liquidación antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                EmpleadoDTO dto = cmbEmpleados.SelectedItem as EmpleadoDTO;
                int horasTrabajadas = int.Parse(txtHorasTrabajadas.Text.Trim());
                int horasExtras = int.Parse(txtHorasExtras.Text.Trim());
                string afp = cmbAFP.SelectedItem.ToString();
                string salud = cmbSalud.SelectedItem.ToString();

                var service = new LiquidacionService();
                LiquidacionDTO liquidacion = service.CalcularLiquidacionDesdeDTO(dto, horasTrabajadas, horasExtras, afp, salud);

                // 🔹 Guardar liquidación completa
                liquidacion.HorasTrabajadas = horasTrabajadas;
                liquidacion.HorasExtras = horasExtras;
                liquidacion.AFP = afp;
                liquidacion.Salud = salud;
                liquidacion.RutEmpleado = dto.Rut;
                liquidacion.NombreEmpleado = dto.Nombre;

                RepositorioLiquidaciones.Guardar(liquidacion);
                RepositorioLiquidaciones.GuardarEnArchivo("liquidaciones.json");

                MessageBox.Show("Liquidación guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbEmpleados.SelectedIndex = -1;
            cmbAFP.SelectedIndex = -1;
            cmbSalud.SelectedIndex = -1;
            txtHorasTrabajadas.Clear();
            txtHorasExtras.Clear();
            txtSueldoBruto.Clear();
            txtSueldoLiquido.Clear();
        }


        private void btnListar_Click(object sender, EventArgs e)
        {
            var lista = RepositorioLiquidaciones.ObtenerTodas();

            if (lista.Count == 0)
            {
                MessageBox.Show("No hay liquidaciones registradas.", "Listado vacío", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var historial = new HistorialLiquidacionesForm();
            historial.ShowDialog();
        }

    }
}
