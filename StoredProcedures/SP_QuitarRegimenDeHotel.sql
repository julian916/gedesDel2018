CREATE PROCEDURE [CUATROGDD2018].[SP_QuitarRegimenDeHotel]
(	
	@id_hotel int,
	@descRegimen nvarchar(255)
)
AS
BEGIN
	declare @idRegimen int;

	select @idRegimen=[id_regimen]
	from [CUATROGDD2018].[Regimenes_Estadia]
	where [descripcion]=@descRegimen

	update [CUATROGDD2018].[Regimen_X_Hotel]
	set [habilitado]='False'
	where [id_regimen]=@idRegimen and [id_hotel]=@id_hotel
END