CREATE TABLE [Credit].[OrderCredit] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [Restaurant_Id] INT NULL,
    [Credit_Id]     INT NULL,
    [Order_Id]      INT NULL,
    [Customer_Id]   INT NULL,
    CONSTRAINT [PK_Credit_OrderCredit] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Credit_OrderCredit_Credit] FOREIGN KEY ([Credit_Id]) REFERENCES [Credit].[Credit] ([Id]),
    CONSTRAINT [FK_Credit_OrderCredit_Customers] FOREIGN KEY ([Customer_Id]) REFERENCES [Customer].[Customers] ([Id]),
    CONSTRAINT [FK_Credit_OrderCredit_Orders] FOREIGN KEY ([Order_Id]) REFERENCES [Orders].[Orders] ([Id]),
    CONSTRAINT [FK_Credit_OrderCredit_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id])
);

