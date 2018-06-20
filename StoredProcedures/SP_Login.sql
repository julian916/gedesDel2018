USE GD1C2018
GO
IF OBJECT_ID('CUATROGDD2018.sp_Login', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.sp_Login
GO
CREATE PROCEDURE CUATROGDD2018.sp_Login @usuario varchar(255), @contras varchar(255), @idUsuario int out
AS
	SELECT @idUsuario=Usu.id_usuario 
	FROM CUATROGDD2018.Usuarios as Usu
	WHERE Usu.username=@usuario AND Usu.password=HASHBYTES('SHA2_256', @contras)
	
	SELECT id_hotel,id_usuario
	FROM CUATROGDD2018.Usuario_X_Hotel_X_Rol as UxHxR
	WHERE UxHxR.id_usuario=@idUsuario
GO
