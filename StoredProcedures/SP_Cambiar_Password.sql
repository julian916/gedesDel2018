USE [GD1C2018]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_Cambiar_Password]
	@idUsuario int,
	@newPassHash varchar(255)
AS
BEGIN
	UPDATE CUATROGDD2018.Usuarios
	SET password=@newPassHash
	WHERE id_usuario=@idUsuario
END
GO