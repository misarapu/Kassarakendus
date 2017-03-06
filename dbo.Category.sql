CREATE TABLE [dbo].[Product]
(
	[ProductId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Price] DECIMAL(10, 2) NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Code] VARCHAR(50) NOT NULL, 
    [Comment] VARCHAR(200) NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [Product_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Product]([CategoryId])
)
