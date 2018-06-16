USE GD1C2018
GO
IF OBJECT_ID('dbo.sp_Login', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Login
GO
CREATE PROCEDURE dbo.sp_Login @usuario varchar(255), @contras varchar(255)
AS
	SELECT * 
	FROM Personas
	JOIN CUATROGDD2018.Usuarios ON CUATROGDD2018.Usuarios.id_usuario=CUATROGDD2018.Personas.id_usuario
	WHERE CUATROGDD2018.Usuarios.username=@usuario AND CUATROGDD2018.Usuarios.password=HASHBYTES('SHA2_256', @contras)
GO
