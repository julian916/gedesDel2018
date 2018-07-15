IF OBJECT_ID('CUATROGDD2018.SP_NuevaReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_NuevaReserva
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_NuevaReserva]
	@idPersona int,
	@idRegimen int,
	@fechaReserva date,
	@fechaDesde date,
	@fechaHasta date,
	@cantNoches int
	
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Reservas](id_persona,id_regimen,id_estado_reserva,fecha_reserva,fecha_desde,fecha_hasta,cantidad_noches)
	VALUES (@idPersona,@idRegimen,1,@fechaReserva,@fechaDesde,@fechaHasta,@cantNoches)
	-- estado 1= reserva correcta
	DECLARE @idNuevaReserva int
	SET @idNuevaReserva = @@IDENTITY
	
	SELECT @idNuevaReserva
END
GO

