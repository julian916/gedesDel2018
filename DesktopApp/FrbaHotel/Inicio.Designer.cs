﻿namespace FrbaHotel
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.hotelesBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.hotelesBtn.Location = new System.Drawing.Point(55, 126);
            this.hotelesBtn.Name = "button1";
            this.hotelesBtn.Size = new System.Drawing.Size(132, 67);
            this.hotelesBtn.TabIndex = 0;
            this.hotelesBtn.Text = "Buscar Hotel";
            this.hotelesBtn.UseVisualStyleBackColor = true;
            this.hotelesBtn.Click += new System.EventHandler(this.buscarHoteles_Click);
            // 
            // button2
            // 
            this.loginBtn.Location = new System.Drawing.Point(259, 126);
            this.loginBtn.Name = "button2";
            this.loginBtn.Size = new System.Drawing.Size(132, 67);
            this.loginBtn.TabIndex = 1;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.login_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 327);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.hotelesBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button hotelesBtn;
        private System.Windows.Forms.Button loginBtn;
    }
}
