USE [GD1C2018]
GO

/*##########################################################################################################*/
/*										SP ALTAS													*/
/*##########################################################################################################*/


/* ALTA HABITACION */
CREATE PROCEDURE [CUATROGDD2018].[SP_AltaHabitacion]
	@idTipoHabitacion int,
	@idHotel int, 
	@piso numeric(18, 0), 
	@frente nvarchar(50), 
	@nroHab numeric(18, 0), 
	@comodidades varchar(255)
AS
	INSERT INTO [CUATROGDD2018].[Habitaciones] ( id_tipo_habitacion, id_hotel, piso, frente, nro_habitacion, comodidades)
	VALUES ( @idTipoHabitacion, @idHotel, @piso, @frente, @nroHab, @comodidades)
GO

/* ALTA HOTEL */
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

/* Creo tipo de dato tabla para tener info de la persona, y pasarlo como parametro */

CREATE TYPE CUATROGDD2018.datosPersonaType AS TABLE
(
	tipoDocumento nvarchar(50) not null,
	nroDocumento int not null,
	emailPers nvarchar(255) not null,
	nombre nvarchar (255),
	apellido nvarchar (255),
	telPerso int,
	nacionPer nvarchar (255),
	callePer nvarchar (255),
	nroCalle nvarchar(50),
	pisoPer nvarchar(50),
	deptoPer nvarchar(50),
	localidadPer nvarchar(255),
	paisPer nvarchar(255),
	fechaPer datetime not null,
	idUsu int
) 


/* ALTA PERSONA */

CREATE PROCEDURE [CUATROGDD2018].[SP_AltaPersona] ( @datosIngresadosPersona as [CUATROGDD2018].[datosPersonaType] READONLY)
AS
BEGIN
	-- We simply insert values into the DB table from the parameter
	-- The table value parameter can be used like a table with only read rights
	INSERT INTO [CUATROGDD2018].[Personas](
					[tipo_documento]
					,[nro_documento]
					,[email]
					,[nombre]
					,[apellido]
					,[telefono]
					,[nacionalidad]
					,[direccion]
					,[nro_calle]
					,[piso]
					,[departamento]
					,[localidad]
					,[pais]
					,[fecha_nacimiento]
					,[id_usuario]
					)
	SELECT	tipoDocumento,
			nroDocumento,
			emailPers,
			nombre,
			apellido,
			telPerso,
			nacionPer,
			callePer,
			nroCalle,
			pisoPer,
			deptoPer,
			localidadPer,
			paisPer,
			fechaPer,
			idUsu
	FROM @datosIngresadosPersona
END
GO

/* ALTA USUARIO */

CREATE PROCEDURE [CUATROGDD2018].[SP_AltaUsuario] 
	@usuario varchar(255), 
	@contras varchar(255),
	@emailUsu varchar (255),  
	@idRol int, 
	@idHotel int,
	@tipoDNI nvarchar(50), 
	@nroDNI numeric(18,0), 
	@idUsu int out
AS
BEGIN
	INSERT INTO CUATROGDD2018.Usuarios (username, password)
	SELECT @usuario,HASHBYTES('SHA2_256', @contras)
	WHERE (NOT EXISTS (SELECT * FROM CUATROGDD2018.Usuarios WHERE username = @usuario))  
		  AND (NOT EXISTS (SELECT * FROM CUATROGDD2018.Personas WHERE email = @emailUsu and tipo_documento=@tipoDNI and nro_documento=@nroDNI))
	DECLARE @nuevoIDUsuario int
	SELECT @idUsu=SCOPE_IDENTITY() FROM CUATROGDD2018.Usuarios
	IF @idUsu is not null
		BEGIN
			INSERT INTO CUATROGDD2018.Usuario_X_Hotel_X_Rol (id_usuario,id_rol,id_hotel)
			VALUES (@idUsu, @idRol,@idHotel)
		END
END
GO

/*##########################################################################################################*/
/*										SP GET TABLAS													*/
/*##########################################################################################################*/

/* GET FUNCIONALIDAD POR ROL */

