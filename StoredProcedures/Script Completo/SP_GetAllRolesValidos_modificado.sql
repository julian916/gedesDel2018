CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllRolesValidos]
AS
	SELECT * FROM CUATROGDD2018.Roles
	WHERE habilitado='True' AND NOT id_rol=1
