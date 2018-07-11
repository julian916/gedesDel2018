CREATE PROCEDURE [CUATROGDD2018].[SP_AltaRol]
	@nombre varchar(50)
AS
BEGIN
	DECLARE @id int
	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Roles] WHERE [nombre]=@nombre)
		BEGIN
			SET @id=-1
		END
	ELSE 
		BEGIN
			INSERT INTO [CUATROGDD2018].[Roles] (nombre)
			VALUES (@nombre)
			SET @id = @@IDENTITY
		END	
	SELECT @id
END
GO