CREATE PROCEDURE [CUATROGDD2018].[SP_Funcionalidad_X_Rol] @idRol int
AS
	SELECT F.id_funcionalidad, F.descripcion
	FROM  CUATROGDD2018.Roles R 
	INNER JOIN [CUATROGDD2018].[Funcionalidad_X_Rol] FR ON R.id_rol=FR.id_rol
	INNER JOIN CUATROGDD2018.Funcionalidades F ON FR.id_funcionalidad = F.id_funcionalidad
	WHERE R.id_rol=@idRol
GO

/* GET FUNCIONALIDADES */
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllFuncionalidades]
AS
	SELECT * FROM CUATROGDD2018.Funcionalidades
GO

/* GET TODOS LOS REGIMENES */

CREATE PROCEDURE [CUATROGDD2018].[SP_getAllRegimenes] 
AS
	SELECT * FROM CUATROGDD2018.Regimenes_Estadia
GO

/* GET HOTELES POR ID ROL */

CREATE PROCEDURE [CUATROGDD2018].[SP_GetHotelesPorID_IDRol]
	@idUsuario int,
	@idRol int
AS
BEGIN
	
	SELECT * FROM [CUATROGDD2018].[Hoteles] H
	INNER JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UHR ON UHR.id_hotel= H.id_hotel
	WHERE UHR.id_usuario = @idUsuario
END
GO

/* GET HOTEL POR ID */

CREATE PROCEDURE [CUATROGDD2018].[SP_GetHotelPorID]
	@idHotel int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Hoteles] H 
	WHERE H.id_hotel = @idHotel
END
GO

/* GET ROLES POR ID  */

CREATE PROCEDURE [CUATROGDD2018].[SP_GetRolesPorID]
	@idUsuario int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Roles] R
	INNER JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UHR ON UHR.id_rol=R.id_rol 
	WHERE UHR.id_usuario = @idUsuario
END
GO

/* GET TIPOS DE HABITACIONES */

CREATE PROCEDURE [CUATROGDD2018].[SP_GetAll_TiposHabitaciones]
AS
BEGIN
	SELECT * FROM CUATROGDD2018.Tipo_Habitacion

END
GO

/* SP GET REGIMENES */

CREATE PROCEDURE [CUATROGDD2018].[SP_getAllRegimenes] 
AS
	SELECT * FROM CUATROGDD2018.Regimenes_Estadia
	GO

/*  GET ID_ HOTEL */

CREATE PROCEDURE [CUATROGDD2018].[SP_IdHoteles]
AS 
	SELECT id_hotel FROM CUATROGDD2018.Hoteles
GO

/* GET DATOS HOTELES */

CREATE PROCEDURE [CUATROGDD2018].[SP_InfoHoteles]
AS
	SELECT *FROM CUATROGDD2018.Hoteles 
GO

/* INFORMACION DE UNA HABITACION POR ID_HOTEL */

CREATE PROCEDURE [CUATROGDD2018].[SP_infoHabitacion] 
	@idhotel int
AS

	SELECT id_habitacion, id_tipo_habitacion, piso, frente, nro_habitacion, habilitado, comodidades 
	from [CUATROGDD2018].[Habitaciones]
	WHERE id_hotel=@idhotel	
GO


/*##########################################################################################################*/
/*										SP MODIFICAR													*/
/*##########################################################################################################*/

/*SP CAMBIAR CONTRASEÑA */

CREATE PROCEDURE [CUATROGDD2018].[SP_Cambiar_Password]
	@idUsuario int,
	@newPassHash varchar(255)
AS
BEGIN
	UPDATE CUATROGDD2018.Usuarios
	SET password=@newPassHash
	WHERE id_usuario=@idUsuario
END
GO

/*SP MODIFICAR USUARIO */

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
/* MODIFICAR HABITACION */

CREATE PROCEDURE [CUATROGDD2018].[SP_modificarHabitacion] 
	@idHab int, 
	@piso numeric(18, 0), 
	@nroHab numeric(18, 0), 
	@frente nvarchar(50), 
	@comodidades varchar(255)
AS
	UPDATE [CUATROGDD2018].[Habitaciones]
	SET piso= @piso, nro_habitacion=@nroHab,  frente= @frente, comodidades=@comodidades 
	WHERE id_habitacion= @idHab

