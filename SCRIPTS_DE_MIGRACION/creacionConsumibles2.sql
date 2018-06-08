CREATE TABLE dbo.Consumibles
(
	id_consumible int PRIMARY KEY,
	descripcion varchar (255) NOT NULL,
	precio numeric(18,2) NOT NULL
)
GO

INSERT INTO Consumibles (id_consumible,descripcion,precio)
SELECT DISTINCT gd_esquema.Maestra.Consumible_Codigo, gd_esquema.Maestra.Consumible_Descripcion,gd_esquema.Maestra.Consumible_Precio
FROM gd_esquema.Maestra
WHERE Consumible_Codigo IS NOT NULL
ORDER BY Consumible_Codigo