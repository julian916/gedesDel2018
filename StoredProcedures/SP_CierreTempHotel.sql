IF OBJECT_ID('CUATROGDD2018.SP_CierreTempHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_CierreTempHotel
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_CierreTempHotel](	
	@id_hotel int,
	@fechaInicio datetime,
	@diasCierre int,
	@comentario nvarchar(255)
)
AS
BEGIN
	DECLARE @MENSAJE varchar(255),@fechaHasta date;
	set @fechaHasta = @fechaInicio+@diasCierre;

	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Reservas] 
					   WHERE (@fechaInicio BETWEEN [fecha_desde] AND [fecha_hasta]) 
					   or (@fechaHasta BETWEEN [fecha_desde] AND [fecha_hasta]))
			OR EXISTS (SELECT 1 FROM [CUATROGDD2018].[Estadias] 
						WHERE (@fechaInicio BETWEEN [fecha_inicio] AND ([fecha_inicio]+[cant_noches]))
						or (@fechaHasta BETWEEN [fecha_inicio] AND ([fecha_inicio]+[cant_noches])))
			BEGIN
				SET @MENSAJE='El hotel no se podrá cerrar en la fecha seleccionada. Existen Reservas/Estadias en ese periodo'
				SELECT @MENSAJE
				RETURN
			END
	ELSE
			BEGIN

				INSERT [CUATROGDD2018].[Historial_Cierres](
						[id_hotel],[fecha_desde],[detalle_cierre],[cant_diasBaja],[fecha_hasta])
				VALUES (@id_hotel,@fechaInicio,@comentario,@diasCierre,@fechaHasta)

				SET @MENSAJE=''
				SELECT @MENSAJE
				RETURN
			END
END
GO