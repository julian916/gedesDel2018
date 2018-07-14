IF OBJECT_ID('CUATROGDD2018.SP_CancelarReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_CancelarReserva
GO
CREATE PROCEDURE CUATROGDD2018.SP_CancelarReserva(
	 @idReserva int
	,@idUsuario int
	,@fecha date
	,@motivo varchar(max))
AS 
BEGIN
	INSERT INTO [CUATROGDD2018].[Reservas_Canceladas]([id_reserva],[id_usuario],[fecha],[motivo])
	VALUES (@idReserva, @idUsuario, @fecha, @motivo)

	IF @idUsuario = 'GUEST'
		BEGIN
			UPDATE [CUATROGDD2018].[Reservas]
			SET id_usuario_reserva=@idUsuario
				,[id_estado_reserva]=4--Reserva cancelada por Cliente
			WHERE id_reserva=@idReserva
		END
	ELSE
		BEGIN
			UPDATE [CUATROGDD2018].[Reservas]
			SET id_usuario_reserva=@idUsuario
				,[id_estado_reserva]=3--Reserva cancelada por Recepcion
			WHERE id_reserva=@idReserva
		END
END
GO