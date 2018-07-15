
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllHoteles_PorUsuario]
	@idUsuario int
AS 
BEGIN
	
	SELECT * 
	FROM [CUATROGDD2018].[Hoteles] H
	INNER JOIN CUATROGDD2018.Usuario_X_Hotel_X_Rol UxHxR ON (H.id_hotel = UxHxR.id_hotel)	
	WHERE UxHxR.id_usuario = @idUsuario

END
GO