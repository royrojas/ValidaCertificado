namespace ValidaCertificado
{
    partial class Form1
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
            this.txtCertificado = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.btnObtienePin = new System.Windows.Forms.Button();
            this.lblPin = new System.Windows.Forms.Label();
            this.txtRawData = new System.Windows.Forms.TextBox();
            this.txtCripto1 = new System.Windows.Forms.TextBox();
            this.txtCripto2 = new System.Windows.Forms.TextBox();
            this.txtCripto3 = new System.Windows.Forms.TextBox();
            this.btnCripto = new System.Windows.Forms.Button();
            this.txtCripto4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCertificado
            // 
            this.txtCertificado.Location = new System.Drawing.Point(12, 12);
            this.txtCertificado.Name = "txtCertificado";
            this.txtCertificado.Size = new System.Drawing.Size(318, 20);
            this.txtCertificado.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(151, 35);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(77, 23);
            this.btnValidar.TabIndex = 2;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(41, 37);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(106, 20);
            this.txtPin.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Vencimiento";
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Location = new System.Drawing.Point(120, 72);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(10, 13);
            this.lblFechaVencimiento.TabIndex = 6;
            this.lblFechaVencimiento.Text = "-";
            // 
            // btnObtienePin
            // 
            this.btnObtienePin.Location = new System.Drawing.Point(231, 35);
            this.btnObtienePin.Name = "btnObtienePin";
            this.btnObtienePin.Size = new System.Drawing.Size(77, 23);
            this.btnObtienePin.TabIndex = 7;
            this.btnObtienePin.Text = "Obtiene Pin";
            this.btnObtienePin.UseVisualStyleBackColor = true;
            this.btnObtienePin.Click += new System.EventHandler(this.btnObtienePin_Click);
            // 
            // lblPin
            // 
            this.lblPin.AutoSize = true;
            this.lblPin.Location = new System.Drawing.Point(317, 40);
            this.lblPin.Name = "lblPin";
            this.lblPin.Size = new System.Drawing.Size(10, 13);
            this.lblPin.TabIndex = 8;
            this.lblPin.Text = "-";
            // 
            // txtRawData
            // 
            this.txtRawData.Location = new System.Drawing.Point(12, 135);
            this.txtRawData.Multiline = true;
            this.txtRawData.Name = "txtRawData";
            this.txtRawData.Size = new System.Drawing.Size(381, 196);
            this.txtRawData.TabIndex = 9;
            // 
            // txtCripto1
            // 
            this.txtCripto1.Location = new System.Drawing.Point(11, 360);
            this.txtCripto1.Name = "txtCripto1";
            this.txtCripto1.Size = new System.Drawing.Size(382, 20);
            this.txtCripto1.TabIndex = 10;
            // 
            // txtCripto2
            // 
            this.txtCripto2.Location = new System.Drawing.Point(11, 385);
            this.txtCripto2.Name = "txtCripto2";
            this.txtCripto2.Size = new System.Drawing.Size(382, 20);
            this.txtCripto2.TabIndex = 11;
            // 
            // txtCripto3
            // 
            this.txtCripto3.Location = new System.Drawing.Point(11, 411);
            this.txtCripto3.Name = "txtCripto3";
            this.txtCripto3.Size = new System.Drawing.Size(382, 20);
            this.txtCripto3.TabIndex = 12;
            // 
            // btnCripto
            // 
            this.btnCripto.Location = new System.Drawing.Point(11, 463);
            this.btnCripto.Name = "btnCripto";
            this.btnCripto.Size = new System.Drawing.Size(75, 23);
            this.btnCripto.TabIndex = 13;
            this.btnCripto.Text = "Cripto";
            this.btnCripto.UseVisualStyleBackColor = true;
            this.btnCripto.Click += new System.EventHandler(this.btnCripto_Click);
            // 
            // txtCripto4
            // 
            this.txtCripto4.Location = new System.Drawing.Point(11, 437);
            this.txtCripto4.Name = "txtCripto4";
            this.txtCripto4.Size = new System.Drawing.Size(382, 20);
            this.txtCripto4.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 492);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Firma";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 536);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCripto4);
            this.Controls.Add(this.btnCripto);
            this.Controls.Add(this.txtCripto3);
            this.Controls.Add(this.txtCripto2);
            this.Controls.Add(this.txtCripto1);
            this.Controls.Add(this.txtRawData);
            this.Controls.Add(this.lblPin);
            this.Controls.Add(this.btnObtienePin);
            this.Controls.Add(this.lblFechaVencimiento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCertificado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Valida Certificado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCertificado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Button btnObtienePin;
        private System.Windows.Forms.Label lblPin;
        private System.Windows.Forms.TextBox txtRawData;
        private System.Windows.Forms.TextBox txtCripto1;
        private System.Windows.Forms.TextBox txtCripto2;
        private System.Windows.Forms.TextBox txtCripto3;
        private System.Windows.Forms.Button btnCripto;
        private System.Windows.Forms.TextBox txtCripto4;
        private System.Windows.Forms.Button button2;
    }
}

