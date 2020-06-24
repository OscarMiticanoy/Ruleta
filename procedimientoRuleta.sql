USE [ruletadb]
GO
/****** Object:  StoredProcedure [dbo].[insertRuleta]    Script Date: 24/06/2020 9:44:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Oscar Miticanoy>
-- Create date: <Create Date,,23-06-2020>
-- Description:	<Description,,insert and return key>
-- =============================================
ALTER PROCEDURE [dbo].[insertRuleta]
	@id int output,
	@state bit,
	@number int,
	@color bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ruletas(state,number,color)
	VALUES (@state, @number, @color)
   
    SELECT SCOPE_IDENTITY();
END
