CREATE PROCEDURE [CUATROGDD2018].[SP_HabInhUsuario]
	@idUsuario int
AS
BEGIN

	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Usuarios] WHERE id_usuario=@idUsuario AND habilitado='False')
		BEGIN
			UPDATE [CUATROGDD2018].[Usuarios] 
			SET [habilitado]='True'
			WHERE id_usuario = @idUsuario
		END
	ELSE 
		BEGIN
			IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Usuarios] WHERE id_usuario=@idUsuario AND habilitado='True')
				BEGIN
					UPDATE [CUATROGDD2018].[Usuarios] 
					SET [habilitado]='False'
					WHERE id_usuario = @idUsuario
				END
		END

END
