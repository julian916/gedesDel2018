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