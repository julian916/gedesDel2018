USE [GD1C2018]
GO
/*##########################################################################################################*/
/*										CREACION DE STORED PROCEDURES Y FUNCTIONS							*/
/*##########################################################################################################*/
IF OBJECT_ID('CUATROGDD2018.SP_AltaUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_AltaUsuario] 
		@usuario varchar(255)
		,@password varchar(255)
AS
Begin
	DECLARE @id int
	INSERT INTO CUATROGDD2018.Usuarios (username, password)
	VALUES (@usuario,@password)
	SELECT @id=SCOPE_IDENTITY() 
	FROM [CUATROGDD2018].[Usuarios]
		 
End
GO
---------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_AltaRol') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaRol
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_AltaRol]
	@nombre varchar(50)
AS
BEGIN
	DECLARE @id int
	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Roles] WHERE [nombre]=@nombre)
		BEGIN
			SET @id=-1
		END
	ELSE 
		BEGIN
			INSERT INTO [CUATROGDD2018].[Roles] (nombre)
			VALUES (@nombre)
			SET @id = @@IDENTITY
		END	
	SELECT @id
END
GO
----------------------------------------------------
--Creo tipo de dato tabla para tener info de la persona, y pasarlo como parametro
--CREATE TYPE CUATROGDD2018.datosPersonaType AS TABLE
--(
--	tipoDocumento nvarchar(50) not null,
--	nroDocumento int not null,
--	emailPers nvarchar(255) not null,
--	nombre nvarchar (255),
--	apellido nvarchar (255),
--	telPerso int,
--	nacionPer nvarchar (255),
--	callePer nvarchar (255),
--	nroCalle nvarchar(50),
--	pisoPer nvarchar(50),
--	deptoPer nvarchar(50),
--	localidadPer nvarchar(255),
--	paisPer nvarchar(255),
--	fechaPer datetime not null,
--	idUsu int
--) 

IF OBJECT_ID('CUATROGDD2018.SP_altaPersona', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_altaPersona
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_altaPersona] ( 
		@datosIngresadosPersona as [CUATROGDD2018].[datosPersonaType] READONLY)
AS
BEGIN
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
--------------------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_AltaHotel_X_Rol_Usuario') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaHotel_X_Rol_Usuario
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_AltaHotel_X_Rol_Usuario] 
		@idUsuario int
		,@idRol int
		,@idHotel int
AS
BEGIN
	INSERT INTO CUATROGDD2018.Usuario_X_Hotel_X_Rol(id_hotel,id_rol,id_usuario)
	VALUES (@idHotel,@idRol,@idUsuario)
	
END
GO
---------------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_Alta_Hotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_Alta_Hotel
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

	SELECT @idHotel 
			
END
GO

------------------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_AltaHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_AltaHabitacion] 
		@idTipoHabitacion int
		,@idHotel int
		,@piso numeric(18, 0)
		,@frente nvarchar(50)
		,@nroHab numeric(18, 0)
		,@comodidades varchar(255)
AS 
BEGIN 
	INSERT INTO [CUATROGDD2018].[Habitaciones] ( id_tipo_habitacion, id_hotel, piso, frente, nro_habitacion, comodidades)
	VALUES ( @idTipoHabitacion, @idHotel, @piso, @frente, @nroHab, @comodidades)
END
GO
----------------------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_AgregarFuncionalidadRol') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AgregarFuncionalidadRol
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_AgregarFuncionalidadRol]
	@idRol int,
	@idFun int
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Funcionalidad_X_Rol] (id_rol,id_funcionalidad)
	VALUES (@idRol,@idFun)
END
GO
---------------------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_BuscarHabitacionPorReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_BuscarHabitacionPorReserva
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_BuscarHabitacionPorReserva] (@idReserva int)
AS
BEGIN
	SELECT h.*, th.descripcion
	FROM [CUATROGDD2018].[Reservas] r
	INNER JOIN [CUATROGDD2018].[Habitacion_X_Reserva] hxr
	ON r.id_reserva=hxr.id_reserva
	INNER JOIN [CUATROGDD2018].[Habitaciones] h
	ON hxr.id_habitacion=h.id_habitacion
	INNER JOIN [CUATROGDD2018].[Tipo_Habitacion] th
	ON h.id_tipo_habitacion=th.id_tipo_habitacion
	where r.id_reserva=@idReserva
END
GO
----------------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_BuscaReservaPorId') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_BuscaReservaPorId
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_BuscaReservaPorId] 
	@idReserva int
AS
BEGIN
	SELECT distinct r.*,h.id_hotel 
	FROM [CUATROGDD2018].[Reservas] r
	INNER JOIN [CUATROGDD2018].[Habitacion_X_Reserva] hxr
	ON r.id_reserva=hxr.id_reserva
	INNER JOIN [CUATROGDD2018].[Habitaciones] h
	ON hxr.id_habitacion=h.id_habitacion
	WHERE r.id_reserva=@idReserva
END
-----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_BuscarCliente') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_BuscarCliente
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_BuscarCliente] 
		@tipoDNI nvarchar(50)
		,@nroDocumento numeric(18,0)
		,@nombre nvarchar (255)
		,@apellido nvarchar(255)
		,@email nvarchar(255)
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
----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_bloquerUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_bloquerUsuario
GO
CREATE PROCEDURE CUATROGDD2018.SP_bloquerUsuario @idUsuario int
AS
BEGIN
	UPDATE CUATROGDD2018.Usuarios  
	SET habilitado = 'False' 
	WHERE id_usuario = @idUsuario;  
END

GO

------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_BajaHotel_X_Rol_Usuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_BajaHotel_X_Rol_Usuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_BajaHotel_X_Rol_Usuario] 
		@idUsuario int
		,@idRol int
		,@idHotel int
AS
BEGIN
	DELETE FROM CUATROGDD2018.Usuario_X_Hotel_X_Rol
	WHERE id_hotel=@idHotel and id_rol=@idRol and id_usuario=@idUsuario
	
