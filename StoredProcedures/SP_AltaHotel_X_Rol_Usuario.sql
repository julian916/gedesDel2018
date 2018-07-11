USE [GD1C2018]
GO

IF OBJECT_ID('CUATROGDD2018.SP_AltaHotel_X_Rol_Usuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaHotel_X_Rol__Usuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_AltaHotel_X_Rol_Usuario] @idUsuario int, @idRol int, @idHotel int
AS
BEGIN
	INSERT INTO CUATROGDD2018.Usuario_X_Hotel_X_Rol(id_hotel,id_rol,id_usuario)
	VALUES (@idHotel,@idRol,@idUsuario)
	
END
