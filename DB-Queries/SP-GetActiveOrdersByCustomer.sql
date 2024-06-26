USE [DCEDb]
GO
/****** Object:  StoredProcedure [dbo].[USP_Order_GetActiveOrdersByCustomer]    Script Date: 5/8/2024 4:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Muditha Weerarathna>
-- Create date: <2024-05-08>
-- Description:	<active orders by customer>
-- =============================================
ALTER PROCEDURE [dbo].[USP_Order_GetActiveOrdersByCustomer]
	@Instance		INT,
	@CustomerId		UNIQUEIDENTIFIER
AS
BEGIN

	SET NOCOUNT ON;

	IF(@Instance = 0)
	BEGIN
		SELECT	O.OrderId,
				O.ProductId,
				O.OrderStatus,
				O.OrderType,
				O.OrderBy,
				O.OrderedOn [OrderDate],
				O.ShippedOn,
				O.IsActive [OrderActive],
				P.ProductName,
				P.UnitPrice,
				P.SupplierId,
				P.CreatedOn [ProductCreatedOn],
				P.IsActive [ProductActive],
				S.SupplierName,
				S.CreatedOn [SupplierCreatedOn],
				S.IsActive [SupplierActive]
		
		FROM	[dbo].[Order] O
		LEFT JOIN [dbo].[Customer] C ON C.UserId = O.OrderBy
		INNER JOIN [dbo].[Product] P ON P.ProductId = O.ProductId
		INNER JOIN [dbo].[Supplier] S ON P.SupplierId = S.SupplierId
		WHERE	C.UserId = @CustomerId
	END
END