END
GO
---------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_CierreTempHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_CierreTempHotel
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_CierreTempHotel](	
	@id_hotel int,
	@fechaInicio datetime,
	@diasCierre int,
	@comentario nvarchar(255)
	)
AS
BEGIN
	DECLARE @MENSAJE varchar(255),@fechaHasta date;
	set @fechaHasta = @fechaInicio+@diasCierre;

	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Reservas] 
					   WHERE (@fechaInicio BETWEEN [fecha_desde] AND [fecha_hasta]) 
					   or (@fechaHasta BETWEEN [fecha_desde] AND [fecha_hasta]))
			OR EXISTS (SELECT 1 FROM [CUATROGDD2018].[Estadias] 
						WHERE (@fechaInicio BETWEEN [fecha_inicio] AND ([fecha_inicio]+[cant_noches]))
						or (@fechaHasta BETWEEN [fecha_inicio] AND ([fecha_inicio]+[cant_noches])))
			BEGIN
				SET @MENSAJE='El hotel no se podrá cerrar en la fecha seleccionada. Existen Reservas/Estadias en ese periodo'
				SELECT @MENSAJE
				RETURN
			END
	ELSE
			BEGIN

				INSERT [CUATROGDD2018].[Historial_Cierres](
						[id_hotel],[fecha_desde],[detalle_cierre],[cant_diasBaja],[fecha_hasta])
				VALUES (@id_hotel,@fechaInicio,@comentario,@diasCierre,@fechaHasta)

				SET @MENSAJE=''
				SELECT @MENSAJE
				RETURN
			END
END
GO
----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_CheckInOutEstadia') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_CheckInOutEstadia
GO
CREATE PROCEDURE CUATROGDD2018.SP_CheckInOutEstadia(
	 @id int
	,@idUsuario int
	,@fecha datetime
	)
AS 
BEGIN

	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Estadias] WHERE [id_estadia]=@id and [id_usuario_checkOut] is null)
		BEGIN
			UPDATE [CUATROGDD2018].[Estadias]
			SET [cant_noches]=DATEDIFF(DAY,[fecha_inicio],@fecha)
				,[id_usuario_checkOut]=@idUsuario
			where [id_estadia]=@id

			UPDATE [CUATROGDD2018].[Reservas]
			SET [id_estado_reserva]=6--Reserva efectivizada
			FROM [CUATROGDD2018].[Reservas] r
			INNER JOIN [CUATROGDD2018].[Estadias] e
			ON r.id_reserva=e.id_reserva
			WHERE r.id_estado_reserva=7 and e.id_usuario_checkOut is not null
	
		END 
	ELSE
		BEGIN

			declare @idHab int,@idEstadiaInsert int

			select @idHab=hxr.id_habitacion
			from [CUATROGDD2018].[Reservas] r
			inner join [CUATROGDD2018].[Habitacion_X_Reserva] hxr
			on r.id_reserva=hxr.id_reserva
			where r.id_reserva=@id

			INSERT INTO [CUATROGDD2018].[Estadias](
						[fecha_inicio]
						,[id_usuario_checkIn]
						,[id_reserva]
						,[id_habitacion])
			VALUES (@fecha,@idUsuario,@id,@idHab)

			SET @idEstadiaInsert = @@IDENTITY

			UPDATE [CUATROGDD2018].[Reservas]
			SET [id_estado_reserva]=7--Reserva con ingreso, en curso
			WHERE id_reserva=@id
	
			SELECT @idEstadiaInsert
		END
END
GO
---------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_CancelarReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_CancelarReserva
GO
CREATE PROCEDURE CUATROGDD2018.SP_CancelarReserva(
	 @idReserva int
	,@idUsuario int
	,@fecha date
	,@motivo varchar(max))
AS 
BEGIN
	INSERT INTO [CUATROGDD2018].[Reservas_Canceladas]([id_reserva],[id_usuario],[fecha],[motivo])
	VALUES (@idReserva, @idUsuario, @fecha, @motivo)

	IF @idUsuario = 'GUEST'
		BEGIN
			UPDATE [CUATROGDD2018].[Reservas]
			SET id_usuario_reserva=@idUsuario
				,[id_estado_reserva]=4--Reserva cancelada por Cliente
			WHERE id_reserva=@idReserva
		END
	ELSE
		BEGIN
			UPDATE [CUATROGDD2018].[Reservas]
			SET id_usuario_reserva=@idUsuario
				,[id_estado_reserva]=3--Reserva cancelada por Recepcion
			WHERE id_reserva=@idReserva
		END
END
GO
---------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_Cambiar_Password') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_Cambiar_Password
GO
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
-----------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_DarHotelesPaises') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_DarHotelesPaises
GO
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
	WHERE uxh.id_usuario=@idUsu
	GROUP BY H.pais
	
END
GO
----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_DarHotelesCiudades') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_DarHotelesCiudades
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_DarHotelesCiudades]
	@idUsu int
AS
BEGIN
	
	SELECT h.ciudad
	FROM [CUATROGDD2018].[Hoteles] h
	INNER JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] uxh 
	ON h.id_hotel=uxh.id_hotel
	INNER JOIN [CUATROGDD2018].[Roles] r
	On uxh.id_rol=r.id_rol
	WHERE uxh.id_usuario=@idUsu
	GROUP BY h.ciudad
	
END
GO
--------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_DarHabitacionesDisponibles') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_DarHabitacionesDisponibles
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_DarHabitacionesDisponibles] 
	@idhotel int,
	@idTipoHab int,
	@fechaInicio date,
	@fechaFin date
AS
BEGIN

