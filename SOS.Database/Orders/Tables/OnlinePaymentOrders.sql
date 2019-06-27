CREATE TABLE [Orders].[OnlinePaymentOrders] (
    [Id]                        INT            IDENTITY (1, 1) NOT NULL,
    [PaymentKey]                NVARCHAR (MAX) NULL,
    [PaymentStatus_Id]          INT            NULL,
    [Order_Id]                  INT            NULL,
    [PrevisionKey]              NVARCHAR (MAX) NULL,
    [PaymentToken]              NVARCHAR (MAX) NULL,
    [PrevisionBeginDatetime]    DATETIME       NULL,
    [PrevisionEndDatetime]      DATETIME       NULL,
    [PaymentSuccessfulDatetime] DATETIME       NULL,
    [PaymentValidate]           BIT            NULL,
    CONSTRAINT [PK_Orders_OnlinePaymentOrders] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Orders_OnlinePaymentOrders_Orders] FOREIGN KEY ([Order_Id]) REFERENCES [Orders].[Orders] ([Id]),
    CONSTRAINT [FK_Orders_OnlinePaymentOrders_PaymentStatus] FOREIGN KEY ([PaymentStatus_Id]) REFERENCES [Orders].[PaymentStatus] ([Id])
);

