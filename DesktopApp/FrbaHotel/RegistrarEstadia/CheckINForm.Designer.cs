namespace FrbaHotel.RegistrarEstadia
{
    partial class CheckINForm
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
            this.regCheckInBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.dataGridHuesped = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nro_documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addHuespedBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cantHuespMaxBox = new System.Windows.Forms.TextBox();
            this.titularResBox = new System.Windows.Forms.TextBox();
            this.cantNochesBox = new System.Windows.Forms.TextBox();
            this.fechaInicioResBox = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fechaInicioEstBox = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.codReservaBox = new System.Windows.Forms.TextBox();
            this.buscarBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHuesped)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // regCheckInBtn
            // 
            this.regCheckInBtn.Location = new System.Drawing.Point(170, 479);
            this.regCheckInBtn.Name = "regCheckInBtn";
            this.regCheckInBtn.Size = new System.Drawing.Size(75, 23);
            this.regCheckInBtn.TabIndex = 4;
            this.regCheckInBtn.Text = "Check IN";
            this.regCheckInBtn.UseVisualStyleBackColor = true;
            this.regCheckInBtn.Click += new System.EventHandler(this.regCheckInBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(338, 479);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarBtn.TabIndex = 5;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridHuesped
            // 
            this.dataGridHuesped.AllowUserToAddRows = false;
            this.dataGridHuesped.AllowUserToDeleteRows = false;
            this.dataGridHuesped.AllowUserToOrderColumns = true;
            this.dataGridHuesped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHuesped.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.apellido,
            this.nro_documento});
            this.dataGridHuesped.Location = new System.Drawing.Point(18, 45);
            this.dataGridHuesped.Name = "dataGridHuesped";
            this.dataGridHuesped.ReadOnly = true;
            this.dataGridHuesped.Size = new System.Drawing.Size(337, 178);
            this.dataGridHuesped.TabIndex = 6;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre Huesped";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // nro_documento
            // 
            this.nro_documento.HeaderText = "Nro Documento";
            this.nro_documento.Name = "nro_documento";
            this.nro_documento.ReadOnly = true;
            // 
            // addHuespedBtn
            // 
            this.addHuespedBtn.Location = new System.Drawing.Point(424, 100);
            this.addHuespedBtn.Name = "addHuespedBtn";
            this.addHuespedBtn.Size = new System.Drawing.Size(75, 56);
            this.addHuespedBtn.TabIndex = 7;
            this.addHuespedBtn.Text = "Agregar Huesped";
            this.addHuespedBtn.UseVisualStyleBackColor = true;
            this.addHuespedBtn.Click += new System.EventHandler(this.addHuespedBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cantHuespMaxBox);
            this.panel1.Controls.Add(this.titularResBox);
            this.panel1.Controls.Add(this.cantNochesBox);
            this.panel1.Controls.Add(this.fechaInicioResBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(30, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 167);
            this.panel1.TabIndex = 8;
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
            // cantHuespMaxBox
            // 
            this.cantHuespMaxBox.Location = new System.Drawing.Point(237, 130);
            this.cantHuespMaxBox.Name = "cantHuespMaxBox";
            this.cantHuespMaxBox.ReadOnly = true;
            this.cantHuespMaxBox.Size = new System.Drawing.Size(100, 20);
            this.cantHuespMaxBox.TabIndex = 13;
            // 
            // titularResBox
            // 
            this.titularResBox.Location = new System.Drawing.Point(237, 104);
            this.titularResBox.Name = "titularResBox";
            this.titularResBox.ReadOnly = true;
            this.titularResBox.Size = new System.Drawing.Size(200, 20);
            this.titularResBox.TabIndex = 12;
            // 
            // cantNochesBox
            // 
            this.cantNochesBox.Location = new System.Drawing.Point(237, 75);
            this.cantNochesBox.Name = "cantNochesBox";
            this.cantNochesBox.ReadOnly = true;
            this.cantNochesBox.Size = new System.Drawing.Size(100, 20);
            this.cantNochesBox.TabIndex = 11;
            // 
            // fechaInicioResBox
            // 
            this.fechaInicioResBox.Location = new System.Drawing.Point(237, 47);
            this.fechaInicioResBox.Name = "fechaInicioResBox";
            this.fechaInicioResBox.Size = new System.Drawing.Size(200, 20);
            this.fechaInicioResBox.TabIndex = 10;
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
            // fechaInicioEstBox
            // 
            this.fechaInicioEstBox.Location = new System.Drawing.Point(225, 5);
            this.fechaInicioEstBox.Name = "fechaInicioEstBox";
            this.fechaInicioEstBox.Size = new System.Drawing.Size(200, 20);
            this.fechaInicioEstBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fecha Inicio Check IN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Ingrese codigo reserva";
            // 
            // codReservaBox
            // 
            this.codReservaBox.Location = new System.Drawing.Point(208, 14);
            this.codReservaBox.Name = "codReservaBox";
            this.codReservaBox.Size = new System.Drawing.Size(182, 20);
            this.codReservaBox.TabIndex = 12;
            // 
            // buscarBtn
            // 
            this.buscarBtn.Location = new System.Drawing.Point(436, 12);
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.Size = new System.Drawing.Size(75, 23);
            this.buscarBtn.TabIndex = 13;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataGridHuesped);
            this.panel2.Controls.Add(this.addHuespedBtn);
            this.panel2.Controls.Add(this.fechaInicioEstBox);
            this.panel2.Location = new System.Drawing.Point(30, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 237);
            this.panel2.TabIndex = 14;
            // 
            // CheckINForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 514);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.codReservaBox);
            this.Controls.Add(this.buscarBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.regCheckInBtn);
            this.Name = "CheckINForm";
            this.Text = "Ingrese los datos de la estadía";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHuesped)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button regCheckInBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.DataGridView dataGridHuesped;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn nro_documento;
        private System.Windows.Forms.Button addHuespedBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cantHuespMaxBox;
        private System.Windows.Forms.TextBox titularResBox;
        private System.Windows.Forms.TextBox cantNochesBox;
        private System.Windows.Forms.DateTimePicker fechaInicioResBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox codReservaBox;
        private System.Windows.Forms.Button buscarBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker fechaInicioEstBox;
    }
}