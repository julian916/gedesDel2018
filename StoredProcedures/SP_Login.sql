USE GD1C2018
GO
IF OBJECT_ID('CUATROGDD2018.SP_Login', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_Login
GO
CREATE PROCEDURE CUATROGDD2018.SP_Login @usuario varchar(255), @contras varchar(255)
AS
-- Selecciono el idUsuario con los valores ingresados, si lo encuentra devuelve null
	DECLARE @idUsuario int
	SELECT @idUsuario=Usu.id_usuario 
	FROM CUATROGDD2018.Usuarios as Usu
	WHERE Usu.username=@usuario AND Usu.password=HASHBYTES('SHA2_256', @contras)
	SELECT @idUsuario
GO
