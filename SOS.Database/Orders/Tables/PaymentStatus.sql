CREATE TABLE [Orders].[PaymentStatus] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [PaymentStatusName] NVARCHAR (1000) NOT NULL,
    CONSTRAINT [PK_Orders_PaymentStatus] PRIMARY KEY CLUSTERED ([Id] ASC)
);



