USE GD1C2018
GO
IF OBJECT_ID('CUATROGDD2018.SP_ObtenerCallesAPartirDeCiudad', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ObtenerCallesAPartirDeCiudad
GO
CREATE PROCEDURE CUATROGDD2018.SP_ObtenerCallesAPartirDeCiudad
@ciudad nvarchar(255)
AS	
	SELECT id_Hotel, LTRIM(RTRIM(calle)) + ' ' + CAST(nro_calle as varchar(10)) as calles from CUATROGDD2018.Hoteles
	where ciudad like '%'+@ciudad+'%'
GO



