/*ELIMINAR RESERVA POR HABITACION*/
IF OBJECT_ID('CUATROGDD2018.SP_QuitarReservaPorHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_QuitarReservaPorHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_QuitarReservaPorHabitacion] (
		@idReserva int,
		@idHabitacion int)
as
BEGIN
	INSERT INTO [CUATROGDD2018].[Habitacion_X_Reserva]([id_habitacion],[id_reserva])
	VALUES (@idHabitacion,@idReserva)
END
GO
/*INSERTAR RESERVA POR HABITACION*/
IF OBJECT_ID('CUATROGDD2018.SP_InsertarReservaPorHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_InsertarReservaPorHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarReservaPorHabitacion] (
		@idReserva int,
		@idHabitacion int)
as
BEGIN
	DELETE [CUATROGDD2018].[Habitacion_X_Reserva]
	WHERE [id_habitacion]=@idHabitacion AND [id_reserva]=@idReserva
END
GO