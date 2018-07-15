IF OBJECT_ID('CUATROGDD2018.SP_infoHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_infoHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_infoHabitacion] @idhotel int
AS
BEGIN
	SELECT id_habitacion, id_tipo_habitacion, piso, frente, nro_habitacion, habilitado, comodidades from [CUATROGDD2018].[Habitaciones]
	WHERE id_hotel=@idhotel
	ORDER BY id_habitacion, id_tipo_habitacion, nro_habitacion
END
GO