namespace FrbaHotel.Login
{
    partial class SelHotelRolLoginForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.hotelesComboBox = new System.Windows.Forms.ComboBox();
            this.rolesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelRol = new System.Windows.Forms.Panel();
            this.selecRolButton = new System.Windows.Forms.Button();
            this.panelDireccion = new System.Windows.Forms.Panel();
            this.selecHotelButton = new System.Windows.Forms.Button();
            this.panelRol.SuspendLayout();
            this.panelDireccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(133, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Aceptar";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(315, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // hotelesComboBox
            // 
            this.hotelesComboBox.FormattingEnabled = true;
            this.hotelesComboBox.Location = new System.Drawing.Point(119, 22);
            this.hotelesComboBox.Name = "hotelesComboBox";
            this.hotelesComboBox.Size = new System.Drawing.Size(194, 21);
            this.hotelesComboBox.TabIndex = 2;
            // 
            // rolesComboBox
            // 
            this.rolesComboBox.FormattingEnabled = true;
            this.rolesComboBox.Location = new System.Drawing.Point(119, 19);
            this.rolesComboBox.Name = "rolesComboBox";
            this.rolesComboBox.Size = new System.Drawing.Size(194, 21);
            this.rolesComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Dirección Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rol";
            // 
            // panelRol
            // 
            this.panelRol.Controls.Add(this.selecRolButton);
            this.panelRol.Controls.Add(this.rolesComboBox);
            this.panelRol.Controls.Add(this.label2);
            this.panelRol.Location = new System.Drawing.Point(32, 12);
            this.panelRol.Name = "panelRol";
            this.panelRol.Size = new System.Drawing.Size(423, 62);
            this.panelRol.TabIndex = 6;
            // 
            // selecRolButton
            // 
            this.selecRolButton.Location = new System.Drawing.Point(327, 17);
            this.selecRolButton.Name = "selecRolButton";
            this.selecRolButton.Size = new System.Drawing.Size(75, 23);
            this.selecRolButton.TabIndex = 6;
            this.selecRolButton.Text = "Seleccionar";
            this.selecRolButton.UseVisualStyleBackColor = true;
            this.selecRolButton.Click += new System.EventHandler(this.selecRolButton_Click);
            // 
            // panelDireccion
            // 
            this.panelDireccion.Controls.Add(this.selecHotelButton);
            this.panelDireccion.Controls.Add(this.label1);
            this.panelDireccion.Controls.Add(this.hotelesComboBox);
            this.panelDireccion.Location = new System.Drawing.Point(32, 80);
            this.panelDireccion.Name = "panelDireccion";
            this.panelDireccion.Size = new System.Drawing.Size(423, 72);
            this.panelDireccion.TabIndex = 7;
            // 
            // selecHotelButton
            // 
            this.selecHotelButton.Location = new System.Drawing.Point(327, 25);
            this.selecHotelButton.Name = "selecHotelButton";
            this.selecHotelButton.Size = new System.Drawing.Size(75, 23);
            this.selecHotelButton.TabIndex = 7;
            this.selecHotelButton.Text = "Seleccionar";
            this.selecHotelButton.UseVisualStyleBackColor = true;
            this.selecHotelButton.Click += new System.EventHandler(this.selecHotelButton_Click);
            // 
            // SelHotelRolLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 213);
            this.Controls.Add(this.panelDireccion);
            this.Controls.Add(this.panelRol);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "SelHotelRolLoginForm";
            this.Text = "Seleccione hotel y rol asignado";
            this.Load += new System.EventHandler(this.SeleccionNuevoHotel_RolFormcs_Load);
            this.panelRol.ResumeLayout(false);
            this.panelRol.PerformLayout();
            this.panelDireccion.ResumeLayout(false);
            this.panelDireccion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox hotelesComboBox;
        private System.Windows.Forms.ComboBox rolesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelRol;
        private System.Windows.Forms.Button selecRolButton;
        private System.Windows.Forms.Panel panelDireccion;
        private System.Windows.Forms.Button selecHotelButton;
    }
}