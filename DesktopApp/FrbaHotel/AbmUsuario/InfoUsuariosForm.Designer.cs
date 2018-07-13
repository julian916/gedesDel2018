namespace FrbaHotel.AbmUsuario
{
    partial class InfoUsuariosForm
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
            this.panelUsername = new System.Windows.Forms.Panel();
            this.buscarBtn = new System.Windows.Forms.Button();
            this.userBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buscarUsernameBtn = new System.Windows.Forms.Button();
            this.allUserBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridUsers = new System.Windows.Forms.DataGridView();
            this.newUserBtn = new System.Windows.Forms.Button();
            this.updateUserBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.panelUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUsername
            // 
            this.panelUsername.Controls.Add(this.buscarBtn);
            this.panelUsername.Controls.Add(this.userBox);
            this.panelUsername.Controls.Add(this.label1);
            this.panelUsername.Location = new System.Drawing.Point(31, 109);
            this.panelUsername.Name = "panelUsername";
            this.panelUsername.Size = new System.Drawing.Size(334, 92);
            this.panelUsername.TabIndex = 0;
            this.panelUsername.Paint += new System.Windows.Forms.PaintEventHandler(this.panelUsername_Paint);
            // 
            // buscarBtn
            // 
            this.buscarBtn.Location = new System.Drawing.Point(131, 54);
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.Size = new System.Drawing.Size(75, 23);
            this.buscarBtn.TabIndex = 2;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(146, 18);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(172, 20);
            this.userBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "username";
            // 
            // buscarUsernameBtn
            // 
            this.buscarUsernameBtn.Location = new System.Drawing.Point(31, 66);
            this.buscarUsernameBtn.Name = "buscarUsernameBtn";
            this.buscarUsernameBtn.Size = new System.Drawing.Size(137, 23);
            this.buscarUsernameBtn.TabIndex = 1;
            this.buscarUsernameBtn.Text = "Buscar por username";
            this.buscarUsernameBtn.UseVisualStyleBackColor = true;
            this.buscarUsernameBtn.Click += new System.EventHandler(this.buscarUsernameBtn_Click);
            // 
            // allUserBtn
            // 
            this.allUserBtn.Location = new System.Drawing.Point(228, 66);
            this.allUserBtn.Name = "allUserBtn";
            this.allUserBtn.Size = new System.Drawing.Size(137, 23);
            this.allUserBtn.TabIndex = 2;
            this.allUserBtn.Text = "Todos los usuarios";
            this.allUserBtn.UseVisualStyleBackColor = true;
            this.allUserBtn.Click += new System.EventHandler(this.allUserBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione modo de búsqueda";
            // 
            // dataGridUsers
            // 
            this.dataGridUsers.AllowUserToAddRows = false;
            this.dataGridUsers.AllowUserToDeleteRows = false;
            this.dataGridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUsers.Location = new System.Drawing.Point(31, 217);
            this.dataGridUsers.Name = "dataGridUsers";
            this.dataGridUsers.ReadOnly = true;
            this.dataGridUsers.Size = new System.Drawing.Size(334, 156);
            this.dataGridUsers.TabIndex = 4;
            // 
            // newUserBtn
            // 
            this.newUserBtn.Location = new System.Drawing.Point(31, 393);
            this.newUserBtn.Name = "newUserBtn";
            this.newUserBtn.Size = new System.Drawing.Size(75, 36);
            this.newUserBtn.TabIndex = 5;
            this.newUserBtn.Text = "Nuevo Usuario";
            this.newUserBtn.UseVisualStyleBackColor = true;
            this.newUserBtn.Click += new System.EventHandler(this.newUserBtn_Click);
            // 
            // updateUserBtn
            // 
            this.updateUserBtn.Location = new System.Drawing.Point(162, 393);
            this.updateUserBtn.Name = "updateUserBtn";
            this.updateUserBtn.Size = new System.Drawing.Size(75, 36);
            this.updateUserBtn.TabIndex = 6;
            this.updateUserBtn.Text = "Modificar Usuario";
            this.updateUserBtn.UseVisualStyleBackColor = true;
            this.updateUserBtn.Click += new System.EventHandler(this.updateUserBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(290, 393);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(75, 36);
            this.cancelarBtn.TabIndex = 7;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // InfoUsuariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 466);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.updateUserBtn);
            this.Controls.Add(this.newUserBtn);
            this.Controls.Add(this.dataGridUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.allUserBtn);
            this.Controls.Add(this.buscarUsernameBtn);
            this.Controls.Add(this.panelUsername);
            this.Name = "InfoUsuariosForm";
            this.Text = "Modificacion-Baja de usuario";
            this.Load += new System.EventHandler(this.ModBajaUsuarioForm_Load);
            this.panelUsername.ResumeLayout(false);
            this.panelUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelUsername;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buscarBtn;
        private System.Windows.Forms.Button buscarUsernameBtn;
        private System.Windows.Forms.Button allUserBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridUsers;
        private System.Windows.Forms.Button newUserBtn;
        private System.Windows.Forms.Button updateUserBtn;
        private System.Windows.Forms.Button cancelarBtn;


    }
}