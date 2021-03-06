--Creo tipo de dato tabla para tener info de la persona, y pasarlo como parametro
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

IF OBJECT_ID('CUATROGDD2018.SP_altaPersona', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_altaPersona
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_altaPersona] ( @datosIngresadosPersona as [CUATROGDD2018].[datosPersonaType] READONLY)
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

