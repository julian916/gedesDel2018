namespace FrbaHotel.ListadoEstadistico
{
    partial class ListadoEstadisticoForm
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
            this.dataGridEstadistica = new System.Windows.Forms.DataGridView();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.anioComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.trimestreBox = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkMayorConsum = new System.Windows.Forms.LinkLabel();
            this.linkHotelResCanc = new System.Windows.Forms.LinkLabel();
            this.linkHotelDiasSinServ = new System.Windows.Forms.LinkLabel();
            this.linkHabSolicitadas = new System.Windows.Forms.LinkLabel();
            this.linkClientePuntos = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadistica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trimestreBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridEstadistica
            // 
            this.dataGridEstadistica.AllowUserToAddRows = false;
            this.dataGridEstadistica.AllowUserToDeleteRows = false;
            this.dataGridEstadistica.AllowUserToOrderColumns = true;
            this.dataGridEstadistica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEstadistica.Location = new System.Drawing.Point(331, 40);
            this.dataGridEstadistica.Name = "dataGridEstadistica";
            this.dataGridEstadistica.ReadOnly = true;
            this.dataGridEstadistica.Size = new System.Drawing.Size(671, 382);
            this.dataGridEstadistica.TabIndex = 0;
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(107, 385);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelarBtn.TabIndex = 1;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Año de consulta";
            // 
            // anioComboBox
            // 
            this.anioComboBox.FormattingEnabled = true;
            this.anioComboBox.Location = new System.Drawing.Point(153, 48);
            this.anioComboBox.Name = "anioComboBox";
            this.anioComboBox.Size = new System.Drawing.Size(102, 21);
            this.anioComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trimestre de Consulta";
            // 
            // trimestreBox
            // 
            this.trimestreBox.Location = new System.Drawing.Point(153, 97);
            this.trimestreBox.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.trimestreBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trimestreBox.Name = "trimestreBox";
            this.trimestreBox.Size = new System.Drawing.Size(102, 20);
            this.trimestreBox.TabIndex = 6;
            this.trimestreBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.trimestreBox);
            this.panel1.Controls.Add(this.anioComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(22, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 137);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ingrese los siguientes parámetros";
            // 
            // linkMayorConsum
            // 
            this.linkMayorConsum.AutoSize = true;
            this.linkMayorConsum.Location = new System.Drawing.Point(39, 253);
            this.linkMayorConsum.Name = "linkMayorConsum";
            this.linkMayorConsum.Size = new System.Drawing.Size(268, 13);
            this.linkMayorConsum.TabIndex = 8;
            this.linkMayorConsum.TabStop = true;
            this.linkMayorConsum.Text = "Hoteles con mayor cantidad de consumibles facturados";
            this.linkMayorConsum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkMayorConsum_LinkClicked);
            // 
            // linkHotelResCanc
            // 
            this.linkHotelResCanc.AutoSize = true;
            this.linkHotelResCanc.Location = new System.Drawing.Point(39, 225);
            this.linkHotelResCanc.Name = "linkHotelResCanc";
            this.linkHotelResCanc.Size = new System.Drawing.Size(255, 13);
            this.linkHotelResCanc.TabIndex = 9;
            this.linkHotelResCanc.TabStop = true;
            this.linkHotelResCanc.Text = "Hoteles con mayor cantidad de reservas canceladas";
            this.linkHotelResCanc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHotelResCanc_LinkClicked);
            // 
            // linkHotelDiasSinServ
            // 
            this.linkHotelDiasSinServ.AutoSize = true;
            this.linkHotelDiasSinServ.Location = new System.Drawing.Point(39, 282);
            this.linkHotelDiasSinServ.Name = "linkHotelDiasSinServ";
            this.linkHotelDiasSinServ.Size = new System.Drawing.Size(259, 13);
            this.linkHotelDiasSinServ.TabIndex = 10;
            this.linkHotelDiasSinServ.TabStop = true;
            this.linkHotelDiasSinServ.Text = "Hoteles con mayor cantidad de días fuera de servicio";
            this.linkHotelDiasSinServ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHotelDiasSinServ_LinkClicked);
            // 
            // linkHabSolicitadas
            // 
            this.linkHabSolicitadas.AutoSize = true;
            this.linkHabSolicitadas.Location = new System.Drawing.Point(39, 311);
            this.linkHabSolicitadas.Name = "linkHabSolicitadas";
            this.linkHabSolicitadas.Size = new System.Drawing.Size(143, 13);
            this.linkHabSolicitadas.TabIndex = 11;
            this.linkHabSolicitadas.TabStop = true;
            this.linkHabSolicitadas.Text = "Habitaciones mas solicitadas";
            this.linkHabSolicitadas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHabSolicitadas_LinkClicked);
            // 
            // linkClientePuntos
            // 
            this.linkClientePuntos.AutoSize = true;
            this.linkClientePuntos.Location = new System.Drawing.Point(39, 340);
            this.linkClientePuntos.Name = "linkClientePuntos";
            this.linkClientePuntos.Size = new System.Drawing.Size(190, 13);
            this.linkClientePuntos.TabIndex = 12;
            this.linkClientePuntos.TabStop = true;
            this.linkClientePuntos.Text = "Clientes con mayor cantidad de puntos";
            this.linkClientePuntos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClientePuntos_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dé click sobre el listado solicitado:";
            // 
            // ListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 434);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkClientePuntos);
            this.Controls.Add(this.linkHabSolicitadas);
            this.Controls.Add(this.linkHotelDiasSinServ);
            this.Controls.Add(this.linkHotelResCanc);
            this.Controls.Add(this.linkMayorConsum);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.dataGridEstadistica);
            this.Name = "ListadoEstadisticoForm";
            this.Text = "Estadísticas - FRBA Hotel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEstadistica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trimestreBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridEstadistica;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox anioComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown trimestreBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkMayorConsum;
        private System.Windows.Forms.LinkLabel linkHotelResCanc;
        private System.Windows.Forms.LinkLabel linkHotelDiasSinServ;
        private System.Windows.Forms.LinkLabel linkHabSolicitadas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkClientePuntos;
    }
}