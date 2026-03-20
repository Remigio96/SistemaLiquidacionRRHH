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
            ConfigurarValidacionesTiempo();
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
            ConfigurarValidacionesTiempo();
        }

        // Validaciones en tiempo real: restringe la entrada de caracteres según el campo
        private void ConfigurarValidacionesTiempo()
        {
            // Nombre: solo letras y espacios
            txtNombre.KeyPress += (s, ev) =>
            {
                if (!char.IsLetter(ev.KeyChar) && !char.IsWhiteSpace(ev.KeyChar) && !char.IsControl(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };

            // Teléfono: solo números y el símbolo +
            txtTelefono.KeyPress += (s, ev) =>
            {
                if (!char.IsDigit(ev.KeyChar) && ev.KeyChar != '+' && !char.IsControl(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };

            // Valor Hora: solo números
            txtValorHora.KeyPress += (s, ev) =>
            {
                if (!char.IsDigit(ev.KeyChar) && !char.IsControl(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };

            // Valor Hora Extra: solo números
            txtValorExtra.KeyPress += (s, ev) =>
            {
                if (!char.IsDigit(ev.KeyChar) && !char.IsControl(ev.KeyChar))
                {
                    ev.Handled = true;
                }
            };
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones usando ValidacionService
                if (ValidacionService.EstaVacio(txtRut.Text) ||
                    ValidacionService.EstaVacio(txtNombre.Text) ||
                    ValidacionService.EstaVacio(txtDireccion.Text) ||
                    ValidacionService.EstaVacio(txtTelefono.Text) ||
                    ValidacionService.EstaVacio(txtValorHora.Text) ||
                    ValidacionService.EstaVacio(txtValorExtra.Text))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidacionService.ContieneSoloLetras(txtNombre.Text))
                {
                    MessageBox.Show("El nombre debe contener solo letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNombre.Focus();
                    return;
                }

                if (!ValidacionService.EsEnteroValido(txtValorHora.Text) ||
                    !ValidacionService.EsEnteroValido(txtValorExtra.Text))
                {
                    MessageBox.Show("Los campos 'Valor Hora' y 'Valor Hora Extra' deben ser numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int valorHora = int.Parse(txtValorHora.Text);
                int valorHoraExtra = int.Parse(txtValorExtra.Text);

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
