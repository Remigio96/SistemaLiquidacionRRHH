using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class RegistroEmpleadoForm : Form
    {
        private Form menuForm;
        private bool esEdicion = false;
        private string rutOriginal;

        public RegistroEmpleadoForm(Form menu)
        {
            InitializeComponent();
            menuForm = menu;
        }

        // Constructor para modo edición que recibe EmpleadoDTO
        public RegistroEmpleadoForm(Form menu, EmpleadoDTO empleado)
        {
            InitializeComponent();
            menuForm = menu;
            esEdicion = true;
            rutOriginal = empleado.Rut;

            txtRut.Text = empleado.Rut;
            txtNombre.Text = empleado.Nombre;
            txtDireccion.Text = empleado.Direccion;
            txtTelefono.Text = empleado.Telefono;
            txtValorHora.Text = empleado.ValorHora.ToString();
            txtValorExtra.Text = empleado.ValorHoraExtra.ToString();

            txtRut.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRut.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtValorHora.Text) ||
                    string.IsNullOrWhiteSpace(txtValorExtra.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtValorHora.Text, out int valorHora) ||
                    !int.TryParse(txtValorExtra.Text, out int valorHoraExtra))
                {
                    MessageBox.Show("Los campos 'Valor Hora' y 'Valor Hora Extra' deben ser numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (esEdicion)
                {
                    // ✅ Usar método intermedio de la capa de negocio
                    bool actualizado = EmpleadoService.ModificarEmpleadoDesdeCampos(
                        rutOriginal,
                        txtNombre.Text,
                        txtDireccion.Text,
                        txtTelefono.Text,
                        valorHora,
                        valorHoraExtra
                    );

                    if (actualizado)
                    {
                        MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        menuForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    EmpleadoService.RegistrarEmpleado(
                        txtRut.Text,
                        txtNombre.Text,
                        txtDireccion.Text,
                        txtTelefono.Text,
                        valorHora,
                        valorHoraExtra
                    );

                    MessageBox.Show("Empleado registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btn_VolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            menuForm.Show();
        }

        private void LimpiarFormulario()
        {
            txtRut.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtValorHora.Clear();
            txtValorExtra.Clear();
            txtRut.Focus();
        }

        private void RegistroEmpleadoForm_Load(object sender, EventArgs e) { }
    }
}
