IF OBJECT_ID('CUATROGDD2018.SP_GetUsers_IdHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetUsers_IdHotel
GO
create PROCEDURE [CUATROGDD2018].[SP_GetUsers_IdHotel] @idHotel int
AS
BEGIN
	SELECT U.id_usuario,username, password,habilitado 
	FROM [CUATROGDD2018].[Usuarios] U
	INNER JOIN CUATROGDD2018.Usuario_X_Hotel_X_Rol UXHXR on UXHXR.id_usuario=U.id_usuario
	WHERE NOT U.id_usuario=1 and not U.id_usuario=2 and UXHXR.id_hotel=@idHotel
END
GO