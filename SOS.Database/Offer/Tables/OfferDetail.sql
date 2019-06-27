CREATE TABLE [Offer].[OfferDetail] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [Offer_Id]    INT      NULL,
    [MenuItem_Id] INT      NULL,
    [Quantity]    INT      NULL,
    [Datetime]    DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Offer_OfferDetail_MenuItem] FOREIGN KEY ([MenuItem_Id]) REFERENCES [Restaurant].[MenuItem] ([Id]),
    CONSTRAINT [FK_Offer_OfferDetail_Offer] FOREIGN KEY ([Offer_Id]) REFERENCES [Offer].[Offer] ([Id])
);

