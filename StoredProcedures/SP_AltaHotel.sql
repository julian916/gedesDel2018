CREATE PROCEDURE [CUATROGDD2018].[SP_Alta_Hotel]
	@idUsuario int,
	@idRol int,
	@nombre NVARCHAR(255),
	@calle NVARCHAR(255),
	@recarga_estrellas NUMERIC(18,0),
	@telefono numeric(18,0),
	@email NVARCHAR (255),
	@nrocalle NUMERIC(18,0),
	@cant_estrellas NUMERIC(18,0),
	@ciudad NVARCHAR(255),
	@pais NVARCHAR(255),
	@fecha_creacion DATETIME
AS
BEGIN
	
	INSERT INTO [CUATROGDD2018].[Hoteles] (nombre, calle, nro_calle, ciudad, pais, cant_estrellas, recarga_estrellas, fecha_creacion, telefono, email)
	VALUES (@nombre,@calle,@nrocalle,@ciudad,@pais,@cant_estrellas,@recarga_estrellas,@fecha_creacion,@telefono,@email)
	
	DECLARE @idHotel int
	
	SET @idHotel = @@IDENTITY
	
	INSERT INTO  [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] ( id_hotel, id_usuario, id_rol)
	VALUES(@idHotel,@idUsuario, @idRol)

	SELECT @idHotel 
			
END
GO

