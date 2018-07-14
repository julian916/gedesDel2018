IF OBJECT_ID('CUATROGDD2018.SP_InsertarConsubleXEstadia') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_InsertarConsubleXEstadia
GO
CREATE PROCEDURE CUATROGDD2018.SP_InsertarConsubleXEstadia  
	@idEstadia int, 
	@idConsumible int,
	@cantidad int
AS
BEGIN
	declare @monto numeric(18,2)

	select @monto=precio*@cantidad
	from [CUATROGDD2018].[Consumibles]
	where id_consumible=@idConsumible
	
	Insert into [CUATROGDD2018].[Consumible_X_Estadia]([id_estadia],[id_consumible],[cantidad],[monto])
	Values (@idEstadia,@idConsumible,@cantidad,@monto)
END
GO