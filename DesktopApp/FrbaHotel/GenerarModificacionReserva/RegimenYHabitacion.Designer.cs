namespace FrbaHotel.GenerarModificacionReserva
{
    partial class RegimenYHabitaciones
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
            this.dataGridHabDisp = new System.Windows.Forms.DataGridView();
            this.confirmHab = new System.Windows.Forms.Button();
            this.panelRegimenes = new System.Windows.Forms.Panel();
            this.clientePrincBtn = new System.Windows.Forms.Button();
            this.totalBox = new System.Windows.Forms.MaskedTextBox();
            this.precioPorDiaBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.regimenComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmResBtn = new System.Windows.Forms.Button();
            this.modHabBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.panelHabitaciones = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabDisp)).BeginInit();
            this.panelRegimenes.SuspendLayout();
            this.panelHabitaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Habitaciones Disponibles";
            // 
            // dataGridHabDisp
            // 
            this.dataGridHabDisp.AllowUserToAddRows = false;
            this.dataGridHabDisp.AllowUserToDeleteRows = false;
            this.dataGridHabDisp.AllowUserToOrderColumns = true;
            this.dataGridHabDisp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHabDisp.Location = new System.Drawing.Point(19, 40);
            this.dataGridHabDisp.Name = "dataGridHabDisp";
            this.dataGridHabDisp.ReadOnly = true;
            this.dataGridHabDisp.Size = new System.Drawing.Size(590, 150);
            this.dataGridHabDisp.TabIndex = 1;
            // 
            // confirmHab
            // 
            this.confirmHab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.confirmHab.Location = new System.Drawing.Point(112, 196);
            this.confirmHab.Name = "confirmHab";
            this.confirmHab.Size = new System.Drawing.Size(176, 23);
            this.confirmHab.TabIndex = 2;
            this.confirmHab.Text = "Confirmar Habitaciones";
            this.confirmHab.UseVisualStyleBackColor = true;
            this.confirmHab.Click += new System.EventHandler(this.confirmHab_Click);
            // 
            // panelRegimenes
            // 
            this.panelRegimenes.Controls.Add(this.clientePrincBtn);
            this.panelRegimenes.Controls.Add(this.totalBox);
            this.panelRegimenes.Controls.Add(this.precioPorDiaBox);
            this.panelRegimenes.Controls.Add(this.label4);
            this.panelRegimenes.Controls.Add(this.label3);
            this.panelRegimenes.Controls.Add(this.regimenComboBox);
            this.panelRegimenes.Controls.Add(this.label2);
            this.panelRegimenes.Location = new System.Drawing.Point(28, 275);
            this.panelRegimenes.Name = "panelRegimenes";
            this.panelRegimenes.Size = new System.Drawing.Size(623, 113);
            this.panelRegimenes.TabIndex = 3;
            // 
            // clientePrincBtn
            // 
            this.clientePrincBtn.Location = new System.Drawing.Point(381, 42);
            this.clientePrincBtn.Name = "clientePrincBtn";
            this.clientePrincBtn.Size = new System.Drawing.Size(188, 23);
            this.clientePrincBtn.TabIndex = 10;
            this.clientePrincBtn.Text = "Seleccionar Cliente Principal";
            this.clientePrincBtn.UseVisualStyleBackColor = true;
            this.clientePrincBtn.Click += new System.EventHandler(this.clientePrincBtn_Click);
            // 
            // totalBox
            // 
            this.totalBox.Culture = new System.Globalization.CultureInfo("es-US");
            this.totalBox.Location = new System.Drawing.Point(146, 74);
            this.totalBox.Mask = "$999999.00";
            this.totalBox.Name = "totalBox";
            this.totalBox.ReadOnly = true;
            this.totalBox.Size = new System.Drawing.Size(138, 20);
            this.totalBox.TabIndex = 9;
            // 
            // precioPorDiaBox
            // 
            this.precioPorDiaBox.Culture = new System.Globalization.CultureInfo("es-US");
            this.precioPorDiaBox.Location = new System.Drawing.Point(146, 42);
            this.precioPorDiaBox.Mask = "$999999.00";
            this.precioPorDiaBox.Name = "precioPorDiaBox";
            this.precioPorDiaBox.ReadOnly = true;
            this.precioPorDiaBox.Size = new System.Drawing.Size(138, 20);
            this.precioPorDiaBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Precio total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio por día";
            // 
            // regimenComboBox
            // 
            this.regimenComboBox.FormattingEnabled = true;
            this.regimenComboBox.Location = new System.Drawing.Point(146, 9);
            this.regimenComboBox.Name = "regimenComboBox";
            this.regimenComboBox.Size = new System.Drawing.Size(138, 21);
            this.regimenComboBox.TabIndex = 1;
            this.regimenComboBox.SelectedIndexChanged += new System.EventHandler(this.regimenComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Seleccione Régimen";
            // 
            // confirmResBtn
            // 
            this.confirmResBtn.Location = new System.Drawing.Point(132, 422);
            this.confirmResBtn.Name = "confirmResBtn";
            this.confirmResBtn.Size = new System.Drawing.Size(136, 23);
            this.confirmResBtn.TabIndex = 4;
            this.confirmResBtn.Text = "Confirmar Reserva";
            this.confirmResBtn.UseVisualStyleBackColor = true;
            this.confirmResBtn.Click += new System.EventHandler(this.confirmResBtn_Click);
            // 
            // modHabBtn
            // 
            this.modHabBtn.Location = new System.Drawing.Point(321, 196);
            this.modHabBtn.Name = "modHabBtn";
            this.modHabBtn.Size = new System.Drawing.Size(176, 23);
            this.modHabBtn.TabIndex = 4;
            this.modHabBtn.Text = "Modificar Habitaciones";
            this.modHabBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.modHabBtn.UseVisualStyleBackColor = true;
            this.modHabBtn.Click += new System.EventHandler(this.modHabBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(365, 422);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(132, 23);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancelar";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // panelHabitaciones
            // 
            this.panelHabitaciones.Controls.Add(this.label1);
            this.panelHabitaciones.Controls.Add(this.dataGridHabDisp);
            this.panelHabitaciones.Controls.Add(this.modHabBtn);
            this.panelHabitaciones.Controls.Add(this.confirmHab);
            this.panelHabitaciones.Location = new System.Drawing.Point(12, 12);
            this.panelHabitaciones.Name = "panelHabitaciones";
            this.panelHabitaciones.Size = new System.Drawing.Size(639, 247);
            this.panelHabitaciones.TabIndex = 6;
            // 
            // RegimenYHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 457);
            this.Controls.Add(this.panelHabitaciones);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.confirmResBtn);
            this.Controls.Add(this.panelRegimenes);
            this.Name = "RegimenYHabitaciones";
            this.Text = "Seleccione habitacion y régimen";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabDisp)).EndInit();
            this.panelRegimenes.ResumeLayout(false);
            this.panelRegimenes.PerformLayout();
            this.panelHabitaciones.ResumeLayout(false);
            this.panelHabitaciones.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridHabDisp;
        private System.Windows.Forms.Button confirmHab;
        private System.Windows.Forms.Panel panelRegimenes;
        private System.Windows.Forms.Button confirmResBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox regimenComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button modHabBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Panel panelHabitaciones;
        private System.Windows.Forms.MaskedTextBox totalBox;
        private System.Windows.Forms.MaskedTextBox precioPorDiaBox;
        private System.Windows.Forms.Button clientePrincBtn;
    }
}