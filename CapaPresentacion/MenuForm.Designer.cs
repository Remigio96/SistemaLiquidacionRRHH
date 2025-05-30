namespace CapaPresentacion
{
    partial class MenuForm
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
            this.lblTituloMenu = new System.Windows.Forms.Label();
            this.btnRegistroEmpleado = new System.Windows.Forms.Button();
            this.btnListado = new System.Windows.Forms.Button();
            this.btnLiquidacion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tlpMenuForm = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMenuForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloMenu
            // 
            this.lblTituloMenu.AutoSize = true;
            this.lblTituloMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloMenu.Location = new System.Drawing.Point(27, 32);
            this.lblTituloMenu.Name = "lblTituloMenu";
            this.lblTituloMenu.Size = new System.Drawing.Size(260, 31);
            this.lblTituloMenu.TabIndex = 0;
            this.lblTituloMenu.Text = "MENÚ PRINCIPAL";
            // 
            // btnRegistroEmpleado
            // 
            this.btnRegistroEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroEmpleado.Location = new System.Drawing.Point(3, 3);
            this.btnRegistroEmpleado.Name = "btnRegistroEmpleado";
            this.btnRegistroEmpleado.Size = new System.Drawing.Size(248, 37);
            this.btnRegistroEmpleado.TabIndex = 1;
            this.btnRegistroEmpleado.Text = "Registrar Empleado";
            this.btnRegistroEmpleado.UseVisualStyleBackColor = true;
            this.btnRegistroEmpleado.Click += new System.EventHandler(this.btnRegistroEmpleado_Click);
            // 
            // btnListado
            // 
            this.btnListado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListado.Location = new System.Drawing.Point(3, 89);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(248, 37);
            this.btnListado.TabIndex = 2;
            this.btnListado.Text = "Listado de Empleados";
            this.btnListado.UseVisualStyleBackColor = true;
            this.btnListado.Click += new System.EventHandler(this.btnListado_Click);
            // 
            // btnLiquidacion
            // 
            this.btnLiquidacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiquidacion.Location = new System.Drawing.Point(3, 46);
            this.btnLiquidacion.Name = "btnLiquidacion";
            this.btnLiquidacion.Size = new System.Drawing.Size(248, 37);
            this.btnLiquidacion.TabIndex = 3;
            this.btnLiquidacion.Text = "Cálculo de Liquidación";
            this.btnLiquidacion.UseVisualStyleBackColor = true;
            this.btnLiquidacion.Click += new System.EventHandler(this.btnLiquidacion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(33, 260);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(254, 37);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tlpMenuForm
            // 
            this.tlpMenuForm.ColumnCount = 1;
            this.tlpMenuForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMenuForm.Controls.Add(this.btnLiquidacion, 0, 1);
            this.tlpMenuForm.Controls.Add(this.btnListado, 0, 2);
            this.tlpMenuForm.Controls.Add(this.btnRegistroEmpleado, 0, 0);
            this.tlpMenuForm.Location = new System.Drawing.Point(33, 96);
            this.tlpMenuForm.Name = "tlpMenuForm";
            this.tlpMenuForm.RowCount = 3;
            this.tlpMenuForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMenuForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMenuForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpMenuForm.Size = new System.Drawing.Size(254, 131);
            this.tlpMenuForm.TabIndex = 5;
            this.tlpMenuForm.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpMenuForm_Paint);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 330);
            this.Controls.Add(this.tlpMenuForm);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblTituloMenu);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú de Inicio";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.tlpMenuForm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloMenu;
        private System.Windows.Forms.Button btnRegistroEmpleado;
        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Button btnLiquidacion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TableLayoutPanel tlpMenuForm;
    }
}