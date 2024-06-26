USE [DCEDb]
GO
/****** Object:  StoredProcedure [dbo].[USP_Customer_GetCustomer]    Script Date: 5/8/2024 4:39:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Muditha Weerarathna>
-- Create date: <2024-05-08>
-- Description:	<get customer details>
-- =============================================
ALTER PROCEDURE [dbo].[USP_Customer_GetCustomer] 
	@Instance	INT
AS
BEGIN

	SET NOCOUNT ON;

	IF(@Instance = 0)
	BEGIN
		SELECT	*
		FROM	Customer c
	END

END
