USE [GD1C2018]
GO
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'CUATROGDD2018')
DROP SCHEMA [CUATROGDD2018]
GO
USE [GD1C2018]
GO
CREATE SCHEMA [CUATROGDD2018]
GO
/*##########################################################################################################*/
/*										CREACION DE TABLAS													*/
/*##########################################################################################################*/
Print 'Inicio de creacion de tablas'
	/*-1- Creo tabla Roles*/
	CREATE TABLE [CUATROGDD2018].[Roles](
		[id_rol] [int] IDENTITY(1,1) NOT NULL,
		[nombre] [varchar](50) NOT NULL,
		[habilitado] [bit] NOT NULL DEFAULT('True'),
		primary key ([id_rol])
	);

	/*-2- Creo tabla Usuarios*/
	CREATE TABLE [CUATROGDD2018].[Usuarios](
		[id_usuario] [int] IDENTITY(1,1) NOT NULL,
		[username] [varchar](255) NOT NULL,
		[password] [varchar](255) NOT NULL,
		[habilitado] [bit] NOT NULL DEFAULT('True'),
		primary key ([id_usuario])
	);

	/*-3- Creo tabla Tipo de Habitaciones*/
	CREATE TABLE [CUATROGDD2018].[Tipo_Habitacion](
		[id_tipo_habitacion] [int] NOT NULL,
		[descripcion] [nvarchar](255) NOT NULL,
		[porcentual] [numeric](18, 2) NOT NULL,
		primary key ([id_tipo_habitacion])
	);

	/*-4- Creo tabla Hoteles*/
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
		[habilitado] bit NOT NULL DEFAULT('True'),
		[email] [nvarchar](255) NOT NULL DEFAULT('No informado'),
		[fecha_creacion] [datetime] NULL,
		primary key ([id_hotel])
	);

	/*-5- Creo tabla Historial de cierres por hotel*/
	CREATE TABLE [CUATROGDD2018].[Historial_Cierres](
		id_Historia int identity(1,1) PRIMARY KEY,
		id_hotel int NOT NULL,
		fecha_desde datetime not null,
		fecha_hasta datetime null,
		detalle_cierre varchar (255) not null,
		FOREIGN KEY (id_hotel) REFERENCES [CUATROGDD2018].[Hoteles] (id_hotel)
	);

	/*-6- Creo tabla Regimen de estadia*/
	create table [CUATROGDD2018].[Regimenes_Estadia](
		id_regimen int identity(1,1) PRIMARY KEY,
		descripcion nvarchar (255) NOT NULL,
		precio_base numeric(18,2) NOT NULL
	);

	/*-7- Creo tabla Regimen por hotel*/
	CREATE TABLE [CUATROGDD2018].[Regimen_X_Hotel](
		id_regimen int NOT NULL,
		id_hotel int NOT NULL,
		habilitado bit NOT NULL DEFAULT('True'),
		PRIMARY KEY CLUSTERED ( id_regimen, id_hotel ),
		FOREIGN KEY (id_regimen) REFERENCES [CUATROGDD2018].[Regimenes_Estadia] (id_regimen),
		FOREIGN KEY (id_hotel) REFERENCES [CUATROGDD2018].[Hoteles] (id_hotel)
	);
	
	/*-8- Creo tabla Habitaciones*/
	CREATE TABLE [CUATROGDD2018].[Habitaciones](
		[id_habitacion] [int] IDENTITY(1,1) NOT NULL,
		[piso] [numeric](18, 0) NOT NULL,
		[nro_habitacion] [numeric](18, 0) NOT NULL,
		[frente] [nvarchar] (50) NOT NULL,
		[comodidades] [varchar](255) NULL,
		[habilitado] bit NOT NULL DEFAULT('True'),
		[id_hotel] [int] NOT NULL,
		[id_tipo_habitacion] [int] NOT NULL,
		primary key ([id_habitacion]),
		foreign key ([id_hotel]) references [CUATROGDD2018].[Hoteles]([id_hotel]),
		foreign key ([id_tipo_habitacion]) references [CUATROGDD2018].[Tipo_Habitacion]([id_tipo_habitacion])
	);

	/*-9- Creo tabla Usuario_X_Hotel_X_Rol*/
	CREATE TABLE [CUATROGDD2018].[Usuario_X_Hotel_X_Rol](
		[id_usuario] [int] NOT NULL,
		[id_hotel] [int],
		[id_rol] [int] NOT NULL,
		PRIMARY KEY ( [id_usuario], [id_rol] ),
		foreign key ([id_usuario]) references [CUATROGDD2018].[Usuarios]([id_usuario]),
		foreign key ([id_hotel]) references [CUATROGDD2018].[Hoteles]([id_hotel]),
		foreign key ([id_rol]) references [CUATROGDD2018].[Roles]([id_rol])
	);


	/*-10- Creo tabla Consumibles*/
	CREATE TABLE [CUATROGDD2018].[Consumibles](
		id_consumible int PRIMARY KEY,
		descripcion nvarchar (255) NOT NULL,
		precio numeric(18,2) NOT NULL
	);

	/*-11- Creo tabla Estado de reservas*/
	CREATE TABLE [CUATROGDD2018].[Estados_Reservas] (
		id_estado_reserva int identity(1,1) PRIMARY KEY,
		descripcion varchar (255) not null
	);
	
	/*-12- Creo tabla Personas*/
	CREATE TABLE [CUATROGDD2018].[Personas](
		[id_persona] [int] IDENTITY(1,1) NOT NULL,
		[tipo_documento] [nvarchar](50) NOT NULL,
		[nro_documento] [numeric](18, 0) NOT NULL,
		[email] [nvarchar](255) NOT NULL,
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
		[estado] [nvarchar](30) NOT NULL,
		[id_usuario] [int] NOT NULL DEFAULT(1),
		foreign key ([id_usuario]) references [CUATROGDD2018].[Usuarios]([id_usuario]),
		primary key ([id_persona])
	);
	CREATE INDEX IDX_Personas ON [CUATROGDD2018].[Personas] (id_persona,nro_documento, email);

	/*-13- Creo tabla Reservas*/
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

	/*-14- Creo tabla Estadias*/
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

	/*-15- Creo tabla Consumible por estadia*/
	CREATE TABLE [CUATROGDD2018].[Consumible_X_Estadia](	
		id_estadia int NOT NULL,
		id_consumible int NOT NULL,
		cantidad numeric(18,0),
		monto numeric(18,2),
		PRIMARY KEY CLUSTERED ( id_estadia, id_consumible ),
		FOREIGN KEY (id_estadia) REFERENCES [CUATROGDD2018].[Estadias] ( id_estadia ),
		FOREIGN KEY (id_consumible) REFERENCES [CUATROGDD2018].[Consumibles] (id_consumible)
	);

	/*-16- Creo tabla Estadia por Persona*/
	CREATE TABLE [CUATROGDD2018].[Estadia_X_Persona](	
		id_persona int NOT NULL,
		id_estadia int NOT NULL,
		PRIMARY KEY CLUSTERED ( id_estadia, id_persona ),
		FOREIGN KEY (id_estadia) REFERENCES [CUATROGDD2018].[Estadias] ( id_estadia ),
		FOREIGN KEY (id_persona) REFERENCES [CUATROGDD2018].[Personas] (id_persona)
	);

	/*-17- Creo tabla Habitaciones por Reserva*/
	CREATE TABLE [CUATROGDD2018].[Habitacion_X_Reserva](
		id_habitacion int not null,
		id_reserva int not null,
		PRIMARY KEY ( id_habitacion, id_reserva ),
		FOREIGN KEY (id_habitacion) REFERENCES [CUATROGDD2018].[Habitaciones] (id_habitacion),
		FOREIGN KEY (id_reserva) REFERENCES [CUATROGDD2018].[Reservas] (id_reserva)
	);
	
	/*-18- Creo tabla Facturas*/
	CREATE TABLE [CUATROGDD2018].[Facturas](	
		nro_factura numeric(18, 0) not null PRIMARY KEY,
		fecha datetime,
		precio_total numeric(18, 2) not null,
		puntos_obtenidos int not null,
		id_estadia int,
		id_persona int, 
		foreign key (id_estadia) references [CUATROGDD2018].[Estadias] (id_estadia),
		foreign key (id_persona) references [CUATROGDD2018].[Personas] (id_persona)
		);
