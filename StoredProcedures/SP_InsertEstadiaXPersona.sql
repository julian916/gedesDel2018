IF OBJECT_ID('CUATROGDD2018.SP_InsertEstadiaXPersona') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_InsertEstadiaXPersona
GO
CREATE PROCEDURE CUATROGDD2018.SP_InsertEstadiaXPersona(
	 @idEstadia int
	,@idPersona int
	)
AS 
BEGIN
	insert into [CUATROGDD2018].[Estadia_X_Persona]([id_persona],[id_estadia])
	values (@idPersona,@idEstadia)
END
GO