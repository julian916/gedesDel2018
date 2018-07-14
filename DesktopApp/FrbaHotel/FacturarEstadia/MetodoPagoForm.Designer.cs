namespace FrbaHotel.FacturarEstadia
{
    partial class MetodoPagoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.idEstadiaBox = new System.Windows.Forms.TextBox();
            this.diasAlojBox = new System.Windows.Forms.TextBox();
            this.diasNoEfectBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.montoTotalBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.metodoPagoBox = new System.Windows.Forms.ComboBox();
            this.finalizarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID_Estadia";
            // 
            // idEstadiaBox
            // 
            this.idEstadiaBox.Location = new System.Drawing.Point(176, 20);
            this.idEstadiaBox.Name = "idEstadiaBox";
            this.idEstadiaBox.ReadOnly = true;
            this.idEstadiaBox.Size = new System.Drawing.Size(199, 20);
            this.idEstadiaBox.TabIndex = 1;
            // 
            // diasAlojBox
            // 
            this.diasAlojBox.Location = new System.Drawing.Point(176, 46);
            this.diasAlojBox.Name = "diasAlojBox";
            this.diasAlojBox.ReadOnly = true;
            this.diasAlojBox.Size = new System.Drawing.Size(100, 20);
            this.diasAlojBox.TabIndex = 2;
            // 
            // diasNoEfectBox
            // 
            this.diasNoEfectBox.Location = new System.Drawing.Point(176, 72);
            this.diasNoEfectBox.Name = "diasNoEfectBox";
            this.diasNoEfectBox.ReadOnly = true;
            this.diasNoEfectBox.Size = new System.Drawing.Size(100, 20);
            this.diasNoEfectBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Días alojamiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Días NO Efectivos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Monto Total";
            // 
            // montoTotalBox
            // 
            this.montoTotalBox.Location = new System.Drawing.Point(176, 105);
            this.montoTotalBox.Name = "montoTotalBox";
            this.montoTotalBox.ReadOnly = true;
            this.montoTotalBox.Size = new System.Drawing.Size(100, 20);
            this.montoTotalBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Elija método de pago";
            // 
            // metodoPagoBox
            // 
            this.metodoPagoBox.FormattingEnabled = true;
            this.metodoPagoBox.Location = new System.Drawing.Point(176, 145);
            this.metodoPagoBox.Name = "metodoPagoBox";
            this.metodoPagoBox.Size = new System.Drawing.Size(121, 21);
            this.metodoPagoBox.TabIndex = 9;
            // 
            // finalizarBtn
            // 
            this.finalizarBtn.Location = new System.Drawing.Point(132, 192);
            this.finalizarBtn.Name = "finalizarBtn";
            this.finalizarBtn.Size = new System.Drawing.Size(144, 23);
            this.finalizarBtn.TabIndex = 10;
            this.finalizarBtn.Text = "Finalizar Factura";
            this.finalizarBtn.UseVisualStyleBackColor = true;
            this.finalizarBtn.Click += new System.EventHandler(this.finalizarBtn_Click);
            // 
            // MetodoPagoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 243);
            this.Controls.Add(this.finalizarBtn);
            this.Controls.Add(this.metodoPagoBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.montoTotalBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.diasNoEfectBox);
            this.Controls.Add(this.diasAlojBox);
            this.Controls.Add(this.idEstadiaBox);
            this.Controls.Add(this.label1);
            this.Name = "MetodoPagoForm";
            this.Text = "Confirme método de pago";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idEstadiaBox;
        private System.Windows.Forms.TextBox diasAlojBox;
        private System.Windows.Forms.TextBox diasNoEfectBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox montoTotalBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox metodoPagoBox;
        private System.Windows.Forms.Button finalizarBtn;
    }
}