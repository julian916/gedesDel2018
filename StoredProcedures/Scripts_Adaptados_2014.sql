USE [GD1C2018]
GO

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

	SELECT *
	FROM [CUATROGDD2018].[Hoteles] H
	WHERE H.id_hotel = @idHotel
			
END
GO
------------------------------------

IF OBJECT_ID('CUATROGDD2018.SP_getAllRegimenes', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_getAllRegimenes
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_getAllRegimenes] 
AS
	SELECT * FROM CUATROGDD2018.Regimenes_Estadia
GO

--------------------------------------------------
CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarHotel_PorId]
	@IdHotel int,
	@nombre nvarchar(255),
	@calle nvarchar(255),
	@RecargaEstrellas numeric(18,0),
	@telefono numeric(18,0),
	@nroCalle numeric(18,0),
	@cantEstrellas numeric(18,0),
	@ciudad nvarchar(255),
	@pais nvarchar(255),
	@email nvarchar(255)
AS
BEGIN
	
	UPDATE CUATROGDD2018.Hoteles
	SET nombre = @nombre,
		calle = @calle, 
		cant_estrellas = @cantEstrellas, 
		ciudad = @ciudad,
		nro_calle = @nroCalle,
		pais = @pais,
		recarga_estrellas = @RecargaEstrellas,
		telefono = @telefono,
		email = @email
	WHERE id_hotel = @IdHotel
		
END
GO


------------------------------------------------------
--POR EL MOMENTO NO SE UTILIZA ESTA FN

CREATE FUNCTION [CUATROGDD2018].[Fn_IdTipoHabitacion]
(
	@descripcion nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN 
	(
		SELECT T.id_tipo_habitacion
		FROM [CUATROGDD2018].[Tipo_Habitacion] T
		WHERE T.descripcion = @descripcion
	)

END
GO

-----------------------------------------

CREATE PROCEDURE [CUATROGDD2018].[SP_GetHotelPorID]
	@idHotel int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Hoteles] H 
	WHERE H.id_hotel = @idHotel
END
GO

-----------------------------------------
CREATE PROCEDURE [CUATROGDD2018].[SP_Cambiar_Password]
	@IdUsuario int,
	@newPass  varchar(255)
AS 
BEGIN
	
	UPDATE CUATROGDD2018.Usuarios
	SET password=@newPass
	WHERE id_usuario =@IdUsuario
END
GO

-----------------------------------------























----------------------------------------------

CREATE FUNCTION [CUATROGDD2018].[Fn_IdRegimenPorDescripcion]
(
	@descripcion nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN (
	SELECT R.id_regimen
	FROM CUATROGDD2018.Regimenes_Estadia R
	WHERE R.descripcion = @descripcion
	)

END
GO

------------------------------------------------------

CREATE FUNCTION [CUATROGDD2018].[Fn_IdHotel]
(
	@Ciudad nvarchar(255),
	@Calle nvarchar(255),
	@NroCalle numeric(18,0),
	@CantEstrellas numeric(18,0),
	@RecargaEstrellas numeric(18,0)
	
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN 
	(
		SELECT H.ID_Hotel
		FROM CUATROGDD2018.Hoteles H
		WHERE H.calle = @Calle 
				AND H.ciudad = @Ciudad
				AND H.nro_calle = @NroCalle
				AND H.recarga_estrellas = @RecargaEstrellas
				AND H.cant_estrellas = @CantEstrellas
	)
END
GO

------------------------------------------------------

CREATE FUNCTION [CUATROGDD2018].[FN_IdEstadoRerserva]  
(
	@descripcion varchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	RETURN 
	(
	SELECT E.[id_estado_reserva]
	FROM CUATROGDD2018.Estados_Reservas E
	WHERE E.descripcion = @descripcion
	)

END
GO

-------------------------------------------------------


CREATE PROCEDURE [CUATROGDD2018].[SP_Modificar_DatosPersona_PorIdUsuario]
	
	@IdUsuario int,
	@nacionalidad nvarchar (255),
	@nombre nvarchar (255),
	@apellido nvarchar(255),
	@tipoDocu nvarchar (50),
	@nroDocu numeric (18,0),
	@fechaNac datetime,
	@direccion nvarchar (50),
	@nroCalle numeric (18,0),
	@piso numeric (18,0),
	@departamento nvarchar (50),
	@localidad nvarchar(255),
	@pais nvarchar(255),
	@telefono numeric (18,0),
	@email nvarchar(255)
	
AS
BEGIN
	UPDATE CUATROGDD2018.Personas
	SET tipo_documento=@tipoDocu,
		nro_documento=@nroDocu,
		nacionalidad =@nacionalidad,
		nombre=@nombre,
		apellido=@apellido,
		email=@email,
		telefono=@telefono,
		direccion=@direccion,
		nro_calle=@nroCalle,
		piso=@piso,
		departamento=@departamento,
		localidad=@localidad,
		pais = @pais,
		fecha_nacimiento=@fechaNac
	WHERE id_usuario=@IdUsuario
	
END
GO

---------------------------------------------------------------

CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarUsuario]
	@idUsuario int,
	@pass varchar(255),
	@habilitado bit
	
AS 
BEGIN
	
	UPDATE CUATROGDD2018.Usuarios
	SET id_usuario =@idUsuario,
		password=@pass,
		habilitado=@habilitado
	WHERE id_usuario=@idUsuario

END
GO

-----------------------------------

CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarRol]
	
	@idRol int,
	@nombre varchar(50),
	@habilitado bit
	
AS 
BEGIN
	
	UPDATE CUATROGDD2018.Roles
	SET nombre=@nombre, 
	habilitado=@habilitado
	WHERE id_rol=@idRol

END
GO

--------------------------------------------


CREATE PROCEDURE [CUATROGDD2018].[SP_IdHoteles]
	
AS 
BEGIN
	SELECT id_hotel FROM CUATROGDD2018.Hoteles
END
GO
-----------------------------------------------

CREATE PROCEDURE [CUATROGDD2018].[SP_InfoHoteles]

AS
BEGIN
	SELECT *FROM CUATROGDD2018.Hoteles 
END
GO