namespace wfEnvioUnitario
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTransaccion = new System.Windows.Forms.Label();
            this.cbxTransaccion = new System.Windows.Forms.ComboBox();
            this.lblLlave = new System.Windows.Forms.Label();
            this.txbLlave = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbXmlEnviar = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbXmlRecibido = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTransaccion
            // 
            this.lblTransaccion.AutoSize = true;
            this.lblTransaccion.Location = new System.Drawing.Point(304, 16);
            this.lblTransaccion.Name = "lblTransaccion";
            this.lblTransaccion.Size = new System.Drawing.Size(72, 13);
            this.lblTransaccion.TabIndex = 0;
            this.lblTransaccion.Text = "Transaccion :";
            // 
            // cbxTransaccion
            // 
            this.cbxTransaccion.FormattingEnabled = true;
            this.cbxTransaccion.Location = new System.Drawing.Point(382, 13);
            this.cbxTransaccion.Name = "cbxTransaccion";
            this.cbxTransaccion.Size = new System.Drawing.Size(146, 21);
            this.cbxTransaccion.TabIndex = 1;
            this.cbxTransaccion.SelectedIndexChanged += new System.EventHandler(this.cbxTransaccion_SelectedIndexChanged);
            // 
            // lblLlave
            // 
            this.lblLlave.AutoSize = true;
            this.lblLlave.Location = new System.Drawing.Point(551, 16);
            this.lblLlave.Name = "lblLlave";
            this.lblLlave.Size = new System.Drawing.Size(39, 13);
            this.lblLlave.TabIndex = 0;
            this.lblLlave.Text = "Llave :";
            // 
            // txbLlave
            // 
            this.txbLlave.Location = new System.Drawing.Point(605, 13);
            this.txbLlave.Name = "txbLlave";
            this.txbLlave.Size = new System.Drawing.Size(122, 20);
            this.txbLlave.TabIndex = 2;
            this.txbLlave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbLlave_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(759, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbXmlEnviar);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 702);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "XML PARA  ENVIAR";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 712);
            this.panel1.TabIndex = 5;
            // 
            // txbXmlEnviar
            // 
            this.txbXmlEnviar.Enabled = false;
            this.txbXmlEnviar.Location = new System.Drawing.Point(5, 18);
            this.txbXmlEnviar.Multiline = true;
            this.txbXmlEnviar.Name = "txbXmlEnviar";
            this.txbXmlEnviar.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbXmlEnviar.Size = new System.Drawing.Size(526, 678);
            this.txbXmlEnviar.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(579, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 712);
            this.panel2.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbXmlRecibido);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 702);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "XML RECIBIDO";
            // 
            // txbXmlRecibido
            // 
            this.txbXmlRecibido.Enabled = false;
            this.txbXmlRecibido.Location = new System.Drawing.Point(5, 18);
            this.txbXmlRecibido.Multiline = true;
            this.txbXmlRecibido.Name = "txbXmlRecibido";
            this.txbXmlRecibido.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbXmlRecibido.Size = new System.Drawing.Size(526, 678);
            this.txbXmlRecibido.TabIndex = 0;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Enabled = false;
            this.btnEnviar.Location = new System.Drawing.Point(532, 56);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 819);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txbLlave);
            this.Controls.Add(this.cbxTransaccion);
            this.Controls.Add(this.lblLlave);
            this.Controls.Add(this.lblTransaccion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTransaccion;
        private System.Windows.Forms.ComboBox cbxTransaccion;
        private System.Windows.Forms.Label lblLlave;
        private System.Windows.Forms.TextBox txbLlave;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbXmlEnviar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbXmlRecibido;
        private System.Windows.Forms.Button btnEnviar;
    }
}

