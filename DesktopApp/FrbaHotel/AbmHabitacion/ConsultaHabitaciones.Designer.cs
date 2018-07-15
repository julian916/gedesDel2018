namespace FrbaHotel.AbmHabitacion
{
    partial class ConsultaHabitaciones
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoHabBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridHabitaciones = new System.Windows.Forms.DataGridView();
            this.newHabBtn = new System.Windows.Forms.Button();
            this.modificarBtn = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.inhHabBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.infoHabBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 44);
            this.panel1.TabIndex = 14;
            // 
            // infoHabBox
            // 
            this.infoHabBox.AutoSize = true;
            this.infoHabBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoHabBox.Location = new System.Drawing.Point(173, 14);
            this.infoHabBox.Name = "infoHabBox";
            this.infoHabBox.Size = new System.Drawing.Size(41, 13);
            this.infoHabBox.TabIndex = 3;
            this.infoHabBox.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "El cambio se realizará en el Hotel: ";
            // 
            // dataGridHabitaciones
            // 
            this.dataGridHabitaciones.AllowUserToAddRows = false;
            this.dataGridHabitaciones.AllowUserToDeleteRows = false;
            this.dataGridHabitaciones.AllowUserToOrderColumns = true;
            this.dataGridHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHabitaciones.Location = new System.Drawing.Point(22, 62);
            this.dataGridHabitaciones.Name = "dataGridHabitaciones";
            this.dataGridHabitaciones.ReadOnly = true;
            this.dataGridHabitaciones.Size = new System.Drawing.Size(642, 197);
            this.dataGridHabitaciones.TabIndex = 15;
            // 
            // newHabBtn
            // 
            this.newHabBtn.Location = new System.Drawing.Point(58, 271);
            this.newHabBtn.Name = "newHabBtn";
            this.newHabBtn.Size = new System.Drawing.Size(108, 23);
            this.newHabBtn.TabIndex = 16;
            this.newHabBtn.Text = "Nuevo";
            this.newHabBtn.UseVisualStyleBackColor = true;
            this.newHabBtn.Click += new System.EventHandler(this.newHabBtn_Click);
            // 
            // modificarBtn
            // 
            this.modificarBtn.Location = new System.Drawing.Point(211, 271);
            this.modificarBtn.Name = "modificarBtn";
            this.modificarBtn.Size = new System.Drawing.Size(108, 23);
            this.modificarBtn.TabIndex = 17;
            this.modificarBtn.Text = "Modificar";
            this.modificarBtn.UseVisualStyleBackColor = true;
            this.modificarBtn.Click += new System.EventHandler(this.modificarBtn_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(512, 271);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(108, 23);
            this.Cancelar.TabIndex = 18;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // inhHabBtn
            // 
            this.inhHabBtn.Location = new System.Drawing.Point(351, 271);
            this.inhHabBtn.Name = "inhHabBtn";
            this.inhHabBtn.Size = new System.Drawing.Size(108, 23);
            this.inhHabBtn.TabIndex = 19;
            this.inhHabBtn.Text = "Habilitar/Inhabilitar";
            this.inhHabBtn.UseVisualStyleBackColor = true;
            this.inhHabBtn.Click += new System.EventHandler(this.inhHabBtn_Click);
            // 
            // ConsultaHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 306);
            this.Controls.Add(this.inhHabBtn);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.modificarBtn);
            this.Controls.Add(this.newHabBtn);
            this.Controls.Add(this.dataGridHabitaciones);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultaHabitaciones";
            this.Text = "Consultar habitaciones";
            this.Load += new System.EventHandler(this.ConsultaHabitaciones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabitaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label infoHabBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridHabitaciones;
        private System.Windows.Forms.Button newHabBtn;
        private System.Windows.Forms.Button modificarBtn;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button inhHabBtn;
    }
}