if @idTipoHab !=0
 begin
	SELECT distinct ha.id_habitacion
		  ,ha.piso
		  ,ha.nro_habitacion
		  ,case when ha.frente='S' then 'Al frente' else 'Interno' end as ubicacion 
		  ,ha.comodidades
		  ,ha.id_tipo_habitacion
		  ,th.descripcion as tipo_habitacion
	FROM [CUATROGDD2018].[Hoteles] h
	inner join [CUATROGDD2018].[Regimen_X_Hotel] rxh on h.id_hotel=rxh.id_hotel and rxh.id_hotel=@idhotel
	inner join [CUATROGDD2018].[Regimenes_Estadia] re on rxh.id_regimen=re.id_regimen
	inner join [CUATROGDD2018].[Habitaciones]  ha on h.id_hotel=ha.id_hotel and h.id_hotel=@idhotel and ha.id_tipo_habitacion=@idTipoHab
	inner join [CUATROGDD2018].[Tipo_Habitacion] th on ha.id_tipo_habitacion=th.id_tipo_habitacion
	WHERE not exists (select 1 FROM [CUATROGDD2018].[Habitacion_X_Reserva] hxr 
					  INNER JOIN [CUATROGDD2018].[Reservas] r
					  ON r.[id_reserva] = hxr.[id_reserva]
					  WHERE hxr.id_habitacion = ha.id_habitacion 
					  and (r.[id_estado_reserva] = 1 or r.[id_estado_reserva] = 2 or r.[id_estado_reserva] = 7)
					  /*Estados de reserva:
					  1: Reserva correcta
					  2: Reserva modificada
					  7: Reserva con ingreso, en curso*/
					  and ((@fechaInicio BETWEEN r.fecha_desde and r.fecha_hasta) and (@fechaFin BETWEEN r.fecha_desde and r.fecha_hasta))
					  )
	and not exists (select 1 from [CUATROGDD2018].[Estadias] e
					where ha.id_habitacion=e.id_habitacion 
					and e.id_usuario_checkOut is null
					and ((@fechaInicio BETWEEN e.fecha_inicio and e.fecha_inicio+e.cant_noches) and (@fechaFin BETWEEN  e.fecha_inicio and e.fecha_inicio+e.cant_noches))
					)
	and not exists (select 1 from [CUATROGDD2018].[Historial_Cierres] hc
					where h.id_hotel=hc.id_hotel 
					and hc.fecha_hasta is null
					and ((@fechaInicio BETWEEN hc.fecha_desde and hc.fecha_desde+hc.cant_diasBaja) and (@fechaFin BETWEEN  hc.fecha_desde and hc.fecha_desde+hc.cant_diasBaja))
					)
	and ha.habilitado='True'
	order by ha.piso,ha.nro_habitacion
 end
else 
 begin
	SELECT distinct ha.id_habitacion
		  ,ha.piso
		  ,ha.nro_habitacion
		  ,case when ha.frente='S' then 'Al frente' else 'Interno' end as ubicacion 
		  ,ha.comodidades
		  ,ha.id_tipo_habitacion
		  ,th.descripcion as tipo_habitacion	
	FROM [CUATROGDD2018].[Hoteles] h
	inner join [CUATROGDD2018].[Regimen_X_Hotel] rxh on h.id_hotel=rxh.id_hotel and rxh.id_hotel=@idhotel
	inner join [CUATROGDD2018].[Regimenes_Estadia] re on rxh.id_regimen=re.id_regimen
	inner join [CUATROGDD2018].[Habitaciones]  ha on h.id_hotel=ha.id_hotel and h.id_hotel=@idhotel 
	inner join [CUATROGDD2018].[Tipo_Habitacion] th on ha.id_tipo_habitacion=th.id_tipo_habitacion
	WHERE not exists (select 1 FROM [CUATROGDD2018].[Habitacion_X_Reserva] hxr 
					  INNER JOIN [CUATROGDD2018].[Reservas] r
					  ON r.[id_reserva] = hxr.[id_reserva]
					  WHERE hxr.id_habitacion = ha.id_habitacion 
					  and (r.[id_estado_reserva] = 1 or r.[id_estado_reserva] = 2 or r.[id_estado_reserva] = 7)
					  /*Estados de reserva:
					  1: Reserva correcta
					  2: Reserva modificada
					  7: Reserva con ingreso, en curso*/
					  and ((@fechaInicio BETWEEN r.fecha_desde and r.fecha_hasta) and (@fechaFin BETWEEN r.fecha_desde and r.fecha_hasta))
					  )
	and not exists (select 1 from [CUATROGDD2018].[Estadias] e
					where ha.id_habitacion=e.id_habitacion 
					and e.id_usuario_checkOut is null
					and ((@fechaInicio BETWEEN e.fecha_inicio and e.fecha_inicio+e.cant_noches) and (@fechaFin BETWEEN  e.fecha_inicio and e.fecha_inicio+e.cant_noches))
					)
	and not exists (select 1 from [CUATROGDD2018].[Historial_Cierres] hc
					where h.id_hotel=hc.id_hotel 
					and hc.fecha_hasta is null
					and ((@fechaInicio BETWEEN hc.fecha_desde and hc.fecha_desde+hc.cant_diasBaja) and (@fechaFin BETWEEN  hc.fecha_desde and hc.fecha_desde+hc.cant_diasBaja))
					)
	and ha.habilitado='True'
	order by ha.piso,ha.nro_habitacion
 end
END

----------------------------------------------------------
--FUNCION QUE DEVUELVE RECARGA DE HOTEL
IF OBJECT_ID('CUATROGDD2018.Fn_DarRecargaHotel') IS NOT NULL
    DROP FUNCTION [CUATROGDD2018].[Fn_DarRecargaHotel]
GO
CREATE FUNCTION [CUATROGDD2018].[Fn_DarRecargaHotel] (@idHotel int)
RETURNS numeric(18,2)
AS BEGIN

    DECLARE @resultado numeric(18,2);
	
    Select @resultado=[cant_estrellas]*[recarga_estrellas]
	from [CUATROGDD2018].[Hoteles]
	where id_hotel=@idHotel
	
    RETURN @resultado
