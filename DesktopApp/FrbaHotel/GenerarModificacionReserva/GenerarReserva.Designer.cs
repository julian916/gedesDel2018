namespace FrbaHotel.GenerarModificarReserva
{
    partial class GenerarReserva
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
            this.comboCiudad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fechaDesdeCalendar = new System.Windows.Forms.MonthCalendar();
            this.fechaHastaCalendar = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboCalles = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tipoHabBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboCiudad
            // 
            this.comboCiudad.FormattingEnabled = true;
            this.comboCiudad.Items.AddRange(new object[] {
            "Hotel 1",
            "Hotel 2",
            "Hotel 3"});
            this.comboCiudad.Location = new System.Drawing.Point(197, 75);
            this.comboCiudad.Name = "comboCiudad";
            this.comboCiudad.Size = new System.Drawing.Size(165, 21);
            this.comboCiudad.TabIndex = 0;
            this.comboCiudad.Text = "Seleccionar Ciudad";
            this.comboCiudad.SelectedIndexChanged += new System.EventHandler(this.CiudadesCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ciudades";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // fechaDesdeCalendar
            // 
            this.fechaDesdeCalendar.Location = new System.Drawing.Point(62, 167);
            this.fechaDesdeCalendar.Name = "fechaDesdeCalendar";
            this.fechaDesdeCalendar.ShowToday = false;
            this.fechaDesdeCalendar.ShowTodayCircle = false;
            this.fechaDesdeCalendar.TabIndex = 2;
            this.fechaDesdeCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.FechaDesdeCalendar_DateChanged);
            // 
            // fechaHastaCalendar
            // 
            this.fechaHastaCalendar.Location = new System.Drawing.Point(469, 167);
            this.fechaHastaCalendar.Name = "fechaHastaCalendar";
            this.fechaHastaCalendar.ShowToday = false;
            this.fechaHastaCalendar.ShowTodayCircle = false;
            this.fechaHastaCalendar.TabIndex = 3;
            this.fechaHastaCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.FechaHastaCalendar_DateChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Desde";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(466, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Hasta";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Búsqueda dis";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(569, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Buscar Disponibilidad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buscarDisponibilidad_Click);
            // 
            // comboCalles
            // 
            this.comboCalles.FormattingEnabled = true;
            this.comboCalles.Location = new System.Drawing.Point(469, 71);
            this.comboCalles.Name = "comboCalles";
            this.comboCalles.Size = new System.Drawing.Size(242, 21);
            this.comboCalles.TabIndex = 9;
            this.comboCalles.Text = "Seleccionar Calle";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(404, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Calles";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(55, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Buscar Hotel";
            // 
            // tipoHabBox
            // 
            this.tipoHabBox.FormattingEnabled = true;
            this.tipoHabBox.Location = new System.Drawing.Point(197, 111);
            this.tipoHabBox.Name = "tipoHabBox";
            this.tipoHabBox.Size = new System.Drawing.Size(165, 21);
            this.tipoHabBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(56, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tipo de Habitación";
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 383);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tipoHabBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboCalles);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fechaHastaCalendar);
            this.Controls.Add(this.fechaDesdeCalendar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboCiudad);
            this.Name = "GenerarReserva";
            this.Text = "GenerarReserva";
            this.Load += new System.EventHandler(this.GenerarReserva_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboCiudad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar fechaDesdeCalendar;
        private System.Windows.Forms.MonthCalendar fechaHastaCalendar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboCalles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tipoHabBox;
        private System.Windows.Forms.Label label5;
    }
}