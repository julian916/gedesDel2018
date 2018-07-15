IF OBJECT_ID('CUATROGDD2018.SP_DarIdHotelPorIdReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_DarIdHotelPorIdReserva
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_DarIdHotelPorIdReserva]
	@idReserva int
AS
BEGIN
	select h.id_hotel
	from [CUATROGDD2018].[Reservas] r
	inner join [CUATROGDD2018].[Habitacion_X_Reserva] hxr
	on r.id_reserva=hxr.id_reserva
	inner join [CUATROGDD2018].[Habitaciones] h
	on hxr.id_habitacion=h.id_habitacion
	where r.id_reserva=@idReserva

END
GO