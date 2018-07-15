namespace FrbaHotel
{
    partial class MenuPrincipal
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administracionHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBMHabitacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaHabitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionBajaToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificacionBajaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarRolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.estadíasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nuevaEstadíaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listaEstadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panelReservas = new System.Windows.Forms.Panel();
            this.cancelReservaButton = new System.Windows.Forms.Button();
            this.updateReservaButton = new System.Windows.Forms.Button();
            this.newReservaButton = new System.Windows.Forms.Button();
            this.passLinkLabel = new System.Windows.Forms.LinkLabel();
            this.closeSessionLink = new System.Windows.Forms.LinkLabel();
            this.panelSession = new System.Windows.Forms.Panel();
            this.inicioSesionLink = new System.Windows.Forms.LinkLabel();
			this.checkOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panelReservas.SuspendLayout();
            this.panelSession.SuspendLayout();
			this.SuspendLayout();
			//
			// menuStrip1
			// 
			this.menuStrip1.AutoSize = false;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.administracionHotelToolStripMenuItem,
			this.toolStripMenuItem1,
			this.rolToolStripMenuItem,
			this.estadíasToolStripMenuItem,
			this.listaEstadisticasToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(906, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			// 
            // administracionHotelToolStripMenuItem
            // 
            this.administracionHotelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMHotelToolStripMenuItem,
            this.aBMHabitacionToolStripMenuItem});
            this.administracionHotelToolStripMenuItem.Name = "administracionHotelToolStripMenuItem";
            this.administracionHotelToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.administracionHotelToolStripMenuItem.Text = "Administración Hotel";
			//
			// aBMHotelToolStripMenuItem
            // 
            this.aBMHotelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaHotelToolStripMenuItem,
            this.modificToolStripMenuItem});
            this.aBMHotelToolStripMenuItem.Name = "aBMHotelToolStripMenuItem";
            this.aBMHotelToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.aBMHotelToolStripMenuItem.Text = "ABM Hotel";
			// 
            // altaHotelToolStripMenuItem
            // 
            this.altaHotelToolStripMenuItem.Name = "altaHotelToolStripMenuItem";
            this.altaHotelToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.altaHotelToolStripMenuItem.Text = "Nuevo Hotel";
            this.altaHotelToolStripMenuItem.Click += new System.EventHandler(this.altaHotelToolStripMenuItem_Click);
			// 
            // modificToolStripMenuItem
            // 
            this.modificToolStripMenuItem.Name = "modificToolStripMenuItem";
            this.modificToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.modificToolStripMenuItem.Text = "Consulta Hoteles";
            this.modificToolStripMenuItem.Click += new System.EventHandler(this.modificToolStripMenuItem_Click);
			// 
            // aBMHabitacionToolStripMenuItem
            // 
            this.aBMHabitacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaHabitaciónToolStripMenuItem,
            this.modificacionBajaToolStripMenuItem2});
            this.aBMHabitacionToolStripMenuItem.Name = "aBMHabitacionToolStripMenuItem";
            this.aBMHabitacionToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.aBMHabitacionToolStripMenuItem.Text = "ABM Habitacion";
			 // 
            // nuevaHabitaciónToolStripMenuItem
            // 
            this.nuevaHabitaciónToolStripMenuItem.Name = "nuevaHabitaciónToolStripMenuItem";
            this.nuevaHabitaciónToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.nuevaHabitaciónToolStripMenuItem.Text = "Nueva habitación";
            this.nuevaHabitaciónToolStripMenuItem.Click += new System.EventHandler(this.nuevaHabitaciónToolStripMenuItem_Click);
			// 
            // modificacionBajaToolStripMenuItem2
            // 
            this.modificacionBajaToolStripMenuItem2.Name = "modificacionBajaToolStripMenuItem2";
            this.modificacionBajaToolStripMenuItem2.Size = new System.Drawing.Size(191, 22);
            this.modificacionBajaToolStripMenuItem2.Text = "Consulta habitaciones";
            this.modificacionBajaToolStripMenuItem2.Click += new System.EventHandler(this.modificacionBajaToolStripMenuItem2_Click);
			// 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 20);
            this.toolStripMenuItem1.Text = "ABM Personas";
			// 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteToolStripMenuItem,
            this.consultarClienteToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
			// 
            // nuevoClienteToolStripMenuItem
            // 
            this.nuevoClienteToolStripMenuItem.Name = "nuevoClienteToolStripMenuItem";
            this.nuevoClienteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.nuevoClienteToolStripMenuItem.Text = "Nuevo Cliente";
            this.nuevoClienteToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteToolStripMenuItem_Click);
			// 
            // consultarClienteToolStripMenuItem
            // 
            this.consultarClienteToolStripMenuItem.Name = "consultarClienteToolStripMenuItem";
            this.consultarClienteToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.consultarClienteToolStripMenuItem.Text = "Consultar Cliente";
            this.consultarClienteToolStripMenuItem.Click += new System.EventHandler(this.consultarClienteToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoUsuarioToolStripMenuItem,
            this.modificacionBajaToolStripMenuItem1});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
			// 
            // nuevoUsuarioToolStripMenuItem
            // 
            this.nuevoUsuarioToolStripMenuItem.Name = "nuevoUsuarioToolStripMenuItem";
            this.nuevoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nuevoUsuarioToolStripMenuItem.Text = "Nuevo Usuario";
            this.nuevoUsuarioToolStripMenuItem.Click += new System.EventHandler(this.nuevoUsuarioToolStripMenuItem_Click);
            // 
            // modificacionBajaToolStripMenuItem1
            // 
            this.modificacionBajaToolStripMenuItem1.Name = "modificacionBajaToolStripMenuItem1";
            this.modificacionBajaToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.modificacionBajaToolStripMenuItem1.Text = "Consultar Usuario";
            this.modificacionBajaToolStripMenuItem1.Click += new System.EventHandler(this.modificacionBajaToolStripMenuItem1_Click);
			// 
            // rolToolStripMenuItem
            // 
            this.rolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoRolToolStripMenuItem,
            this.modificarRolToolStripMenuItem});
            this.rolToolStripMenuItem.Name = "rolToolStripMenuItem";
            this.rolToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rolToolStripMenuItem.Text = "Roles";
			// 
            // nuevoRolToolStripMenuItem
            // 
            this.nuevoRolToolStripMenuItem.Name = "nuevoRolToolStripMenuItem";
            this.nuevoRolToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.nuevoRolToolStripMenuItem.Text = "Nuevo Rol";
            this.nuevoRolToolStripMenuItem.Click += new System.EventHandler(this.nuevoRolToolStripMenuItem_Click);
			// 
            // modificarRolToolStripMenuItem
            // 
            this.modificarRolToolStripMenuItem.Name = "modificarRolToolStripMenuItem";
            this.modificarRolToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.modificarRolToolStripMenuItem.Text = "Consultar Roles";
            this.modificarRolToolStripMenuItem.Click += new System.EventHandler(this.modificarRolToolStripMenuItem_Click);
            // 
            // estadíasToolStripMenuItem
            // 
            this.estadíasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaEstadíaToolStripMenuItem,
            this.checkOUTToolStripMenuItem});
            this.estadíasToolStripMenuItem.Name = "estadíasToolStripMenuItem";
            this.estadíasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.estadíasToolStripMenuItem.Text = "Estadías";
            // 
            // nuevaEstadíaToolStripMenuItem
            // 
            this.nuevaEstadíaToolStripMenuItem.Name = "nuevaEstadíaToolStripMenuItem";
            this.nuevaEstadíaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevaEstadíaToolStripMenuItem.Text = "Check IN";
            this.nuevaEstadíaToolStripMenuItem.Click += new System.EventHandler(this.nuevaEstadíaToolStripMenuItem_Click);
			// 
            // listaEstadisticasToolStripMenuItem
            // 
            this.listaEstadisticasToolStripMenuItem.Name = "listaEstadisticasToolStripMenuItem";
            this.listaEstadisticasToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.listaEstadisticasToolStripMenuItem.Text = "Lista Estadisticas";
            this.listaEstadisticasToolStripMenuItem.Click += new System.EventHandler(this.listaEstadisticasToolStripMenuItem_Click);
			//
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(272, 118);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(405, 39);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bienvenido a FRBA Hotel";            
            // 
            // panelReservas
            // 
            this.panelReservas.AutoSize = true;
			this.panelReservas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelReservas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelReservas.Controls.Add(this.cancelReservaButton);
            this.panelReservas.Controls.Add(this.updateReservaButton);
            this.panelReservas.Controls.Add(this.newReservaButton);
			this.panelReservas.Location = new System.Drawing.Point(165, 220);
            this.panelReservas.Name = "panelReservas";
            this.panelReservas.Size = new System.Drawing.Size(572, 96);
            this.panelReservas.TabIndex = 2;
            // 
            // cancelReservaButton
            // 
            this.cancelReservaButton.Location = new System.Drawing.Point(383, 18);
            this.cancelReservaButton.Name = "cancelReservaButton";
            this.cancelReservaButton.Size = new System.Drawing.Size(139, 65);
            this.cancelReservaButton.TabIndex = 2;
            this.cancelReservaButton.Text = "Cancelar reserva";
            this.cancelReservaButton.UseVisualStyleBackColor = true;
			this.cancelReservaButton.Click += new System.EventHandler(this.cancelReservaButton_Click);
            // 
            // updateReservaButton
            // 
            this.updateReservaButton.Location = new System.Drawing.Point(217, 18);
            this.updateReservaButton.Name = "updateReservaButton";
            this.updateReservaButton.Size = new System.Drawing.Size(139, 65);
            this.updateReservaButton.TabIndex = 1;
            this.updateReservaButton.Text = "Modificar reserva";
            this.updateReservaButton.UseVisualStyleBackColor = true;
			this.updateReservaButton.Click += new System.EventHandler(this.updateReservaButton_Click);
            // 
            // newReservaButton
            // 
            this.newReservaButton.Location = new System.Drawing.Point(54, 18);
            this.newReservaButton.Name = "newReservaButton";
            this.newReservaButton.Size = new System.Drawing.Size(139, 65);
            this.newReservaButton.TabIndex = 0;
            this.newReservaButton.Text = "Generar reserva";
            this.newReservaButton.UseVisualStyleBackColor = true;
            this.newReservaButton.Click += new System.EventHandler(this.newReservaButton_Click);
            // 
            // passLinkLabel
            // 
            this.passLinkLabel.AutoSize = true;
            this.passLinkLabel.Location = new System.Drawing.Point(18, 17);
            this.passLinkLabel.Name = "passLinkLabel";
            this.passLinkLabel.Size = new System.Drawing.Size(101, 13);
            this.passLinkLabel.TabIndex = 3;
            this.passLinkLabel.TabStop = true;
            this.passLinkLabel.Text = "Cambiar contraseña";
            this.passLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.passLinkLabel_LinkClicked);
            // 
            // closeSessionLink
            // 
            this.closeSessionLink.AutoSize = true;
            this.closeSessionLink.Location = new System.Drawing.Point(142, 17);
            this.closeSessionLink.Name = "closeSessionLink";
            this.closeSessionLink.Size = new System.Drawing.Size(68, 13);
            this.closeSessionLink.TabIndex = 4;
            this.closeSessionLink.TabStop = true;
            this.closeSessionLink.Text = "Cerrar sesión";
            this.closeSessionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.closeSessionLink_LinkClicked);
            // 
            // panelSession
            // 
            this.panelSession.Controls.Add(this.closeSessionLink);
            this.panelSession.Controls.Add(this.passLinkLabel);
            this.panelSession.Location = new System.Drawing.Point(643, 27);
            this.panelSession.Name = "panelSession";
            this.panelSession.Size = new System.Drawing.Size(233, 56);
            this.panelSession.TabIndex = 5;
            // 
            // inicioSesionLink
            // 
            this.inicioSesionLink.AutoSize = true;
            this.inicioSesionLink.Location = new System.Drawing.Point(795, 422);
            this.inicioSesionLink.Name = "inicioSesionLink";
            this.inicioSesionLink.Size = new System.Drawing.Size(65, 13);
            this.inicioSesionLink.TabIndex = 5;
            this.inicioSesionLink.TabStop = true;
            this.inicioSesionLink.Text = "Inicio sesión";
            this.inicioSesionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.inicioSesionLink_LinkClicked);            
            // 
            // checkOUTToolStripMenuItem
            // 
            this.checkOUTToolStripMenuItem.Name = "checkOUTToolStripMenuItem";
            this.checkOUTToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.checkOUTToolStripMenuItem.Text = "Check OUT";
            this.checkOUTToolStripMenuItem.Click += new System.EventHandler(this.checkOUTToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
			this.ClientSize = new System.Drawing.Size(900, 477);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkTurquoise;            
            this.Controls.Add(this.inicioSesionLink);
            this.Controls.Add(this.panelSession);
            this.Controls.Add(this.panelReservas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(900, 414);
            this.Name = "MenuPrincipal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrincipal - FRBA Hotel";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
			this.panelReservas.ResumeLayout(false);
            this.panelSession.ResumeLayout(false);
            this.panelSession.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificacionBajaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem administracionHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBMHabitacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaHabitaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificacionBajaToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem nuevoRolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarRolToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelReservas;
        private System.Windows.Forms.Button cancelReservaButton;
        private System.Windows.Forms.Button updateReservaButton;
        private System.Windows.Forms.Button newReservaButton;
        private System.Windows.Forms.LinkLabel passLinkLabel;
        private System.Windows.Forms.LinkLabel closeSessionLink;
        private System.Windows.Forms.Panel panelSession;
        private System.Windows.Forms.LinkLabel inicioSesionLink;
        private System.Windows.Forms.ToolStripMenuItem listaEstadisticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadíasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaEstadíaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelesConMasReservasCanceladasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelesConMasConsumiblesFacturadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelesConMásDíasSinServicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habitacionesMasOcupadasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteConMayorCantidadDePuntosToolStripMenuItem;        

    }
}