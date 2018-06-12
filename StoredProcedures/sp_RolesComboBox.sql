USE GD1C2018
GO
IF OBJECT_ID('dbo.sp_RolesComboBox', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_RolesComboBox
GO
CREATE PROCEDURE dbo.sp_RolesComboBox
AS
	SELECT id_rol, nombre from Roles
GO
