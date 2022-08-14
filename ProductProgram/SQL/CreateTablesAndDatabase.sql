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

USE solution
CREATE Table Sale(
    SaleId int identity (1, 1) primary key,
	Value decimal(5,2),
	CreationDate datetime,
    UpdateDate datetime,
	DeletionDate datetime
);

USE solution
CREATE Table Sales(
    SalesId int identity (1, 1) primary key,
	SaleId int,
	ProductId int,
	Quantidade int,
	Value decimal(5, 2),
	CreationDate datetime,
    UpdateDate datetime,
	DeletionDate datetime
);

ALTER TABLE Sales
ADD CONSTRAINT FK_SALEID FOREIGN KEY (SaleId) REFERENCES solution..Sale (SaleId);

ALTER TABLE Sales
ADD CONSTRAINT FK_PRODUCTID FOREIGN KEY (ProductId) REFERENCES solution..Product (ProductId);