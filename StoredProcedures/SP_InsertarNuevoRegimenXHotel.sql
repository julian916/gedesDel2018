IF OBJECT_ID('CUATROGDD2018.SP_InsertarNuevoRegimenXHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_InsertarNuevoRegimenXHotel
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarNuevoRegimenXHotel]
	@idHotel int,
	@idRegimen int
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Regimen_X_Hotel](id_hotel,id_regimen)
	VALUES(@idHotel,@idRegimen)
END
GO