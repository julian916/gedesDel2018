USE GD1C2018
GO
IF OBJECT_ID('CUATROGDD2018.SP_bloquerUsuario', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_bloquerUsuario
GO
CREATE PROCEDURE CUATROGDD2018.SP_bloquerUsuario @idUsuario int
AS
	UPDATE CUATROGDD2018.Usuarios  
	SET habilitado = 'False' 
	WHERE id_usuario = @idUsuario;  

GO

