create procedure SP_Migración_Personas as
begin

	/*Creo tabla Personas*/
	CREATE TABLE [dbo].[Personas](
		[id_persona] [int] IDENTITY(1,1) NOT NULL,
		[tipo_documento] [nvarchar](50) NOT NULL DEFAULT('No informado'),
		[nro_documento] [numeric](18, 0) UNIQUE NOT NULL,
		[email] [nvarchar](255) UNIQUE NOT NULL,
		[nombre] [nvarchar](255) NOT NULL,
		[apellido] [nvarchar](255) NOT NULL,
		[telefono] [int] NOT NULL DEFAULT(0),
		[nacionalidad] [nvarchar](255) NULL,
		[direccion] [nvarchar](50) NULL,
		[nro_calle] [nvarchar](50) NULL,
		[piso] [nvarchar](50) NULL,
		[departamento] [nvarchar](50) NULL,
		[localidad] [nvarchar](50) NULL DEFAULT('No informado'),
		[pais] [nvarchar](50) NULL DEFAULT('No informado'),
		[fecha_nacimiento] [datetime] NULL,
		[estado] [nvarchar](50) NULL,
		[id_usuario] [int] NULL,
		foreign key ([id_usuario]) references [dbo].[Usuarios]([id_usuario]),
		primary key ([id_persona])
	);

	/*Creo tabla para registrar personas duplicadas*/
	CREATE TABLE [dbo].Personas_Repetidas(
		[nro_documento] [numeric](18, 0) NOT NULL,
		[email] [nvarchar](255) NOT NULL,
		[tipo_documento] [nvarchar](50) NULL,
		[nombre] [nvarchar](255) NULL,
		[apellido] [nvarchar](255) NULL,
		[nacionalidad] [nvarchar](255) NULL,
		[fecha_nacimiento] [nvarchar](255) NULL
	) ON [PRIMARY];
	

	/*Genero una consulta utilizando row_number() para contabilizar la cantidad de recurrencia de un documento y un email
		para luego filtrar con recurrencia igual a 1 tal que pueda alimentar la entidad personas sin los duplicados*/
	with clientes as(
	  SELECT Cliente_Pasaporte_Nro as nro_documento
				,Cliente_Mail as email
				,Cliente_Nombre as nombre
				,Cliente_Apellido as apellido
				,Cliente_Nacionalidad as nacionalidad
				,Cliente_Fecha_Nac as fecha_nac
				,Cliente_Dom_Calle as calle
				,Cliente_Nro_Calle as nro_calle
				,Cliente_Piso as piso
				,Cliente_Depto as depto
				,row_number() OVER(PARTITION BY Cliente_Pasaporte_Nro ORDER BY Cliente_Mail) AS cantDocumentos
				,row_number() OVER(PARTITION BY [Cliente_Mail] ORDER BY Cliente_Mail) AS cantEmail
	  FROM [Tabla_Maestra]
	  GROUP BY	Cliente_Pasaporte_Nro
				,Cliente_Mail
				,Cliente_Nombre
				,Cliente_Apellido
				,Cliente_Nacionalidad
				,Cliente_Dom_Calle
				,Cliente_Nro_Calle
				,Cliente_Piso
				,Cliente_Depto
				,Cliente_Fecha_Nac
	)	
		/*Inserto tabla temporal*/
		select * into #temp_clientes 
		from clientes;

	/*Inserto la entidad Personas teniendo como filtro que cantidad de recurrencia de documentos e email sean unicas*/
	insert into [Personas](
					[nro_documento]
					,[email]
					,[nombre]
					,[apellido]
					,[nacionalidad]
					,[direccion]
					,[nro_calle]
					,[piso]
					,[departamento]
					,[fecha_nacimiento]
					)
	select nro_documento
			,email
			,nombre
			,apellido
			,nacionalidad
			,calle
			,nro_calle
			,piso
			,depto 
			,fecha_nac
	from #temp_clientes
	where cantDocumentos=1 and cantEmail=1
	order by nro_documento,email;--84.507 registros insertados
	print	'Insersión de personas finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';

	/*Inserto table Personas_Repetidas teniendo como filtro lo opuesto al filtro anterior*/
	insert into [dbo].[Personas_Repetidas](
			[nro_documento]
			,[email]
			,[nombre]
			,[apellido]
			,[nacionalidad]
			,[fecha_nacimiento])
	select nro_documento
			,email
			,nombre
			,apellido
			,nacionalidad
			,fecha_nac
	from #temp_clientes 
	where cantDocumentos>1 or cantEmail>1
	order by [nro_documento],[email]
	print	'Insersión de personas duplicadas finalizada - ' + convert(varchar,@@rowcount) + ' registros insertados.';

	/*Borro tabla temporal*/
	drop table #temp_clientes;
end
