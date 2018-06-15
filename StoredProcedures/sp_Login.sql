USE GD1C2018
GO
IF OBJECT_ID('dbo.sp_Login', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Login
GO
CREATE PROCEDURE dbo.sp_Login @usuario varchar(255), @contras varchar(255)
AS
	SELECT * 
	FROM Personas
	JOIN Usuarios ON Usuarios.id_usuario=Personas.id_usuario
	WHERE Usuarios.username=@usuario AND Usuarios.password=HASHBYTES('SHA2_256', @contras)
GO
