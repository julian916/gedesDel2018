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