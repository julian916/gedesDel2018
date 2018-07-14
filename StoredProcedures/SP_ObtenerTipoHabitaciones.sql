USE [GD1C2018]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_ObtenerTipoHabitaciones]
AS
BEGIN
		SELECT id_tipo_habitacion, descripcion from CUATROGDD2018.Tipo_Habitacion	
END


