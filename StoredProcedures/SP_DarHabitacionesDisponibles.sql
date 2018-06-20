CREATE PROCEDURE [CUATROGDD2018].[DarHabitacionesDisponibles] 
	@idhotel int,
	@idTipoHab int,
	@fechaInicio date,
	@fechaFin date
AS
BEGIN
	
	--set @idTipoHab= 1001;
	--set @fechaInicio='2018-06-30';
	--set @fechaFin='2018-07-30';
	--set @idhotel=4;

if @idTipoHab is not null
	SELECT h.ciudad as [Ciudad]
		  ,h.calle as [Direccion]
		  ,h.nro_calle as [Numero]
		  ,h.cant_estrellas as [Holel estrellas]
		  ,ha.piso as [Piso de Habitacion]
		  ,case when ha.frente='S' then 'Al frente' else 'Interno' end as [Ubicacion de Habitacion] 
		  ,th.descripcion as [Tipo de Habitacion]
		  ,re.descripcion as [Regimen]
		  ,[CUATROGDD2018].[DarCostoXNoche](rxh.id_regimen,ha.id_tipo_habitacion)+[CUATROGDD2018].[DarRecargaHotel](h.id_hotel) as [Precion por noche]
	FROM [CUATROGDD2018].[Hoteles] h
	inner join [CUATROGDD2018].[Regimen_X_Hotel] rxh on h.id_hotel=rxh.id_hotel and rxh.id_hotel=@idhotel
	inner join [CUATROGDD2018].[Regimenes_Estadia] re on rxh.id_regimen=re.id_regimen
	inner join [CUATROGDD2018].[Habitaciones]  ha on h.id_hotel=ha.id_hotel and h.id_hotel=@idhotel and ha.id_tipo_habitacion=@idTipoHab
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
	order by h.ciudad,h.calle,h.nro_calle,h.cant_estrellas,ha.piso,th.descripcion,re.descripcion
else 
	SELECT h.ciudad as [Ciudad]
		  ,h.calle as [Direccion]
		  ,h.nro_calle as [Numero]
		  ,h.cant_estrellas as [Holel estrellas]
		  ,ha.piso as [Piso de Habitacion]
		  ,case when ha.frente='S' then 'Al frente' else 'Interno' end as [Ubicacion de Habitacion] 
		  ,th.descripcion as [Tipo de Habitacion]
		  ,re.descripcion as [Regimen]
		  ,[CUATROGDD2018].[DarCostoXNoche](rxh.id_regimen,ha.id_tipo_habitacion)+[CUATROGDD2018].[DarRecargaHotel](h.id_hotel) as [Precion por noche]
	FROM [CUATROGDD2018].[Hoteles] h
	inner join [CUATROGDD2018].[Regimen_X_Hotel] rxh on h.id_hotel=rxh.id_hotel and rxh.id_hotel=@idhotel
	inner join [CUATROGDD2018].[Regimenes_Estadia] re on rxh.id_regimen=re.id_regimen
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
	order by h.ciudad,h.calle,h.nro_calle,h.cant_estrellas,ha.piso,th.descripcion,re.descripcion
END