END
GO
--FUNCION QUE DEVUELVE EL PRECIO BASE POR HABITACION
IF OBJECT_ID('CUATROGDD2018.Fn_DarCostoXNoche') IS NOT NULL
    DROP FUNCTION CUATROGDD2018.Fn_DarCostoXNoche
GO
CREATE FUNCTION [CUATROGDD2018].[Fn_DarCostoXNoche] (@idRegimen int,@idTipoHab int)
RETURNS numeric(18,2)
AS BEGIN

    DECLARE @precioBaseReg numeric(18,0);
	DECLARE @porcentual numeric(18,2);
	DECLARE @resultado numeric(18,2);
	
    SELECT @precioBaseReg=[precio_base]
	FROM [CUATROGDD2018].[Regimenes_Estadia]
	where id_regimen=@idRegimen

    SELECT @porcentual=[porcentual]
	FROM [CUATROGDD2018].[Tipo_Habitacion]
	where [id_tipo_habitacion]=@idTipoHab

	set @resultado=@precioBaseReg*@porcentual;
	
    RETURN @resultado
END
GO

--PROCEDIMIENTO QUE CALCULA EL PRECIO X NOCHE
IF OBJECT_ID('CUATROGDD2018.SP_DarCostoHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_DarCostoHabitacion
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_DarCostoHabitacion] 
	@idhotel int,
	@idTipoHab int,
	@idRegimen int
AS
BEGIN
	SELECT [CUATROGDD2018].[Fn_DarCostoXNoche](@idRegimen,@idTipoHab)+[CUATROGDD2018].[Fn_DarRecargaHotel](@idhotel)
END
GO
-----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_Funcionalidad_X_Rol', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_Funcionalidad_X_Rol
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_Funcionalidad_X_Rol] @idRol int
AS
BEGIN
	SELECT F.id_funcionalidad, F.descripcion
	FROM CUATROGDD2018.Roles R 
	INNER JOIN CUATROGDD2018.Funcionalidad_x_Rol FR ON R.id_rol=FR.id_rol
	INNER JOIN CUATROGDD2018.Funcionalidades F ON FR.id_funcionalidad = F.id_funcionalidad
	WHERE R.id_rol=@idRol
END
GO
---------------------------------------------------------
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
	and (h.nombre = @nombre OR @nombre IS NULL OR @nombre = '')
	
END
GO
-----------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_EliminarFuncionalidadXRol') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_EliminarFuncionalidadXRol
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_EliminarFuncionalidadXRol]
	@idRol int,
	@idFuncionalidad int
AS
BEGIN
	DELETE FROM [CUATROGDD2018].[Funcionalidad_X_Rol]
	WHERE id_funcionalidad=@idFuncionalidad AND ID_Rol=@idRol; 
END
GO
-----------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetUsers_IdHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetUsers_IdHotel
GO
create PROCEDURE [CUATROGDD2018].[SP_GetUsers_IdHotel] @idHotel int
AS
BEGIN
	SELECT U.id_usuario,username, password,habilitado 
	FROM [CUATROGDD2018].[Usuarios] U
	INNER JOIN CUATROGDD2018.Usuario_X_Hotel_X_Rol UXHXR on UXHXR.id_usuario=U.id_usuario
	WHERE NOT U.id_usuario=1 and not U.id_usuario=2 and UXHXR.id_hotel=@idHotel
END
GO
--------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetUserPorUsername') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetUserPorUsername
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetUserPorUsername] @username varchar(255), @idHotel int
AS
BEGIN
	SELECT U.id_usuario,username, password,habilitado 
	FROM [CUATROGDD2018].[Usuarios] U
	INNER JOIN CUATROGDD2018.Usuario_X_Hotel_X_Rol UXHXR on UXHXR.id_usuario=U.id_usuario
	WHERE NOT U.id_usuario=1 and not U.id_usuario=2 and UXHXR.id_hotel=@idHotel and U.username=@username
END
GO
---------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetTipoHabitacion_PorID') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetTipoHabitacion_PorID
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetTipoHabitacion_PorID]
	@idTipo int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Tipo_Habitacion] T_H
	WHERE T_H.id_tipo_habitacion = @idTipo
END
GO
--------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetRolesPorID') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetRolesPorID
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
-----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetRegimenPorHotel_DeIdHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetRegimenPorHotel_DeIdHotel
GO
Create PROCEDURE [CUATROGDD2018].[SP_GetRegimenPorHotel_DeIdHotel]
	@idHotel int
AS
BEGIN
	SELECT R.id_regimen, R.descripcion, R.precio_base,RH.habilitado
	FROM [CUATROGDD2018].[Regimenes_Estadia] R 
	JOIN [CUATROGDD2018].[Regimen_X_Hotel] RH ON (RH.id_regimen= R.id_regimen)
	WHERE RH.id_hotel = @idHotel and RH.habilitado='True'
	GROUP BY R.id_regimen, R.descripcion, R.precio_base,RH.habilitado
END
GO
----------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetMenorAnioActividad') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetMenorAnioActividad
GO
CREATE PROCEDURE CUATROGDD2018.SP_GetMenorAnioActividad
AS
	SELECT TOP 1 (YEAR(R.fecha_desde)) AÑO
	FROM CUATROGDD2018.Reservas R
	ORDER BY R.fecha_desde ASC
GO
--------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetHotelPorID') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetHotelPorID
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetHotelPorID]
	@idHotel int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Hoteles] H 
	WHERE H.id_hotel = @idHotel
END
GO
------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetHotelesPorID_IDRol') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetHotelesPorID_IDRol
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetHotelesPorID_IDRol]
	@idUsuario int,
	@idRol int
