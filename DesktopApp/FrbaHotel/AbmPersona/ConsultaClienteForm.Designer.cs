namespace FrbaHotel.AbmPersona
{
    partial class ConsultaClienteForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buscarBtn = new System.Windows.Forms.Button();
            this.dataClientesEncontrados = new System.Windows.Forms.DataGridView();
            this.gD1C2018DataSet = new FrbaHotel.GD1C2018DataSet();
            this.personasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personasTableAdapter = new FrbaHotel.GD1C2018DataSetTableAdapters.PersonasTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nroDNIBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.comboTipoDNI = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.apellidoBox = new System.Windows.Forms.TextBox();
            this.newClienteBtn = new System.Windows.Forms.Button();
            this.modificarBtn = new System.Windows.Forms.Button();
            this.cancelarBtn = new System.Windows.Forms.Button();
            this.tipodocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nrodocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cambiarEstadoCliente = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientesEncontrados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2018DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.apellidoBox);
            this.panel1.Controls.Add(this.nombreBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboTipoDNI);
            this.panel1.Controls.Add(this.emailBox);
            this.panel1.Controls.Add(this.nroDNIBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(127, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 130);
            this.panel1.TabIndex = 0;
            // 
            // buscarBtn
            // 
            this.buscarBtn.Location = new System.Drawing.Point(795, 161);
            this.buscarBtn.Name = "buscarBtn";
            this.buscarBtn.Size = new System.Drawing.Size(75, 23);
            this.buscarBtn.TabIndex = 1;
            this.buscarBtn.Text = "Buscar";
            this.buscarBtn.UseVisualStyleBackColor = true;
            this.buscarBtn.Click += new System.EventHandler(this.buscarBtn_Click);
            // 
            // dataClientesEncontrados
            // 
            this.dataClientesEncontrados.AutoGenerateColumns = false;
            this.dataClientesEncontrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataClientesEncontrados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipodocumentoDataGridViewTextBoxColumn,
            this.nrodocumentoDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.apellidoDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn,
            this.cambiarEstadoCliente});
            this.dataClientesEncontrados.DataSource = this.personasBindingSource;
            this.dataClientesEncontrados.Location = new System.Drawing.Point(78, 190);
            this.dataClientesEncontrados.Name = "dataClientesEncontrados";
            this.dataClientesEncontrados.Size = new System.Drawing.Size(856, 150);
            this.dataClientesEncontrados.TabIndex = 2;
            this.dataClientesEncontrados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataClientesEncontrados_CellContentClick);
            // 
            // gD1C2018DataSet
            // 
            this.gD1C2018DataSet.DataSetName = "GD1C2018DataSet";
            this.gD1C2018DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personasBindingSource
            // 
            this.personasBindingSource.DataMember = "Personas";
            this.personasBindingSource.DataSource = this.gD1C2018DataSet;
            // 
            // personasTableAdapter
            // 
            this.personasTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar búsqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nro. Documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // nroDNIBox
            // 
            this.nroDNIBox.Location = new System.Drawing.Point(158, 67);
            this.nroDNIBox.Name = "nroDNIBox";
            this.nroDNIBox.Size = new System.Drawing.Size(184, 20);
            this.nroDNIBox.TabIndex = 4;
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(158, 99);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(184, 20);
            this.emailBox.TabIndex = 5;
            // 
            // comboTipoDNI
            // 
            this.comboTipoDNI.FormattingEnabled = true;
            this.comboTipoDNI.Location = new System.Drawing.Point(158, 33);
            this.comboTipoDNI.Name = "comboTipoDNI";
            this.comboTipoDNI.Size = new System.Drawing.Size(184, 21);
            this.comboTipoDNI.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Apellido";
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(478, 33);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(219, 20);
            this.nombreBox.TabIndex = 9;
            // 
            // apellidoBox
            // 
            this.apellidoBox.Location = new System.Drawing.Point(478, 67);
            this.apellidoBox.Name = "apellidoBox";
            this.apellidoBox.Size = new System.Drawing.Size(219, 20);
            this.apellidoBox.TabIndex = 10;
            // 
            // newClienteBtn
            // 
            this.newClienteBtn.Location = new System.Drawing.Point(256, 371);
            this.newClienteBtn.Name = "newClienteBtn";
            this.newClienteBtn.Size = new System.Drawing.Size(116, 23);
            this.newClienteBtn.TabIndex = 3;
            this.newClienteBtn.Text = "Nuevo Cliente";
            this.newClienteBtn.UseVisualStyleBackColor = true;
            this.newClienteBtn.Click += new System.EventHandler(this.newClienteBtn_Click);
            // 
            // modificarBtn
            // 
            this.modificarBtn.Location = new System.Drawing.Point(432, 371);
            this.modificarBtn.Name = "modificarBtn";
            this.modificarBtn.Size = new System.Drawing.Size(116, 23);
            this.modificarBtn.TabIndex = 4;
            this.modificarBtn.Text = "Modificar";
            this.modificarBtn.UseVisualStyleBackColor = true;
            this.modificarBtn.Click += new System.EventHandler(this.modificarBtn_Click);
            // 
            // cancelarBtn
            // 
            this.cancelarBtn.Location = new System.Drawing.Point(607, 371);
            this.cancelarBtn.Name = "cancelarBtn";
            this.cancelarBtn.Size = new System.Drawing.Size(116, 23);
            this.cancelarBtn.TabIndex = 5;
            this.cancelarBtn.Text = "Cancelar";
            this.cancelarBtn.UseVisualStyleBackColor = true;
            this.cancelarBtn.Click += new System.EventHandler(this.cancelarBtn_Click);
            // 
            // tipodocumentoDataGridViewTextBoxColumn
            // 
            this.tipodocumentoDataGridViewTextBoxColumn.DataPropertyName = "tipo_documento";
            this.tipodocumentoDataGridViewTextBoxColumn.HeaderText = "Tipo Documento";
            this.tipodocumentoDataGridViewTextBoxColumn.Name = "tipodocumentoDataGridViewTextBoxColumn";
            // 
            // nrodocumentoDataGridViewTextBoxColumn
            // 
            this.nrodocumentoDataGridViewTextBoxColumn.DataPropertyName = "nro_documento";
            this.nrodocumentoDataGridViewTextBoxColumn.HeaderText = "Nro Documento";
            this.nrodocumentoDataGridViewTextBoxColumn.Name = "nrodocumentoDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Teléfono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            // 
            // cambiarEstadoCliente
            // 
            this.cambiarEstadoCliente.FillWeight = 115F;
            this.cambiarEstadoCliente.HeaderText = "Deshabilitar/Habilitar";
            this.cambiarEstadoCliente.Name = "cambiarEstadoCliente";
            this.cambiarEstadoCliente.ReadOnly = true;
            this.cambiarEstadoCliente.Width = 115;
            // 
            // ConsultaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 420);
            this.Controls.Add(this.cancelarBtn);
            this.Controls.Add(this.modificarBtn);
            this.Controls.Add(this.newClienteBtn);
            this.Controls.Add(this.dataClientesEncontrados);
            this.Controls.Add(this.buscarBtn);
            this.Controls.Add(this.panel1);
            this.Name = "ConsultaClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar clientes";
            this.Load += new System.EventHandler(this.ConsultaClienteForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientesEncontrados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD1C2018DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buscarBtn;
        private System.Windows.Forms.DataGridView dataClientesEncontrados;
        private GD1C2018DataSet gD1C2018DataSet;
        private System.Windows.Forms.BindingSource personasBindingSource;
        private GD1C2018DataSetTableAdapters.PersonasTableAdapter personasTableAdapter;
        private System.Windows.Forms.TextBox apellidoBox;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboTipoDNI;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox nroDNIBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newClienteBtn;
        private System.Windows.Forms.Button modificarBtn;
        private System.Windows.Forms.Button cancelarBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrodocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn cambiarEstadoCliente;
    }
}