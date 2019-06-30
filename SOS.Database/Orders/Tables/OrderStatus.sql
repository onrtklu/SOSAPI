CREATE TABLE [Orders].[OrderStatus] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [OrderStatusName] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Orders_OrderStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);



