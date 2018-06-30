namespace FrbaHotel.ABMHotel
{
    partial class AltaHotelForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.recargaEstrellaBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nroCalleBoxNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.calleBox = new System.Windows.Forms.TextBox();
            this.ciudadBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.telBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.regimenesCheckList = new System.Windows.Forms.CheckedListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.paisCombo = new System.Windows.Forms.ComboBox();
            this.cantidadEstreBox = new System.Windows.Forms.ComboBox();
            this.crearHotelButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.recargaEstrellaBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCalleBoxNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Ciudad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Calle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Numero calle";
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(156, 225);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(317, 20);
            this.emailBox.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Email";
            // 
            // recargaEstrellaBox
            // 
            this.recargaEstrellaBox.DecimalPlaces = 2;
            this.recargaEstrellaBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.recargaEstrellaBox.Location = new System.Drawing.Point(156, 191);
            this.recargaEstrellaBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.recargaEstrellaBox.Name = "recargaEstrellaBox";
            this.recargaEstrellaBox.Size = new System.Drawing.Size(317, 20);
            this.recargaEstrellaBox.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Cantidad de Estrellas";
            // 
            // nroCalleBoxNumeric
            // 
            this.nroCalleBoxNumeric.Location = new System.Drawing.Point(156, 127);
            this.nroCalleBoxNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nroCalleBoxNumeric.Name = "nroCalleBoxNumeric";
            this.nroCalleBoxNumeric.Size = new System.Drawing.Size(317, 20);
            this.nroCalleBoxNumeric.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Recarga Estrellas";
            // 
            // calleBox
            // 
            this.calleBox.Location = new System.Drawing.Point(156, 98);
            this.calleBox.Name = "calleBox";
            this.calleBox.Size = new System.Drawing.Size(317, 20);
            this.calleBox.TabIndex = 40;
            // 
            // ciudadBox
            // 
            this.ciudadBox.Location = new System.Drawing.Point(156, 68);
            this.ciudadBox.Name = "ciudadBox";
            this.ciudadBox.Size = new System.Drawing.Size(317, 20);
            this.ciudadBox.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Nombre";
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(156, 16);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(317, 20);
            this.nombreBox.TabIndex = 46;
            // 
            // telBox
            // 
            this.telBox.Location = new System.Drawing.Point(156, 251);
            this.telBox.Name = "telBox";
            this.telBox.Size = new System.Drawing.Size(317, 20);
            this.telBox.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 47;
            this.label9.Text = "Telefono";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(119, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Pais";
            // 
            // regimenesCheckList
            // 
            this.regimenesCheckList.FormattingEnabled = true;
            this.regimenesCheckList.Location = new System.Drawing.Point(156, 278);
            this.regimenesCheckList.Name = "regimenesCheckList";
            this.regimenesCheckList.Size = new System.Drawing.Size(317, 94);
            this.regimenesCheckList.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 52;
            this.label7.Text = "Regimen/es";
            // 
            // paisCombo
            // 
            this.paisCombo.FormattingEnabled = true;
            this.paisCombo.Location = new System.Drawing.Point(156, 43);
            this.paisCombo.Name = "paisCombo";
            this.paisCombo.Size = new System.Drawing.Size(317, 21);
            this.paisCombo.TabIndex = 53;
            // 
            // cantidadEstreBox
            // 
            this.cantidadEstreBox.FormattingEnabled = true;
            this.cantidadEstreBox.Location = new System.Drawing.Point(156, 158);
            this.cantidadEstreBox.Name = "cantidadEstreBox";
            this.cantidadEstreBox.Size = new System.Drawing.Size(317, 21);
            this.cantidadEstreBox.TabIndex = 54;
            // 
            // crearHotelButton
            // 
            this.crearHotelButton.Location = new System.Drawing.Point(178, 392);
            this.crearHotelButton.Name = "crearHotelButton";
            this.crearHotelButton.Size = new System.Drawing.Size(75, 23);
            this.crearHotelButton.TabIndex = 55;
            this.crearHotelButton.Text = "Crear Hotel";
            this.crearHotelButton.UseVisualStyleBackColor = true;
            this.crearHotelButton.Click += new System.EventHandler(this.crearHotelButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(312, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 56;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AltaHotelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 438);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.crearHotelButton);
            this.Controls.Add(this.cantidadEstreBox);
            this.Controls.Add(this.paisCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.regimenesCheckList);
            this.Controls.Add(this.telBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nombreBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.recargaEstrellaBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nroCalleBoxNumeric);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.calleBox);
            this.Controls.Add(this.ciudadBox);
            this.Name = "AltaHotelForm";
            this.Text = "Ingrese nuevo hotel";
            this.Load += new System.EventHandler(this.AltaHotelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recargaEstrellaBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroCalleBoxNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown recargaEstrellaBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nroCalleBoxNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox calleBox;
        private System.Windows.Forms.TextBox ciudadBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.TextBox telBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox regimenesCheckList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox paisCombo;
        private System.Windows.Forms.ComboBox cantidadEstreBox;
        private System.Windows.Forms.Button crearHotelButton;
        private System.Windows.Forms.Button button2;
    }
}