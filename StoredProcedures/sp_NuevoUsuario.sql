USE GD1C2018
GO
IF OBJECT_ID('dbo.sp_altaUsuario', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_altaUsuario
GO
CREATE PROCEDURE dbo.sp_altaUsuario @usuario varchar(255), @contras varchar(255), @idRol int, @idHotel int
AS
	
	INSERT INTO dbo.Usuarios (username, password)
	SELECT @usuario,HASHBYTES('SHA2_256', @contras)
	WHERE (NOT EXISTS (SELECT * FROM dbo.Usuarios WHERE username = @usuario))  
		  /*AND (NOT EXISTS (SELECT * FROM dbo.Personas WHERE email = @mailUsuario)) */
	DECLARE @nuevoIDUsuario int
	SELECT @nuevoIDUsuario=SCOPE_IDENTITY() FROM Usuarios
	IF @@ROWCOUNT >0 
		BEGIN
			INSERT INTO dbo.Usuario_X_Rol (id_usuario,id_rol)
			VALUES (@nuevoIDUsuario, @idRol)
			INSERT INTO dbo.Usuario_X_Hotel (id_usuario,id_hotel)
			VALUES (@nuevoIDUsuario, @idHotel)
		END
GO