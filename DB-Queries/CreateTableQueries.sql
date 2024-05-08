--Query to create customer table
CREATE TABLE [dbo].[Customer] (
	UserId		UNIQUEIDENTIFIER PRIMARY KEY,
	UserName	VARCHAR(30) NOT NULL,
	Email		VARCHAR(20) NOT NULL,
	FirstName	VARCHAR(20) NOT NULL,
	LastName	VARCHAR(20) NOT NULL,
	CreatedOn	DATETIME DEFAULT GETDATE() NOT NULL ,
	IsActive	BIT DEFAULT 1
)

--query to create supplier table
CREATE TABLE [dbo].[Supplier] (
	SupplierId		UNIQUEIDENTIFIER PRIMARY KEY,
	SupplierName	VARCHAR(50) NOT NULL,
	CreatedOn		DATETIME DEFAULT GETDATE() NOT NULL,
	IsActive		BIT DEFAULT 1
)

--query to create product table
CREATE TABLE [dbo].[Product] (
	ProductId	UNIQUEIDENTIFIER PRIMARY KEY,
	ProductName	VARCHAR(50) NOT NULL,
	UnitPrice	DECIMAL (18, 2) NOT NULL,
	SupplierId	UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Supplier (SupplierId) NOT NULL,
	CreatedOn	DATETIME DEFAULT GETDATE() NOT NULL,
	IsActive	BIT DEFAULT 1 NOT NULL
)

--query to create order table
CREATE TABLE [dbo].[Order] (
	OrderId		UNIQUEIDENTIFIER PRIMARY KEY,
	ProductId	UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Product (ProductId) NOT NULL,
	OrderStatus	TINYINT NOT NULL,
	OrderType	TINYINT NOT NULL,
	OrderBy		UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Customer (UserId) NOT NULL,
	OrderedOn	DATETIME NOT NULL,
	ShippedOn	DATETIME NOT NULL,
	IsActive	BIT DEFAULT 1 NOT NULL
)


--query to insert dummy data into supplier table
INSERT INTO [dbo].[Supplier]
(
	SupplierId,
	SupplierName,
	CreatedOn,
	IsActive
)	
VALUES
(
	NEWID(),
	'Supplier Name One',
	GETDATE(),
	1
)

--query to insert two dummy data into product table
INSERT INTO [dbo].[Product]
(
	ProductId,
	ProductName,
	UnitPrice,
	SupplierId,
	CreatedOn,
	IsActive
)
VALUES
(
	NEWID(),
	'Product Name One',
	100.00,
	(SELECT TOP(1) SupplierId FROM Supplier),
	GETDATE(),
	1
)
INSERT INTO [dbo].[Product]
(
	ProductId,
	ProductName,
	UnitPrice,
	SupplierId,
	CreatedOn,
	IsActive
)
VALUES
(
	NEWID(),
	'Product Name Two',
	100.00,
	(SELECT TOP(1) SupplierId FROM Supplier),
	GETDATE(),
	1
)

--query to insert two orders from each product
INSERT INTO [dbo].[Order]
(
	OrderId,
	ProductId,
	OrderStatus,
	OrderType,
	OrderBy,
	OrderedOn,
	ShippedOn,
	IsActive
)
VALUES
(
	NEWID(),
	(SELECT TOP(1) ProductId FROM [dbo].[Product]),
	0,
	0,
	(SELECT TOP(1) UserId FROM Customer),
	GETDATE(),
	GETDATE(),
	1
)

INSERT INTO [dbo].[Order]
(
	OrderId,
	ProductId,
	OrderStatus,
	OrderType,
	OrderBy,
	OrderedOn,
	ShippedOn,
	IsActive
)
VALUES
(
	NEWID(),
	(SELECT TOP(1) ProductId FROM [dbo].[Product] ORDER BY ProductId DESC),
	0,
	0,
	(SELECT TOP(1) UserId FROM Customer),
	GETDATE(),
	GETDATE(),
	1
)