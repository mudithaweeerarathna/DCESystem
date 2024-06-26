USE [DCEDb]
GO
/****** Object:  StoredProcedure [dbo].[USP_Customer_CreateCustomer]    Script Date: 5/8/2024 4:39:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Muditha Weerarathna>
-- Create date: <2024-05-08>
-- Description:	<insert update customer>
-- =============================================
ALTER PROCEDURE [dbo].[USP_Customer_CreateCustomer]
	@Instance	INT,
	@UserId		UNIQUEIDENTIFIER,
	@UserName	VARCHAR(30),
	@Email		VARCHAR(20),
	@FirstName	VARCHAR(20),
	@LastName	VARCHAR(20),
	@CreatedOn	DATETIME,
	@IsActive	BIT = 1
AS
BEGIN

	SET NOCOUNT ON;

	IF(@Instance = 0)
	BEGIN
		INSERT INTO Customer
		(
			UserId,
			UserName,
			Email,
			FirstName,
			LastName,
			CreatedOn,
			IsActive
		)
		VALUES
		(
			@UserId,
			@UserName,
			@Email,
			@FirstName,
			@LastName,
			@CreatedOn,
			@IsActive
		)

	END
	ELSE IF(@Instance = 1)
	BEGIN
		UPDATE	Customer
		SET		UserName = @UserName,
				Email = @Email,
				FirstName = @FirstName,
				LastName = @LastName,
				IsActive = @IsActive
		WHERE	UserId = @UserId
	END

END
