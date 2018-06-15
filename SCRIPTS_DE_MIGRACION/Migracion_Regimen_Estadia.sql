INSERT INTO [CUATROGDD2018].[Regimenes_Estadia](descripcion,precio_base)
SELECT DISTINCT Regimen_Descripcion, Regimen_Precio
	FROM gd_esquema.Maestra
	ORDER BY Regimen_Descripcion