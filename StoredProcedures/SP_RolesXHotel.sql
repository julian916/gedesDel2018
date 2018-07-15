IF OBJECT_ID('CUATROGDD2018.SP_RolesXHotel', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_RolesXHotel
GO
CREATE PROCEDURE CUATROGDD2018.SP_RolesXHotel @idUsuario int
AS

	SELECT H.id_hotel, R.id_rol, R.nombre+'-'+H.nombre as 'Rol-Hotel'
	FROM CUATROGDD2018.Usuario_X_Hotel_X_Rol as UxHxR
	INNER JOIN CUATROGDD2018.Hoteles as H on UxHxR.id_hotel=H.id_hotel
	INNER JOIN CUATROGDD2018.Roles as R on R.id_rol=UxHxR.id_rol
	WHERE UxHxR.id_usuario=@idUsuario

GO
