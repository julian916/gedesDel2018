IF OBJECT_ID('CUATROGDD2018.SP_BuscaReservaPorId') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_BuscaReservaPorId
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_BuscaReservaPorId] 
	@idReserva int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Reservas] r
	INNER JOIN [CUATROGDD2018].[Regimenes_Estadia] re
	ON r.id_regimen=re.id_regimen
	WHERE id_reserva=@idReserva
END