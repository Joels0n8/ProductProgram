create database solution

use solution
create table Product(
	ProductId int identity (1, 1) primary key,
	Name varchar(max),
	Value decimal(5,2),
	Type tinyint,
	CreationDate datetime,
    UpdateDate datetime,
	DeletionDate datetime    
);

ALTER TABLE solution..Product
ALTER COLUMN Value decimal (5,2)

USE solution
CREATE Table Sale(
    SaleId int identity (1, 1) primary key,
    ProductId int,
	Value varchar(10),
	CreationDate datetime,
    UpdateDate datetime,
	DeletionDate datetime
);

ALTER TABLE Sale
ADD CONSTRAINT FK_SALEP FOREIGN KEY (ProductId) REFERENCES solution..Product (ProductId);

USE solution
CREATE PROCEDURE [dbo].[GetAllProducts]
AS
BEGIN
SELECT
	ProductId,
	[Name],
	[Value],
	[Type],
	CreationDate
From 
	solution..Product (NOLOCK)
WHERE 
	DeletionDate IS NULL
OPTION(MAXDOP 1);
END