namespace Transer.Tecnologia.Automatizacion.EnvioUnitarioVs1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTransacciones = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbLlave = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txbXmlEnvio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txbXmlRecibido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1363, 112);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "ENVIO UNITARIO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Transer.Tecnologia.Automatizacion.EnvioUnitarioVs1.Properties.Resources.Logo_transer;
            this.pictureBox1.Location = new System.Drawing.Point(1070, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Transaccion :";
            // 
            // cbxTransacciones
            // 
            this.cbxTransacciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTransacciones.FormattingEnabled = true;
            this.cbxTransacciones.Location = new System.Drawing.Point(437, 132);
            this.cbxTransacciones.Name = "cbxTransacciones";
            this.cbxTransacciones.Size = new System.Drawing.Size(218, 28);
            this.cbxTransacciones.TabIndex = 2;
            this.cbxTransacciones.SelectedIndexChanged += new System.EventHandler(this.cbxTransacciones_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(672, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Llave :";
            // 
            // txbLlave
            // 
            this.txbLlave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLlave.Location = new System.Drawing.Point(720, 132);
            this.txbLlave.Name = "txbLlave";
            this.txbLlave.Size = new System.Drawing.Size(125, 29);
            this.txbLlave.TabIndex = 3;
            this.txbLlave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbLlave_KeyPress);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(898, 132);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(111, 28);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txbXmlEnvio
            // 
            this.txbXmlEnvio.Location = new System.Drawing.Point(23, 229);
            this.txbXmlEnvio.Multiline = true;
            this.txbXmlEnvio.Name = "txbXmlEnvio";
            this.txbXmlEnvio.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbXmlEnvio.Size = new System.Drawing.Size(666, 551);
            this.txbXmlEnvio.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "XML MINISTERIO";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(1236, 190);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(111, 28);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "ENVIAR";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txbXmlRecibido
            // 
            this.txbXmlRecibido.Location = new System.Drawing.Point(720, 229);
            this.txbXmlRecibido.Multiline = true;
            this.txbXmlRecibido.Name = "txbXmlRecibido";
            this.txbXmlRecibido.Size = new System.Drawing.Size(637, 551);
            this.txbXmlRecibido.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1013, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "XML RECIBIDO";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 817);
            this.Controls.Add(this.txbXmlRecibido);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbXmlEnvio);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txbLlave);
            this.Controls.Add(this.cbxTransacciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTransacciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbLlave;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox txbXmlEnvio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txbXmlRecibido;
        private System.Windows.Forms.Label label5;
    }
}

