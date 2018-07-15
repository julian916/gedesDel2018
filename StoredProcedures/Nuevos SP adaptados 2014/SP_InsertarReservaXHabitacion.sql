CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarReservaXHabitacion]
	@idReserva int,
	@idHab int
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Habitacion_X_Reserva] (id_habitacion,id_reserva)
	VALUES (@idHab,@idReserva)
END
GO