GO

/*SP MODIFICAR HOTEL POR ID */
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

/* SP MODIFICAR DATOS DE PERSONA POR ID USUARIO */

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

/* SP MODIFICAR DATOS DEL ROL CON ID_ROL*/
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

/*SP UPDATE- DESHABILITAR UN USUARIO */

CREATE PROCEDURE CUATROGDD2018.SP_bloquerUsuario 
	@idUsuario int
AS
	UPDATE CUATROGDD2018.Usuarios  
	SET habilitado = 'False' 
	WHERE id_usuario = @idUsuario;  
GO

/* SP UPDATE- HABILITAR O DESHABILITAR CLIENTE */

CREATE PROCEDURE [CUATROGDD2018].[SP_HabilitarDeshabilitarCliente] 
	@idPersona int
AS
BEGIN
	UPDATE CUATROGDD2018.Personas
	SET estado = CASE	WHEN estado='Habilitado' THEN 'Deshabilitado'
						WHEN estado='Deshabilitado' THEN 'Habilitado'
						ELSE estado
						END
	WHERE CUATROGDD2018.Personas.id_persona=@idPersona	
END
GO

/*##########################################################################################################*/
/*										OTROS SP													*/
/*##########################################################################################################*/


/* SP BUSCAR CLIENTE */

CREATE PROCEDURE [CUATROGDD2018].[SP_BuscarCliente] 
	@tipoDNI nvarchar(50),
	@nroDocumento numeric(18,0),
	@nombre nvarchar (255),
	@apellido nvarchar(255),
	@email nvarchar(255)
AS
BEGIN
	SELECT * 
	FROM CUATROGDD2018.Personas P
	WHERE (P.nro_documento = @nroDocumento OR @nroDocumento IS NULL)
	AND (UPPER(P.apellido) LIKE '%'+@apellido OR @apellido+'%' IS NULL OR @apellido = '')
	AND (UPPER(P.nombre) LIKE '%'+@nombre+'%' OR @nombre IS NULL OR @nombre = '')
	AND (UPPER(P.email) LIKE '%'+@email+'%' OR @email IS NULL OR @email = '')
	AND (UPPER(P.tipo_documento) LIKE '%'+@tipoDNI+'%' OR @tipoDNI IS NULL OR @tipoDNI = '')
END
GO

/*FUNCION DAR COSTO POR NOCHE */

CREATE FUNCTION [CUATROGDD2018].[FN_DarCostoXNoche] (@idRegimen int,@idTipoHab int)
RETURNS numeric(18,0)
AS BEGIN
    DECLARE @precioBaseReg numeric(18,0);
	DECLARE @porcentual numeric(18,2);
	DECLARE @resultado numeric(18,0);
	
    SELECT @precioBaseReg=[precio_base]
	FROM [CUATROGDD2018].[Regimenes_Estadia]
	where id_regimen=@idRegimen

    SELECT @porcentual=[porcentual]
	FROM [CUATROGDD2018].[Tipo_Habitacion]
	where [id_tipo_habitacion]=@idTipoHab

	set @resultado=@precioBaseReg*@porcentual;
	
    RETURN @resultado
END


/* FUNCION DAR RECARGA HOTEL */

CREATE FUNCTION [CUATROGDD2018].[FN_DarRecargaHotel] (@idHotel int)
RETURNS numeric(18,0)
AS BEGIN
    DECLARE @resultado numeric(18,0);
	
    Select @resultado=[cant_estrellas]*[recarga_estrellas]
	from [CUATROGDD2018].[Hoteles]
	where id_hotel=4
	
    RETURN @resultado
END

/*SP DAR HABITACIONES DISPONIBLES*/

CREATE PROCEDURE [CUATROGDD2018].[SP_DarHabitacionesDisponibles] 
	@idhotel int,
	@idRegimen int,
	@fechaInicio date,
	@fechaFin date
