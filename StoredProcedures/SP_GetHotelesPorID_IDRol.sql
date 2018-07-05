USE [GD1C2018]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetHotelesPorID_IDRol]
	@idUsuario int,
	@idRol int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Hoteles] H
	INNER JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UHR ON UHR.id_Hotel=H.id_Hotel 
	WHERE UHR.id_usuario = @idUsuario
END
GO