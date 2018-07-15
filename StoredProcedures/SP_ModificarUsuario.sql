IF OBJECT_ID('CUATROGDD2018.SP_ModificarUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ModificarUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarUsuario] @user varchar(255), @pass varchar(255), @idUsuario int
AS
BEGIN
	UPDATE CUATROGDD2018.Usuarios
	SET username=@user,
	password=@pass
	WHERE id_usuario=@idUsuario
	
END
GO