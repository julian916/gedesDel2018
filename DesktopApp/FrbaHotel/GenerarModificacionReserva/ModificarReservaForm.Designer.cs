namespace FrbaHotel.GenerarModificacionReserva
{
    partial class ModificarReservaForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaInicioBox = new System.Windows.Forms.DateTimePicker();
            this.fechaFinBox = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridHabActuales = new System.Windows.Forms.DataGridView();
            this.dataGridHabDispon = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cambiarFechasBtn = new System.Windows.Forms.Button();
            this.confirmarHab = new System.Windows.Forms.Button();
            this.cambiarRegBtn = new System.Windows.Forms.Button();
            this.agregarHabBtn = new System.Windows.Forms.Button();
            this.quitarHabBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.infoHotelBox = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.confirmCambiosBtn = new System.Windows.Forms.Button();
            this.panelRegimenes = new System.Windows.Forms.Panel();
            this.totalBox = new System.Windows.Forms.MaskedTextBox();
            this.precioPorDiaBox = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.regimenComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.infoClienteBox = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.infoUsername = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tipoHabBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabActuales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabDispon)).BeginInit();
            this.panel3.SuspendLayout();
            this.panelRegimenes.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fechaFinBox);
            this.panel1.Controls.Add(this.fechaInicioBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(41, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 109);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Fin";
            // 
            // fechaInicioBox
            // 
            this.fechaInicioBox.Location = new System.Drawing.Point(125, 27);
            this.fechaInicioBox.Name = "fechaInicioBox";
            this.fechaInicioBox.Size = new System.Drawing.Size(200, 20);
            this.fechaInicioBox.TabIndex = 2;
            // 
            // fechaFinBox
            // 
            this.fechaFinBox.Location = new System.Drawing.Point(125, 59);
            this.fechaFinBox.Name = "fechaFinBox";
            this.fechaFinBox.Size = new System.Drawing.Size(200, 20);
            this.fechaFinBox.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.quitarHabBtn);
            this.panel2.Controls.Add(this.agregarHabBtn);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dataGridHabDispon);
            this.panel2.Controls.Add(this.dataGridHabActuales);
            this.panel2.Location = new System.Drawing.Point(41, 232);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(692, 197);
            this.panel2.TabIndex = 1;
            // 
            // dataGridHabActuales
            // 
            this.dataGridHabActuales.AllowUserToAddRows = false;
            this.dataGridHabActuales.AllowUserToDeleteRows = false;
            this.dataGridHabActuales.AllowUserToOrderColumns = true;
            this.dataGridHabActuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHabActuales.Location = new System.Drawing.Point(21, 37);
            this.dataGridHabActuales.Name = "dataGridHabActuales";
            this.dataGridHabActuales.ReadOnly = true;
            this.dataGridHabActuales.Size = new System.Drawing.Size(272, 117);
            this.dataGridHabActuales.TabIndex = 2;
            // 
            // dataGridHabDispon
            // 
            this.dataGridHabDispon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHabDispon.Location = new System.Drawing.Point(362, 37);
            this.dataGridHabDispon.Name = "dataGridHabDispon";
            this.dataGridHabDispon.Size = new System.Drawing.Size(297, 117);
            this.dataGridHabDispon.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Habitaciones de reserva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Habitaciones Disponibles";
            // 
            // cambiarFechasBtn
            // 
            this.cambiarFechasBtn.Location = new System.Drawing.Point(756, 112);
            this.cambiarFechasBtn.Name = "cambiarFechasBtn";
            this.cambiarFechasBtn.Size = new System.Drawing.Size(137, 23);
            this.cambiarFechasBtn.TabIndex = 2;
            this.cambiarFechasBtn.Text = "Cambiar Fecha";
            this.cambiarFechasBtn.UseVisualStyleBackColor = true;
            this.cambiarFechasBtn.Click += new System.EventHandler(this.cambiarFechasBtn_Click);
            // 
            // confirmarHab
            // 
            this.confirmarHab.Location = new System.Drawing.Point(756, 151);
            this.confirmarHab.Name = "confirmarHab";
            this.confirmarHab.Size = new System.Drawing.Size(137, 23);
            this.confirmarHab.TabIndex = 3;
            this.confirmarHab.Text = "Confirmar Habitaciones";
            this.confirmarHab.UseVisualStyleBackColor = true;
            this.confirmarHab.Click += new System.EventHandler(this.confirmarHab_Click);
            // 
            // cambiarRegBtn
            // 
            this.cambiarRegBtn.Location = new System.Drawing.Point(756, 191);
            this.cambiarRegBtn.Name = "cambiarRegBtn";
            this.cambiarRegBtn.Size = new System.Drawing.Size(137, 23);
            this.cambiarRegBtn.TabIndex = 4;
            this.cambiarRegBtn.Text = "Cambiar Régimen";
            this.cambiarRegBtn.UseVisualStyleBackColor = true;
            // 
            // agregarHabBtn
            // 
            this.agregarHabBtn.Location = new System.Drawing.Point(459, 160);
            this.agregarHabBtn.Name = "agregarHabBtn";
            this.agregarHabBtn.Size = new System.Drawing.Size(131, 23);
            this.agregarHabBtn.TabIndex = 6;
            this.agregarHabBtn.Text = "Agregar Habitación";
            this.agregarHabBtn.UseVisualStyleBackColor = true;
            this.agregarHabBtn.Click += new System.EventHandler(this.agregarHabBtn_Click);
            // 
            // quitarHabBtn
            // 
            this.quitarHabBtn.Location = new System.Drawing.Point(99, 160);
            this.quitarHabBtn.Name = "quitarHabBtn";
            this.quitarHabBtn.Size = new System.Drawing.Size(118, 23);
            this.quitarHabBtn.TabIndex = 7;
            this.quitarHabBtn.Text = "Quitar habitación";
            this.quitarHabBtn.UseVisualStyleBackColor = true;
            this.quitarHabBtn.Click += new System.EventHandler(this.quitarHabBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.infoUsername);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.infoClienteBox);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.infoHotelBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(41, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(876, 44);
            this.panel3.TabIndex = 14;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "La reserva es sobre el Hotel:";
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(465, 453);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(129, 23);
            this.Cancelar.TabIndex = 4;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            // 
            // confirmCambiosBtn
            // 
            this.confirmCambiosBtn.Location = new System.Drawing.Point(219, 453);
            this.confirmCambiosBtn.Name = "confirmCambiosBtn";
            this.confirmCambiosBtn.Size = new System.Drawing.Size(128, 23);
            this.confirmCambiosBtn.TabIndex = 15;
            this.confirmCambiosBtn.Text = "Confirmar Cambios";
            this.confirmCambiosBtn.UseVisualStyleBackColor = true;
            // 
            // panelRegimenes
            // 
            this.panelRegimenes.Controls.Add(this.totalBox);
            this.panelRegimenes.Controls.Add(this.precioPorDiaBox);
            this.panelRegimenes.Controls.Add(this.label6);
            this.panelRegimenes.Controls.Add(this.label7);
            this.panelRegimenes.Controls.Add(this.regimenComboBox);
            this.panelRegimenes.Controls.Add(this.label8);
            this.panelRegimenes.Location = new System.Drawing.Point(417, 108);
            this.panelRegimenes.Name = "panelRegimenes";
            this.panelRegimenes.Size = new System.Drawing.Size(316, 113);
            this.panelRegimenes.TabIndex = 4;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Precio total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Precio por día";
            // 
            // regimenComboBox
            // 
            this.regimenComboBox.FormattingEnabled = true;
            this.regimenComboBox.Location = new System.Drawing.Point(146, 9);
            this.regimenComboBox.Name = "regimenComboBox";
            this.regimenComboBox.Size = new System.Drawing.Size(138, 21);
            this.regimenComboBox.TabIndex = 1;

            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Seleccione Régimen";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(387, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Cliente asignado:";
            // 
            // infoClienteBox
            // 
            this.infoClienteBox.AutoSize = true;
            this.infoClienteBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoClienteBox.Location = new System.Drawing.Point(501, 14);
            this.infoClienteBox.Name = "infoClienteBox";
            this.infoClienteBox.Size = new System.Drawing.Size(41, 13);
            this.infoClienteBox.TabIndex = 5;
            this.infoClienteBox.Text = "label2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(649, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Usuario de cambio:";
            // 
            // infoUsername
            // 
            this.infoUsername.AutoSize = true;
            this.infoUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoUsername.Location = new System.Drawing.Point(764, 14);
            this.infoUsername.Name = "infoUsername";
            this.infoUsername.Size = new System.Drawing.Size(41, 13);
            this.infoUsername.TabIndex = 7;
            this.infoUsername.Text = "label2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Tipos de Habitación";
            // 
            // tipoHabBox
            // 
            this.tipoHabBox.FormattingEnabled = true;
            this.tipoHabBox.Location = new System.Drawing.Point(24, 38);
            this.tipoHabBox.Name = "tipoHabBox";
            this.tipoHabBox.Size = new System.Drawing.Size(121, 21);
            this.tipoHabBox.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 40);
            this.button1.TabIndex = 18;
            this.button1.Text = "Confirmar Tipo Habitacion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.tipoHabBox);
            this.panel4.Location = new System.Drawing.Point(744, 232);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(173, 197);
            this.panel4.TabIndex = 19;
            // 
            // ModificarReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 488);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelRegimenes);
            this.Controls.Add(this.confirmCambiosBtn);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.cambiarRegBtn);
            this.Controls.Add(this.confirmarHab);
            this.Controls.Add(this.cambiarFechasBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ModificarReservaForm";
            this.Text = "Modificar Reserva";
            this.Load += new System.EventHandler(this.ModificarReservaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabActuales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHabDispon)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelRegimenes.ResumeLayout(false);
            this.panelRegimenes.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker fechaFinBox;
        private System.Windows.Forms.DateTimePicker fechaInicioBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridHabActuales;
        private System.Windows.Forms.Button agregarHabBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridHabDispon;
        private System.Windows.Forms.Button cambiarFechasBtn;
        private System.Windows.Forms.Button confirmarHab;
        private System.Windows.Forms.Button cambiarRegBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label infoHotelBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button confirmCambiosBtn;
        private System.Windows.Forms.Panel panelRegimenes;
        private System.Windows.Forms.MaskedTextBox totalBox;
        private System.Windows.Forms.MaskedTextBox precioPorDiaBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox regimenComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label infoUsername;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label infoClienteBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button quitarHabBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox tipoHabBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
    }
}