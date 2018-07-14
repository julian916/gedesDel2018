IF OBJECT_ID('CUATROGDD2018.SP_GetUsers_IdHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetUsers_IdHotel
GO
create PROCEDURE [CUATROGDD2018].[SP_GetUsers_IdHotel] @idHotel int
AS
BEGIN
	SELECT id_usuario,username,password,habilitado	
	FROM [CUATROGDD2018].[Usuarios]
	WHERE NOT id_usuario=1 and not id_usuario=2
END
GO