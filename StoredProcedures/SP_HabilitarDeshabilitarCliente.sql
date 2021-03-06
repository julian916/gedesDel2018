IF OBJECT_ID('CUATROGDD2018.SP_HabilitarDeshabilitarCliente') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_HabilitarDeshabilitarCliente
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_HabilitarDeshabilitarCliente] @idPersona int
AS
BEGIN
	UPDATE CUATROGDD2018.Personas
	SET estado = CASE	WHEN estado='Habilitado' THEN 'Deshabilitado'
						WHEN estado='Deshabilitado' THEN 'Habilitado'
						ELSE estado
						END
	WHERE CUATROGDD2018.Personas.id_persona=@idPersona	

END
GO