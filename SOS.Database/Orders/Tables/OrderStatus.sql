CREATE TABLE [Orders].[OrderStatus] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [OrderStatusName] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Orders_OrderStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);

