CREATE PROCEDURE [CUATROGDD2018].[SP_DarHotelesPaises]
	@idUsu int
AS
BEGIN
	
	SELECT h.pais
	FROM [CUATROGDD2018].[Hoteles] h
	INNER JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] uxh 
	ON h.id_hotel=uxh.id_hotel
	INNER JOIN [CUATROGDD2018].[Roles] r
	On uxh.id_rol=r.id_rol
	WHERE uxh.id_usuario=@idUsu and r.nombre='Administrador'
	GROUP BY H.pais
	
END
GO