IF OBJECT_ID('CUATROGDD2018.SP_GetAllRoles') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetAllRoles
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllRoles]
AS
	SELECT id_rol,nombre,habilitado from CUATROGDD2018.Roles
GO
