namespace FrbaHotel.ABMHotel
{
    partial class ConsultaHotelForm
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
            this.paisComboBox = new System.Windows.Forms.ComboBox();
            this.ciudadComboBox = new System.Windows.Forms.ComboBox();
            this.filtrarBtn = new System.Windows.Forms.Button();
            this.estrellasBox = new System.Windows.Forms.NumericUpDown();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridHoteles = new System.Windows.Forms.DataGridView();
            this.newBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estrellasBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.paisComboBox);
            this.panel1.Controls.Add(this.ciudadComboBox);
            this.panel1.Controls.Add(this.filtrarBtn);
            this.panel1.Controls.Add(this.estrellasBox);
            this.panel1.Controls.Add(this.nombreBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(178, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 180);
            this.panel1.TabIndex = 0;
            // 
            // paisComboBox
            // 
            this.paisComboBox.FormattingEnabled = true;
            this.paisComboBox.Location = new System.Drawing.Point(222, 114);
            this.paisComboBox.Name = "paisComboBox";
            this.paisComboBox.Size = new System.Drawing.Size(259, 21);
            this.paisComboBox.TabIndex = 11;
            // 
            // ciudadComboBox
            // 
            this.ciudadComboBox.FormattingEnabled = true;
            this.ciudadComboBox.Location = new System.Drawing.Point(222, 87);
            this.ciudadComboBox.Name = "ciudadComboBox";
            this.ciudadComboBox.Size = new System.Drawing.Size(259, 21);
            this.ciudadComboBox.TabIndex = 10;
            // 
            // filtrarBtn
            // 
            this.filtrarBtn.Location = new System.Drawing.Point(406, 145);
            this.filtrarBtn.Name = "filtrarBtn";
            this.filtrarBtn.Size = new System.Drawing.Size(75, 23);
            this.filtrarBtn.TabIndex = 9;
            this.filtrarBtn.Text = "Filtrar";
            this.filtrarBtn.UseVisualStyleBackColor = true;
            this.filtrarBtn.Click += new System.EventHandler(this.filtrarBtn_Click);
            // 
            // estrellasBox
            // 
            this.estrellasBox.Location = new System.Drawing.Point(222, 60);
            this.estrellasBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.estrellasBox.Name = "estrellasBox";
            this.estrellasBox.Size = new System.Drawing.Size(120, 20);
            this.estrellasBox.TabIndex = 6;
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(222, 34);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(259, 20);
            this.nombreBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "País";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ciudad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad Estrellas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese parámetros de búsqueda";
            // 
            // dataGridHoteles
            // 
            this.dataGridHoteles.AllowUserToAddRows = false;
            this.dataGridHoteles.AllowUserToDeleteRows = false;
            this.dataGridHoteles.AllowUserToOrderColumns = true;
            this.dataGridHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHoteles.Location = new System.Drawing.Point(13, 222);
            this.dataGridHoteles.Name = "dataGridHoteles";
            this.dataGridHoteles.ReadOnly = true;
            this.dataGridHoteles.Size = new System.Drawing.Size(927, 208);
            this.dataGridHoteles.TabIndex = 1;
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(178, 458);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(103, 23);
            this.newBtn.TabIndex = 2;
            this.newBtn.Text = "Nuevo";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(332, 458);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(103, 23);
            this.updateBtn.TabIndex = 3;
            this.updateBtn.Text = "Modificar";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(625, 458);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(103, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Cancelar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(476, 458);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(103, 23);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Baja Temporal";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // ConsultaHotelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 517);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.dataGridHoteles);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultaHotelForm";
            this.Text = "Consulta de hoteles";
            this.Load += new System.EventHandler(this.ConsultaHotelForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estrellasBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHoteles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown estrellasBox;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button filtrarBtn;
        private System.Windows.Forms.DataGridView dataGridHoteles;
        private System.Windows.Forms.ComboBox paisComboBox;
        private System.Windows.Forms.ComboBox ciudadComboBox;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button deleteBtn;
    }
}