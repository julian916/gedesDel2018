USE [GD1C2018]
GO
/****** Object:  StoredProcedure [CUATROGDD2018].[sp_HotelesComboBox]    Script Date: 19/6/2018 14:15:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('CUATROGDD2018.sp_asignarHotelYRolAUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.sp_asignarHotelYRolAUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[sp_asignarHotelYRolAUsuario] @idUsu int, @idRol int, @idHotel int
AS
	INSERT INTO CUATROGDD2018.Usuario_X_Rol (id_usuario, id_rol)
	SELECT @idUsu,@idRol
	WHERE (NOT EXISTS (SELECT * FROM CUATROGDD2018.Usuario_X_Rol WHERE id_usuario = @idUsu and id_rol = @idRol ))
	
	INSERT INTO CUATROGDD2018.Usuario_X_Hotel(id_usuario, id_hotel)
	SELECT @idUsu,@idHotel
	WHERE (NOT EXISTS (SELECT * FROM CUATROGDD2018.Usuario_X_Hotel WHERE id_usuario = @idUsu and id_hotel = @idHotel ))

GO
