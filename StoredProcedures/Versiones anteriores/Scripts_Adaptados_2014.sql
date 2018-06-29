CREATE PROCEDURE [CUATROGDD2018].[SP_MODIFICAR_HOTEL_PORID]
	@ID_HOTEL NUMERIC(18,0),
	@CALLE NVARCHAR(255),
	@RECARGA_ESTRELLA NUMERIC(18,2),
	@TELEFONO NVARCHAR(25),
	@NRO_CALLE NUMERIC(18,0),
	@CANTIDAD_ESTRELLAS NUMERIC(18,0),
	@CIUDAD NVARCHAR(255),
	@PAIS NVARCHAR(255)
AS
BEGIN
	
	UPDATE CUATROGDD2018.Hoteles
	SET calle = @CALLE,cant_estrellas = @CANTIDAD_ESTRELLAS,ciudad = @CIUDAD,
	nro_calle = @NRO_CALLE,pais = @PAIS,recarga_estrellas = @RECARGA_ESTRELLA,felefono = @TELEFONO
	WHERE id_hotel = @ID_HOTEL
	
	
END

CREATE PROCEDURE [CUATROGDD2018].[SP_RESET_LOGIN_TRIES]
	@ID_USER varchar(50)
	
AS 
BEGIN
	
	UPDATE CUATROGDD2018.Usuarios
	SET Intentos=0
	WHERE id_usuario=@ID_USER

END
GO

CREATE PROCEDURE [CUATROGDD2018].[LOGIN_FALLIDO]
	@ID_USER varchar(50)
	
AS 
BEGIN
	
	UPDATE CUATROGDD2018.Usuarios
	SET Intentos+=1
	WHERE id_usuario=@ID_USER

END
GO

CREATE FUNCTION [CUATROGDD2018].[Fn_ID_TIPOHABITACION]
(
	@Descripcion nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN 
	(
		SELECT T.id_tipo_habitacion
		FROM Tipo_Habitacion T
		WHERE T.descripcion = @Descripcion
	)

END
GO

CREATE FUNCTION [CUATROGDD2018].[Fn_ID_REGIMEN]
(
	@DESCRIPCION nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	
	RETURN (
	SELECT R.id_regimen
	FROM CUATROGDD2018.Regimenes_Estadia R
	WHERE R.descripcion = @DESCRIPCION
	)

END
GO

CREATE FUNCTION [CUATROGDD2018].[Fn_ID_HOTEL]
(
	@Ciudad nvarchar(255),
	@Calle nvarchar(255),
	@Nro_Calle numeric(18,0),
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
		AND H.nro_calle = @Nro_Calle
		AND H.recarga_estrellas = @RecargaEstrellas
		AND H.cant_estrellas = @CantEstrellas
	)
END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_INSERTAR_USER]
	@USUARIO varchar(50),
	@PASS varchar(64),
	@HABILITADO bit
	
AS
BEGIN
	INSERT INTO CUATROGDD2018.UsuarioS (usuario,password,Habilitado)
	VALUES (@USUARIO,@PASS,@HABILITADO)
	
END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_INSERTAR_ROL]
	@NOMBRE_ROL varchar(18),
	@HABILITADO bit
	
AS
BEGIN
	INSERT INTO CUATROGDD2018.Roles (nombre,habilitado)
	VALUES (@NOMBRE_ROL,@HABILITADO)
	
END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_INSERTARDATOS_USER]
	@ID_USER varchar(50),
	@NOM varchar (50),
	@AP varchar(50),
	@TDOC varchar (5),
	@DOC numeric (18,0),
	@FEC date,
	@DOM varchar (60),
	@NRO numeric(18,0),
	@PISO numeric (18,0),
	@DPTO varchar (18),
	@LOC varchar (50),
	@TEL varchar (20),
	@MAIL varchar (20)
	
AS
BEGIN
	INSERT INTO CUATROGDD2018.Personas (tipo_documento,nro_documento,nombre,apellido,email,telefono,direccion,nro_calle,piso,departamento,localidad,fecha_nacimiento,id_usuario)
	VALUES (@TDOC,@DOC,@NOM,@AP,@MAIL,@TEL,@DOM,@NRO,@PISO,@DPTO,@LOC,@FEC,@ID_USER)
	
END
GO

CREATE FUNCTION [CUATROGDD2018].[Fn_ID_ESTADORESERVA] 
(
	@ESTADO_RESERVA nvarchar(255)
)
RETURNS numeric(18,0)
AS
BEGIN
	RETURN 
	(
	SELECT E.ID_Estado
	FROM CUATROGDD2018.Estados_Reservas E
	WHERE E.descripcion = @ESTADO_RESERVA
	)

END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_MODIFICARDATOSPERS_USER]
	@ID_USER varchar(50),
	@NOM varchar (50),
	@AP varchar(50),
	@TDOC varchar (5),
	@DOC numeric (18,0),
	@FEC date,
	@DOM varchar (60),
	@NRO numeric (18,0),
	@PISO numeric (18,0),
	@DPTO varchar (18),
	@LOC varchar (50),
	@TEL varchar (20),
	@MAIL varchar (20)
	
AS
BEGIN
	UPDATE CUATROGDD2018.Personas
	SET tipo_documento=@TDOC,nro_documento=@DOC,nombre=@NOM,apellido=@AP,email=@MAIL,telefono=@TEL,
		direccion=@DOM,nro_calle=@NRO,piso=@PISO,departamento=@DPTO,localidad=@LOC,fecha_nacimiento=@FEC
	WHERE id_usuario=@ID_USER
	
END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_MODIFICAR_USER]
	@ID_USER varchar(50),
	@PASS varchar(64),
	@TRIES numeric (18,0),
	@BAJA_LOGICA bit,
	@NUEVO_USER varchar(50)
	
AS 
BEGIN
	
	UPDATE CUATROGDD2018.Usuarios
	SET usuario=@NUEVO_USER,password=@PASS, habilitado=@BAJA_LOGICA
	WHERE id_usuario=@ID_USER

END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_MODIFICAR_ROL]
	@ID_ROL numeric(18,0),
	@NOMBRE_ROL varchar(18),
	@BAJA_LOGICA bit
	
AS 
BEGIN
	
	UPDATE CUATROGDD2018.Roles
	SET nombre=@NOMBRE_ROL, habilitado=@BAJA_LOGICA
	WHERE id_rol=@ID_ROL

END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_CAMBIAR_PASSWORD]
	@ID_USER varchar(50),
	@PASS varchar(64)
AS 
BEGIN
	
	UPDATE CUATROGDD2018.Usuarios
	SET password=@PASS
	WHERE id_usuario=@ID_USER
END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_DARHOTEL]
	
AS 
BEGIN
	
	SELECT id_hotel FROM CUATROGDD2018.Hoteles

END
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_ALLHOTELES]

AS
BEGIN
	SELECT *
	FROM CUATROGDD2018.Hoteles 
END
GO