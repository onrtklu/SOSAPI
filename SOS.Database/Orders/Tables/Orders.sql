CREATE TABLE [Orders].[Orders] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [Restaurant_Id]         INT             NULL,
    [OrderTime]             DATETIME        NULL,
    [EstimatedDeliveryTime] DATETIME        NULL,
    [ActualDeliveryTime]    DATETIME        NULL,
    [Customer_Id]           INT             NULL,
    [TotalPrice]            DECIMAL (18, 2) NULL,
    [Discount]              DECIMAL (18, 2) NULL,
    [FinalPrice]            DECIMAL (18, 2) NULL,
    [Comments]              NVARCHAR (MAX)  NULL,
    [IsSuccess]             BIT             NULL,
    [OrderStatus_Id]        INT             NULL,
    [Datetime]              DATETIME        NULL,
    CONSTRAINT [PK__Orders__3214EC07B82B05EF] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_Orders_Customers] FOREIGN KEY ([Customer_Id]) REFERENCES [Customer].[Customers] ([Id]),
    CONSTRAINT [FK_Orders_Orders_OrderStatus] FOREIGN KEY ([OrderStatus_Id]) REFERENCES [Orders].[OrderStatus] ([Id]),
    CONSTRAINT [FK_Orders_Orders_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id])
);

