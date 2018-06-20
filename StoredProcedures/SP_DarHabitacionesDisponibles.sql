alter PROCEDURE [CUATROGDD2018].[SP_DarHabitacionesDisponibles] 
	@idhotel int,
	@idRegimen int,
	@fechaInicio date,
	@fechaFin date
AS
BEGIN

	SELECT ha.id_habitacion
		  ,th.descripcion +case when ha.frente='S' then ' Al frente' else ' Interno' end +
		  '. Precio base $'+
		  cast([CUATROGDD2018].[FN_DarCostoXNoche](@idRegimen,ha.id_tipo_habitacion)+[CUATROGDD2018].[FN_DarRecargaHotel](h.id_hotel) as varchar(10)) as [Descripacion de habitacion]
	FROM [CUATROGDD2018].[Hoteles] h
	inner join [CUATROGDD2018].[Regimen_X_Hotel] rxh on h.id_hotel=rxh.id_hotel and rxh.id_hotel=@idhotel
	inner join [CUATROGDD2018].[Regimenes_Estadia] re on rxh.id_regimen=re.id_regimen and re.id_regimen=@idRegimen
	inner join [CUATROGDD2018].[Habitaciones]  ha on h.id_hotel=ha.id_hotel and h.id_hotel=@idhotel 
	inner join [CUATROGDD2018].[Tipo_Habitacion] th on ha.id_tipo_habitacion=th.id_tipo_habitacion
	WHERE (
			SELECT COUNT(1)
			FROM [CUATROGDD2018].[Habitacion_X_Reserva] hxr 
			INNER JOIN [CUATROGDD2018].[Reservas] r
			ON r.[id_reserva] = hxr.[id_reserva]
			WHERE hxr.id_habitacion = ha.id_habitacion and 
				r.[id_estado_reserva] != 1 and R.[id_estado_reserva] != 2 and R.[id_estado_reserva] != 7 and 
				r.[fecha_desde] BETWEEN @fechaInicio AND @fechaFin
			) = 0 and
	
		 ( 
			SELECT COUNT(1)
			FROM [CUATROGDD2018].[Historial_Cierres] hc
			WHERE h.id_hotel=hc.id_hotel and 
				  hc.[fecha_desde] BETWEEN @fechaInicio AND @fechaFin
			) = 0
	order by [Descripacion de habitacion]
END