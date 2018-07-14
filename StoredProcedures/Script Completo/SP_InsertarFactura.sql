IF OBJECT_ID('CUATROGDD2018.SP_InsertarFactura') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_InsertarFactura
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarFactura] 
		@fecha datetime
		,@precioTotal numeric(18,2)
		,@idEstadia int
		,@idPersona int
		,@idPago int
AS
Begin
	declare @idSig numeric(18,0),@puntos int
	select @idSig=max([nro_factura])+1 from [CUATROGDD2018].[Facturas]

	select @puntos= [CUATROGDD2018].[Fn_DarPuntos](th.porcentual,re.precio_base,1,e.cant_noches)
	from [CUATROGDD2018].[Estadias] e
	inner join [CUATROGDD2018].[Habitaciones] h
	on e.id_habitacion=h.id_habitacion
	inner join [CUATROGDD2018].[Tipo_Habitacion] th
	on h.id_tipo_habitacion=th.id_tipo_habitacion
	inner join [CUATROGDD2018].[Reservas] r
	on e.id_reserva=r.id_reserva
	inner join [CUATROGDD2018].[Regimenes_Estadia] re
	on r.id_regimen=re.id_regimen
	where e.id_estadia=@idEstadia

	Insert into [CUATROGDD2018].[Facturas]([nro_factura],[fecha],[precio_total],[puntos_obtenidos],[id_estadia],[id_persona],[id_forma_depago])
	Values (@idSig,@fecha,@precioTotal,@puntos,@idEstadia,@idPersona,@idPago)

	select @idSig
End
GO

