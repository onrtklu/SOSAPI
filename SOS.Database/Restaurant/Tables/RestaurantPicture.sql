CREATE TABLE [Restaurant].[RestaurantPicture] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [PictureName]   NVARCHAR (1000) NULL,
    [PictureUrl]    NVARCHAR (MAX)  NULL,
    [Cover]         BIT             NULL,
    [IsActive]      BIT             NULL,
    [Restaurant_Id] INT             NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Restaurant_RestaurantPicture_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id])
);

