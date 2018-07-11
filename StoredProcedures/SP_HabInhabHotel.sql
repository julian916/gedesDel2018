CREATE PROCEDURE [CUATROGDD2018].[SP_HabInhabHotel]
(	
	@id_hotel int,
	@fechaInicio datetime,
	@diasCierre int,
	@comentario nvarchar(255)
)
AS
BEGIN
	DECLARE @MENSAJE varchar(255),@fechaHasta date;
	set @fechaHasta = @fechaInicio+@diasCierre;

	IF @comentario != NULL
		BEGIN
			IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Reservas] 
					   WHERE (@fechaInicio BETWEEN [fecha_desde] AND [fecha_hasta]) 
					   or (@fechaHasta BETWEEN [fecha_desde] AND [fecha_hasta]))
			OR EXISTS (SELECT 1 FROM [CUATROGDD2018].[Estadias] 
						WHERE (@fechaInicio BETWEEN [fecha_inicio] AND ([fecha_inicio]+[cant_noches]))
						or (@fechaHasta BETWEEN [fecha_inicio] AND ([fecha_inicio]+[cant_noches])))
			BEGIN
				SET @MENSAJE='El hotel no se podrá cerrar entre las fechas '++@fechaInicio++' y '++@fechaHasta++'. Existen Reservas/Estadias en ese periodo'
				SELECT @MENSAJE
				RETURN
			END
			ELSE
			BEGIN
				--Inhabilitar hotel
				UPDATE [CUATROGDD2018].[Hoteles]
				SET [habilitado]='False'
				WHERE [id_hotel]=@id_hotel;

				INSERT [CUATROGDD2018].[Historial_Cierres](
						[id_hotel],[fecha_desde],[detalle_cierre],[dias_cierre])
				VALUES (@id_hotel,@fechaInicio,@comentario,@diasCierre)

				SET @MENSAJE=''
				SELECT @MENSAJE
				RETURN
			END
		END
	ELSE
	BEGIN
			--Habilitar hotel
			UPDATE [CUATROGDD2018].[Hoteles]
			SET [habilitado]='True'
			FROM [CUATROGDD2018].[Hoteles] H
			inner join [CUATROGDD2018].[Historial_Cierres] HC
			on H.[id_hotel]=HC.[id_hotel] AND H.[id_hotel]=@id_hotel
			WHERE [fecha_hasta] is null;

			UPDATE [CUATROGDD2018].[Historial_Cierres]
			SET [fecha_hasta]=GETDATE()
			FROM [CUATROGDD2018].[Historial_Cierres] HC
			inner join [CUATROGDD2018].[Hoteles] H
			on HC.[id_hotel]=H.[id_hotel] and HC.[id_hotel]=@id_hotel
			WHERE [fecha_hasta] is null;

			SET @MENSAJE=''
			SELECT @MENSAJE
			RETURN
	END
END