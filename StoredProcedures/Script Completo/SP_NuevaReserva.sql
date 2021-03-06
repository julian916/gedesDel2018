IF OBJECT_ID('CUATROGDD2018.SP_NuevaReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_NuevaReserva
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_NuevaReserva]
	@idPersona int,
	@idRegimen int,
	@fechaReserva date,
	@fechaDesde date,
	@fechaHasta date,
	@cantNoches int,
	@idUsu int
	
AS
BEGIN
	declare @idSig int
	select @idSig=MAX(id_reserva)+1 from [CUATROGDD2018].[Reservas]

	INSERT INTO [CUATROGDD2018].[Reservas]([id_reserva],id_persona,id_regimen,id_estado_reserva,fecha_reserva,fecha_desde,fecha_hasta,cantidad_noches,[id_usuario_reserva])
	VALUES (@idSig,@idPersona,@idRegimen,1,@fechaReserva,@fechaDesde,@fechaHasta,@cantNoches,@idUsu)
	-- estado 1= reserva correcta
	SELECT @idSig
END
GO

