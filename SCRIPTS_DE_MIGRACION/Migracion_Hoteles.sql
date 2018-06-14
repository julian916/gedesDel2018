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
FROM gd_esquema.Maestra