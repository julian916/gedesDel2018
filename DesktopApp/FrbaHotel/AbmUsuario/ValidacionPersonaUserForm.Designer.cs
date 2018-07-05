namespace FrbaHotel.AbmUsuario
{
    partial class ValidacionPersonaUserForm
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
            this.label10 = new System.Windows.Forms.Label();
            this.dniBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboTipoDni = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mailBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.validarBtn = new System.Windows.Forms.Button();
            this.CancelarBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(315, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "A continuación se validarán los siguientes datos";
            // 
            // dniBox
            // 
            this.dniBox.Location = new System.Drawing.Point(141, 86);
            this.dniBox.Name = "dniBox";
            this.dniBox.Size = new System.Drawing.Size(179, 20);
            this.dniBox.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "DNI";
            // 
            // comboTipoDni
            // 
            this.comboTipoDni.FormattingEnabled = true;
            this.comboTipoDni.Location = new System.Drawing.Point(141, 59);
            this.comboTipoDni.Name = "comboTipoDni";
            this.comboTipoDni.Size = new System.Drawing.Size(121, 21);
            this.comboTipoDni.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Tipo Documento";
            // 
            // mailBox
            // 
            this.mailBox.Location = new System.Drawing.Point(141, 119);
            this.mailBox.Name = "mailBox";
            this.mailBox.Size = new System.Drawing.Size(179, 20);
            this.mailBox.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "E-mail";
            // 
            // validarBtn
            // 
            this.validarBtn.Location = new System.Drawing.Point(35, 171);
            this.validarBtn.Name = "validarBtn";
            this.validarBtn.Size = new System.Drawing.Size(75, 23);
            this.validarBtn.TabIndex = 29;
            this.validarBtn.Text = "Validar";
            this.validarBtn.UseVisualStyleBackColor = true;
            this.validarBtn.Click += new System.EventHandler(this.validarBtn_Click);
            // 
            // CancelarBtn
            // 
            this.CancelarBtn.Location = new System.Drawing.Point(245, 171);
            this.CancelarBtn.Name = "CancelarBtn";
            this.CancelarBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelarBtn.TabIndex = 30;
            this.CancelarBtn.Text = "Cancelar";
            this.CancelarBtn.UseVisualStyleBackColor = true;
            this.CancelarBtn.Click += new System.EventHandler(this.CancelarBtn_Click);
            // 
            // ValidacionPersonaUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 219);
            this.Controls.Add(this.CancelarBtn);
            this.Controls.Add(this.validarBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dniBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboTipoDni);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mailBox);
            this.Controls.Add(this.label7);
            this.Name = "ValidacionPersonaUserForm";
            this.Text = "Ingrese los siguientes datos";
            this.Load += new System.EventHandler(this.ValidacionPersonaUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox dniBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboTipoDni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mailBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button validarBtn;
        private System.Windows.Forms.Button CancelarBtn;
    }
}