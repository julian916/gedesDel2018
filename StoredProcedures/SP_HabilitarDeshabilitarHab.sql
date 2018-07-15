IF OBJECT_ID('CUATROGDD2018.SP_HabilitarDeshabilitarHab') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_HabilitarDeshabilitarHab
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_HabilitarDeshabilitarHab]
	@idHabitacion int
AS
BEGIN
	DECLARE @MENSAJE varchar(255);
	--Volver a habilitar habitacion
	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Habitaciones] WHERE id_habitacion=@idHabitacion AND habilitado='False')
	BEGIN
		UPDATE [CUATROGDD2018].[Habitaciones] 
		SET [habilitado]='True'
		WHERE id_habitacion = @idHabitacion
	
		SET @MENSAJE=''
		SELECT @MENSAJE
		RETURN
	END
	--Inhabilitar habitacion
	ELSE IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Habitaciones]
					WHERE id_habitacion=@idHabitacion AND habilitado='True'
					AND (EXISTS (SELECT 1 
								FROM [CUATROGDD2018].[Habitacion_X_Reserva] hxr
								INNER JOIN [CUATROGDD2018].[Reservas] r 
								ON hxr.id_habitacion=@idHabitacion
								and hxr.id_reserva=r.id_reserva
								where r.fecha_desde>=GETDATE())
					OR EXISTS (SELECT 1 
								FROM [CUATROGDD2018].[Estadias] e
								WHERE e.id_habitacion=@idHabitacion and e.id_usuario_checkOut is null))
					)
	BEGIN
		SET @MENSAJE='No puede inhabilitarse. Existe Reserva/Estadía en esa habitacion'
		SELECT @MENSAJE
		RETURN
	END
	ELSE 
	BEGIN
		UPDATE [CUATROGDD2018].[Habitaciones] 
		SET [habilitado]='False'
		WHERE id_habitacion = @idHabitacion

		SET @MENSAJE=''
		SELECT @MENSAJE
		RETURN
	END
END
GO