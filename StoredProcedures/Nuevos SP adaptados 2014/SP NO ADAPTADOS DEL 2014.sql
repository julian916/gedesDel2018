/****** Object:  UserDefinedFunction [LOS_NULL].[CANTIDAD_DIAS_SIN_SERVICIO]    Script Date: 11/11/2014 21:57:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [LOS_NULL].[CANTIDAD_DIAS_SIN_SERVICIO]
(
	@ID_HOTEL numeric (18,0),
	@FECHA datetime
)

RETURNS numeric (18,0)

AS
BEGIN
	
	RETURN
	(
	SELECT SUM (DATEDIFF(day,Fecha_Inicio,LOS_NULL.MENOR_FECHA(Fecha_Fin,@FECHA))) FROM   
		(SELECT Id_Hotel FROM LOS_NULL.Hotel WHERE Id_Hotel = @ID_HOTEL) HO 
		JOIN LOS_NULL.BajaTemporalHotel BH ON (HO.Id_Hotel = BH.Id_Hotel)
		WHERE DATEDIFF (QUARTER,Fecha_Inicio,@FECHA)=0
	)

	/*--utilizo la funcion MENOR_FECHA para lo siguiente:
	Si por ejemplo:
	Fecha_Inicio_de_baja=11/3/2014
	Fecha_Fin_de_baja=2/4/2014
	Entonces, la fecha de fin supera el primer trimestre de consulta (que termina el 31/3/2014)
	Utilizando esta funcion, me va a devolver la cantidad de dias inhabilitados desde inicio hasta la fecha limite del fin del trimestre
	Por ahi esta demás, pero me parece logico
	
	*/
	
END
GO
/****** Object:  Table [LOS_NULL].[CancelacionReserva]    Script Date: 11/11/2014 21:57:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [LOS_NULL].[CancelacionReserva](
	[ID_Cancelacion] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Motivo] [nvarchar](255) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Usuario] [nvarchar](255) NOT NULL,
	[Codigo_Reserva] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_CancelacionReserva] PRIMARY KEY CLUSTERED 
(
	[ID_Cancelacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [LOS_NULL].[DAMEMENORFECHA]    Script Date: 11/11/2014 21:57:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [LOS_NULL].[DAMEMENORFECHA] 

AS
BEGIN
	
	SELECT TOP 1 (YEAR(R.Fecha_Inicio)) AÑO
	FROM LOS_NULL.Reserva R
	ORDER BY R.Fecha_Inicio ASC
	
END
GO