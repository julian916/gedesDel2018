USE GD1C2018
GO

IF OBJECT_ID('CUATROGDD2018.FN_PerteneceATrimestre') IS NOT NULL
    DROP FUNCTION CUATROGDD2018.FN_PerteneceATrimestre
GO
--Funcion Para saber si una fecha pertenece al trimestre seleccionado
CREATE FUNCTION CUATROGDD2018.FN_PerteneceATrimestre ( @anio int, @trimestre int , @fecha datetime)
RETURNS bit
AS BEGIN
	DECLARE @pertenece bit

	set @pertenece = CASE WHEN  (@anio = YEAR(@fecha) and @trimestre=DATEPART(QUARTER,@fecha)) then 0
					 ELSE 1
					 END
	RETURN @pertenece
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopHotelesConReservasCanceladas') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopHotelesConReservasCanceladas
GO
/*Además el sistema nos pedirá que ingresemos obligatoriamente el año por el cual
queremos consultar, luego nos pedirá el trimestre*/
CREATE PROCEDURE CUATROGDD2018.SP_TopHotelesConReservasCanceladas ( @anio int, @trimestre int )
AS 
BEGIN
	SELECT top 5 ho.pais
				,ho.nombre as hotel
				,count (1) as [cantidad de reservas canceladas]
	FROM [CUATROGDD2018].[Reservas] r
	JOIN [CUATROGDD2018].[Habitacion_X_Reserva]  hxr 
	on r.id_reserva=hxr.id_reserva
	JOIN [CUATROGDD2018].[Habitaciones] ha
	on hxr.id_habitacion=ha.id_habitacion
	JOIN [CUATROGDD2018].[Hoteles] ho
	on ha.id_hotel=ho.id_hotel
	WHERE r.id_estado_reserva in ( 3, 4, 5 ) and  @anio = YEAR(r.fecha_desde) and @trimestre=DATEPART(QUARTER,r.fecha_desde)
	GROUP BY (ho.nombre)
	ORDER BY  [cantidad de reservas canceladas] DESC
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopHotelesConsumiblesFacturados') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopHotelesConsumiblesFacturados
GO
/*Hoteles con mayor cantidad de consumibles facturados.*/
CREATE PROCEDURE CUATROGDD2018.SP_TopHotelesConsumiblesFacturados (@anio int, @trimestre int )
AS 
BEGIN
	SELECT top 5 ho.pais
				,ho.nombre as hotel
				,sum(cxe.cantidad) as [cantidad de consumibles facturados]
	FROM [CUATROGDD2018].[Facturas] f
	JOIN [CUATROGDD2018].[Estadias] e
	on f.id_estadia=e.id_estadia
	JOIN [CUATROGDD2018].[Consumible_X_Estadia] cxe
	on e.id_estadia=cxe.id_estadia
	JOIN [CUATROGDD2018].[Habitaciones] ha
	on e.id_habitacion=ha.id_habitacion
	JOIN [CUATROGDD2018].[Hoteles] ho
	on ha.id_hotel=ho.id_hotel
	WHERE @anio = YEAR(f.fecha) and @trimestre=DATEPART(QUARTER,f.fecha)
	GROUP BY ho.pais,ho.nombre
	ORDER BY [cantidad de consumibles facturados] DESC
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopHotelesDiasSinServ') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopHotelesDiasSinServ
GO
/*Hoteles con mayor cantidad de días fuera de servicio.*/
CREATE PROCEDURE CUATROGDD2018.SP_TopHotelesDiasSinServ ( @anio int, @trimestre int )
AS
BEGIN
	SELECT top 5 ho.pais
				,ho.nombre as hotel
				,SUM(cie.cant_diasBaja) as [dias fuera de servicio]
	FROM [CUATROGDD2018].[Hoteles] ho
	JOIN [CUATROGDD2018].[Historial_Cierres] cie 
	on ho.id_hotel=cie.id_hotel
	WHERE @anio = YEAR(cie.fecha_desde) and @trimestre=DATEPART(QUARTER,cie.fecha_desde)
	GROUP BY ho.pais,ho.nombre
	ORDER BY [Dias fuera de servicio] DESC
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopHabitacionOcupadas') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopHabitacionOcupadas
GO
/*Habitaciones con mayor cantidad de días y veces que fueron ocupadas, informando a demás a que hotel pertenecen.*/
CREATE PROCEDURE CUATROGDD2018.SP_TopHabitacionOcupadas ( @anio int, @trimestre int )
AS
BEGIN
	SELECT top 5 ho.pais
				,ho.nombre as hotel
				,ha.piso
				,ha.nro_habitacion as [numero]
				,case when ha.frente='N' then 'Al frente' else 'Interno' end as ubicacion
				,th.descripcion as [tipo de habitacion]
				,sum(est.cant_noches) as [cantidad dias ocupado]
				,count(ha.id_habitacion) as [cantidad veces ocupado]
	FROM [CUATROGDD2018].[Habitaciones] ha
	JOIN [CUATROGDD2018].[Tipo_Habitacion] th
	on ha.id_tipo_habitacion=th.id_tipo_habitacion
	JOIN [CUATROGDD2018].[Estadias] est 
	on ha.id_habitacion=est.id_habitacion
	JOIN [CUATROGDD2018].[Hoteles] ho
	on ha.id_hotel=ho.id_hotel
	WHERE @anio = YEAR(est.fecha_inicio) and @trimestre=DATEPART(QUARTER,est.fecha_inicio)
	GROUP BY ho.pais,ho.nombre,ha.piso,ha.nro_habitacion,ha.frente,th.descripcion
	ORDER BY [cantidad dias ocupado] DESC
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopClientesMasPuntos') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopClientesMasPuntos
GO
/*Cliente con mayor cantidad de puntos, donde cada $20 en estadías vale 1
puntos y cada $10 de consumibles es 1 punto, de la sumatoria de todas las
facturaciones que haya tenido dentro de un periodo independientemente
del Hotel. Tener en cuenta que la facturación siempre es a quien haya
realizado la reserva.*/
CREATE PROCEDURE CUATROGDD2018.SP_TopClientesConMasPuntos ( @anio int, @trimestre int )
AS
BEGIN
	SELECT top 5 p.tipo_documento as [tipo documento]
				,p.nro_documento as [numero]
				,p.nombre
				,p.apellido
				,p.email
				,sum(f.puntos_obtenidos) as [puntos acumulados]
	FROM [CUATROGDD2018].[Facturas] f
	JOIN [CUATROGDD2018].[Personas] p 
	on f.id_persona=p.id_persona
	WHERE @anio = YEAR(f.fecha) and @trimestre=DATEPART(QUARTER,f.fecha)
	GROUP BY p.tipo_documento,p.nro_documento,p.nombre,p.apellido,p.email
	ORDER BY [puntos acumulados] DESC
END
GO