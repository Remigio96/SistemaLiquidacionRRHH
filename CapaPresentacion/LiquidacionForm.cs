using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class LiquidacionForm : Form
    {
        private Form menuForm; // 🔹 Referencia al formulario del menú

        // 🔹 Constructor modificado
        public LiquidacionForm(Form menu)
        {
            InitializeComponent();
            menuForm = menu;
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

        }

        // 🔹 Evento del botón "Volver"
        private void btnVolverLiquidaciones_Click(object sender, EventArgs e)
        {
            this.Close();         // Cierra el formulario actual
            menuForm.Show();      // Muestra el menú principal
        }
    }
}
