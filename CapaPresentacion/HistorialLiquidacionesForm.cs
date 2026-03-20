using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public class HistorialLiquidacionesForm : Form
    {
        private TextBox txtBuscar;
        private DataGridView dgvLiquidaciones;
        private Label lblTitulo;
        private Label lblBuscar;
        private Button btnCerrar;
        private List<LiquidacionDTO> todasLasLiquidaciones;

        public HistorialLiquidacionesForm()
        {
            ConfigurarFormulario();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            this.Text = "Historial de Liquidaciones";
            this.Size = new Size(750, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Título
            lblTitulo = new Label
            {
                Text = "HISTORIAL DE LIQUIDACIONES",
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold),
                Location = new Point(170, 15),
                AutoSize = true
            };

            // Label buscar
            lblBuscar = new Label
            {
                Text = "Buscar:",
                Font = new Font("Microsoft Sans Serif", 11F),
                Location = new Point(15, 60),
                AutoSize = true
            };

            // Barra de búsqueda
            txtBuscar = new TextBox
            {
                Font = new Font("Microsoft Sans Serif", 11F),
                Location = new Point(80, 58),
                Size = new Size(300, 25),
                ForeColor = Color.Gray,
                Text = "Nombre o apellido..."
            };
            // Simular placeholder en .NET Framework 4.8
            txtBuscar.Enter += (s, ev) =>
            {
                if (txtBuscar.ForeColor == Color.Gray)
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };
            txtBuscar.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Nombre o apellido...";
                    txtBuscar.ForeColor = Color.Gray;
                }
            };
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            // DataGridView
            dgvLiquidaciones = new DataGridView
            {
                Location = new Point(15, 95),
                Size = new Size(700, 310),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                BackgroundColor = SystemColors.Window,
                BorderStyle = BorderStyle.Fixed3D,
                AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(240, 240, 240) }
            };

            // Columnas
            dgvLiquidaciones.Columns.Add("colNombre", "Nombre");
            dgvLiquidaciones.Columns.Add("colRut", "RUT");
            dgvLiquidaciones.Columns.Add("colBruto", "Sueldo Bruto");
            dgvLiquidaciones.Columns.Add("colAFP", "AFP");
            dgvLiquidaciones.Columns.Add("colSalud", "Salud");
            dgvLiquidaciones.Columns.Add("colLiquido", "Sueldo Líquido");

            // Anchos proporcionales
            dgvLiquidaciones.Columns["colNombre"].FillWeight = 25;
            dgvLiquidaciones.Columns["colRut"].FillWeight = 18;
            dgvLiquidaciones.Columns["colBruto"].FillWeight = 16;
            dgvLiquidaciones.Columns["colAFP"].FillWeight = 12;
            dgvLiquidaciones.Columns["colSalud"].FillWeight = 14;
            dgvLiquidaciones.Columns["colLiquido"].FillWeight = 16;

            // Alineación a la derecha para montos
            dgvLiquidaciones.Columns["colBruto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLiquidaciones.Columns["colLiquido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Botón cerrar
            btnCerrar = new Button
            {
                Text = "Cerrar",
                Font = new Font("Microsoft Sans Serif", 12F),
                Size = new Size(95, 37),
                Location = new Point(620, 415)
            };
            btnCerrar.Click += (s, e) => this.Close();

            // Agregar controles
            this.Controls.Add(lblTitulo);
            this.Controls.Add(lblBuscar);
            this.Controls.Add(txtBuscar);
            this.Controls.Add(dgvLiquidaciones);
            this.Controls.Add(btnCerrar);
        }

        private void CargarDatos()
        {
            todasLasLiquidaciones = RepositorioLiquidaciones.ObtenerTodas();
            MostrarLiquidaciones(todasLasLiquidaciones);
        }

        private void MostrarLiquidaciones(List<LiquidacionDTO> lista)
        {
            dgvLiquidaciones.Rows.Clear();

            foreach (var l in lista)
            {
                dgvLiquidaciones.Rows.Add(
                    l.NombreEmpleado,
                    l.RutEmpleado,
                    $"${l.SueldoBruto:N0}",
                    l.AFP,
                    l.Salud,
                    $"${l.SueldoLiquido:N0}"
                );
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro) || txtBuscar.ForeColor == Color.Gray)
            {
                MostrarLiquidaciones(todasLasLiquidaciones);
                return;
            }

            var filtradas = todasLasLiquidaciones
                .Where(l => l.NombreEmpleado != null &&
                            RemoverTildes(l.NombreEmpleado.ToLower()).Contains(RemoverTildes(filtro)))
                .ToList();

            MostrarLiquidaciones(filtradas);
        }

        private string RemoverTildes(string texto)
        {
            string normalizado = texto.Normalize(NormalizationForm.FormD);
            char[] sinTildes = normalizado
                .Where(c => UnicodeCategory.NonSpacingMark != char.GetUnicodeCategory(c))
                .ToArray();
            return new string(sinTildes).Normalize(NormalizationForm.FormC);
        }
    }
}
