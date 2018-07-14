IF OBJECT_ID('CUATROGDD2018.SP_DarEstadiaPorCodReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_DarEstadiaPorCodReserva
GO
CREATE PROCEDURE CUATROGDD2018.SP_DarEstadiaPorCodReserva  
	@idReserva int
AS
BEGIN
	select [id_estadia]
		  ,[fecha_inicio]
		  ,case when [cant_noches] is null then 0
		   else [cant_noches] end as [cant_noches]
		  ,[id_usuario_checkIn]
		  ,case when [id_usuario_checkOut] is null then 0 
		   else [id_usuario_checkOut] end as [id_usuario_checkOut]
		  ,[id_habitacion]
		  ,[id_reserva]
	from [CUATROGDD2018].[Estadias]
	where id_reserva=@idReserva

END
GO

