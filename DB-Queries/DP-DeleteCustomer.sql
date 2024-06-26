USE [DCEDb]
GO
/****** Object:  StoredProcedure [dbo].[USP_Customer_DeleteCustomer]    Script Date: 5/8/2024 4:39:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Muditha Weerarathna>
-- Create date: <2024-05-08>
-- Description:	<delete customer>
-- =============================================
ALTER PROCEDURE [dbo].[USP_Customer_DeleteCustomer] 
	@Instance	INT,
	@UserId		UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	IF(@Instance = 0)
	BEGIN
		DELETE	Customer
		WHERE	UserId = @UserId
	END
END
