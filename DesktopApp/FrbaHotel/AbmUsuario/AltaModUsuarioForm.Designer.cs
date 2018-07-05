namespace FrbaHotel.AbmUsuario
{
    partial class AltaModUsuarioForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.pass2TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.comboRoles = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rolPanel = new System.Windows.Forms.Panel();
            this.selectRolBtn = new System.Windows.Forms.Button();
            this.hotelListBox = new System.Windows.Forms.CheckedListBox();
            this.hotelPanel = new System.Windows.Forms.Panel();
            this.confirmRol = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.updateRolBtn = new System.Windows.Forms.Button();
            this.deleteRolBtn = new System.Windows.Forms.Button();
            this.newRolBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rolPanel.SuspendLayout();
            this.hotelPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirmar contraseña";
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(300, 58);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(179, 20);
            this.userTextBox.TabIndex = 3;
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(300, 96);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(179, 20);
            this.passTextBox.TabIndex = 4;
            // 
            // pass2TextBox
            // 
            this.pass2TextBox.Location = new System.Drawing.Point(300, 135);
            this.pass2TextBox.Name = "pass2TextBox";
            this.pass2TextBox.PasswordChar = '*';
            this.pass2TextBox.Size = new System.Drawing.Size(179, 20);
            this.pass2TextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(253, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ingrese datos de usuario";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(159, 409);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 7;
            this.acceptButton.Text = "Aceptar";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(439, 409);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // comboRoles
            // 
            this.comboRoles.FormattingEnabled = true;
            this.comboRoles.Location = new System.Drawing.Point(110, 17);
            this.comboRoles.Name = "comboRoles";
            this.comboRoles.Size = new System.Drawing.Size(179, 21);
            this.comboRoles.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hoteles para Rol";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Rol asignado";
            // 
            // rolPanel
            // 
            this.rolPanel.Controls.Add(this.selectRolBtn);
            this.rolPanel.Controls.Add(this.label6);
            this.rolPanel.Controls.Add(this.comboRoles);
            this.rolPanel.Location = new System.Drawing.Point(20, 16);
            this.rolPanel.Name = "rolPanel";
            this.rolPanel.Size = new System.Drawing.Size(306, 85);
            this.rolPanel.TabIndex = 20;
            // 
            // selectRolBtn
            // 
            this.selectRolBtn.Location = new System.Drawing.Point(110, 44);
            this.selectRolBtn.Name = "selectRolBtn";
            this.selectRolBtn.Size = new System.Drawing.Size(75, 23);
            this.selectRolBtn.TabIndex = 13;
            this.selectRolBtn.Text = "Seleccionar";
            this.selectRolBtn.UseVisualStyleBackColor = true;
            this.selectRolBtn.Click += new System.EventHandler(this.selectRolBtn_Click);
            // 
            // hotelListBox
            // 
            this.hotelListBox.FormattingEnabled = true;
            this.hotelListBox.Location = new System.Drawing.Point(110, 20);
            this.hotelListBox.Name = "hotelListBox";
            this.hotelListBox.Size = new System.Drawing.Size(179, 94);
            this.hotelListBox.TabIndex = 13;
            // 
            // hotelPanel
            // 
            this.hotelPanel.Controls.Add(this.confirmRol);
            this.hotelPanel.Controls.Add(this.label5);
            this.hotelPanel.Controls.Add(this.hotelListBox);
            this.hotelPanel.Location = new System.Drawing.Point(332, 16);
            this.hotelPanel.Name = "hotelPanel";
            this.hotelPanel.Size = new System.Drawing.Size(334, 152);
            this.hotelPanel.TabIndex = 22;
            // 
            // confirmRol
            // 
            this.confirmRol.Location = new System.Drawing.Point(129, 120);
            this.confirmRol.Name = "confirmRol";
            this.confirmRol.Size = new System.Drawing.Size(132, 23);
            this.confirmRol.TabIndex = 27;
            this.confirmRol.Text = "Confirmar Rol";
            this.confirmRol.UseVisualStyleBackColor = true;
            this.confirmRol.Click += new System.EventHandler(this.confirmRol_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.updateRolBtn);
            this.panel3.Controls.Add(this.deleteRolBtn);
            this.panel3.Controls.Add(this.newRolBtn);
            this.panel3.Controls.Add(this.rolPanel);
            this.panel3.Controls.Add(this.hotelPanel);
            this.panel3.Location = new System.Drawing.Point(12, 210);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 193);
            this.panel3.TabIndex = 24;
            // 
            // updateRolBtn
            // 
            this.updateRolBtn.Location = new System.Drawing.Point(108, 165);
            this.updateRolBtn.Name = "updateRolBtn";
            this.updateRolBtn.Size = new System.Drawing.Size(132, 23);
            this.updateRolBtn.TabIndex = 26;
            this.updateRolBtn.Text = "Modificar Rol";
            this.updateRolBtn.UseVisualStyleBackColor = true;
            // 
            // deleteRolBtn
            // 
            this.deleteRolBtn.Location = new System.Drawing.Point(108, 136);
            this.deleteRolBtn.Name = "deleteRolBtn";
            this.deleteRolBtn.Size = new System.Drawing.Size(132, 23);
            this.deleteRolBtn.TabIndex = 25;
            this.deleteRolBtn.Text = "Desasignar Rol";
            this.deleteRolBtn.UseVisualStyleBackColor = true;
            // 
            // newRolBtn
            // 
            this.newRolBtn.Location = new System.Drawing.Point(108, 107);
            this.newRolBtn.Name = "newRolBtn";
            this.newRolBtn.Size = new System.Drawing.Size(132, 23);
            this.newRolBtn.TabIndex = 23;
            this.newRolBtn.Text = "Nuevo Rol";
            this.newRolBtn.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(297, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Permisos";
            // 
            // AltaModUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 444);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pass2TextBox);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaModUsuarioForm";
            this.Text = "Alta - Modificacion Usuario";
            this.Load += new System.EventHandler(this.AltaModUsuarioForm_Load);
            this.rolPanel.ResumeLayout(false);
            this.rolPanel.PerformLayout();
            this.hotelPanel.ResumeLayout(false);
            this.hotelPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox pass2TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox comboRoles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel rolPanel;
        private System.Windows.Forms.Button selectRolBtn;
        private System.Windows.Forms.CheckedListBox hotelListBox;
        private System.Windows.Forms.Panel hotelPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button newRolBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button updateRolBtn;
        private System.Windows.Forms.Button deleteRolBtn;
        private System.Windows.Forms.Button confirmRol;
    }
}