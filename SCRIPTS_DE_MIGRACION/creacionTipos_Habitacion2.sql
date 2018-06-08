create table Tipos_Habitacion
(
	id_Tipo_Habitacion int PRIMARY KEY,
	descripcion varchar (255) NOT NULL,
	porcentual numeric(18,2) NOT NULL
)
GO


INSERT INTO Tipos_Habitacion (descripcion,porcentual)
SELECT DISTINCT  Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra