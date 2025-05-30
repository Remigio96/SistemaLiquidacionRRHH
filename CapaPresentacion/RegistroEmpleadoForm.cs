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
    public partial class RegistroEmpleadoForm : Form
    {
        private Form menuForm; // Referencia al menú principal

        public RegistroEmpleadoForm(Form menu)
        {
            InitializeComponent();
            menuForm = menu;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones básicas
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

                // Validaciones numéricas
                if (!int.TryParse(txtValorHora.Text, out int valorHora) ||
                    !int.TryParse(txtValorExtra.Text, out int valorHoraExtra))
                {
                    MessageBox.Show("Los campos 'Valor Hora' y 'Valor Hora Extra' deben ser numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Llamar a la lógica de negocio
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btn_VolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();       // Cierra este formulario
            menuForm.Show();    // Vuelve al menú principal
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

        // Métodos generados por el diseñador (sin implementación)
        private void lblTelefono_Click(object sender, EventArgs e) { }
        private void lblNombre_Click(object sender, EventArgs e) { }
        private void txtRut_TextChanged(object sender, EventArgs e) { }
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtDireccion_TextChanged(object sender, EventArgs e) { }
        private void txtTelefono_TextChanged(object sender, EventArgs e) { }
        private void txtValorHora_TextChanged(object sender, EventArgs e) { }
        private void txtValorExtra_TextChanged(object sender, EventArgs e) { }

        private void RegistroEmpleadoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
