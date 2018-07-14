namespace FrbaHotel.AbmRol
{
    partial class ConsultaRolForm
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
            this.dataGridRoles = new System.Windows.Forms.DataGridView();
            this.nuevoRolBtn = new System.Windows.Forms.Button();
            this.updateRolBtn = new System.Windows.Forms.Button();
            this.cancelarRolBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridRoles
            // 
            this.dataGridRoles.AllowUserToAddRows = false;
            this.dataGridRoles.AllowUserToDeleteRows = false;
            this.dataGridRoles.AllowUserToOrderColumns = true;
            this.dataGridRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRoles.Location = new System.Drawing.Point(33, 35);
            this.dataGridRoles.Name = "dataGridRoles";
            this.dataGridRoles.ReadOnly = true;
            this.dataGridRoles.Size = new System.Drawing.Size(316, 150);
            this.dataGridRoles.TabIndex = 0;
            // 
            // nuevoRolBtn
            // 
            this.nuevoRolBtn.Location = new System.Drawing.Point(33, 217);
            this.nuevoRolBtn.Name = "nuevoRolBtn";
            this.nuevoRolBtn.Size = new System.Drawing.Size(75, 23);
            this.nuevoRolBtn.TabIndex = 1;
            this.nuevoRolBtn.Text = "Nuevo Rol";
            this.nuevoRolBtn.UseVisualStyleBackColor = true;
            this.nuevoRolBtn.Click += new System.EventHandler(this.nuevoRolBtn_Click);
            // 
            // updateRolBtn
            // 
            this.updateRolBtn.Location = new System.Drawing.Point(152, 217);
            this.updateRolBtn.Name = "updateRolBtn";
            this.updateRolBtn.Size = new System.Drawing.Size(75, 23);
            this.updateRolBtn.TabIndex = 2;
            this.updateRolBtn.Text = "Modificar";
            this.updateRolBtn.UseVisualStyleBackColor = true;
            this.updateRolBtn.Click += new System.EventHandler(this.updateRolBtn_Click);
            // 
            // cancelarRolBtn
            // 
            this.cancelarRolBtn.Location = new System.Drawing.Point(274, 217);
            this.cancelarRolBtn.Name = "cancelarRolBtn";
            this.cancelarRolBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarRolBtn.TabIndex = 3;
            this.cancelarRolBtn.Text = "Cancelar";
            this.cancelarRolBtn.UseVisualStyleBackColor = true;
            this.cancelarRolBtn.Click += new System.EventHandler(this.cancelarRolBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Se listan los roles actuales del sistema";
            // 
            // ConsultaRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelarRolBtn);
            this.Controls.Add(this.updateRolBtn);
            this.Controls.Add(this.nuevoRolBtn);
            this.Controls.Add(this.dataGridRoles);
            this.Name = "ConsultaRolForm";
            this.Text = "Consulte roles";
            this.Load += new System.EventHandler(this.ConsultaRolForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridRoles;
        private System.Windows.Forms.Button nuevoRolBtn;
        private System.Windows.Forms.Button updateRolBtn;
        private System.Windows.Forms.Button cancelarRolBtn;
        private System.Windows.Forms.Label label1;
    }
}