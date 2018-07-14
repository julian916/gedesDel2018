USE [GD1C2018]
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_VerificarUsuario] @usuario varchar(255), @idUsuario int
AS
BEGIN
	DECLARE @esValido bit
	SET @esValido='True'
	IF EXISTS (SELECT 1 FROM CUATROGDD2018.Usuarios WHERE username = @usuario and NOT id_usuario=@idUsuario) 
		SET @esValido='False'
	SELECT @esValido
END
