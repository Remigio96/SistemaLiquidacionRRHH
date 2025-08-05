using System;
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

                if (!int.TryParse(txtHorasTrabajadas.Text.Trim(), out int horasTrabajadas) ||
                    !int.TryParse(txtHorasExtras.Text.Trim(), out int horasExtras))
                {
                    MessageBox.Show("Ingrese valores válidos para horas trabajadas y extras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string afp = cmbAFP.SelectedItem?.ToString();
                string salud = cmbSalud.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(afp) || string.IsNullOrWhiteSpace(salud))
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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSueldoBruto.Text) || string.IsNullOrWhiteSpace(txtSueldoLiquido.Text))
            {
                MessageBox.Show("Debe calcular la liquidación antes de guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                double.TryParse(txtSueldoBruto.Text.Replace(".", ""), out double bruto);
                double.TryParse(txtSueldoLiquido.Text.Replace(".", ""), out double liquido);

                var liquidacion = new LiquidacionDTO
                {
                    SueldoBruto = (int)bruto,
                    SueldoLiquido = liquido
                };

                RepositorioLiquidaciones.Guardar(liquidacion);

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

            string resumen = "LIQUIDACIONES GUARDADAS:\n\n";

            foreach (var l in lista)
            {
                resumen += $"Sueldo Bruto: {l.SueldoBruto:N0} | Sueldo Líquido: {l.SueldoLiquido:N0}\n";
            }

            MessageBox.Show(resumen, "Historial de Liquidaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