AS
BEGIN

	SELECT ha.id_habitacion
		  ,th.descripcion +case when ha.frente='S' then ' Al frente' else ' Interno' end +
		  '. Precio base $'+
		  cast([CUATROGDD2018].[FN_DarCostoXNoche](@idRegimen,ha.id_tipo_habitacion)+[CUATROGDD2018].[FN_DarRecargaHotel](h.id_hotel) as varchar(10)) as [Descripacion de habitacion]
	FROM [CUATROGDD2018].[Hoteles] h
	inner join [CUATROGDD2018].[Regimen_X_Hotel] rxh on h.id_hotel =rxh.id_hotel and rxh.id_hotel=@idhotel
	inner join [CUATROGDD2018].[Regimenes_Estadia] re on rxh.id_regimen=re.id_regimen and re.id_regimen=@idRegimen
	inner join [CUATROGDD2018].[Habitaciones]  ha on h.id_hotel=ha.id_hotel and h.id_hotel=@idhotel 
	inner join [CUATROGDD2018].[Tipo_Habitacion] th on ha.id_tipo_habitacion=th.id_tipo_habitacion
	WHERE (
			SELECT COUNT(1)
			FROM [CUATROGDD2018].[Habitacion_X_Reserva] hxr 
			INNER JOIN [CUATROGDD2018].[Reservas] r
			ON r.[id_reserva] = hxr.[id_reserva]
			WHERE hxr.id_habitacion = ha.id_habitacion and 
				r.[id_estado_reserva] != 1 and R.[id_estado_reserva] != 2 and R.[id_estado_reserva] != 7 and 
				r.[fecha_desde] BETWEEN @fechaInicio AND @fechaFin
			) = 0 and
	
		 ( 
			SELECT COUNT(1)
			FROM [CUATROGDD2018].[Historial_Cierres] hc
			WHERE h.id_hotel=hc.id_hotel and 
				  hc.[fecha_desde] BETWEEN @fechaInicio AND @fechaFin
			) = 0
	order by [Descripacion de habitacion]
END


/*SP HOTELES COMBOBOX */

CREATE PROCEDURE CUATROGDD2018.SP_HotelesComboBox
AS
	SELECT id_Hotel, LTRIM(RTRIM(pais)) + '-' + LTRIM(RTRIM(ciudad)) + '-' + LTRIM(RTRIM(calle)) + '-' + CAST(nro_calle as varchar(10)) as dir_Hotel from CUATROGDD2018.Hoteles
GO

/* LOGIN */

CREATE PROCEDURE CUATROGDD2018.SP_Login 
	 @usuario varchar(255), 
	 @contras varchar(255),
	 @existeUsername bit out, 
	 @loginCorrecto bit out, 
	 @idUsuario int out, 
	 @estaHabilitado bit out
AS
/* Selecciono el idUsuario con los valores ingresados, si no lo encuentra devuelve null */
	--Seteo como falsas las variable
	SET  @loginCorrecto = 1
	SET @estaHabilitado = 1
	
	
	SELECT [id_usuario] FROM [CUATROGDD2018].[Usuarios]
	WHERE id_usuario=@idUsuario and username=@usuario 
	
	SELECT habilitado FROM CUATROGDD2018.Usuarios
	WHERE habilitado =@estaHabilitado username=@usuario 

	IF @idUsuario IS NOT NULL
		IF EXISTS (SELECT * FROM CUATROGDD2018.Usuarios WHERE username = @usuario AND password=HASHBYTES('SHA2_256', @contras) AND habilitado = 'True')
			SET @loginCorrecto = 0


GO

/* OBTENER CALLES A PARTIR DE CIUDAD */

CREATE PROCEDURE CUATROGDD2018.SP_ObtenerCallesAPartirDeCiudad
@ciudad nvarchar(255)
AS	
	SELECT id_hotel, LTRIM(RTRIM(calle)) + ' ' + CAST(nro_calle as varchar(10)) as calles from CUATROGDD2018.Hoteles
	where ciudad like '%'+@ciudad+'%'
GO

/* Obtener ciudades */
CREATE PROCEDURE CUATROGDD2018.SP_ObtenerCiudades
AS
	SELECT DISTINCT(LTRIM(RTRIM(ciudad))) as ciudad from CUATROGDD2018.Hoteles	
GO


/* OBTENET ID REGIMEN Y DESCRIPCION */

