USE [GD1C2018]
GO
/****** Object:  StoredProcedure [CUATROGDD2018].[SP_RolesComboBox]    Script Date: 9/7/2018 15:55:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAllRoles]
AS
	SELECT id_rol,nombre,habilitado from CUATROGDD2018.Roles
