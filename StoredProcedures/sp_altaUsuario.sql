USE [GD1C2018]
GO
/****** Object:  StoredProcedure [dbo].[sp_altaUsuario]    Script Date: 14/6/2018 22:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_altaUsuario] @usuario varchar(255), @contras varchar(255),@emailUsu varchar (255),  @idRol int, @idHotel int
AS
	INSERT INTO dbo.Usuarios (username, password)
	SELECT @usuario,HASHBYTES('SHA2_256', @contras)
	WHERE (NOT EXISTS (SELECT * FROM dbo.Usuarios WHERE username = @usuario))  
		  AND (NOT EXISTS (SELECT * FROM dbo.Personas WHERE email = @emailUsu))
	DECLARE @nuevoIDUsuario int
	SELECT @nuevoIDUsuario=SCOPE_IDENTITY() FROM Usuarios
	IF @nuevoIDUsuario is not null
		BEGIN
			INSERT INTO dbo.Usuario_X_Rol (id_usuario,id_rol)
			VALUES (@nuevoIDUsuario, @idRol)
			INSERT INTO dbo.Usuario_X_Hotel (id_usuario,id_hotel)
			VALUES (@nuevoIDUsuario, @idHotel)
		END
	SELECT @nuevoIDUsuario;