USE [GD1C2018]
GO
/****** Object:  StoredProcedure [CUATROGDD2018].[sp_altaUsuario]    Script Date: 14/6/2018 22:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('CUATROGDD2018.SP_AltaUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_AltaUsuario] @usuario varchar(255), @contras varchar(255),@emailUsu varchar (255),  @idRol int, @idHotel int,@tipoDNI nvarchar(50), @nroDNI numeric(18,0), @idUsu int out
AS
Begin
	INSERT INTO CUATROGDD2018.Usuarios (username, password)
	SELECT @usuario,HASHBYTES('SHA2_256', @contras)
	WHERE NOT EXISTS (SELECT 1 FROM CUATROGDD2018.Usuarios WHERE username = @usuario) 
	  AND NOT EXISTS (SELECT 1 FROM CUATROGDD2018.Personas WHERE email = @emailUsu and tipo_documento=@tipoDNI and nro_documento=@nroDNI)
	SELECT @idUsu=SCOPE_IDENTITY() FROM CUATROGDD2018.Usuarios
	IF @idUsu is not null
		BEGIN
			INSERT INTO CUATROGDD2018.Usuario_X_Hotel_X_Rol (id_usuario,id_rol,id_hotel)
			VALUES (@idUsu, @idRol,@idHotel)
		END
End
