namespace FrbaHotel.RegistrarConsumible
{
    partial class NuevoConsumibleForm
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
            this.idEstadiaBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridConsumibles = new System.Windows.Forms.DataGridView();
            this.consumiblesBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cantBox = new System.Windows.Forms.NumericUpDown();
            this.confirmarBtn = new System.Windows.Forms.Button();
            this.addConsumBtn = new System.Windows.Forms.Button();
            this.deleteConsBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.precioBox = new System.Windows.Forms.TextBox();
            this.consumible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsumibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código estadía";
            // 
            // idEstadiaBox
            // 
            this.idEstadiaBox.Location = new System.Drawing.Point(152, 20);
            this.idEstadiaBox.Name = "idEstadiaBox";
            this.idEstadiaBox.ReadOnly = true;
            this.idEstadiaBox.Size = new System.Drawing.Size(154, 20);
            this.idEstadiaBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Consumible";
            // 
            // dataGridConsumibles
            // 
            this.dataGridConsumibles.AllowUserToAddRows = false;
            this.dataGridConsumibles.AllowUserToDeleteRows = false;
            this.dataGridConsumibles.AllowUserToOrderColumns = true;
            this.dataGridConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConsumibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.consumible,
            this.cantidad,
            this.precio});
            this.dataGridConsumibles.Location = new System.Drawing.Point(36, 126);
            this.dataGridConsumibles.Name = "dataGridConsumibles";
            this.dataGridConsumibles.ReadOnly = true;
            this.dataGridConsumibles.Size = new System.Drawing.Size(406, 125);
            this.dataGridConsumibles.TabIndex = 3;
            // 
            // consumiblesBox
            // 
            this.consumiblesBox.FormattingEnabled = true;
            this.consumiblesBox.Location = new System.Drawing.Point(152, 58);
            this.consumiblesBox.Name = "consumiblesBox";
            this.consumiblesBox.Size = new System.Drawing.Size(290, 21);
            this.consumiblesBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Precio";
            // 
            // cantBox
            // 
            this.cantBox.Location = new System.Drawing.Point(152, 93);
            this.cantBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cantBox.Name = "cantBox";
            this.cantBox.Size = new System.Drawing.Size(64, 20);
            this.cantBox.TabIndex = 8;
            this.cantBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // confirmarBtn
            // 
            this.confirmarBtn.Location = new System.Drawing.Point(36, 257);
            this.confirmarBtn.Name = "confirmarBtn";
            this.confirmarBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmarBtn.TabIndex = 10;
            this.confirmarBtn.Text = "Confirmar";
            this.confirmarBtn.UseVisualStyleBackColor = true;
            this.confirmarBtn.Click += new System.EventHandler(this.confirmarBtn_Click);
            // 
            // addConsumBtn
            // 
            this.addConsumBtn.Location = new System.Drawing.Point(141, 257);
            this.addConsumBtn.Name = "addConsumBtn";
            this.addConsumBtn.Size = new System.Drawing.Size(75, 23);
            this.addConsumBtn.TabIndex = 11;
            this.addConsumBtn.Text = "Agregar";
            this.addConsumBtn.UseVisualStyleBackColor = true;
            this.addConsumBtn.Click += new System.EventHandler(this.addConsumBtn_Click);
            // 
            // deleteConsBtn
            // 
            this.deleteConsBtn.Location = new System.Drawing.Point(250, 257);
            this.deleteConsBtn.Name = "deleteConsBtn";
            this.deleteConsBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteConsBtn.TabIndex = 12;
            this.deleteConsBtn.Text = "Eliminar";
            this.deleteConsBtn.UseVisualStyleBackColor = true;
            this.deleteConsBtn.Click += new System.EventHandler(this.deleteConsBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(367, 257);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarBtn.TabIndex = 13;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // precioBox
            // 
            this.precioBox.Location = new System.Drawing.Point(342, 92);
            this.precioBox.Name = "precioBox";
            this.precioBox.ReadOnly = true;
            this.precioBox.Size = new System.Drawing.Size(100, 20);
            this.precioBox.TabIndex = 14;
            // 
            // consumible
            // 
            this.consumible.HeaderText = "Consumible";
            this.consumible.Name = "consumible";
            this.consumible.ReadOnly = true;
            this.consumible.Width = 150;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio Acumulado";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // NuevoConsumibleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 312);
            this.Controls.Add(this.precioBox);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.deleteConsBtn);
            this.Controls.Add(this.addConsumBtn);
            this.Controls.Add(this.confirmarBtn);
            this.Controls.Add(this.cantBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.consumiblesBox);
            this.Controls.Add(this.dataGridConsumibles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idEstadiaBox);
            this.Controls.Add(this.label1);
            this.Name = "NuevoConsumibleForm";
            this.Text = "Ingrese consumible a Estadía";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsumibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cantBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idEstadiaBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridConsumibles;
        private System.Windows.Forms.ComboBox consumiblesBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown cantBox;
        private System.Windows.Forms.Button confirmarBtn;
        private System.Windows.Forms.Button addConsumBtn;
        private System.Windows.Forms.Button deleteConsBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.TextBox precioBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
    }
}