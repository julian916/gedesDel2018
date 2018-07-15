namespace FrbaHotel.RegistrarEstadia
{
    partial class CheckOUTForm
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
            this.codReservaBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.huespedesMaxBox = new System.Windows.Forms.TextBox();
            this.titularBox = new System.Windows.Forms.TextBox();
            this.cantNochesBox = new System.Windows.Forms.TextBox();
            this.fechaInicioRes = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buscarBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.fechaCheckOutBox = new System.Windows.Forms.DateTimePicker();
            this.dataGridConsumibles = new System.Windows.Forms.DataGridView();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.newConsumBtn = new System.Windows.Forms.Button();
            this.cerrarEstadiaBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.facturarBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.fechaInicioEstBox = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsumibles)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese codigo reserva";
            // 
            // codReservaBox
            // 
            this.codReservaBox.Location = new System.Drawing.Point(197, 14);
            this.codReservaBox.Name = "codReservaBox";
            this.codReservaBox.Size = new System.Drawing.Size(182, 20);
            this.codReservaBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Huéspedes permitidos";
            // 
            // huespedesMaxBox
            // 
            this.huespedesMaxBox.Location = new System.Drawing.Point(237, 130);
            this.huespedesMaxBox.Name = "huespedesMaxBox";
            this.huespedesMaxBox.ReadOnly = true;
            this.huespedesMaxBox.Size = new System.Drawing.Size(100, 20);
            this.huespedesMaxBox.TabIndex = 13;
            // 
            // titularBox
            // 
            this.titularBox.Location = new System.Drawing.Point(237, 104);
            this.titularBox.Name = "titularBox";
            this.titularBox.ReadOnly = true;
            this.titularBox.Size = new System.Drawing.Size(200, 20);
            this.titularBox.TabIndex = 12;
            // 
            // cantNochesBox
            // 
            this.cantNochesBox.Location = new System.Drawing.Point(237, 75);
            this.cantNochesBox.Name = "cantNochesBox";
            this.cantNochesBox.ReadOnly = true;
            this.cantNochesBox.Size = new System.Drawing.Size(100, 20);
            this.cantNochesBox.TabIndex = 11;
            // 
            // fechaInicioRes
            // 
            this.fechaInicioRes.Location = new System.Drawing.Point(237, 47);
            this.fechaInicioRes.Name = "fechaInicioRes";
            this.fechaInicioRes.Size = new System.Drawing.Size(200, 20);
            this.fechaInicioRes.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Titular Reserva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cantidad de noches";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha Inicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Datos de la reserva";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.huespedesMaxBox);
            this.panel1.Controls.Add(this.titularBox);
            this.panel1.Controls.Add(this.cantNochesBox);
            this.panel1.Controls.Add(this.fechaInicioRes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 167);
            this.panel1.TabIndex = 2;
            // 
            // buscarBtn
            // 
            this.buscarBtn.Location = new System.Drawing.Point(425, 12);
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.Size = new System.Drawing.Size(75, 23);
            this.buscarBtn.TabIndex = 3;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Fecha Check OUT";
            // 
            // fechaCheckOutBox
            // 
            this.fechaCheckOutBox.Location = new System.Drawing.Point(169, 37);
            this.fechaCheckOutBox.Name = "fechaCheckOutBox";
            this.fechaCheckOutBox.Size = new System.Drawing.Size(200, 20);
            this.fechaCheckOutBox.TabIndex = 5;
            // 
            // dataGridConsumibles
            // 
            this.dataGridConsumibles.AllowUserToAddRows = false;
            this.dataGridConsumibles.AllowUserToDeleteRows = false;
            this.dataGridConsumibles.AllowUserToOrderColumns = true;
            this.dataGridConsumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConsumibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcion,
            this.cantidad,
            this.precioUnitario});
            this.dataGridConsumibles.Location = new System.Drawing.Point(169, 63);
            this.dataGridConsumibles.Name = "dataGridConsumibles";
            this.dataGridConsumibles.ReadOnly = true;
            this.dataGridConsumibles.Size = new System.Drawing.Size(341, 150);
            this.dataGridConsumibles.TabIndex = 6;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // precioUnitario
            // 
            this.precioUnitario.HeaderText = "Precio Unitario";
            this.precioUnitario.Name = "precioUnitario";
            this.precioUnitario.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Consumibles registrados";
            // 
            // newConsumBtn
            // 
            this.newConsumBtn.Location = new System.Drawing.Point(47, 130);
            this.newConsumBtn.Name = "newConsumBtn";
            this.newConsumBtn.Size = new System.Drawing.Size(75, 50);
            this.newConsumBtn.TabIndex = 8;
            this.newConsumBtn.Text = "Agregar Consumibles";
            this.newConsumBtn.UseVisualStyleBackColor = true;
            this.newConsumBtn.Click += new System.EventHandler(this.newConsumBtn_Click);
            // 
            // cerrarEstadiaBtn
            // 
            this.cerrarEstadiaBtn.Location = new System.Drawing.Point(102, 469);
            this.cerrarEstadiaBtn.Name = "cerrarEstadiaBtn";
            this.cerrarEstadiaBtn.Size = new System.Drawing.Size(99, 23);
            this.cerrarEstadiaBtn.TabIndex = 9;
            this.cerrarEstadiaBtn.Text = "Cerrar Estadía";
            this.cerrarEstadiaBtn.UseVisualStyleBackColor = true;
            this.cerrarEstadiaBtn.Click += new System.EventHandler(this.cerrarEstadiaBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(389, 469);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(101, 23);
            this.cancelarBtn.TabIndex = 10;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            // 
            // facturarBtn
            // 
            this.facturarBtn.Location = new System.Drawing.Point(249, 469);
            this.facturarBtn.Name = "facturarBtn";
            this.facturarBtn.Size = new System.Drawing.Size(100, 23);
            this.facturarBtn.TabIndex = 11;
            this.facturarBtn.Text = "Facturar";
            this.facturarBtn.UseVisualStyleBackColor = true;
            this.facturarBtn.Click += new System.EventHandler(this.facturarBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.fechaInicioEstBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.fechaCheckOutBox);
            this.panel2.Controls.Add(this.dataGridConsumibles);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.newConsumBtn);
            this.panel2.Location = new System.Drawing.Point(12, 230);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 216);
            this.panel2.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Fecha Check IN";
            // 
            // fechaInicioEstBox
            // 
            this.fechaInicioEstBox.Location = new System.Drawing.Point(169, 14);
            this.fechaInicioEstBox.Name = "fechaInicioEstBox";
            this.fechaInicioEstBox.Size = new System.Drawing.Size(200, 20);
            this.fechaInicioEstBox.TabIndex = 10;
            // 
            // CheckOUTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 504);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.facturarBtn);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.cerrarEstadiaBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.codReservaBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buscarBtn);
            this.Name = "CheckOUTForm";
            this.Text = "Ingrese datos de check OUT";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsumibles)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codReservaBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox huespedesMaxBox;
        private System.Windows.Forms.TextBox titularBox;
        private System.Windows.Forms.TextBox cantNochesBox;
        private System.Windows.Forms.DateTimePicker fechaInicioRes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker fechaCheckOutBox;
        private System.Windows.Forms.DataGridView dataGridConsumibles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button newConsumBtn;
        private System.Windows.Forms.Button cerrarEstadiaBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Button facturarBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buscarBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioUnitario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker fechaInicioEstBox;
    }
}