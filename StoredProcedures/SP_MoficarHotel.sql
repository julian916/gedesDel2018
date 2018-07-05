CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarHotel]
(	
	@id_hotel int,
	@nombre nvarchar(255),
	@pais nvarchar(255),
	@ciudad nvarchar(255), 
	@calle nvarchar(255),
	@nro_calle numeric(18, 0),
	@cant_estrellas numeric(18, 0),
	@recarga_estrellas numeric(18, 0),
	@email nvarchar(255),
	@telefono numeric(18, 0)
)
AS
BEGIN
	
		UPDATE [CUATROGDD2018].[Hoteles]
		SET [nombre]=@nombre
		   ,[telefono]=@telefono
		   ,[calle]=@calle
		   ,[nro_calle]=@nro_calle
		   ,[ciudad]=@ciudad
		   ,[pais]=@pais
		   ,[cant_estrellas]=@cant_estrellas
		   ,[recarga_estrellas]=@recarga_estrellas
		   ,[email]=@email

		WHERE [id_hotel]=@id_hotel

END
GO