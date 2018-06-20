USE GD1C2018
GO
IF OBJECT_ID('CUATROGDD2018.sp_ObtenerCiudades', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.sp_ObtenerCiudades
GO
CREATE PROCEDURE CUATROGDD2018.sp_ObtenerCiudades
AS
	SELECT DISTINCT(LTRIM(RTRIM(ciudad))) as ciudad from CUATROGDD2018.Hoteles	
GO