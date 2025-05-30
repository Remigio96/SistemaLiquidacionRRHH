namespace CapaPresentacion
{
    partial class LiquidacionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHorasTrabajadas = new System.Windows.Forms.Label();
            this.lblHorasExtras = new System.Windows.Forms.Label();
            this.lblSueldoBruto = new System.Windows.Forms.Label();
            this.lblSueldoLiquido = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.txtHorasTrabajadas = new System.Windows.Forms.TextBox();
            this.txtHorasExtras = new System.Windows.Forms.TextBox();
            this.txtSueldoBruto = new System.Windows.Forms.TextBox();
            this.txtSueldoLiquido = new System.Windows.Forms.TextBox();
            this.cmbAFP = new System.Windows.Forms.ComboBox();
            this.cmbSalud = new System.Windows.Forms.ComboBox();
            this.lblTituloCalcular = new System.Windows.Forms.Label();
            this.btnVolverLiquidaciones = new System.Windows.Forms.Button();
            this.cmbEmpleados = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblHorasTrabajadas
            // 
            this.lblHorasTrabajadas.AutoSize = true;
            this.lblHorasTrabajadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorasTrabajadas.Location = new System.Drawing.Point(24, 93);
            this.lblHorasTrabajadas.Name = "lblHorasTrabajadas";
            this.lblHorasTrabajadas.Size = new System.Drawing.Size(210, 24);
            this.lblHorasTrabajadas.TabIndex = 0;
            this.lblHorasTrabajadas.Text = "HORAS TRABAJADAS:";
            // 
            // lblHorasExtras
            // 
            this.lblHorasExtras.AutoSize = true;
            this.lblHorasExtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorasExtras.Location = new System.Drawing.Point(70, 138);
            this.lblHorasExtras.Name = "lblHorasExtras";
            this.lblHorasExtras.Size = new System.Drawing.Size(164, 24);
            this.lblHorasExtras.TabIndex = 1;
            this.lblHorasExtras.Text = "HORAS EXTRAS:";
            // 
            // lblSueldoBruto
            // 
            this.lblSueldoBruto.AutoSize = true;
            this.lblSueldoBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSueldoBruto.Location = new System.Drawing.Point(236, 249);
            this.lblSueldoBruto.Name = "lblSueldoBruto";
            this.lblSueldoBruto.Size = new System.Drawing.Size(161, 24);
            this.lblSueldoBruto.TabIndex = 2;
            this.lblSueldoBruto.Text = "SUELDO BRUTO:";
            // 
            // lblSueldoLiquido
            // 
            this.lblSueldoLiquido.AutoSize = true;
            this.lblSueldoLiquido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSueldoLiquido.Location = new System.Drawing.Point(227, 336);
            this.lblSueldoLiquido.Name = "lblSueldoLiquido";
            this.lblSueldoLiquido.Size = new System.Drawing.Size(170, 24);
            this.lblSueldoLiquido.TabIndex = 3;
            this.lblSueldoLiquido.Text = "SUELDO LÍQUIDO:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(28, 196);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(95, 37);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(28, 246);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 37);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(28, 296);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 37);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnListar
            // 
            this.btnListar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Location = new System.Drawing.Point(28, 346);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(95, 37);
            this.btnListar.TabIndex = 7;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            // 
            // txtHorasTrabajadas
            // 
            this.txtHorasTrabajadas.Location = new System.Drawing.Point(240, 92);
            this.txtHorasTrabajadas.Multiline = true;
            this.txtHorasTrabajadas.Name = "txtHorasTrabajadas";
            this.txtHorasTrabajadas.Size = new System.Drawing.Size(148, 25);
            this.txtHorasTrabajadas.TabIndex = 8;
            // 
            // txtHorasExtras
            // 
            this.txtHorasExtras.Location = new System.Drawing.Point(240, 137);
            this.txtHorasExtras.Multiline = true;
            this.txtHorasExtras.Name = "txtHorasExtras";
            this.txtHorasExtras.Size = new System.Drawing.Size(148, 25);
            this.txtHorasExtras.TabIndex = 9;
            // 
            // txtSueldoBruto
            // 
            this.txtSueldoBruto.Location = new System.Drawing.Point(403, 248);
            this.txtSueldoBruto.Multiline = true;
            this.txtSueldoBruto.Name = "txtSueldoBruto";
            this.txtSueldoBruto.Size = new System.Drawing.Size(148, 25);
            this.txtSueldoBruto.TabIndex = 10;
            // 
            // txtSueldoLiquido
            // 
            this.txtSueldoLiquido.Location = new System.Drawing.Point(403, 333);
            this.txtSueldoLiquido.Multiline = true;
            this.txtSueldoLiquido.Name = "txtSueldoLiquido";
            this.txtSueldoLiquido.Size = new System.Drawing.Size(148, 25);
            this.txtSueldoLiquido.TabIndex = 11;
            // 
            // cmbAFP
            // 
            this.cmbAFP.FormattingEnabled = true;
            this.cmbAFP.Items.AddRange(new object[] {
            "CUPRUM",
            "MODELO",
            "CAPITAL",
            "PROVIDA"});
            this.cmbAFP.Location = new System.Drawing.Point(482, 93);
            this.cmbAFP.Name = "cmbAFP";
            this.cmbAFP.Size = new System.Drawing.Size(121, 21);
            this.cmbAFP.TabIndex = 12;
            // 
            // cmbSalud
            // 
            this.cmbSalud.FormattingEnabled = true;
            this.cmbSalud.Items.AddRange(new object[] {
            "FONASA",
            "CONSALUD",
            "MASVIDA",
            "BANMEDICA"});
            this.cmbSalud.Location = new System.Drawing.Point(482, 138);
            this.cmbSalud.Name = "cmbSalud";
            this.cmbSalud.Size = new System.Drawing.Size(121, 21);
            this.cmbSalud.TabIndex = 13;
            // 
            // lblTituloCalcular
            // 
            this.lblTituloCalcular.AutoSize = true;
            this.lblTituloCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloCalcular.Location = new System.Drawing.Point(48, 22);
            this.lblTituloCalcular.Name = "lblTituloCalcular";
            this.lblTituloCalcular.Size = new System.Drawing.Size(263, 29);
            this.lblTituloCalcular.TabIndex = 14;
            this.lblTituloCalcular.Text = "CALCULAR SUELDO:";
            this.lblTituloCalcular.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // btnVolverLiquidaciones
            // 
            this.btnVolverLiquidaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverLiquidaciones.Location = new System.Drawing.Point(28, 396);
            this.btnVolverLiquidaciones.Name = "btnVolverLiquidaciones";
            this.btnVolverLiquidaciones.Size = new System.Drawing.Size(95, 37);
            this.btnVolverLiquidaciones.TabIndex = 15;
            this.btnVolverLiquidaciones.Text = "Volver";
            this.btnVolverLiquidaciones.UseVisualStyleBackColor = true;
            this.btnVolverLiquidaciones.Click += new System.EventHandler(this.btnVolverLiquidaciones_Click);
            // 
            // cmbEmpleados
            // 
            this.cmbEmpleados.FormattingEnabled = true;
            this.cmbEmpleados.Location = new System.Drawing.Point(340, 26);
            this.cmbEmpleados.Name = "cmbEmpleados";
            this.cmbEmpleados.Size = new System.Drawing.Size(203, 21);
            this.cmbEmpleados.TabIndex = 16;
            // 
            // LiquidacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 450);
            this.Controls.Add(this.cmbEmpleados);
            this.Controls.Add(this.btnVolverLiquidaciones);
            this.Controls.Add(this.lblTituloCalcular);
            this.Controls.Add(this.cmbSalud);
            this.Controls.Add(this.cmbAFP);
            this.Controls.Add(this.txtSueldoLiquido);
            this.Controls.Add(this.txtSueldoBruto);
            this.Controls.Add(this.txtHorasExtras);
            this.Controls.Add(this.txtHorasTrabajadas);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblSueldoLiquido);
            this.Controls.Add(this.lblSueldoBruto);
            this.Controls.Add(this.lblHorasExtras);
            this.Controls.Add(this.lblHorasTrabajadas);
            this.Name = "LiquidacionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cálculo de Liquidación";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHorasTrabajadas;
        private System.Windows.Forms.Label lblHorasExtras;
        private System.Windows.Forms.Label lblSueldoBruto;
        private System.Windows.Forms.Label lblSueldoLiquido;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.TextBox txtHorasTrabajadas;
        private System.Windows.Forms.TextBox txtHorasExtras;
        private System.Windows.Forms.TextBox txtSueldoBruto;
        private System.Windows.Forms.TextBox txtSueldoLiquido;
        private System.Windows.Forms.ComboBox cmbAFP;
        private System.Windows.Forms.ComboBox cmbSalud;
        private System.Windows.Forms.Label lblTituloCalcular;
        private System.Windows.Forms.Button btnVolverLiquidaciones;
        private System.Windows.Forms.ComboBox cmbEmpleados;
    }
}