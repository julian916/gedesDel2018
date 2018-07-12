IF OBJECT_ID('CUATROGDD2018.SP_DarHabitacionesDisponibles') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_DarHabitacionesDisponibles
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_DarHabitacionesDisponibles] 
	@idhotel int,
	@idTipoHab int,
	@fechaInicio date,
	@fechaFin date
AS
BEGIN

if @idTipoHab !=0
 begin
	SELECT ha.id_habitacion
		  ,ha.piso
		  ,ha.nro_habitacion
		  ,case when ha.frente='S' then 'Al frente' else 'Interno' end as ubicacion 
		  ,ha.comodidades
		  ,th.descripcion as tipo_habitacion
	FROM [CUATROGDD2018].[Hoteles] h
	inner join [CUATROGDD2018].[Regimen_X_Hotel] rxh on h.id_hotel=rxh.id_hotel and rxh.id_hotel=@idhotel
	inner join [CUATROGDD2018].[Regimenes_Estadia] re on rxh.id_regimen=re.id_regimen
	inner join [CUATROGDD2018].[Habitaciones]  ha on h.id_hotel=ha.id_hotel and h.id_hotel=@idhotel and ha.id_tipo_habitacion=@idTipoHab
	inner join [CUATROGDD2018].[Tipo_Habitacion] th on ha.id_tipo_habitacion=th.id_tipo_habitacion
	WHERE not exists (select 1 FROM [CUATROGDD2018].[Habitacion_X_Reserva] hxr 
					  INNER JOIN [CUATROGDD2018].[Reservas] r
					  ON r.[id_reserva] = hxr.[id_reserva]
					  WHERE hxr.id_habitacion = ha.id_habitacion 
					  and (r.[id_estado_reserva] = 1 or r.[id_estado_reserva] = 2 or r.[id_estado_reserva] = 7)
					  /*Estados de reserva:
					  1: Reserva correcta
					  2: Reserva modificada
					  7: Reserva con ingreso, en curso*/
					  and ((@fechaInicio BETWEEN r.fecha_desde and r.fecha_hasta) and (@fechaFin BETWEEN r.fecha_desde and r.fecha_hasta))
					  )
	and not exists (select 1 from [CUATROGDD2018].[Estadias] e
					where ha.id_habitacion=e.id_habitacion 
					and e.id_usuario_checkOut is null
					and ((@fechaInicio BETWEEN e.fecha_inicio and e.fecha_inicio+e.cant_noches) and (@fechaFin BETWEEN  e.fecha_inicio and e.fecha_inicio+e.cant_noches))
					)
	and not exists (select 1 from [CUATROGDD2018].[Historial_Cierres] hc
					where h.id_hotel=hc.id_hotel 
					and hc.fecha_hasta is null
					and ((@fechaInicio BETWEEN hc.fecha_desde and hc.fecha_desde+hc.cant_diasBaja) and (@fechaFin BETWEEN  hc.fecha_desde and hc.fecha_desde+hc.cant_diasBaja))
					)
	and ha.habilitado='True'
	order by ha.piso,ha.nro_habitacion
 end
else 
 begin
	SELECT ha.id_habitacion
		  ,ha.piso
		  ,ha.nro_habitacion
		  ,case when ha.frente='S' then 'Al frente' else 'Interno' end as ubicacion 
		  ,ha.comodidades
		  ,th.descripcion as tipo_habitacion	
	FROM [CUATROGDD2018].[Hoteles] h
	inner join [CUATROGDD2018].[Regimen_X_Hotel] rxh on h.id_hotel=rxh.id_hotel and rxh.id_hotel=@idhotel
	inner join [CUATROGDD2018].[Regimenes_Estadia] re on rxh.id_regimen=re.id_regimen
	inner join [CUATROGDD2018].[Habitaciones]  ha on h.id_hotel=ha.id_hotel and h.id_hotel=@idhotel 
	inner join [CUATROGDD2018].[Tipo_Habitacion] th on ha.id_tipo_habitacion=th.id_tipo_habitacion
	WHERE not exists (select 1 FROM [CUATROGDD2018].[Habitacion_X_Reserva] hxr 
					  INNER JOIN [CUATROGDD2018].[Reservas] r
					  ON r.[id_reserva] = hxr.[id_reserva]
					  WHERE hxr.id_habitacion = ha.id_habitacion 
					  and (r.[id_estado_reserva] = 1 or r.[id_estado_reserva] = 2 or r.[id_estado_reserva] = 7)
					  /*Estados de reserva:
					  1: Reserva correcta
					  2: Reserva modificada
					  7: Reserva con ingreso, en curso*/
					  and ((@fechaInicio BETWEEN r.fecha_desde and r.fecha_hasta) and (@fechaFin BETWEEN r.fecha_desde and r.fecha_hasta))
					  )
	and not exists (select 1 from [CUATROGDD2018].[Estadias] e
					where ha.id_habitacion=e.id_habitacion 
					and e.id_usuario_checkOut is null
					and ((@fechaInicio BETWEEN e.fecha_inicio and e.fecha_inicio+e.cant_noches) and (@fechaFin BETWEEN  e.fecha_inicio and e.fecha_inicio+e.cant_noches))
					)
	and not exists (select 1 from [CUATROGDD2018].[Historial_Cierres] hc
					where h.id_hotel=hc.id_hotel 
					and hc.fecha_hasta is null
					and ((@fechaInicio BETWEEN hc.fecha_desde and hc.fecha_desde+hc.cant_diasBaja) and (@fechaFin BETWEEN  hc.fecha_desde and hc.fecha_desde+hc.cant_diasBaja))
					)
	and ha.habilitado='True'
	order by ha.piso,ha.nro_habitacion
 end
END

