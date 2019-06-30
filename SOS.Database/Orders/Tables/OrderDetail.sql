CREATE TABLE [Orders].[OrderDetail] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Order_Id]    INT             NULL,
    [MenuItem_Id] INT             NULL,
    [Quantity]    INT             NULL,
    [OrderNote]   NVARCHAR (MAX)  NULL,
    [ItemPrice]   DECIMAL (18, 2) NULL,
    [TotalPrice]  DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Orders_OrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_OrderDetails_MenuItem] FOREIGN KEY ([MenuItem_Id]) REFERENCES [Restaurant].[MenuItem] ([Id]),
    CONSTRAINT [FK_Orders_OrderDetails_Orders] FOREIGN KEY ([Order_Id]) REFERENCES [Orders].[Orders] ([Id])
);





