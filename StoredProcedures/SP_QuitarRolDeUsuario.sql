IF OBJECT_ID('CUATROGDD2018.SP_QuitarRolDeUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_QuitarRolDeUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_QuitarRolDeUsuario] (@idRol int, @idUsuario int)
AS
Begin
	Delete [CUATROGDD2018].[Usuario_X_Hotel_X_Rol]
	where [id_usuario]=@idUsuario and [id_rol]=@idRol
End
