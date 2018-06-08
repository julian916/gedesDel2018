CREATE TABLE Hoteles
(
	id_hotel int identity(1,1) PRIMARY KEY,
	nombre varchar (255),
	telefono varchar (20),
	nombre_calle varchar (255) NOT NULL,
	nro_calle numeric(18,0) NOT NULL,
	ciudad varchar (255) NOT NULL,
	pais varchar (255) NOT NULL,
	cant_estrellas numeric(18,0) NOT NULL,
	recarga_estrellas numeric(18,0) NOT NULL,
	estado varchar (255) NOT NULL,
)
GO

INSERT INTO Hoteles (nro_calle,ciudad,nombre_calle,cant_estrellas,recarga_estrellas,pais,estado)
SELECT DISTINCT Hotel_Nro_Calle,Hotel_Ciudad,Hotel_Calle,Hotel_CantEstrella,Hotel_Recarga_Estrella,'Argentina','Activo'
FROM gd_esquema.Maestra
ORDER BY Hotel_Ciudad,Hotel_Calle
