namespace FrbaHotel.CancelarReserva
{
    partial class CancelarReservaForm
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
            this.codResBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.motivoBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fechaCancelacionBox = new System.Windows.Forms.DateTimePicker();
            this.cancelResBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // codResBox
            // 
            this.codResBox.Location = new System.Drawing.Point(200, 70);
            this.codResBox.Name = "codResBox";
            this.codResBox.Size = new System.Drawing.Size(154, 20);
            this.codResBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código Reserva";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese los siguientes datos para cancelar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Motivo de cancelación";
            // 
            // motivoBox
            // 
            this.motivoBox.Location = new System.Drawing.Point(200, 106);
            this.motivoBox.Multiline = true;
            this.motivoBox.Name = "motivoBox";
            this.motivoBox.Size = new System.Drawing.Size(193, 86);
            this.motivoBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fecha de cancelación";
            // 
            // fechaCancelacionBox
            // 
            this.fechaCancelacionBox.Location = new System.Drawing.Point(200, 213);
            this.fechaCancelacionBox.Name = "fechaCancelacionBox";
            this.fechaCancelacionBox.Size = new System.Drawing.Size(193, 20);
            this.fechaCancelacionBox.TabIndex = 7;
            // 
            // cancelResBtn
            // 
            this.cancelResBtn.Location = new System.Drawing.Point(53, 267);
            this.cancelResBtn.Name = "cancelResBtn";
            this.cancelResBtn.Size = new System.Drawing.Size(112, 23);
            this.cancelResBtn.TabIndex = 8;
            this.cancelResBtn.Text = "Cancelar Reserva";
            this.cancelResBtn.UseVisualStyleBackColor = true;
            this.cancelResBtn.Click += new System.EventHandler(this.cancelResBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(239, 266);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Salir";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // CancelarReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 313);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.cancelResBtn);
            this.Controls.Add(this.fechaCancelacionBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.motivoBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codResBox);
            this.Name = "CancelarReservaForm";
            this.Text = "Cancelar Reserva";
            this.Load += new System.EventHandler(this.CancelarReservaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox codResBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox motivoBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker fechaCancelacionBox;
        private System.Windows.Forms.Button cancelResBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}