AS
BEGIN
	SELECT H.* FROM [CUATROGDD2018].[Hoteles] H
	INNER JOIN [CUATROGDD2018].[Usuario_X_Hotel_X_Rol] UHR ON UHR.id_Hotel=H.id_Hotel 
	WHERE UHR.id_usuario = @idUsuario
	ORDER BY H.nombre
END
GO
-------------------------------------------------------------
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
--------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetAllRolesValidos') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetAllRolesValidos
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllRolesValidos]
AS
	SELECT * FROM CUATROGDD2018.Roles
	WHERE habilitado='True'
GO
--------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetAllRoles') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetAllRoles
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllRoles]
AS
	SELECT id_rol,nombre,habilitado from CUATROGDD2018.Roles
GO
--------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_getAllRegimenes', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_getAllRegimenes
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_getAllRegimenes] 
AS
	SELECT * FROM CUATROGDD2018.Regimenes_Estadia
GO
------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetAllHoteles') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetAllHoteles
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllHoteles]
AS
BEGIN
	SELECT * FROM CUATROGDD2018.Hoteles
	ORDER BY nombre
END
---------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetAllHabitacion_PorHotel') IS NOT NULL
    DROP PROCEDURE [CUATROGDD2018].[SP_GetAllHabitacion_PorHotel]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllHabitacion_PorHotel]
	@idHotel int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Habitaciones] 
	WHERE  id_hotel = @idHotel
	ORDER BY nro_habitacion
END
---------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetAllFuncionalidades') IS NOT NULL
    DROP PROCEDURE [CUATROGDD2018].[SP_GetAllFuncionalidades]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllFuncionalidades]
AS
	SELECT * FROM CUATROGDD2018.Funcionalidades
GO
--------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_GetAll_TiposHabitaciones') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetAll_TiposHabitaciones
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAll_TiposHabitaciones]
AS
BEGIN
	SELECT * FROM CUATROGDD2018.Tipo_Habitacion

END
GO
---------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_HotelesComboBox', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_HotelesComboBox
GO
CREATE PROCEDURE CUATROGDD2018.SP_HotelesComboBox
AS
	SELECT id_Hotel, pais + ' - ' + ciudad + ' - ' + calle + ' - Nro de calle ' + CAST(nro_calle as varchar(10)) as dir_Hotel 
	from CUATROGDD2018.Hoteles
GO
------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_HabInhUsuario') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_HabInhUsuario
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_HabInhUsuario]
	@idUsuario int
AS
BEGIN

	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Usuarios] WHERE id_usuario=@idUsuario AND habilitado='False')
		BEGIN
			UPDATE [CUATROGDD2018].[Usuarios] 
			SET [habilitado]='True'
			WHERE id_usuario = @idUsuario
		END
	ELSE 
		BEGIN
			IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Usuarios] WHERE id_usuario=@idUsuario AND habilitado='True')
				BEGIN
					UPDATE [CUATROGDD2018].[Usuarios] 
					SET [habilitado]='False'
					WHERE id_usuario = @idUsuario
				END
		END

END
GO
-------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_HabilitarDeshabilitarHab') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_HabilitarDeshabilitarHab
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_HabilitarDeshabilitarHab]
	@idHabitacion int
AS
BEGIN
	DECLARE @MENSAJE varchar(255);
	--Volver a habilitar habitacion
	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Habitaciones] WHERE id_habitacion=@idHabitacion AND habilitado='False')
	BEGIN
		UPDATE [CUATROGDD2018].[Habitaciones] 
		SET [habilitado]='True'
		WHERE id_habitacion = @idHabitacion
	
		SET @MENSAJE=''
		SELECT @MENSAJE
		RETURN
	END
	--Inhabilitar habitacion
	ELSE IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Habitaciones]
					WHERE id_habitacion=@idHabitacion AND habilitado='True'
					AND (EXISTS (SELECT 1 
								FROM [CUATROGDD2018].[Habitacion_X_Reserva] hxr
								INNER JOIN [CUATROGDD2018].[Reservas] r 
								ON hxr.id_habitacion=@idHabitacion
								and hxr.id_reserva=r.id_reserva
								where r.fecha_desde>=GETDATE())
					OR EXISTS (SELECT 1 
								FROM [CUATROGDD2018].[Estadias] e
								WHERE e.id_habitacion=@idHabitacion and e.id_usuario_checkOut is null))
					)
	BEGIN
		SET @MENSAJE='No puede inhabilitarse. Existe Reserva/Estadía en esa habitacion'
		SELECT @MENSAJE
		RETURN
	END
	ELSE 
	BEGIN
		UPDATE [CUATROGDD2018].[Habitaciones] 
		SET [habilitado]='False'
		WHERE id_habitacion = @idHabitacion

		SET @MENSAJE=''
		SELECT @MENSAJE
		RETURN
	END
END
GO
-----------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_HabilitarDeshabilitarCliente') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_HabilitarDeshabilitarCliente
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_HabilitarDeshabilitarCliente] @idPersona int
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
-------------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_InsertEstadiaXPersona') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_InsertEstadiaXPersona
GO
CREATE PROCEDURE CUATROGDD2018.SP_InsertEstadiaXPersona(
	 @idEstadia int
	,@idPersona int
	)
AS 
BEGIN
	insert into [CUATROGDD2018].[Estadia_X_Persona]([id_persona],[id_estadia])
	values (@idPersona,@idEstadia)
END
GO
--------------------------------------------------------------
/*ELIMINAR RESERVA POR HABITACION*/
IF OBJECT_ID('CUATROGDD2018.SP_QuitarReservaPorHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_QuitarReservaPorHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_QuitarReservaPorHabitacion] (
		@idReserva int,
		@idHabitacion int)
as
BEGIN
	INSERT INTO [CUATROGDD2018].[Habitacion_X_Reserva]([id_habitacion],[id_reserva])
	VALUES (@idHabitacion,@idReserva)
