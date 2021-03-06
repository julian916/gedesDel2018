IF OBJECT_ID('CUATROGDD2018.SP_GetRegimenPorHotel_DeIdHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetRegimenPorHotel_DeIdHotel
GO
Create PROCEDURE [CUATROGDD2018].[SP_GetRegimenPorHotel_DeIdHotel]
	@idHotel int
AS
BEGIN
	SELECT R.id_regimen, R.descripcion, R.precio_base,RH.habilitado
	FROM [CUATROGDD2018].[Regimenes_Estadia] R 
	JOIN [CUATROGDD2018].[Regimen_X_Hotel] RH ON (RH.id_regimen= R.id_regimen)
	WHERE RH.id_hotel = @idHotel and RH.habilitado='True'
	GROUP BY R.id_regimen, R.descripcion, R.precio_base,RH.habilitado
END
GO
