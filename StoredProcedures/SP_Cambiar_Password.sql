IF OBJECT_ID('CUATROGDD2018.SP_Cambiar_Password') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_Cambiar_Password
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