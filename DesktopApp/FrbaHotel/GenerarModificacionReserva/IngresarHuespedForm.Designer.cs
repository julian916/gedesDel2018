﻿namespace FrbaHotel.GenerarModificacionReserva
{
    partial class IngresarHuespedForm
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
            this.apellidoBox = new System.Windows.Forms.TextBox();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboTipoDNI = new System.Windows.Forms.ComboBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.nroDNIBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataClientesEncontrados = new System.Windows.Forms.DataGridView();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.newClienteBtn = new System.Windows.Forms.Button();
            this.buscarBtn = new System.Windows.Forms.Button();
            this.seleccionarBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientesEncontrados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.apellidoBox);
            this.panel1.Controls.Add(this.nombreBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboTipoDNI);
            this.panel1.Controls.Add(this.emailBox);
            this.panel1.Controls.Add(this.nroDNIBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(64, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 130);
            this.panel1.TabIndex = 1;
            // 
            // apellidoBox
            // 
            this.apellidoBox.Location = new System.Drawing.Point(478, 67);
            this.apellidoBox.Name = "apellidoBox";
            this.apellidoBox.Size = new System.Drawing.Size(219, 20);
            this.apellidoBox.TabIndex = 10;
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(478, 33);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(219, 20);
            this.nombreBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Apellido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre";
            // 
            // comboTipoDNI
            // 
            this.comboTipoDNI.FormattingEnabled = true;
            this.comboTipoDNI.Location = new System.Drawing.Point(158, 33);
            this.comboTipoDNI.Name = "comboTipoDNI";
            this.comboTipoDNI.Size = new System.Drawing.Size(184, 21);
            this.comboTipoDNI.TabIndex = 6;
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(158, 99);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(184, 20);
            this.emailBox.TabIndex = 5;
            // 
            // nroDNIBox
            // 
            this.nroDNIBox.Location = new System.Drawing.Point(158, 67);
            this.nroDNIBox.Name = "nroDNIBox";
            this.nroDNIBox.Size = new System.Drawing.Size(184, 20);
            this.nroDNIBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nro. Documento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo Documento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar búsqueda";
            // 
            // dataClientesEncontrados
            // 
            this.dataClientesEncontrados.AllowUserToAddRows = false;
            this.dataClientesEncontrados.AllowUserToDeleteRows = false;
            this.dataClientesEncontrados.AllowUserToOrderColumns = true;
            this.dataClientesEncontrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataClientesEncontrados.Location = new System.Drawing.Point(46, 208);
            this.dataClientesEncontrados.Name = "dataClientesEncontrados";
            this.dataClientesEncontrados.ReadOnly = true;
            this.dataClientesEncontrados.Size = new System.Drawing.Size(782, 150);
            this.dataClientesEncontrados.TabIndex = 7;
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(589, 394);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(116, 23);
            this.cancelarBtn.TabIndex = 10;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // newClienteBtn
            // 
            this.newClienteBtn.Location = new System.Drawing.Point(203, 394);
            this.newClienteBtn.Name = "newClienteBtn";
            this.newClienteBtn.Size = new System.Drawing.Size(116, 23);
            this.newClienteBtn.TabIndex = 9;
            this.newClienteBtn.Text = "Nuevo Cliente";
            this.newClienteBtn.UseVisualStyleBackColor = true;
            this.newClienteBtn.Click += new System.EventHandler(this.newClienteBtn_Click);
            // 
            // buscarBtn
            // 
            this.buscarBtn.Location = new System.Drawing.Point(697, 166);
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.Size = new System.Drawing.Size(75, 23);
            this.buscarBtn.TabIndex = 8;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // seleccionarBtn
            // 
            this.seleccionarBtn.Location = new System.Drawing.Point(391, 394);
            this.seleccionarBtn.Name = "seleccionarBtn";
            this.seleccionarBtn.Size = new System.Drawing.Size(116, 23);
            this.seleccionarBtn.TabIndex = 11;
            this.seleccionarBtn.Text = "Seleccionar";
            this.seleccionarBtn.UseVisualStyleBackColor = true;
            this.seleccionarBtn.Click += new System.EventHandler(this.seleccionarBtn_Click);
            // 
            // IngresarHuespedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 446);
            this.Controls.Add(this.seleccionarBtn);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.newClienteBtn);
            this.Controls.Add(this.buscarBtn);
            this.Controls.Add(this.dataClientesEncontrados);
            this.Controls.Add(this.panel1);
            this.Name = "IngresarHuespedForm";
            this.Text = "IngresarHuespedForm";
            this.Load += new System.EventHandler(this.IngresarHuespedForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientesEncontrados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox apellidoBox;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboTipoDNI;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox nroDNIBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataClientesEncontrados;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Button newClienteBtn;
        private System.Windows.Forms.Button buscarBtn;
        private System.Windows.Forms.Button seleccionarBtn;
    }
}