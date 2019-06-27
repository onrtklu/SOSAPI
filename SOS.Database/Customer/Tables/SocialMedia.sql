CREATE TABLE [Customer].[SocialMedia] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Customer_Id]  INT            NOT NULL,
    [FacebookKey]  NVARCHAR (MAX) NULL,
    [TwitterKey]   NVARCHAR (MAX) NULL,
    [InstagramKey] NVARCHAR (MAX) NULL,
    [GoogleKey]    NVARCHAR (MAX) NULL,
    [LinkedinKey]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Customer_SocialMedia] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_SocialMedia_Customers] FOREIGN KEY ([Customer_Id]) REFERENCES [Customer].[Customers] ([Id])
);

