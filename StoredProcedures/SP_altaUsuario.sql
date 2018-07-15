IF OBJECT_ID('CUATROGDD2018.SP_AltaUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_AltaUsuario] @usuario varchar(255), @password varchar(255)
AS
Begin
	DECLARE @id int
	INSERT INTO CUATROGDD2018.Usuarios (username, password)
	VALUES (@usuario,@password)
	SELECT @id=SCOPE_IDENTITY() 
	FROM [CUATROGDD2018].[Usuarios]
		 
End
GO
