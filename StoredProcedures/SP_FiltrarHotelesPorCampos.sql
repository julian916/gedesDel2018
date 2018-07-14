IF OBJECT_ID('CUATROGDD2018.SP_FiltrarHotelesPorCampos') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_FiltrarHotelesPorCampos
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_FiltrarHotelesPorCampos]
	@idUsu int,
	@cantEstrellas numeric(18,0),
	@ciudad nvarchar(255),
	@pais nvarchar(255),
	@nombre nvarchar(255)
AS
BEGIN

	SELECT h.[id_hotel]
		  ,h.[nombre]
		  ,h.[telefono]
		  ,h.[calle]
		  ,h.[nro_calle]
		  ,h.[ciudad]
		  ,h.[pais]
		  ,h.[cant_estrellas]
		  ,h.[recarga_estrellas]
		  ,h.[habilitado]
		  ,h.[email]
		  ,h.[fecha_creacion]
	FROM [CUATROGDD2018].[Hoteles] h
	INNER JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] uxh 
	ON h.id_hotel=uxh.id_hotel
	INNER JOIN [CUATROGDD2018].[Roles] r
	On uxh.id_rol=r.id_rol
	WHERE uxh.id_usuario=@idUsu 
	and (h.ciudad = @ciudad OR @ciudad IS NULL OR @ciudad = '')
	and (h.cant_estrellas = @cantEstrellas OR @cantEstrellas IS NULL OR @cantEstrellas = 0)
	and (h.pais = @pais OR @pais IS NULL OR @pais = '')
	and (h.pais = @nombre OR @nombre IS NULL OR @nombre = '')
	
END
GO