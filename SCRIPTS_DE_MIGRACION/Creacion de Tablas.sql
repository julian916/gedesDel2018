USE [GD1C2018]
GO

CREATE SCHEMA [CUATROGDD2018]
GO

	/*Creo tabla Roles*/
	CREATE TABLE [CUATROGDD2018].[Roles](
		[id_rol] [int] IDENTITY(1,1) NOT NULL,
		[nombre] [varchar](50) NOT NULL,
		[estado] [varchar](10) NOT NULL DEFAULT('Activo'),
		primary key ([id_rol])
	);

	/*Creo tabla Usuarios*/
	CREATE TABLE [CUATROGDD2018].[Usuarios](
		[id_usuario] [int] IDENTITY(1,1) NOT NULL,
		[password] [varchar](255) NOT NULL,
		[esta_Habilitado] [bit] NOT NULL DEFAULT(0),
		[username] [varchar](255) NOT NULL,
		primary key ([id_usuario])
	);

	/*Creo tabla Usuarios por Rol*/
	CREATE TABLE [CUATROGDD2018].[Usuario_X_Rol](
		[id_usuario] [int] NOT NULL,
		[id_rol] [int] NOT NULL,
		PRIMARY KEY ( [id_usuario], [id_rol] ),
		foreign key ([id_usuario]) references [CUATROGDD2018].[Usuarios]([id_usuario]),
		foreign key ([id_rol]) references [CUATROGDD2018].[Roles]([id_rol])
	);

	/*Creo tabla Tipo de Habitaciones*/
	CREATE TABLE [CUATROGDD2018].[Tipo_Habitacion](
		[id_tipo_habitacion] [int] NOT NULL,
		[descripcion] [nvarchar](255) NOT NULL,
		[porcentual] [numeric](18, 2) NOT NULL,
		primary key ([id_tipo_habitacion])
	);

	/*Creo tabla Hoteles*/
	CREATE TABLE [CUATROGDD2018].[Hoteles](
		[id_hotel] [int] IDENTITY(1,1) NOT NULL,
		[nombre] [nvarchar](255) NOT NULL,
		[telefono] [numeric](18, 0) NOT NULL DEFAULT(0),
		[calle] [nvarchar](255) NOT NULL,
		[nro_calle] [numeric](18, 0) NOT NULL,
		[ciudad] [nvarchar](255) NOT NULL,
		[pais] [nvarchar](255) NOT NULL,
		[cant_estrellas] [numeric](18, 0) NOT NULL,
		[recarga_estrellas] [numeric](18, 0) NOT NULL,
		[estado] [nvarchar](255) NOT NULL DEFAULT('Activo'),
		[email] [nvarchar](255) NOT NULL DEFAULT('No informado'),
		[fecha_creacion] [datetime] NULL,
		primary key ([id_hotel])
	);

	/*Creo tabla Historial de cierres por hotel*/
	CREATE TABLE [CUATROGDD2018].[Historial_Cierres](
		id_Historia int identity(1,1) PRIMARY KEY,
		id_hotel int NOT NULL,
		fecha_inicio datetime not null,
		fecha_final datetime null,
		detalle_cierre varchar (255) not null,
		FOREIGN KEY (id_hotel) REFERENCES [CUATROGDD2018].[Hoteles] (id_hotel)
	);
	
	/*Creo tabla Habitaciones*/
	CREATE TABLE [CUATROGDD2018].[Habitaciones](
		[id_habitacion] [int] IDENTITY(1,1) NOT NULL,
		[piso] [numeric](18, 0) NOT NULL,
		[nro_habitacion] [numeric](18, 0) NOT NULL,
		[frente] [nvarchar] (50) NOT NULL,
		[comodidades] [varchar](255) NULL,
		[estado] [varchar](255) NOT NULL DEFAULT('Disponible'),
		[id_hotel] [int] NOT NULL,
		[id_tipo_habitacion] [int] NOT NULL,
		primary key ([id_habitacion]),
		foreign key ([id_hotel]) references [CUATROGDD2018].[Hoteles]([id_hotel]),
		foreign key ([id_tipo_habitacion]) references [CUATROGDD2018].[Tipo_Habitacion]([id_tipo_habitacion])
	);

	/*Creo tabla Usuarios por hotel*/
	CREATE TABLE [CUATROGDD2018].[Usuario_X_Hotel](
		[id_usuario] [int] NOT NULL,
		[id_hotel] [int] NOT NULL,
		PRIMARY KEY ( [id_usuario], [id_hotel] ),
		foreign key ([id_usuario]) references [CUATROGDD2018].[Usuarios]([id_usuario]),
		foreign key ([id_hotel]) references [CUATROGDD2018].[Hoteles]([id_hotel])
	);

	/*Creo tabla Regimen de estadia*/
	create table [CUATROGDD2018].[Regimenes_Estadia](
		id_regimen int identity(1,1) PRIMARY KEY,
		descripcion nvarchar (255) NOT NULL,
		precio_base numeric(18,2) NOT NULL
	);

	/*Creo tabla Regimen por hotel*/
	CREATE TABLE [CUATROGDD2018].[Regimen_X_Hotel](
		id_regimen int NOT NULL,
		id_hotel int NOT NULL,
		estado varchar(255) NOT NULL,
		PRIMARY KEY CLUSTERED ( id_regimen, id_hotel ),
		FOREIGN KEY (id_regimen) REFERENCES [CUATROGDD2018].[Regimenes_Estadia] (id_regimen),
		FOREIGN KEY (id_hotel) REFERENCES [CUATROGDD2018].[Hoteles] (id_hotel)
	);

	/*Creo tabla Consumibles*/
	CREATE TABLE [CUATROGDD2018].[Consumibles](
		id_consumible int PRIMARY KEY,
		descripcion nvarchar (255) NOT NULL,
		precio numeric(18,2) NOT NULL
	);

	/*Creo tabla Estado de reservas*/
	CREATE TABLE [CUATROGDD2018].[Estados_Reservas] (
		id_estado_reserva int identity(1,1) PRIMARY KEY,
		descripcion varchar (255) not null
	);
	
	/*Creo tabla Personas*/
	CREATE TABLE [CUATROGDD2018].[Personas](
		[id_persona] [int] IDENTITY(1,1) NOT NULL,
		[tipo_documento] [nvarchar](50) NOT NULL,
		[nro_documento] [numeric](18, 0) UNIQUE NOT NULL,
		[email] [nvarchar](255) UNIQUE NOT NULL,
		[nombre] [nvarchar](255) NOT NULL,
		[apellido] [nvarchar](255) NOT NULL,
		[telefono] [numeric](18, 0) NOT NULL DEFAULT(0),
		[nacionalidad] [nvarchar](255) NOT NULL,
		[direccion] [nvarchar](255) NULL,
		[nro_calle] [numeric](18, 0) NULL,
		[piso] [numeric](18, 0) NULL,
		[departamento] [nvarchar](50) NULL,
		[localidad] [nvarchar](255) NULL DEFAULT('No informado'),
		[pais] [nvarchar](255) NULL DEFAULT('No informado'),
		[fecha_nacimiento] [datetime] NOT NULL,
		[estado] [nvarchar](30) NOT NULL DEFAULT('Habilitado'),
		[id_usuario] [int] NOT NULL DEFAULT(1),
		foreign key ([id_usuario]) references [CUATROGDD2018].[Usuarios]([id_usuario]),
		primary key ([id_persona]),
	);
	CREATE INDEX IDX_Personas ON [CUATROGDD2018].[Personas] (id_persona,nro_documento, email);  

	/*Creo tabla Reservas*/
	CREATE TABLE [CUATROGDD2018].[Reservas] (
		id_reserva int PRIMARY KEY not null,
		id_persona int not null,
		id_regimen int not null,
		id_estado_reserva int not null,
		fecha_reserva date not null,
		fecha_desde date not null,
		fecha_hasta date not null,
		cantidad_noches int,
		FOREIGN KEY (id_persona) REFERENCES [CUATROGDD2018].[Personas] (id_persona),
		FOREIGN KEY (id_regimen) REFERENCES [CUATROGDD2018].[Regimenes_Estadia] (id_regimen),
		FOREIGN KEY (id_estado_reserva) REFERENCES [CUATROGDD2018].[Estados_Reservas] (id_estado_reserva)
	);

	/*Creo tabla Estadias*/
	CREATE TABLE [CUATROGDD2018].[Estadias](	
		id_estadia int identity(1,1) PRIMARY KEY,
		fecha_inicio datetime,
		cant_noches numeric(18,0) null,
		id_usuario_checkIn int not null,
		id_usuario_checkOut int not null, /* recepcionistas */
		id_habitacion int not null,
		id_reserva int not null,
		FOREIGN KEY (id_habitacion) REFERENCES [CUATROGDD2018].[Habitaciones] ( id_habitacion ),
		FOREIGN KEY (id_usuario_checkIn) REFERENCES [CUATROGDD2018].[Usuarios] ( id_usuario ),
		FOREIGN KEY (id_usuario_checkOut) REFERENCES [CUATROGDD2018].[Usuarios] ( id_usuario ),
		FOREIGN KEY (id_reserva) REFERENCES [CUATROGDD2018].[Reservas] ( id_reserva )
	);

	/*Creo tabla Consumible por estadia*/
	CREATE TABLE [CUATROGDD2018].[Consumible_X_Estadia](	
		id_estadia int NOT NULL,
		id_consumible int NOT NULL,
		cantidad numeric(18,0),
		monto numeric(18,2),
		PRIMARY KEY CLUSTERED ( id_estadia, id_consumible ),
		FOREIGN KEY (id_estadia) REFERENCES [CUATROGDD2018].[Estadias] ( id_estadia ),
		FOREIGN KEY (id_consumible) REFERENCES [CUATROGDD2018].[Consumibles] (id_consumible)
	);

	/*Creo tabla Estadia por Persona*/
	CREATE TABLE [CUATROGDD2018].[Estadia_X_Persona](	
		id_persona int NOT NULL,
		id_estadia int NOT NULL,
		PRIMARY KEY CLUSTERED ( id_estadia, id_persona ),
		FOREIGN KEY (id_estadia) REFERENCES [CUATROGDD2018].[Estadias] ( id_estadia ),
		FOREIGN KEY (id_persona) REFERENCES [CUATROGDD2018].[Personas] (id_persona)
	);

	/*Creo tabla Habitaciones por Reserva*/
	CREATE TABLE [CUATROGDD2018].[Habitacion_X_Reservas](
		id_habitacion int not null,
		id_reserva int not null,
		PRIMARY KEY ( id_habitacion, id_reserva ),
		FOREIGN KEY (id_habitacion) REFERENCES [CUATROGDD2018].[Habitaciones] (id_habitacion),
		FOREIGN KEY (id_reserva) REFERENCES [CUATROGDD2018].[Reservas] (id_reserva)
	);
	
	/*Creo tabla Facturas*/
	CREATE TABLE [CUATROGDD2018].[Facturas](	
		nro_factura numeric(18, 0) not null PRIMARY KEY,
		fecha datetime,
		precio_total numeric(18, 2) not null,
		puntos_obtenidos int not null,
		id_estadias int,
		id_persona int, 
		foreign key (id_estadias) references [CUATROGDD2018].[Estadias] (id_estadia),
		foreign key (id_persona) references [CUATROGDD2018].[Personas] (id_persona)
		);