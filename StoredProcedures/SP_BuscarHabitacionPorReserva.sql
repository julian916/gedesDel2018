IF OBJECT_ID('CUATROGDD2018.SP_BuscarHabitacionPorReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_BuscarHabitacionPorReserva
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_BuscarHabitacionPorReserva] (@idReserva int)
AS
BEGIN
	SELECT h.*, th.descripcion
	FROM [CUATROGDD2018].[Reservas] r
	INNER JOIN [CUATROGDD2018].[Habitacion_X_Reserva] hxr
	ON r.id_reserva=hxr.id_reserva
	INNER JOIN [CUATROGDD2018].[Habitaciones] h
	ON hxr.id_habitacion=h.id_habitacion
	INNER JOIN [CUATROGDD2018].[Tipo_Habitacion] th
	ON h.id_tipo_habitacion=th.id_tipo_habitacion
	where r.id_reserva=@idReserva
END
GO