IF OBJECT_ID('CUATROGDD2018.CalcularMontoTotalFactura') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.CalcularMontoTotalFactura
GO
CREATE PROCEDURE CUATROGDD2018.CalcularMontoTotalFactura  
	@idEstadia int
AS
BEGIN
	declare @precioEstadia numeric(18,2)
		   ,@recarga numeric(18,2)
		   ,@consumibles numeric(18,2)
		   ,@costoTotal numeric (18,2)
		   ,@idRegimen int

	select @precioEstadia= [CUATROGDD2018].[Fn_DarCostoXNoche](r.id_regimen,h.id_tipo_habitacion)*e.cant_noches
		  ,@idRegimen = r.id_regimen
	from [CUATROGDD2018].[Estadias] e
	inner join [CUATROGDD2018].[Habitaciones] h
	on e.id_habitacion=h.id_habitacion
	inner join [CUATROGDD2018].[Reservas] r
	on e.id_reserva=r.id_reserva
	where e.id_estadia=@idEstadia

	select @recarga= [CUATROGDD2018].[Fn_DarRecargaHotel](ho.id_hotel)
	from [CUATROGDD2018].[Estadias] e
	inner join [CUATROGDD2018].[Habitaciones] ha
	on e.id_habitacion=ha.id_habitacion
	inner join [CUATROGDD2018].[Hoteles] ho
	on ha.id_hotel=ho.id_hotel
	where e.id_estadia=@idEstadia

	select @consumibles= SUM(cxe.monto)
	from [CUATROGDD2018].[Estadias] e
	inner join [CUATROGDD2018].[Consumible_X_Estadia] cxe
	on e.id_estadia=cxe.id_estadia
	where e.id_estadia=@idEstadia
	group by cxe.id_estadia

	if @idRegimen=1
		begin
			set @costoTotal=@precioEstadia+@recarga;
		end
	else 
		begin
			set @costoTotal=@precioEstadia+@recarga+@consumibles;
		end
	select @costoTotal as Total
END
GO