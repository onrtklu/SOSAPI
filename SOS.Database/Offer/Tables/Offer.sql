CREATE TABLE [Offer].[Offer] (
    [Id]                  INT      IDENTITY (1, 1) NOT NULL,
    [StartOfferDatetime]  DATETIME NULL,
    [FinishOfferDatetime] DATETIME NULL,
    [OfferPaymentType_Id] INT      NULL,
    [Customer_Id]         INT      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Offer_Offer_Customers] FOREIGN KEY ([Customer_Id]) REFERENCES [Customer].[Customers] ([Id]),
    CONSTRAINT [FK_Offer_Offer_PaymentType] FOREIGN KEY ([OfferPaymentType_Id]) REFERENCES [Orders].[PaymentType] ([Id])
);

