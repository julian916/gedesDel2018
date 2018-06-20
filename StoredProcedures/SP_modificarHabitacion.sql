CREATE PROCEDURE [CUATROGDD2018].[SP_modificarHabitacion] @idHab int, @piso numeric(18, 0), @nroHab numeric(18, 0), 
				@frente nvarchar(50), @comodidades varchar(255)
AS
	UPDATE [CUATROGDD2018].[Habitaciones]
	SET piso= @piso, nro_habitacion=@nroHab,  frente= @frente, comodidades=@comodidades 
	WHERE id_habitacion= @idHab

GO