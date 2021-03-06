﻿namespace FrbaHotel.ABMHotel
{
    partial class BajaHotelForm
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
            this.infoHotelBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaInicioBaja = new System.Windows.Forms.DateTimePicker();
            this.detalleBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.darDeBajaBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cantidadDiasBox = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadDiasBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.infoHotelBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 44);
            this.panel1.TabIndex = 14;
            // 
            // infoHotelBox
            // 
            this.infoHotelBox.AutoSize = true;
            this.infoHotelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoHotelBox.Location = new System.Drawing.Point(173, 14);
            this.infoHotelBox.Name = "infoHotelBox";
            this.infoHotelBox.Size = new System.Drawing.Size(41, 13);
            this.infoHotelBox.TabIndex = 3;
            this.infoHotelBox.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "La baja será en el hotel con Info:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Fecha Inicio de Baja";
            // 
            // fechaInicioBaja
            // 
            this.fechaInicioBaja.Location = new System.Drawing.Point(190, 67);
            this.fechaInicioBaja.Name = "fechaInicioBaja";
            this.fechaInicioBaja.Size = new System.Drawing.Size(200, 20);
            this.fechaInicioBaja.TabIndex = 16;
            // 
            // detalleBox
            // 
            this.detalleBox.Location = new System.Drawing.Point(190, 142);
            this.detalleBox.Multiline = true;
            this.detalleBox.Name = "detalleBox";
            this.detalleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detalleBox.Size = new System.Drawing.Size(200, 71);
            this.detalleBox.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Detalle";
            // 
            // darDeBajaBtn
            // 
            this.darDeBajaBtn.Location = new System.Drawing.Point(190, 226);
            this.darDeBajaBtn.Name = "darDeBajaBtn";
            this.darDeBajaBtn.Size = new System.Drawing.Size(75, 23);
            this.darDeBajaBtn.TabIndex = 21;
            this.darDeBajaBtn.Text = "Dar de Baja";
            this.darDeBajaBtn.UseVisualStyleBackColor = true;
            this.darDeBajaBtn.Click += new System.EventHandler(this.darDeBajaBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(322, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Cantidad de días";
            // 
            // cantidadDiasBox
            // 
            this.cantidadDiasBox.Location = new System.Drawing.Point(190, 106);
            this.cantidadDiasBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cantidadDiasBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantidadDiasBox.Name = "cantidadDiasBox";
            this.cantidadDiasBox.Size = new System.Drawing.Size(120, 20);
            this.cantidadDiasBox.TabIndex = 24;
            this.cantidadDiasBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BajaHotelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 296);
            this.Controls.Add(this.cantidadDiasBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.darDeBajaBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.detalleBox);
            this.Controls.Add(this.fechaInicioBaja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "BajaHotelForm";
            this.Text = "Informe baja de hotel";
            this.Load += new System.EventHandler(this.BajaHotelForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cantidadDiasBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label infoHotelBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechaInicioBaja;
        private System.Windows.Forms.TextBox detalleBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button darDeBajaBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cantidadDiasBox;
    }
}