END
GO
/*INSERTAR RESERVA POR HABITACION*/
IF OBJECT_ID('CUATROGDD2018.SP_InsertarReservaPorHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_InsertarReservaPorHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarReservaPorHabitacion] (
		@idReserva int,
		@idHabitacion int)
as
BEGIN
	DELETE [CUATROGDD2018].[Habitacion_X_Reserva]
	WHERE [id_habitacion]=@idHabitacion AND [id_reserva]=@idReserva
END
GO
---------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_InsertarNuevoRegimenXHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_InsertarNuevoRegimenXHotel
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_InsertarNuevoRegimenXHotel]
	@idHotel int,
	@idRegimen int
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Regimen_X_Hotel](id_hotel,id_regimen)
	VALUES(@idHotel,@idRegimen)
END
GO
---------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_infoHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_infoHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_infoHabitacion] @idhotel int
AS
BEGIN
	SELECT id_habitacion, id_tipo_habitacion, piso, frente, nro_habitacion, habilitado, comodidades from [CUATROGDD2018].[Habitaciones]
	WHERE id_hotel=@idhotel
	ORDER BY id_habitacion, id_tipo_habitacion, nro_habitacion
END
GO
----------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_ModificarHotel') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ModificarHotel
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarHotel]
	@id_hotel int,
	@nombre nvarchar(255),
	@pais nvarchar(255),
	@ciudad nvarchar(255), 
	@calle nvarchar(255),
	@nro_calle numeric(18, 0),
	@cant_estrellas numeric(18, 0),
	@recarga_estrellas numeric(18, 0),
	@email nvarchar(255),
	@telefono numeric(18, 0)

AS
BEGIN
	
		UPDATE [CUATROGDD2018].[Hoteles]
		SET [nombre]=@nombre
		   ,[telefono]=@telefono
		   ,[calle]=@calle
		   ,[nro_calle]=@nro_calle
		   ,[ciudad]=@ciudad
		   ,[pais]=@pais
		   ,[cant_estrellas]=@cant_estrellas
		   ,[recarga_estrellas]=@recarga_estrellas
		   ,[email]=@email

		WHERE [id_hotel]=@id_hotel

END
GO
------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_ModificarUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ModificarUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarUsuario] 
		@user varchar(255)
		,@pass varchar(255)
		,@idUsuario int
AS
BEGIN
	UPDATE CUATROGDD2018.Usuarios
	SET username=@user,
	password=@pass
	WHERE id_usuario=@idUsuario
	
END
GO
----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_ModificarRol') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ModificarRol
GO
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
----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_ModificarPersona') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ModificarPersona
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarPersona]
(	
	@id_persona int,
	@nacionalidad nvarchar(255),
	@nro_documento numeric(18, 0), 
	@apellido nvarchar(255), 
	@nombre nvarchar(255),
	@fecha_nac datetime,
	@email nvarchar(255),
	@direccion nvarchar(255),
	@piso numeric(18, 0),
	@depto nvarchar(255),
	@nro_calle numeric(18, 0),
	@estado bit,
	@pais nvarchar(255),
	@telefono numeric(18, 0),
	@tipo_Documento nvarchar(50),
	@localidad nvarchar(255)
)
AS
BEGIN
	DECLARE @MENSAJE nvarchar(255);
	
	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Personas]  WHERE nro_documento = @nro_documento)
	BEGIN
		SET @MENSAJE = 'El numero de documento ya se encuentra registrado'
		SELECT @MENSAJE
		RETURN
	END
	ELSE IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Personas] WHERE email = @email)
	BEGIN
		SET @MENSAJE = 'El mail ya se encuentra registrado'
		SELECT @MENSAJE
		RETURN
	END
	ELSE
		
		UPDATE [CUATROGDD2018].[Personas]
		SET 
			nacionalidad=@nacionalidad,
			nro_documento=@nro_documento,
			nombre=@nombre, 
			apellido=@apellido,
			fecha_nacimiento=@fecha_nac, 
			direccion=@direccion, 
			piso=@piso,
			departamento=@depto, 
			email=@email,
			estado=@estado,
			nro_calle= @nro_calle,
			pais = @pais,
			telefono= @telefono,
			tipo_documento= @tipo_Documento,
			localidad=@localidad 

		WHERE id_persona=@id_persona

END
GO
---------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_ModificarHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ModificarHabitacion
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_ModificarHabitacion] 
		@idHab int
		,@piso numeric(18, 0)
		,@nroHab numeric(18, 0)
		,@frente nvarchar(50)
		,@comodidades varchar(255)
AS
BEGIN
	UPDATE [CUATROGDD2018].[Habitaciones]
	SET piso= @piso, nro_habitacion=@nroHab,  frente= @frente, comodidades=@comodidades 
	WHERE id_habitacion= @idHab
END
GO
---------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_Login') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_Login
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_Login] (
		@usuario varchar(255)
		,@contras varchar(255)
		,@loginCorrecto bit out
		,@idUsuario int out
		,@estaHabilitado bit out)
AS
BEGIN
-- Selecciono el idUsuario con los valores ingresados, si no lo encuentra devuelve null
	--Seteo como falsas las variable
	SET  @loginCorrecto = 0
	SET @estaHabilitado = 1
	SELECT @idUsuario=id_usuario 
	FROM CUATROGDD2018.Usuarios
	WHERE username=@usuario 
	
	SELECT @estaHabilitado=habilitado 
	FROM CUATROGDD2018.Usuarios
	WHERE username=@usuario 

	IF @idUsuario IS NOT NULL
		IF EXISTS (SELECT 1 FROM CUATROGDD2018.Usuarios WHERE username = @usuario AND password=@contras AND habilitado = 'True')
			SET @loginCorrecto = 1
END
GO
-----------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_QuitarRolDeUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_QuitarRolDeUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_QuitarRolDeUsuario] (@idRol int, @idUsuario int)
AS
Begin
	Delete [CUATROGDD2018].[Usuario_X_Hotel_X_Rol]
	where [id_usuario]=@idUsuario and [id_rol]=@idRol
