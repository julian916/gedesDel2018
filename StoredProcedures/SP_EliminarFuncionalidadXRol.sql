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