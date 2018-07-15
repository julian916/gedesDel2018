IF OBJECT_ID('CUATROGDD2018.SP_BuscaReservaPorId') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_BuscaReservaPorId
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_BuscaReservaPorId] 
	@idReserva int
AS
BEGIN
	SELECT distinct r.*,h.id_hotel 
	FROM [CUATROGDD2018].[Reservas] r
	INNER JOIN [CUATROGDD2018].[Habitacion_X_Reserva] hxr
	ON r.id_reserva=hxr.id_reserva
	INNER JOIN [CUATROGDD2018].[Habitaciones] h
	ON hxr.id_habitacion=h.id_habitacion
	WHERE r.id_reserva=@idReserva
END
