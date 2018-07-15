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