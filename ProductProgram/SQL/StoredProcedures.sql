SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateSale]
	@paramCreationDate DATETIME,
	@paramUpdateDate DATETIME,
	@paramDeletionDate DATETIME
AS
BEGIN
	INSERT INTO
		solution..Sale
	VALUES
		(
			0.0,
			@paramCreationDate,
			@paramUpdateDate,
			@paramDeletionDate
		);

	SELECT SCOPE_IDENTITY();
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateSales]
	@paramSaleId int,
	@paramProductId int,
	@paramQuantidade int,
	@paramValue decimal(5,2),
	@paramCreationDate DATETIME,
	@paramUpdateDate DATETIME,
	@paramDeletionDate DATETIME
AS
BEGIN
	INSERT INTO
		solution..Sales
	VALUES
		(
			@paramSaleId,
			@paramProductId,
			@paramQuantidade,
			@paramValue,
			@paramCreationDate,
			@paramUpdateDate,
			@paramDeletionDate
		);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetProductById]
	@parameterId int
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
		ProductId = @parameterId AND
		DeletionDate IS NULL
	OPTION(MAXDOP 1);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateProduct]
	@parameterId INT,
	@parameterName VARCHAR(MAX),
	@parameterValue DECIMAL(5,2),
	@parameterType TINYINT,
	@parameterUpdateDate DATETIME
AS
BEGIN
	UPDATE solution..Product
	SET Name = @parameterName,
		Value = @parameterValue,
		Type = @parameterType,
		UpdateDate = @parameterUpdateDate
	WHERE
		ProductId = @parameterId AND
		DeletionDate IS NULL
	OPTION(MAXDOP 1);
END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateSaleValue]
    @paramSaleId DECIMAL (5, 2)
AS
BEGIN
    DECLARE
        @paramDate DATETIME = GETDATE()
    UPDATE solution..Sale
        SET 
            Value = (
                SELECT 
                    SUM(VALUE)
                FROM 
                    Sales
                WHERE
                    SaleId = @paramSaleId
            ),
            UpdateDate = @paramDate
    WHERE
        SaleId = @paramSaleId
END
;
GO
