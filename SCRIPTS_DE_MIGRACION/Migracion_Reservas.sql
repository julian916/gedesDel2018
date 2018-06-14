insert into [CUATROGDD2018].[Reservas](
			id_reserva
			,id_persona
			,id_regimen
			,fecha_inicio
			,fecha_hasta
			,id_estado_reserva)
SELECT Reserva_Codigo as id_reserva
		,id_persona
		,id_regimen
		,Reserva_Fecha_Inicio as fecha_inicio
		,DATEADD(day,Reserva_Cant_Noches,Reserva_Fecha_Inicio) as  fecha_hasta
		, 1 as id_estado_reserva
FROM gd_esquema.Maestra
inner join [CUATROGDD2018].Personas per
on Cliente_Pasaporte_Nro=per.nro_documento and Cliente_Mail=per.email
inner join  [CUATROGDD2018].Regimenes_Estadia re
on Regimen_Descripcion=re.descripcion
WHERE Reserva_Codigo is not null
GROUP BY Reserva_Codigo,id_persona,id_regimen,Reserva_Fecha_Inicio,DATEADD(day,Reserva_Cant_Noches,Reserva_Fecha_Inicio)
order by Reserva_Codigo