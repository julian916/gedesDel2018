IF OBJECT_ID('CUATROGDD2018.SP_AltaHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_AltaHabitacion] (
		@idTipoHabitacion int
		,@idHotel int
		,@piso numeric(18, 0)
		,@frente nvarchar(50)
		,@nroHab numeric(18, 0)
		,@comodidades varchar(255)
AS 
BEGIN 
	INSERT INTO [CUATROGDD2018].[Habitaciones] ( id_tipo_habitacion, id_hotel, piso, frente, nro_habitacion, comodidades)
	VALUES ( @idTipoHabitacion, @idHotel, @piso, @frente, @nroHab, @comodidades)
END
GO