IF OBJECT_ID('CUATROGDD2018.SP_RegimenEstadia') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_RegimenEstadia
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_RegimenEstadia] 
AS
BEGIN
	select id_regimen, descripcion 
	from [GD1C2018].[Regimenes_Estadia]
END