CREATE TABLE [Offer].[OfferDetail] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Offer_Id]    INT            NOT NULL,
    [MenuItem_Id] INT            NOT NULL,
    [Quantity]    INT            NULL,
    [OfferNote]   NVARCHAR (MAX) NULL,
    [Datetime]    DATETIME       CONSTRAINT [DF_OfferDetail_Datetime] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__OfferDet__3214EC071F0DD331] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Offer_OfferDetail_MenuItem] FOREIGN KEY ([MenuItem_Id]) REFERENCES [Restaurant].[MenuItem] ([Id]),
    CONSTRAINT [FK_Offer_OfferDetail_Offer] FOREIGN KEY ([Offer_Id]) REFERENCES [Offer].[Offer] ([Id])
);





