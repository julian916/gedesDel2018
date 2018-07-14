USE [GD1C2018]
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_ValidarDatosPersona]  @tipoDNI nvarchar(50),@nroDNI numeric(18,0),@emailPer nvarchar (255),@idPersona int
AS
BEGIN
	DECLARE @esValido bit
	SET @esValido='True'
	if @idPersona = 0
	  begin
		IF EXISTS (SELECT * FROM CUATROGDD2018.Personas WHERE (tipo_documento = @tipoDNI AND nro_documento=@nroDNI) OR email = @emailPer)
				SET @esValido = 'False'
		end
	ELSE
		begin
			IF EXISTS (SELECT * FROM CUATROGDD2018.Personas WHERE ((tipo_documento = @tipoDNI AND nro_documento=@nroDNI) OR email = @emailPer ) AND NOT id_persona=@idPersona) 
				SET @esValido = 'False'
		end
	SELECT @esValido
END