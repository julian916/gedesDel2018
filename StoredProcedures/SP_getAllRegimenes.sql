USE [GD1C2018]
GO

IF OBJECT_ID('CUATROGDD2018.SP_getAllRegimenes', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_getAllRegimenes
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_getAllRegimenes] 
AS
	SELECT * FROM CUATROGDD2018.Regimenes_Estadia
GO
