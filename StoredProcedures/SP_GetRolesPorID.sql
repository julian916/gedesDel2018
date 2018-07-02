USE [GD1C2018]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetRolesPorID]
	@idUsuario int
AS
BEGIN
	SELECT DISTINCT UHR.id_rol, nombre, habilitado  FROM [CUATROGDD2018].[Roles] R
	INNER JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UHR ON UHR.id_rol=R.id_rol 
	WHERE UHR.id_usuario = @idUsuario AND R.habilitado='True'
END
GO
