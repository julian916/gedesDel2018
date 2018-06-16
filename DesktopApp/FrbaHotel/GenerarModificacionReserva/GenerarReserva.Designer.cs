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
            this.label1 = new System.Windows.Forms.Label();
            this.fechaDesdeCalendar = new System.Windows.Forms.MonthCalendar();
            this.fechaHastaCalendar = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboHoteles
            // 
            this.comboHoteles.FormattingEnabled = true;
            this.comboHoteles.Items.AddRange(new object[] {
            "Hotel 1",
            "Hotel 2",
            "Hotel 3"});
            this.comboHoteles.Location = new System.Drawing.Point(158, 58);
            this.comboHoteles.Name = "comboHoteles";
            this.comboHoteles.Size = new System.Drawing.Size(158, 21);
            this.comboHoteles.TabIndex = 0;
            this.comboHoteles.Text = "Seleccionar Hotel";
            this.comboHoteles.SelectedIndexChanged += new System.EventHandler(this.HotelesCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hoteles";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // fechaDesdeCalendar
            // 
            this.fechaDesdeCalendar.Location = new System.Drawing.Point(64, 124);
            this.fechaDesdeCalendar.Name = "fechaDesdeCalendar";
            this.fechaDesdeCalendar.TabIndex = 2;
            this.fechaDesdeCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.FechaDesdeCalendar_DateChanged);
            // 
            // fechaHastaCalendar
            // 
            this.fechaHastaCalendar.Location = new System.Drawing.Point(328, 124);
            this.fechaHastaCalendar.Name = "fechaHastaCalendar";
            this.fechaHastaCalendar.TabIndex = 3;
            this.fechaHastaCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.FechaHastaCalendar_DateChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Desde";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(325, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fecha Hasta";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 46);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nueva Reserva";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Comprobar Disponibilidad";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fechaHastaCalendar);
            this.Controls.Add(this.fechaDesdeCalendar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboHoteles);
            this.Name = "GenerarReserva";
            this.Text = "GenerarReserva";
            this.Load += new System.EventHandler(this.GenerarReserva_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboHoteles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar fechaDesdeCalendar;
        private System.Windows.Forms.MonthCalendar fechaHastaCalendar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}