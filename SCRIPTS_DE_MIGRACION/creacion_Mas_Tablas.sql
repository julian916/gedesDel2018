CREATE TABLE dbo.Roles
(
	id_rol int identity(1,1) PRIMARY KEY,
	nombre varchar (255) NOT NULL
)
GO

CREATE TABLE dbo.Usuario_X_Rol
(
	id_usuario int NOT NULL,
	id_rol int NOT NULL,
	PRIMARY KEY CLUSTERED ( id_usuario, id_rol ),
	FOREIGN KEY (id_usuario) REFERENCES [Usuarios] ( id_usuario ),
	FOREIGN KEY (id_rol) REFERENCES [Roles] (id_rol)
)
GO

CREATE TABLE dbo.Usuario_X_Hotel
(
	id_usuario int NOT NULL,
	id_hotel int NOT NULL,
	PRIMARY KEY CLUSTERED ( id_usuario, id_hotel ),
	FOREIGN KEY (id_usuario) REFERENCES [Usuarios] ( id_usuario ),
	FOREIGN KEY (id_hotel) REFERENCES [Hoteles] (id_hotel)
)
GO

CREATE TABLE dbo.Historial_Cierres
(
	id_Historia int identity(1,1) PRIMARY KEY,
	id_hotel int NOT NULL,
	fecha_inicio datetime,
	fecha_final datetime,
	detalle_cierre varchar (255),
	FOREIGN KEY (id_hotel) REFERENCES [Hoteles] (id_hotel)
)
GO

CREATE TABLE dbo.Estados_Reservas 
(
	id_estado_reserva int identity(1,1) PRIMARY KEY,
	descripcion_estado varchar (255)
)
GO

INSERT INTO dbo.Estados_Reservas ( descripcion_estado )
VALUES ('Reserva correcta')
INSERT INTO dbo.Estados_Reservas ( descripcion_estado )
VALUES ('Reserva modificada')
INSERT INTO dbo.Estados_Reservas ( descripcion_estado )
VALUES ('Reserva cancelada por Recepcion')
INSERT INTO dbo.Estados_Reservas ( descripcion_estado )
VALUES ('Reserva cancelada por Cliente')
INSERT INTO dbo.Estados_Reservas ( descripcion_estado )
VALUES ('Reserva cancelada por No-Show')
INSERT INTO dbo.Estados_Reservas ( descripcion_estado )
VALUES ('Reserva con ingreso (efectivizada)')

