namespace FrbaHotel.FacturarEstadia
{
    partial class FacturaFinalForm
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
            this.nroFactBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.titularBox = new System.Windows.Forms.TextBox();
            this.puntosBox = new System.Windows.Forms.TextBox();
            this.montoTotalBox = new System.Windows.Forms.TextBox();
            this.dataGridFactura = new System.Windows.Forms.DataGridView();
            this.aceptarBtn = new System.Windows.Forms.Button();
            this.fechaFactBox = new System.Windows.Forms.DateTimePicker();
            this.Nro_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro. Factura";
            // 
            // nroFactBox
            // 
            this.nroFactBox.Location = new System.Drawing.Point(252, 19);
            this.nroFactBox.Name = "nroFactBox";
            this.nroFactBox.ReadOnly = true;
            this.nroFactBox.Size = new System.Drawing.Size(154, 20);
            this.nroFactBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puntos Obtenidos: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Facturado A:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha Facturacion:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(94, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Monto Total:";
            // 
            // titularBox
            // 
            this.titularBox.Location = new System.Drawing.Point(216, 55);
            this.titularBox.Name = "titularBox";
            this.titularBox.ReadOnly = true;
            this.titularBox.Size = new System.Drawing.Size(246, 20);
            this.titularBox.TabIndex = 6;
            // 
            // puntosBox
            // 
            this.puntosBox.Location = new System.Drawing.Point(216, 81);
            this.puntosBox.Name = "puntosBox";
            this.puntosBox.ReadOnly = true;
            this.puntosBox.Size = new System.Drawing.Size(246, 20);
            this.puntosBox.TabIndex = 7;
            // 
            // montoTotalBox
            // 
            this.montoTotalBox.Location = new System.Drawing.Point(216, 135);
            this.montoTotalBox.Name = "montoTotalBox";
            this.montoTotalBox.ReadOnly = true;
            this.montoTotalBox.Size = new System.Drawing.Size(246, 20);
            this.montoTotalBox.TabIndex = 9;
            // 
            // dataGridFactura
            // 
            this.dataGridFactura.AllowUserToAddRows = false;
            this.dataGridFactura.AllowUserToDeleteRows = false;
            this.dataGridFactura.AllowUserToOrderColumns = true;
            this.dataGridFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nro_Item,
            this.detalle,
            this.monto});
            this.dataGridFactura.Location = new System.Drawing.Point(74, 161);
            this.dataGridFactura.Name = "dataGridFactura";
            this.dataGridFactura.ReadOnly = true;
            this.dataGridFactura.Size = new System.Drawing.Size(446, 150);
            this.dataGridFactura.TabIndex = 10;
            // 
            // aceptarBtn
            // 
            this.aceptarBtn.Location = new System.Drawing.Point(235, 335);
            this.aceptarBtn.Name = "aceptarBtn";
            this.aceptarBtn.Size = new System.Drawing.Size(75, 23);
            this.aceptarBtn.TabIndex = 11;
            this.aceptarBtn.Text = "Aceptar";
            this.aceptarBtn.UseVisualStyleBackColor = true;
            this.aceptarBtn.Click += new System.EventHandler(this.aceptarBtn_Click);
            // 
            // fechaFactBox
            // 
            this.fechaFactBox.Enabled = false;
            this.fechaFactBox.Location = new System.Drawing.Point(216, 109);
            this.fechaFactBox.Name = "fechaFactBox";
            this.fechaFactBox.Size = new System.Drawing.Size(246, 20);
            this.fechaFactBox.TabIndex = 12;
            // 
            // Nro_Item
            // 
            this.Nro_Item.HeaderText = "Nro_Item";
            this.Nro_Item.Name = "Nro_Item";
            this.Nro_Item.ReadOnly = true;
            // 
            // detalle
            // 
            this.detalle.HeaderText = "Detalle";
            this.detalle.Name = "detalle";
            this.detalle.ReadOnly = true;
            this.detalle.Width = 200;
            // 
            // monto
            // 
            this.monto.HeaderText = "Monto";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // FacturaFinalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 362);
            this.Controls.Add(this.fechaFactBox);
            this.Controls.Add(this.aceptarBtn);
            this.Controls.Add(this.dataGridFactura);
            this.Controls.Add(this.montoTotalBox);
            this.Controls.Add(this.puntosBox);
            this.Controls.Add(this.titularBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nroFactBox);
            this.Controls.Add(this.label1);
            this.Name = "FacturaFinalForm";
            this.Text = "Factura Final";
            this.Load += new System.EventHandler(this.FacturaFinalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nroFactBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox titularBox;
        private System.Windows.Forms.TextBox puntosBox;
        private System.Windows.Forms.TextBox montoTotalBox;
        private System.Windows.Forms.Button aceptarBtn;
        private System.Windows.Forms.DataGridView dataGridFactura;
        private System.Windows.Forms.DateTimePicker fechaFactBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nro_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
    }
}