End
--------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_QuitarRegimenDeHotel') IS NOT NULL
    DROP PROCEDURE [CUATROGDD2018].[SP_QuitarRegimenDeHotel]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_QuitarRegimenDeHotel](	
	@idHotel int,
	@idRegimen int
)
AS
BEGIN

	update [CUATROGDD2018].[Regimen_X_Hotel]
	set [habilitado]='False'
	where [id_regimen]=@idRegimen and [id_hotel]=@idHotel
END
GO
------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_ObtenerCiudades', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ObtenerCiudades
GO
CREATE PROCEDURE CUATROGDD2018.SP_ObtenerCiudades
AS
	SELECT DISTINCT ciudad from CUATROGDD2018.Hoteles	
GO
-------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_ObtenerCallesAPartirDeCiudad', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ObtenerCallesAPartirDeCiudad
GO
CREATE PROCEDURE CUATROGDD2018.SP_ObtenerCallesAPartirDeCiudad
	@ciudad nvarchar(255)
AS	
	SELECT id_Hotel, calle + ' ' + CAST(nro_calle as varchar(10)) as calles 
	from CUATROGDD2018.Hoteles
	where ciudad like '%'+@ciudad+'%'
GO
----------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_NuevaReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_NuevaReserva
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_NuevaReserva]
	@idPersona int,
	@idRegimen int,
	@idUsu int,
	@fechaReserva date,
	@fechaDesde date,
	@fechaHasta date,
	@cantNoches int
	
AS
BEGIN
	INSERT INTO [CUATROGDD2018].[Reservas](id_persona,id_regimen,id_estado_reserva,fecha_reserva,fecha_desde,fecha_hasta,cantidad_noches,[id_usuario_reserva])
	VALUES (@idPersona,@idRegimen,1,@fechaReserva,@fechaDesde,@fechaHasta,@cantNoches,@idUsu)
	-- estado 1= reserva correcta
	DECLARE @idNuevaReserva int
	SET @idNuevaReserva = @@IDENTITY
	
	SELECT @idNuevaReserva
END
GO
----------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_RolesXHotel', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_RolesXHotel
GO
CREATE PROCEDURE CUATROGDD2018.SP_RolesXHotel @idUsuario int
AS

	SELECT H.id_hotel, R.id_rol, R.nombre+'-'+H.nombre as 'Rol-Hotel'
	FROM CUATROGDD2018.Usuario_X_Hotel_X_Rol as UxHxR
	INNER JOIN CUATROGDD2018.Hoteles as H on UxHxR.id_hotel=H.id_hotel
	INNER JOIN CUATROGDD2018.Roles as R on R.id_rol=UxHxR.id_rol
	WHERE UxHxR.id_usuario=@idUsuario

GO
-------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_RolesComboBox', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_RolesComboBox
GO
CREATE PROCEDURE CUATROGDD2018.SP_RolesComboBox
AS
	SELECT id_rol, nombre from CUATROGDD2018.Roles
	WHERE nombre != 'GUEST' AND nombre != 'Administrador General'
GO
----------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_RegimenEstadia') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_RegimenEstadia
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_RegimenEstadia] 
AS
BEGIN
	select id_regimen, descripcion 
	from [CUATROGDD2018].[Regimenes_Estadia]
END
--------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_VerificarUsuario') IS NOT NULL
    DROP PROCEDURE [CUATROGDD2018].[SP_VerificarUsuario]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_VerificarUsuario] @usuario varchar(255), @idUsuario int
AS
BEGIN
	DECLARE @esValido bit
	SET @esValido='True'
	IF EXISTS (SELECT 1 FROM CUATROGDD2018.Usuarios WHERE username = @usuario and NOT id_usuario=@idUsuario) 
		SET @esValido='False'
	SELECT @esValido
END
GO
------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.SP_ValidarDatosPersona') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_ValidarDatosPersona
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_ValidarDatosPersona]  
		@tipoDNI nvarchar(50)
		,@nroDNI numeric(18,0)
		,@emailPer nvarchar (255)
		,@idPersona int
AS
BEGIN
	DECLARE @esValido bit
	SET @esValido='True'
	if @idPersona = 0
	  begin
		IF EXISTS (SELECT 1 FROM CUATROGDD2018.Personas WHERE (tipo_documento = @tipoDNI AND nro_documento=@nroDNI) OR email = @emailPer)
				SET @esValido = 'False'
		end
	ELSE
		begin
			IF EXISTS (SELECT 1 FROM CUATROGDD2018.Personas WHERE ((tipo_documento = @tipoDNI AND nro_documento=@nroDNI) OR email = @emailPer ) AND NOT id_persona=@idPersona) 
				SET @esValido = 'False'
		end
	SELECT @esValido
END
GO
-------------------------------------------------------------------
IF OBJECT_ID('CUATROGDD2018.FN_PerteneceATrimestre') IS NOT NULL
    DROP FUNCTION CUATROGDD2018.FN_PerteneceATrimestre