CREATE PROCEDURE [CUATROGDD2018].[SP_InfoRegimenEstadia] 
AS
BEGIN
	select id_regimen, descripcion 
	from [GD1C2018].[Regimenes_Estadia]
END
GO

/* Roles COMBO BOX */

CREATE PROCEDURE CUATROGDD2018.SP_RolesComboBox
AS
	SELECT id_rol, nombre from CUATROGDD2018.Roles
	WHERE NOT nombre = 'GUEST' AND NOT nombre = 'Administrados General'
GO

/* Roles  por Hotel */

CREATE PROCEDURE CUATROGDD2018.SP_RolesXHotel 
	@idUsuario int
AS

	SELECT H.id_hotel, R.id_rol, R.nombre+'-'+H.nombre as 'Rol-Hotel'
	FROM CUATROGDD2018.Usuario_X_Hotel_X_Rol as UxHxR
	INNER JOIN CUATROGDD2018.Hoteles as H on UxHxR.id_hotel=H.id_hotel
	INNER JOIN CUATROGDD2018.Roles as R on R.id_rol=UxHxR.id_rol
	WHERE UxHxR.id_usuario=@idUsuario

GO
/*Validar datos persona */
CREATE PROCEDURE [CUATROGDD2018].[SP_ValidarDatosPersona] 
	@tipoDNI nvarchar(50),
	@nroDNI numeric(18,0),
	@emailPer nvarchar (255)
AS
BEGIN
	DECLARE @esValido bit
	SET @esValido='True'
	IF EXISTS (SELECT * FROM CUATROGDD2018.Personas WHERE (tipo_documento = @tipoDNI AND nro_documento=@nroDNI) OR email = @emailPer)
			SET @esValido = 'False'
	SELECT @esValido
END

/*##########################################################################################################*/
/*										SP ESTADISTICAS													*/
/*##########################################################################################################*/


	/* SP Funcion Para saber si una fecha pertenece al trimestre seleccionado  */

	CREATE PROCEDURE CUATROGDD2018.fnc_perteneceATrimestre 
		(	@anioConsulta int, 
			@trimestre int , 
			@fechaConsulta datetime)
	AS
	RETURN BIT
	declare @pertenece BIT

	@pertenece = CASE WHEN  (@anioConsulta = YEAR(@fechaConsulta) and @trimestre=(MONTH(@fechaConsulta)-1)/4+1) then 0
							ELSE 1
	RETURN @pertenece
	END

	IF OBJECT_ID('CUATROGDD2018.SP_TopHotelesConReservasCanceladas', 'P') IS NOT NULL
		DROP PROCEDURE CUATROGDD2018.SP_TopHotelesConReservasCanceladas
	GO

	/*Además el sistema nos pedirá que ingresemos obligatoriamente el año por el cual
	queremos consultar, luego nos pedirá el trimestre*/

	CREATE PROCEDURE CUATROGDD2018.sp_TopHotelesConReservasCanceladas ( @anioConsulta int, @trimestre int )
	AS
		SELECT top 5 calle, nro_calle, ciudad, pais, cant_estrellas, count (*) as "Cantidad reservas canceladas"
		FROM [CUATROGDD2018].[Reservas] R
		JOIN [CUATROGDD2018].[Habitacion_X_Reserva] as HabXRes on HabXRes.id_reserva=R.id_reserva
		JOIN [CUATROGDD2018].[Habitaciones] hab on Hab.id_habitacion=HabXRes.id_habitacion
		JOIN [CUATROGDD2018].[Hoteles] H on Hab.id_hotel=H.id_hotel
		WHERE R.id_estado_reserva in ( 3, 4, 5 ) and  @anioConsulta = YEAR(R.fecha_inicio) and @trimestre=(MONTH(R.fecha_inicio)-1)/4+1
		GROUP BY (id_reserva)
		ORDER BY  count (*) DESC
	GO
/*Hoteles con mayor cantidad de consumibles facturados.*/

CREATE PROCEDURE CUATROGDD2018.SP_TopHotelesConsumiblesFacturados
 (	@anioConsulta int, 
	@trimestre int )
