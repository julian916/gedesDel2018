namespace FrbaHotel.GenerarReserva
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
            this.SuspendLayout();
            // 
            // comboHoteles
            // 
            this.comboHoteles.FormattingEnabled = true;
            this.comboHoteles.Items.AddRange(new object[] {
            "Hotel 1",
            "Hotel 2",
            "Hotel 3"});
            this.comboHoteles.Location = new System.Drawing.Point(124, 40);
            this.comboHoteles.Name = "comboHoteles";
            this.comboHoteles.Size = new System.Drawing.Size(158, 21);
            this.comboHoteles.TabIndex = 0;
            this.comboHoteles.Text = "Seleccionar Hotel";
            this.comboHoteles.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hoteles";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboHoteles);
            this.Name = "GenerarReserva";
            this.Text = "GenerarReserva";
            //this.Load += new System.EventHandler(this.GenerarReserva_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboHoteles;
        private System.Windows.Forms.Label label1;
    }
}