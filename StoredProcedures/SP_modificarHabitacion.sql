IF OBJECT_ID('CUATROGDD2018.SP_ModificarHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ModificarHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarHabitacion] (
		@idHab int
		,@piso numeric(18, 0)
		,@nroHab numeric(18, 0)
		,@frente nvarchar(50)
		,@comodidades varchar(255)
AS
BEGIN
	UPDATE [CUATROGDD2018].[Habitaciones]
	SET piso= @piso, nro_habitacion=@nroHab,  frente= @frente, comodidades=@comodidades 
	WHERE id_habitacion= @idHab
END
GO