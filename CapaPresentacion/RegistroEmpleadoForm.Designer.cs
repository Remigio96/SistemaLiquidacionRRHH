namespace CapaPresentacion
{
    partial class RegistroEmpleadoForm
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
            this.txtRut = new System.Windows.Forms.TextBox();
            this.lblTituloRegistro = new System.Windows.Forms.Label();
            this.lblRut = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblValorHora = new System.Windows.Forms.Label();
            this.lblValorExtra = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtValorHora = new System.Windows.Forms.TextBox();
            this.txtValorExtra = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btn_VolverMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRut
            // 
            this.txtRut.Location = new System.Drawing.Point(161, 109);
            this.txtRut.Name = "txtRut";
            this.txtRut.Size = new System.Drawing.Size(236, 20);
            this.txtRut.TabIndex = 0;
            this.txtRut.TextChanged += new System.EventHandler(this.txtRut_TextChanged);
            // 
            // lblTituloRegistro
            // 
            this.lblTituloRegistro.AutoSize = true;
            this.lblTituloRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloRegistro.Location = new System.Drawing.Point(39, 45);
            this.lblTituloRegistro.Name = "lblTituloRegistro";
            this.lblTituloRegistro.Size = new System.Drawing.Size(358, 31);
            this.lblTituloRegistro.TabIndex = 1;
            this.lblTituloRegistro.Text = "REGISTRAR EMPLEADO:";
            // 
            // lblRut
            // 
            this.lblRut.AutoSize = true;
            this.lblRut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRut.Location = new System.Drawing.Point(102, 105);
            this.lblRut.Name = "lblRut";
            this.lblRut.Size = new System.Drawing.Size(53, 24);
            this.lblRut.TabIndex = 2;
            this.lblRut.Text = "RUT:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(71, 139);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(84, 24);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(60, 174);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(95, 24);
            this.lblDireccion.TabIndex = 4;
            this.lblDireccion.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(65, 209);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(90, 24);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono:";
            this.lblTelefono.Click += new System.EventHandler(this.lblTelefono_Click);
            // 
            // lblValorHora
            // 
            this.lblValorHora.AutoSize = true;
            this.lblValorHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorHora.Location = new System.Drawing.Point(50, 249);
            this.lblValorHora.Name = "lblValorHora";
            this.lblValorHora.Size = new System.Drawing.Size(105, 24);
            this.lblValorHora.TabIndex = 6;
            this.lblValorHora.Text = "Valor Hora:";
            // 
            // lblValorExtra
            // 
            this.lblValorExtra.AutoSize = true;
            this.lblValorExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorExtra.Location = new System.Drawing.Point(2, 287);
            this.lblValorExtra.Name = "lblValorExtra";
            this.lblValorExtra.Size = new System.Drawing.Size(153, 24);
            this.lblValorExtra.TabIndex = 7;
            this.lblValorExtra.Text = "Valor Hora Extra:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(161, 143);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(236, 20);
            this.txtNombre.TabIndex = 8;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(161, 179);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(236, 20);
            this.txtDireccion.TabIndex = 9;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(161, 214);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(236, 20);
            this.txtTelefono.TabIndex = 10;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // txtValorHora
            // 
            this.txtValorHora.Location = new System.Drawing.Point(161, 254);
            this.txtValorHora.Name = "txtValorHora";
            this.txtValorHora.Size = new System.Drawing.Size(236, 20);
            this.txtValorHora.TabIndex = 11;
            this.txtValorHora.TextChanged += new System.EventHandler(this.txtValorHora_TextChanged);
            // 
            // txtValorExtra
            // 
            this.txtValorExtra.Location = new System.Drawing.Point(161, 291);
            this.txtValorExtra.Name = "txtValorExtra";
            this.txtValorExtra.Size = new System.Drawing.Size(236, 20);
            this.txtValorExtra.TabIndex = 12;
            this.txtValorExtra.TextChanged += new System.EventHandler(this.txtValorExtra_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(302, 368);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(95, 37);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(176, 368);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(95, 37);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btn_VolverMenu
            // 
            this.btn_VolverMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VolverMenu.Location = new System.Drawing.Point(45, 368);
            this.btn_VolverMenu.Name = "btn_VolverMenu";
            this.btn_VolverMenu.Size = new System.Drawing.Size(95, 37);
            this.btn_VolverMenu.TabIndex = 15;
            this.btn_VolverMenu.Text = "Volver";
            this.btn_VolverMenu.UseVisualStyleBackColor = true;
            this.btn_VolverMenu.Click += new System.EventHandler(this.btn_VolverMenu_Click);
            // 
            // RegistroEmpleadoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 450);
            this.Controls.Add(this.btn_VolverMenu);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtValorExtra);
            this.Controls.Add(this.txtValorHora);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblValorExtra);
            this.Controls.Add(this.lblValorHora);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblRut);
            this.Controls.Add(this.lblTituloRegistro);
            this.Controls.Add(this.txtRut);
            this.Name = "RegistroEmpleadoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Empleados";
            this.Load += new System.EventHandler(this.RegistroEmpleadoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRut;
        private System.Windows.Forms.Label lblTituloRegistro;
        private System.Windows.Forms.Label lblRut;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblValorHora;
        private System.Windows.Forms.Label lblValorExtra;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtValorHora;
        private System.Windows.Forms.TextBox txtValorExtra;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btn_VolverMenu;
    }
}