GO
--Funcion Para saber si una fecha pertenece al trimestre seleccionado
CREATE FUNCTION CUATROGDD2018.FN_PerteneceATrimestre ( @anio int, @trimestre int , @fecha datetime)
RETURNS bit
AS BEGIN
	DECLARE @pertenece bit

	set @pertenece = CASE WHEN  (@anio = YEAR(@fecha) and @trimestre=DATEPART(QUARTER,@fecha)) then 0
					 ELSE 1
					 END
	RETURN @pertenece
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopHotelesConReservasCanceladas') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopHotelesConReservasCanceladas
GO
/*Además el sistema nos pedirá que ingresemos obligatoriamente el año por el cual
queremos consultar, luego nos pedirá el trimestre*/
CREATE PROCEDURE CUATROGDD2018.SP_TopHotelesConReservasCanceladas ( @anio int, @trimestre int )
AS 
BEGIN
	SELECT top 5 ho.pais
				,ho.nombre as hotel
				,count (1) as [cantidad de reservas canceladas]
	FROM [CUATROGDD2018].[Reservas] r
	JOIN [CUATROGDD2018].[Habitacion_X_Reserva]  hxr 
	on r.id_reserva=hxr.id_reserva
	JOIN [CUATROGDD2018].[Habitaciones] ha
	on hxr.id_habitacion=ha.id_habitacion
	JOIN [CUATROGDD2018].[Hoteles] ho
	on ha.id_hotel=ho.id_hotel
	WHERE r.id_estado_reserva in ( 3, 4, 5 ) and  @anio = YEAR(r.fecha_desde) and @trimestre=DATEPART(QUARTER,r.fecha_desde)
	GROUP BY ho.pais,ho.nombre
	ORDER BY  [cantidad de reservas canceladas] DESC
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopHotelesConsumiblesFacturados') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopHotelesConsumiblesFacturados
GO
/*Hoteles con mayor cantidad de consumibles facturados.*/
CREATE PROCEDURE CUATROGDD2018.SP_TopHotelesConsumiblesFacturados (@anio int, @trimestre int )
AS 
BEGIN
	SELECT top 5 ho.pais
				,ho.nombre as hotel
				,sum(cxe.cantidad) as [cantidad de consumibles facturados]
	FROM [CUATROGDD2018].[Facturas] f
	JOIN [CUATROGDD2018].[Estadias] e
	on f.id_estadia=e.id_estadia
	JOIN [CUATROGDD2018].[Consumible_X_Estadia] cxe
	on e.id_estadia=cxe.id_estadia
	JOIN [CUATROGDD2018].[Habitaciones] ha
	on e.id_habitacion=ha.id_habitacion
	JOIN [CUATROGDD2018].[Hoteles] ho
	on ha.id_hotel=ho.id_hotel
	WHERE @anio = YEAR(f.fecha) and @trimestre=DATEPART(QUARTER,f.fecha)
	GROUP BY ho.pais,ho.nombre
	ORDER BY [cantidad de consumibles facturados] DESC
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopHotelesDiasSinServ') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopHotelesDiasSinServ
GO
/*Hoteles con mayor cantidad de días fuera de servicio.*/
CREATE PROCEDURE CUATROGDD2018.SP_TopHotelesDiasSinServ ( @anio int, @trimestre int )
AS
BEGIN
	SELECT top 5 ho.pais
				,ho.nombre as hotel
				,SUM(cie.cant_diasBaja) as [dias fuera de servicio]
	FROM [CUATROGDD2018].[Hoteles] ho
	JOIN [CUATROGDD2018].[Historial_Cierres] cie 
	on ho.id_hotel=cie.id_hotel
	WHERE @anio = YEAR(cie.fecha_desde) and @trimestre=DATEPART(QUARTER,cie.fecha_desde)
	GROUP BY ho.pais,ho.nombre
	ORDER BY [Dias fuera de servicio] DESC
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopHabitacionOcupadas') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopHabitacionOcupadas
GO
/*Habitaciones con mayor cantidad de días y veces que fueron ocupadas, informando a demás a que hotel pertenecen.*/
CREATE PROCEDURE CUATROGDD2018.SP_TopHabitacionOcupadas ( @anio int, @trimestre int )
AS
BEGIN
	SELECT top 5 ho.pais
				,ho.nombre as hotel
				,ha.piso
				,ha.nro_habitacion as [numero]
				,case when ha.frente='N' then 'Al frente' else 'Interno' end as ubicacion
				,th.descripcion as [tipo de habitacion]
				,sum(est.cant_noches) as [cantidad dias ocupado]
				,count(ha.id_habitacion) as [cantidad veces ocupado]
	FROM [CUATROGDD2018].[Habitaciones] ha
	JOIN [CUATROGDD2018].[Tipo_Habitacion] th
	on ha.id_tipo_habitacion=th.id_tipo_habitacion
	JOIN [CUATROGDD2018].[Estadias] est 
	on ha.id_habitacion=est.id_habitacion
	JOIN [CUATROGDD2018].[Hoteles] ho
	on ha.id_hotel=ho.id_hotel
	WHERE @anio = YEAR(est.fecha_inicio) and @trimestre=DATEPART(QUARTER,est.fecha_inicio)
	GROUP BY ho.pais,ho.nombre,ha.piso,ha.nro_habitacion,ha.frente,th.descripcion
	ORDER BY [cantidad dias ocupado] DESC
END
GO

IF OBJECT_ID('CUATROGDD2018.SP_TopClientesConMasPuntos') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_TopClientesConMasPuntos
GO
/*Cliente con mayor cantidad de puntos, donde cada $20 en estadías vale 1
puntos y cada $10 de consumibles es 1 punto, de la sumatoria de todas las
facturaciones que haya tenido dentro de un periodo independientemente
del Hotel. Tener en cuenta que la facturación siempre es a quien haya
realizado la reserva.*/
CREATE PROCEDURE CUATROGDD2018.SP_TopClientesConMasPuntos ( @anio int, @trimestre int )
AS
BEGIN
	SELECT top 5 p.tipo_documento as [tipo documento]
				,p.nro_documento as [numero]
				,p.nombre
				,p.apellido
				,p.email
				,sum(f.puntos_obtenidos) as [puntos acumulados]
	FROM [CUATROGDD2018].[Facturas] f
	JOIN [CUATROGDD2018].[Personas] p 
	on f.id_persona=p.id_persona
	WHERE @anio = YEAR(f.fecha) and @trimestre=DATEPART(QUARTER,f.fecha)
	GROUP BY p.tipo_documento,p.nro_documento,p.nombre,p.apellido,p.email
	ORDER BY [puntos acumulados] DESC
END
GO
