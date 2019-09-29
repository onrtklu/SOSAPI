CREATE TABLE [Offer].[Offer] (
    [Id]                  INT      IDENTITY (1, 1) NOT NULL,
    [Restaurant_Id]       INT      NOT NULL,
    [StartOfferDatetime]  DATETIME NULL,
    [FinishOfferDatetime] DATETIME NULL,
    [Customer_Id]         INT      NOT NULL,
    [Table_Id]            INT      NULL,
    CONSTRAINT [PK__Offer__3214EC07B4C38900] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Offer_Offer_Customers] FOREIGN KEY ([Customer_Id]) REFERENCES [Customer].[Customers] ([Id]),
    CONSTRAINT [FK_Offer_Offer_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id])
);





