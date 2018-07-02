USE [GD1C2018]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_ValidarDatosPersona] @tipoDNI nvarchar(50),@nroDNI numeric(18,0),@emailPer nvarchar (255)
AS
BEGIN
	DECLARE @esValido bit
	SET @esValido='True'
	IF EXISTS (SELECT * FROM CUATROGDD2018.Personas WHERE (tipo_documento = @tipoDNI AND nro_documento=@nroDNI) OR email = @emailPer)
			SET @esValido = 'False'
	SELECT @esValido
END