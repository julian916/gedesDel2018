CREATE PROCEDURE [CUATROGDD2018].[SP_HabInhabHotel]
(	
	@id_hotel int,
	@comentario nvarchar(255)
)
AS
BEGIN
IF @comentario != NULL
BEGIN
		--Inhabilitar hotel
		UPDATE [CUATROGDD2018].[Hoteles]
		SET [habilitado]='False'
		WHERE [id_hotel]=@id_hotel;

		INSERT [CUATROGDD2018].[Historial_Cierres](
				[id_hotel],[fecha_desde],[detalle_cierre])
		VALUES (@id_hotel,GETDATE(),@comentario);
END
ELSE
BEGIN
		--Habilitar hotel
		UPDATE [CUATROGDD2018].[Hoteles]
		SET [habilitado]='False'
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
END
END