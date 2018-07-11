USE [GD1C2018]
GO
/****** Object:  StoredProcedure [CUATROGDD2018].[SP_AltaUsuario]    Script Date: 14/6/2018 22:29:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF OBJECT_ID('CUATROGDD2018.SP_AltaUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_AltaUsuario
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_AltaUsuario] @usuario varchar(255), @password varchar(255)
AS
Begin
	DECLARE @id int
	INSERT INTO CUATROGDD2018.Usuarios (username, password)
	VALUES (@usuario,@password)
	SELECT @id=SCOPE_IDENTITY() FROM [CUATROGDD2018].[Usuarios]
		 
End
