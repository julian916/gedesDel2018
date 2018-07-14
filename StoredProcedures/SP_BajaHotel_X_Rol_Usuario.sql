IF OBJECT_ID('CUATROGDD2018.SP_BajaHotel_X_Rol_Usuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_BajaHotel_X_Rol_Usuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_BajaHotel_X_Rol_Usuario] @idUsuario int, @idRol int, @idHotel int
AS
BEGIN
	DELETE FROM CUATROGDD2018.Usuario_X_Hotel_X_Rol
	WHERE id_hotel=@idHotel and id_rol=@idRol and id_usuario=@idUsuario
	
END
GO
