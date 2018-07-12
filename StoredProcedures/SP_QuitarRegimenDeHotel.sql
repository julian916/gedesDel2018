CREATE PROCEDURE [CUATROGDD2018].[SP_QuitarRegimenDeHotel]
(	
	@id_hotel int,
	@idRegimen int
)
AS
BEGIN

	update [CUATROGDD2018].[Regimen_X_Hotel]
	set [habilitado]='False'
	where [id_regimen]=@idRegimen and [id_hotel]=@id_hotel
END