AS
	SELECT top 5 calle, nro_calle, ciudad, pais, cant_estrellas, sum (ConsumXEst.cantidad) as "Cantidad consumibles facturados"
	FROM [CUATROGDD2018].[Facturas] F
	JOIN [CUATROGDD2018].[Estadias] E on F.id_Estadia=E.id_Estadia
	JOIN [CUATROGDD2018].[Consumible_X_Estadia] as ConsumXEst on E.id_Estadia=ConsumXEst.id_estadia
	WHERE @anioConsulta = YEAR(F.fecha) and @trimestre=(MONTH(F.fecha)-1)/4+1
	GROUP BY (id_Estadia)
	ORDER BY sum (ConsumXEst.cantidad) DESC
GO

/*Hoteles con mayor cantidad de días fuera de servicio.*/

CREATE PROCEDURE CUATROGDD2018.SP_TopHotelesDiasSinServ 
	(	@anioConsulta int, 
		@trimestre int )
AS
	SELECT top 5 calle, nro_calle, ciudad, pais, cant_estrellas, sum (DATEDIFF(DAY, Historial.fecha_desde, Historial.fecha_hasta)) as "Cantidad días fuera de servicio"
	FROM [CUATROGDD2018].[Hoteles] H
	JOIN [CUATROGDD2018].[Historial_Cierres] as Historial on H.id_hotel =Historial.id_hotel
	WHERE @anioConsulta = YEAR(Historial.fecha_desde) and @trimestre=(MONTH(Historial.fecha_desde)-1)/4+1
	GROUP BY (id_hotel)
	ORDER BY sum (DATEDIFF(DAY, Historial.fecha_desde, Historial.fecha_hasta)) DESC
GO

/*Habitaciones con mayor cantidad de días y veces que fueron ocupadas, informando a demás a que hotel pertenecen.*/

CREATE PROCEDURE CUATROGDD2018.sp_TopHabitacionOcupadas
	 @anioConsulta int, 
	 @trimestre int 
AS
	SELECT top 5 calle, nro_calle, piso, departamento, count(hab.id_habitacion) as "Cantidas veces ocupado",sum (DATEDIFF(DAY, Est.fecha_inicio, Est.fecha_fin)) as "Cantidad días ocupado"
	FROM [CUATROGDD2018].[Hoteles] H
	JOIN [CUATROGDD2018].[Habitaciones] as Hab on Hab.id_hotel=H.id_hotel
	JOIN [CUATROGDD2018].[Estadias] as Est on Est.id_habitacion = Hab.id_habitacion
	JOIN [CUATROGDD2018].[Reservas] as Res on Est.id_reserva=Res.id_reserva
	
	WHERE @anioConsulta = YEAR(Est.fecha_inicio) and @trimestre=(MONTH(Est.fecha_inicio)-1)/4+1
	GROUP BY (id_hotel)
	ORDER BY  count(id_habitacion), sum (DATEDIFF(DAY, Est.fecha_inicio, Est.fecha_fin)) DESC
GO

/*Cliente con mayor cantidad de puntos, donde cada $20 en estadías vale 1
puntos y cada $10 de consumibles es 1 punto, de la sumatoria de todas las
facturaciones que haya tenido dentro de un periodo independientemente
del Hotel. Tener en cuenta que la facturación siempre es a quien haya
realizado la reserva.*/

CREATE PROCEDURE CUATROGDD2018.SP_TopClientesMasPuntos 
	@anioConsulta int, 
	@trimestre int 
AS
	SELECT top 5 sum(Fact.puntos_obtenidos) as "Puntos acumulados", Pers.nombre, Pers.nro_documento
	FROM CUATROGDD2018.Facturas as Fact
	JOIN CUATROGDD2018.Estadias as Es on Fact.id_estadia = Es.id_estadia
	JOIN CUATROGDD2018.Personas as Pers on Fact.id_persona=Pers.id_persona
	WHERE @anioConsulta = YEAR(Fact.fecha) and @trimestre=(MONTH(Fact.fecha)-1)/4+1
	GROUP BY (Pers.id_persona)
	ORDER BY sum(Fact.puntos_obtenidos) DESC
GO