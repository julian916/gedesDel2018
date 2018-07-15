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
            this.comboHoteles = new System.Windows.Forms.ComboBox();
            this.fechaDesdeCalendar = new System.Windows.Forms.MonthCalendar();
            this.fechaHastaCalendar = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tipoHabBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboHoteles
            // 
            this.comboHoteles.FormattingEnabled = true;
            this.comboHoteles.Items.AddRange(new object[] {
            "Hotel 1",
            "Hotel 2",
            "Hotel 3"});
            this.comboHoteles.Location = new System.Drawing.Point(198, 73);
            this.comboHoteles.Name = "comboHoteles";
            this.comboHoteles.Size = new System.Drawing.Size(293, 21);
            this.comboHoteles.TabIndex = 0;
            // 
            // fechaDesdeCalendar
            // 
            this.fechaDesdeCalendar.Location = new System.Drawing.Point(139, 167);
            this.fechaDesdeCalendar.Name = "fechaDesdeCalendar";
            this.fechaDesdeCalendar.ShowToday = false;
            this.fechaDesdeCalendar.ShowTodayCircle = false;
            this.fechaDesdeCalendar.TabIndex = 2;
            this.fechaDesdeCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.FechaDesdeCalendar_DateChanged);
            // 
            // fechaHastaCalendar
            // 
            this.fechaHastaCalendar.Location = new System.Drawing.Point(498, 167);
            this.fechaHastaCalendar.Name = "fechaHastaCalendar";
            this.fechaHastaCalendar.ShowToday = false;
            this.fechaHastaCalendar.ShowTodayCircle = false;
            this.fechaHastaCalendar.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Desde";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(495, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Hasta";
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
            this.label4.Size = new System.Drawing.Size(247, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Búsqueda disponibilidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Buscar Disponibilidad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buscarDisponibilidad_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(56, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Buscar Hotel";
            // 
            // tipoHabBox
            // 
            this.tipoHabBox.FormattingEnabled = true;
            this.tipoHabBox.Location = new System.Drawing.Point(707, 71);
            this.tipoHabBox.Name = "tipoHabBox";
            this.tipoHabBox.Size = new System.Drawing.Size(165, 21);
            this.tipoHabBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(566, 71);
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
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fechaHastaCalendar);
            this.Controls.Add(this.fechaDesdeCalendar);
            this.Controls.Add(this.comboHoteles);
            this.Name = "GenerarReserva";
            this.Text = "Ingrese parámetros de búsqueda";

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboHoteles;
        private System.Windows.Forms.MonthCalendar fechaDesdeCalendar;
        private System.Windows.Forms.MonthCalendar fechaHastaCalendar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tipoHabBox;
        private System.Windows.Forms.Label label5;
    }
}