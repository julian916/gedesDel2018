CREATE TABLE dbo.Usuarios
(
	id_usuario int identity(1,1) PRIMARY KEY,
	password varchar(255),
	esta_Habilitado BIT NOT NULL DEFAULT 0,
	username varchar(255) UNIQUE
)
GO


INSERT INTO Usuarios (username,password)
VALUES ('NO DEFINIDO','')

INSERT INTO Usuarios (username,password)
VALUES ('GUEST','')

INSERT INTO Usuario_X_Rol (id_usuario,id_rol) VALUES (2,1)
