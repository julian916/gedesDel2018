USE GD1C2018
GO

--Funcion Para saber si una fecha pertenece al trimestre seleccionado
IF OBJECT_ID('CUATROGDD2018.fnc_perteneceATrimestre', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.fnc_perteneceATrimestre
GO

CREATE PROCEDURE CUATROGDD2018.fnc_perteneceATrimestre ( @anioConsulta int, @trimestre int , @fechaConsulta datetime)
AS
RETURN BIT
declare @pertenece BIT

@pertenece = CASE WHEN  (@anioConsulta = YEAR(@fechaConsulta) and @trimestre=(MONTH(@fechaConsulta)-1)/4+1) then 0
						ELSE 1
RETURN @pertenece
END


IF OBJECT_ID('CUATROGDD2018.sp_TopHotelesConReservasCanceladas', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.sp_TopHotelesConReservasCanceladas
GO

/*Además el sistema nos pedirá que ingresemos obligatoriamente el año por el cual
queremos consultar, luego nos pedirá el trimestre*/

CREATE PROCEDURE CUATROGDD2018.sp_TopHotelesConReservasCanceladas ( @anioConsulta int, @trimestre int )
AS
	SELECT top 5 calle, nro_calle, ciudad, pais, cant_estrellas, count (*) as "Cantidad reservas canceladas"
	FROM Reservas
	JOIN Habitacion_X_Reserva as HabXRes on HabXRes.id_reserva=Reservas.id_reserva
	JOIN Habitaciones on Habitaciones.id_habitacion=HabXRes=id.Habitacion
	JOIN Hoteles on Habitaciones.id_hotel=Hoteles.id_hotel
	WHERE Reservas.id_estado_reserva in ( 3, 4, 5 ) and  @anioConsulta = YEAR(Reservas.fecha_inicio) and @trimestre=(MONTH(Reservas.fecha_inicio)-1)/4+1
	GROUP BY (id_reserva)
	ORDER BY  count (*) DESC
GO
/*Hoteles con mayor cantidad de consumibles facturados.*/

IF OBJECT_ID('CUATROGDD2018.sp_TopHotelesConsumiblesFacturados', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.sp_TopHotelesConsumiblesFacturados
GO

CREATE PROCEDURE CUATROGDD2018.sp_TopHotelesConsumiblesFacturados ( @anioConsulta int, @trimestre int )
AS
	SELECT top 5 calle, nro_calle, ciudad, pais, cant_estrellas, sum (ConsumXEst.cantidad) as "Cantidad consumibles facturados"
	FROM Facturas
	JOIN Estadias on Facturas.id_Estadia=Estadias.id_Estadia
	JOIN Consumibles_X_Estadias as ConsumXEst on Estadias.id_Estadia=ConsumXEst=id.Estadia
	WHERE @anioConsulta = YEAR(Facturas.fecha) and @trimestre=(MONTH(Facturas.fecha)-1)/4+1
	GROUP BY (id_Estadia)
	ORDER BY sum (ConsumXEst.cantidad) DESC
GO

/*Hoteles con mayor cantidad de días fuera de servicio.*/

IF OBJECT_ID('CUATROGDD2018.sp_TopHotelesDiasSinServ', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.sp_TopHotelesDiasSinServ
GO

CREATE PROCEDURE CUATROGDD2018.sp_TopHotelesDiasSinServ ( @anioConsulta int, @trimestre int )
AS
	SELECT top 5 calle, nro_calle, ciudad, pais, cant_estrellas, sum (DATEDIFF(DAY, Historial.fecha_inicio, Historial.fecha_fin)) as "Cantidad días fuera de servicio"
	FROM Hoteles
	JOIN Historial_Cierres as Historial on Hoteles.id_hotel=Historial.id_hotel
	WHERE @anioConsulta = YEAR(Historial.fecha_inicio) and @trimestre=(MONTH(Historial.fecha_inicio)-1)/4+1
	GROUP BY (id_hotel)
	ORDER BY sum (DATEDIFF(DAY, Historial.fecha_inicio, Historial.fecha_fin)) DESC
GO

/*Habitaciones con mayor cantidad de días y veces que fueron ocupadas, informando a demás a que hotel pertenecen.*/

IF OBJECT_ID('CUATROGDD2018.sp_TopHabitacionOcupadas', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.sp_TopHabitacionOcupadas
GO

CREATE PROCEDURE CUATROGDD2018.sp_TopHabitacionOcupadas ( @anioConsulta int, @trimestre int )
AS
	SELECT top 5 calle, nro_calle, piso, departamento, count(id_habitacion) as "Cantidas veces ocupado",sum (DATEDIFF(DAY, Est.fecha_inicio, Est.fecha_fin)) as "Cantidad días ocupado"
	FROM Hoteles
	JOIN Habitaciones as Hab on Hab.id_hotel=Hoteles.id_hotel
	JOIN Habitacion_X_Reserva as HabXRes on HabXRes.id_habitacion=Hab.id_habitacion
	JOIN Estadias as Est on Est.id_estadia=HabXRes.id_estadia
	WHERE @anioConsulta = YEAR(Est.fecha_inicio) and @trimestre=(MONTH(Est.fecha_inicio)-1)/4+1
	GROUP BY (id_hotel)
	ORDER BY  count(id_habitacion), sum (DATEDIFF(DAY, Est.fecha_inicio, Est.fecha_fin)) DESC
GO

/*Cliente con mayor cantidad de puntos, donde cada $20 en estadías vale 1
puntos y cada $10 de consumibles es 1 punto, de la sumatoria de todas las
facturaciones que haya tenido dentro de un periodo independientemente
del Hotel. Tener en cuenta que la facturación siempre es a quien haya
realizado la reserva.*/

IF OBJECT_ID('CUATROGDD2018.sp_TopClientesMasPuntos', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.sp_TopClientesMasPuntos
GO

CREATE PROCEDURE CUATROGDD2018.sp_TopClientesMasPuntos ( @anioConsulta int, @trimestre int )
AS
	SELECT top 5 sum(Facturas.puntos_obtenidos) as "Puntos acumulados", Pers.nombre, Pers.nro_documento
	FROM Facturas as Fact
	JOIN Reservas as Res on Fact.id_reserva = Res.id_reserva
	JOIN Personas as Pers on Res.id_persona=Pers.id_persona
	WHERE @anioConsulta = YEAR(Facturas.fecha_inicio) and @trimestre=(MONTH(Facturas.fecha_inicio)-1)/4+1
	GROUP BY (id_persona)
	ORDER BY sum(Facturas.puntos_obtenidos) DESC
GO
