IF OBJECT_ID('CUATROGDD2018.SP_Login') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_Login
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_Login] (
		@usuario varchar(255)
		,@contras varchar(255)
		,@loginCorrecto bit out
		,@idUsuario int out
		,@estaHabilitado bit out)
AS
BEGIN
-- Selecciono el idUsuario con los valores ingresados, si no lo encuentra devuelve null
	--Seteo como falsas las variable
	SET  @loginCorrecto = 0
	SET @estaHabilitado = 1
	SELECT @idUsuario=id_usuario 
	FROM CUATROGDD2018.Usuarios
	WHERE username=@usuario 
	
	SELECT @estaHabilitado=habilitado 
	FROM CUATROGDD2018.Usuarios
	WHERE username=@usuario 

	IF @idUsuario IS NOT NULL
		IF EXISTS (SELECT 1 FROM CUATROGDD2018.Usuarios WHERE username = @usuario AND password=@contras AND habilitado = 'True')
			SET @loginCorrecto = 1
END
GO