Print 'Fin de creacion de tablas'

/*##########################################################################################################*/
/*										MIGRACION													*/
/*##########################################################################################################*/
Print 'Inicio de migracion de datos'
	/*-1- Insertar Usuarios*/
	INSERT INTO [CUATROGDD2018].[Usuarios] (username,password)
	VALUES ('No definido','');
	INSERT INTO [CUATROGDD2018].[Usuarios] (username,password)
	VALUES ('GUEST','');
	INSERT INTO [CUATROGDD2018].[Usuarios] (username,password)
	VALUES ('admin', HASHBYTES('SHA2_256', 'w23e') );

	/*-2- Insertar Roles*/
	INSERT INTO [CUATROGDD2018].[Roles]([nombre])
	VALUES ('Guest');
	INSERT INTO [CUATROGDD2018].[Roles]([nombre])
	VALUES ('Administrador');
	INSERT INTO [CUATROGDD2018].[Roles]([nombre])
	VALUES ('Recepcionista');
	INSERT INTO [CUATROGDD2018].[Roles]([nombre])
	VALUES ('Administrador General');
	
	CREATE TABLE [CUATROGDD2018].[Funcionalidades](
				id_funcionalidad int IDENTITY(1,1) not null PRIMARY KEY,
				descripcion varchar(30))
	GO
	--INSERTAR FUNCIONALIDADES
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('ABM Rol');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('ABM Usuario');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('ABM Clientes');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('ABM Hotel');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('ABM Habitacion');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('Generar Reserva');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('Cancelar Reserva');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('Registrar Estadia');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('Registrar Consumible');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('Facturar estadia');
	INSERT INTO [CUATROGDD2018].[Funcionalidades] (descripcion) VALUES ('Listado Estadistico');

	CREATE TABLE [CUATROGDD2018].[Funcionalidad_X_Rol](
				[id_funcionalidad] [int] NOT NULL,
				[id_rol] [int] NOT NULL,
				PRIMARY KEY ( [id_funcionalidad], [id_rol] ),
				foreign key ([id_funcionalidad]) references [CUATROGDD2018].[Funcionalidades]([id_funcionalidad]),
				foreign key ([id_rol]) references [CUATROGDD2018].[Roles]([id_rol]))
	GO
	--INSERTAR FUNCIONALIDADES X ROL
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,1);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,2);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,3);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,4);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,5);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,6);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,7);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,8);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,9);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,10);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (4,11);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (3,3);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (3,6);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (3,7);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (3,8);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (3,9);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (3,10);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (3,11);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (2,1);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (2,2);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (2,4);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (2,5);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (1,6);
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad) VALUES (1,7);

	/*-3- Insertar Usuarios por Rol*/
	INSERT INTO [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] (id_usuario,id_rol,id_hotel) VALUES (2,1,null);
	INSERT INTO [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] (id_usuario,id_rol,id_hotel) VALUES (3,4,null);
	
	/*-4- Insertar Estado de reservas*/
	INSERT INTO [CUATROGDD2018].[Estados_Reservas] ( descripcion )
	VALUES ('Reserva correcta');
	INSERT INTO [CUATROGDD2018].[Estados_Reservas] ( descripcion )
	VALUES ('Reserva modificada');
	INSERT INTO [CUATROGDD2018].[Estados_Reservas] ( descripcion )
	VALUES ('Reserva cancelada por Recepcion');
	INSERT INTO [CUATROGDD2018].[Estados_Reservas] ( descripcion )
	VALUES ('Reserva cancelada por Cliente');
	INSERT INTO [CUATROGDD2018].[Estados_Reservas] ( descripcion )
	VALUES ('Reserva cancelada por No-Show');
	INSERT INTO [CUATROGDD2018].[Estados_Reservas] ( descripcion )
	VALUES ('Reserva con ingreso, efectivizada');
	INSERT INTO [CUATROGDD2018].[Estados_Reservas] ( descripcion )
	VALUES ('Reserva con ingreso, en curso');

	
	/*-5- Insertar Tipo de Habitaciones*/
	INSERT INTO [CUATROGDD2018].[Tipo_Habitacion] (
				[id_tipo_habitacion]
				,[descripcion]
				,[porcentual])
	SELECT DISTINCT  Habitacion_Tipo_Codigo
					,Habitacion_Tipo_Descripcion
					,Habitacion_Tipo_Porcentual
	FROM [gd_esquema].[Maestra]
	print	'Insersión Tipo de Habitaciones finalizada - ' + convert(varchar,@@rowcount) + ' filas insertadas.';

	/*-6- Insertar Hoteles*/
	INSERT INTO [CUATROGDD2018].[Hoteles] (
				nombre
				,nro_calle
				,ciudad
				,calle
				,cant_estrellas
				,recarga_estrellas
				,pais
				)
	SELECT DISTINCT 
				rtrim(Hotel_Ciudad)+' - '+rtrim(Hotel_Calle)
				,Hotel_Nro_Calle
				,Hotel_Ciudad
				,Hotel_Calle
				,Hotel_CantEstrella
				,Hotel_Recarga_Estrella
				,'Argentina'
	FROM [gd_esquema].[Maestra]
	print	'Insersión de Hoteles finalizada - ' + convert(varchar,@@rowcount) + ' filas insertadas.';

	/*-7- Insertar Habitaciones*/
	DECLARE @nroCalle numeric(18,0)
			,@numHab numeric (18,0)
			,@habPiso varchar (255)
			,@habFrente varchar(1)
			,@tipoHab numeric (18,0)
			,@codHotel int
			,@dirHotel varchar(50)
			,@contador int
	DECLARE insert_cursor2 CURSOR FOR 
		SELECT Hotel_Calle
			  ,Hotel_Nro_Calle
			  ,Habitacion_Numero
			  ,Habitacion_Piso
			  ,Habitacion_Frente
			  ,Habitacion_Tipo_Codigo
		FROM [gd_esquema].[Maestra]
		GROUP BY Hotel_Calle
				,Hotel_Nro_Calle
				,Habitacion_Numero
				,Habitacion_Tipo_Codigo
				,Habitacion_Piso
				,Habitacion_Frente
		ORDER BY Hotel_Calle,Hotel_Nro_Calle,Habitacion_Numero,Habitacion_Piso
	OPEN insert_cursor2
	FETCH NEXT FROM insert_cursor2 INTO @dirHotel,@nroCalle, @numHab, @habPiso, @habFrente, @tipoHab 
	WHILE @@FETCH_STATUS=0
		BEGIN
			SELECT @codHotel=id_hotel 
			FROM [CUATROGDD2018].[Hoteles] 
			where calle=@dirHotel and nro_calle = @nroCalle
			INSERT INTO [CUATROGDD2018].[Habitaciones] (
						id_tipo_habitacion
						,id_hotel
						,piso
						,frente
						,nro_habitacion)
			VALUES  (	@tipoHab
						,@codHotel
						,@habPiso
						,@habFrente
						,@numHab)
			set @contador=@contador+@@rowcount
			FETCH NEXT FROM insert_cursor2 INTO @dirHotel,@nroCalle, @numHab, @habPiso, @habFrente, @tipoHab 
		END
	print	'Insersión de Habitaciones finalizada - ' + convert(varchar,@contador) + ' filas insertadas.';
	CLOSE insert_cursor2
	DEALLOCATE insert_cursor2
	GO
	
	/*-8- Insertar Regimen de estadia*/
	INSERT INTO [CUATROGDD2018].[Regimenes_Estadia](
				descripcion
				,precio_base)
	SELECT DISTINCT Regimen_Descripcion
					,Regimen_Precio
		FROM [gd_esquema].[Maestra]
		ORDER BY Regimen_Descripcion
	print	'Insersión de Regimenes de estadia finalizada - ' + convert(varchar,@@rowcount) + ' filas insertadas.';

	/*-9- Insertar Regimen por hotel*/
	DECLARE @nroCalle numeric(18,0)
			,@descReg varchar(255)
			,@codReg int
			,@codHotel int
			,@dirHotel varchar(255)
			,@contador int
	DECLARE insert_cursor CURSOR FOR 
		SELECT Hotel_Calle
			  ,Hotel_Nro_Calle
			  ,Regimen_Descripcion 
		FROM [gd_esquema].[Maestra]
		GROUP BY Hotel_Calle
				,Hotel_Nro_Calle
				,Regimen_Descripcion
		ORDER BY Hotel_Calle,Hotel_Nro_Calle
	OPEN insert_cursor
	FETCH NEXT FROM insert_cursor INTO @dirHotel,@nroCalle,@descReg
	WHILE @@FETCH_STATUS=0
		BEGIN
			SELECT @codHotel=id_hotel 
			FROM [CUATROGDD2018].[Hoteles] 
			where calle=@dirHotel and nro_calle = @nroCalle 
			SELECT @codReg=id_regimen 
			FROM  [CUATROGDD2018].[Regimenes_Estadia]
			where descripcion = @descReg
			INSERT INTO [CUATROGDD2018].[Regimen_X_Hotel](id_regimen,id_hotel)
			VALUES  (@codReg,@codHotel)
			set @contador=@contador+@@rowcount
			FETCH NEXT FROM insert_cursor INTO @dirHotel,@nroCalle,@descReg
		END
	print	'Insersión Regimen por hotel finalizada - ' + convert(varchar,@contador) + ' filas insertadas.';
	CLOSE insert_cursor 	
	DEALLOCATE insert_cursor
	GO
		
	/*-10- Insertar Consumibles*/
	INSERT INTO [CUATROGDD2018].[Consumibles] (
				id_consumible
				,descripcion
				,precio)
	SELECT DISTINCT 
				Consumible_Codigo
				,Consumible_Descripcion
				,Consumible_Precio
	FROM [gd_esquema].[Maestra]
	WHERE Consumible_Codigo IS NOT NULL
	ORDER BY Consumible_Codigo
	print	'Insersión de Consumibles finalizada - ' + convert(varchar,@@rowcount) + ' filas insertadas.';

	/*-11- Insertar Personas*/
	with clientes as(
	  SELECT Cliente_Pasaporte_Nro as nro_documento
				,Cliente_Mail as email
				,Cliente_Nombre as nombre
				,Cliente_Apellido as apellido
				,Cliente_Nacionalidad as nacionalidad
				,Cliente_Fecha_Nac as fecha_nac
				,Cliente_Dom_Calle as calle
				,Cliente_Nro_Calle as nro_calle
				,Cliente_Piso as piso
				,Cliente_Depto as depto
				,row_number() OVER(PARTITION BY Cliente_Pasaporte_Nro ORDER BY Cliente_Mail) AS cantDocumentos
				,row_number() OVER(PARTITION BY [Cliente_Mail] ORDER BY Cliente_Mail) AS cantEmail
	  FROM [gd_esquema].[Maestra]
	  GROUP BY	Cliente_Pasaporte_Nro
				,Cliente_Mail
				,Cliente_Nombre
				,Cliente_Apellido
				,Cliente_Nacionalidad
				,Cliente_Dom_Calle
				,Cliente_Nro_Calle
				,Cliente_Piso
				,Cliente_Depto
				,Cliente_Fecha_Nac
	)	
		/*Uso tabla temporal clientes*/
		select * into #temp_clientes 
		from clientes;

	insert into [CUATROGDD2018].[Personas](
					[tipo_documento]
					,[nro_documento]
					,[email]
					,[nombre]
					,[apellido]
					,[nacionalidad]
					,[direccion]
					,[nro_calle]
					,[piso]
					,[departamento]
					,[pais]
					,[fecha_nacimiento]
					,[id_usuario]
					)
	select 'DNI'
			,nro_documento
			,email
			,nombre
			,apellido
			,nacionalidad
			,calle
			,nro_calle
			,piso
			,depto
			,'ARGENTINA' 
			,fecha_nac
			,1

	from #temp_clientes
	where cantDocumentos=1 and cantEmail=1
	order by nro_documento,email;
	print	'Insersión de Personas sin repetir finalizada - ' + convert(varchar,@@rowcount) + ' filas insertadas.';
	
	insert into [CUATROGDD2018].[Personas](
					[tipo_documento]
					,[nro_documento]
					,[email]
					,[nombre]
					,[apellido]
					,[nacionalidad]
					,[direccion]
					,[nro_calle]
					,[piso]
					,[departamento]
					,[pais]
					,[fecha_nacimiento]
					,[id_usuario]
					,[estado]
					)
	select 'DNI'
			,nro_documento
			,email
			,nombre
			,apellido
			,nacionalidad
			,calle
			,nro_calle
			,piso
			,depto
			,'ARGENTINA' 
			,fecha_nac
			,1
			,'Inconsistente'
	from #temp_clientes 
	where cantDocumentos>1 or cantEmail>1
	order by [nro_documento],[email]
	print	'Insersión de personas con datos inconsistentes finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';

	drop table #temp_clientes;

	/*-12- Insertar Reservas*/
	insert into [CUATROGDD2018].[Reservas](
				id_reserva
				,id_persona
				,id_regimen
				,fecha_desde
				,fecha_hasta
				,id_estado_reserva
				,fecha_reserva)
	SELECT Reserva_Codigo as id_reserva
			,id_persona
			,id_regimen
			,Reserva_Fecha_Inicio as fecha_inicio
			,DATEADD(day,Reserva_Cant_Noches,Reserva_Fecha_Inicio) as  fecha_hasta
			, 1 as id_estado_reserva
			,''
	FROM [gd_esquema].[Maestra] 
	inner join [CUATROGDD2018].Personas per
	on Cliente_Pasaporte_Nro=per.nro_documento and Cliente_Mail=per.email
	inner join  [CUATROGDD2018].Regimenes_Estadia re
	on Regimen_Descripcion=re.descripcion
	WHERE Reserva_Codigo is not null
	GROUP BY Reserva_Codigo,id_persona,id_regimen,Reserva_Fecha_Inicio,DATEADD(day,Reserva_Cant_Noches,Reserva_Fecha_Inicio)
	order by Reserva_Codigo
	print	'Insersión de Reservas finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';

	/*-13- Insertar Habitaciones por Reserva*/
	select id_reserva, Habitacion_Numero,Habitacion_Piso,Hotel_Nro_Calle
	INTO #temp_infoReservas 
	from [gd_esquema].[Maestra]
	Inner join [CUATROGDD2018].[Reservas] 
	on id_reserva=Reserva_Codigo
	group by id_reserva,Habitacion_Numero,Habitacion_Piso,Hotel_Nro_Calle

	select hab.id_habitacion, hab.[nro_habitacion] as habNumero,hab.piso as habPiso ,ho.nro_calle as hotelCalle
	into #temp_infoHabitacion
	from [CUATROGDD2018].[Habitaciones] hab
	inner join [CUATROGDD2018].[Hoteles] ho 
	on hab.id_hotel = ho.id_hotel

	insert into [CUATROGDD2018].[Habitacion_X_Reserva](id_habitacion,id_reserva)
	select id_habitacion, id_reserva
	from #temp_infoReservas
	inner join #temp_infoHabitacion
	on Habitacion_Numero=habNumero and Habitacion_Piso=habPiso and Hotel_Nro_Calle=hotelCalle
	group by id_habitacion, id_reserva
	order by id_reserva
	print	'Insersión de Habitacion por Reserva finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';

	drop table #temp_infoHabitacion;
	drop table #temp_infoReservas;

	/*-14- Insertar Estadias*/
	insert into [CUATROGDD2018].[Estadias](
				id_habitacion
				,id_reserva
				,fecha_inicio
				,cant_noches
				,id_usuario_checkIn
				,id_usuario_checkOut)
	SELECT   id_habitacion
			,id_reserva
			,Estadia_Fecha_Inicio
			,Estadia_Cant_Noches
			,1
			,1
	FROM [gd_esquema].[Maestra] ma
	JOIN [CUATROGDD2018].[Habitacion_X_Reserva] hr
	on ma.Reserva_Codigo=hr.id_reserva
	where  Estadia_Fecha_Inicio is  not null 
	GROUP BY id_habitacion, id_reserva, Estadia_Fecha_Inicio,Estadia_Cant_Noches
	order by id_reserva;
	print	'Insersión de Estadias finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';

	/*-15- Insertar Consumible por estadia*/
	INSERT INTO [CUATROGDD2018].[Consumible_X_Estadia](
				id_estadia
				,id_consumible
				,monto
				,cantidad)
	SELECT  distinct 
			id_estadia
			,Consumible_Codigo
			,Item_Factura_Monto
			,Item_Factura_Cantidad
	from [gd_esquema].[Maestra]
	inner join [CUATROGDD2018].[Hoteles]
	on Hotel_Nro_Calle= nro_calle 
	inner join [CUATROGDD2018].[Habitaciones]
	on Habitacion_Numero=nro_habitacion and Habitacion_Piso= piso 
	inner join [CUATROGDD2018].[Estadias]
	on Estadia_Fecha_Inicio=fecha_inicio and Estadia_Cant_Noches=cant_noches 
	where Consumible_Codigo is not null
	group by id_estadia, Consumible_Codigo, Item_Factura_Cantidad, Item_Factura_Monto;
	print	'Insersión Consumible por Estadia finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';

	/*-16- Insertar Estadia por Persona*/
	INSERT INTO [CUATROGDD2018].[Estadia_X_Persona] ( id_estadia, id_persona)
	select distinct e.id_estadia, p.id_persona
	from [gd_esquema].[Maestra] m
	inner join [CUATROGDD2018].[Personas] p
	on Cliente_Pasaporte_Nro=nro_documento and Cliente_Mail=email
	inner join [CUATROGDD2018].[Reservas] r
	on Reserva_Codigo=id_reserva
	inner join [CUATROGDD2018].[Estadias] e
	on r.id_reserva=e.id_reserva and m.Estadia_Fecha_Inicio=e.fecha_inicio and m.Estadia_Cant_Noches=e.cant_noches
	where Estadia_Fecha_Inicio is not null
	print	'Insersión de Estadia por persona finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';

	/*-17- Insertar Facturas*/
	/*Generar una tabla temporal con los campos necesarios para armar la tabla Facturas*/
	create FUNCTION [CUATROGDD2018].[Fn_DarPuntos] (@porcentual numeric(18,2),@precioRegimen numeric(18,2),@consumibles numeric(18,2),@noches numeric(18,0))
	RETURNS int
	AS BEGIN
		DECLARE @resultado int;
		
		set @resultado = ((@porcentual*@precioRegimen)*@noches)/20+@consumibles/10

		RETURN @resultado
	END
		
	SELECT 
		  [Reserva_Codigo]
		  ,Estadia_Fecha_Inicio
		  ,[Cliente_Pasaporte_Nro]
		  ,Cliente_Mail
		  ,[Factura_Nro]
		  ,Factura_Fecha
		  ,Factura_Total
		  ,Regimen_Precio
		  ,Habitacion_Tipo_Porcentual
		  ,Estadia_Cant_Noches
		  ,sum(Consumible_Precio) as total_consumible
	INTO #TEMP_FACTURA     
	FROM [gd_esquema].[Maestra]
	WHERE Factura_Nro IS NOT NULL
	GROUP BY [Reserva_Codigo]
		  ,Estadia_Fecha_Inicio
		  ,[Cliente_Pasaporte_Nro]
		  ,Cliente_Mail
		  ,[Factura_Nro]
		  ,Factura_Fecha
		  ,Factura_Total
		  ,Regimen_Precio
		  ,Estadia_Cant_Noches
		  ,Habitacion_Tipo_Porcentual
	ORDER BY [Factura_Nro];

	insert into [CUATROGDD2018].[Facturas](
				nro_factura
				,fecha
				,precio_total
				,puntos_obtenidos
				,id_estadia
				,id_persona
				,id_forma_pago)
	select temp.[Factura_Nro]
			,temp.Factura_Fecha
			,temp.Factura_Total
			,[CUATROGDD2018].[Fn_DarPuntos](temp.Regimen_Precio,temp.Habitacion_Tipo_Porcentual,temp.total_consumible,temp.Estadia_Cant_Noches) as puntos
			,est.id_estadia
			,per.id_persona
			,1 as id_forma_pago
	from #TEMP_FACTURA temp
	inner join [CUATROGDD2018].[Personas] per
	on temp.[Cliente_Pasaporte_Nro]=per.nro_documento
	and temp.Cliente_Mail=per.email
	inner join [CUATROGDD2018].[Estadias] est
	on temp.[Reserva_Codigo]=est.[id_reserva];
	print	'Insersión de Facturas finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';
	drop table #TEMP_FACTURA;

Print 'Fin de migracion de datos'