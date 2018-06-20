USE GD1C2018
GO
IF OBJECT_ID('dbo.sp_ObtenerCiudades', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_ObtenerCiudades
GO
CREATE PROCEDURE dbo.sp_ObtenerCiudades
AS
	SELECT DISTINCT(LTRIM(RTRIM(ciudad))) as ciudad from CUATROGDD2018.Hoteles	
GO