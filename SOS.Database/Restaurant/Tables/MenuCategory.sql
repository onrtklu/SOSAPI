CREATE TABLE [Restaurant].[MenuCategory] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Parent_Id]     INT             NULL,
    [CategoryName]  NVARCHAR (1000) NULL,
    [Restaurant_Id] INT             NULL,
    [ImageUrl]      NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK__MenuCate__3214EC07980532D8] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Restaurant_MenuCategory_MenuCategory] FOREIGN KEY ([Parent_Id]) REFERENCES [Restaurant].[MenuCategory] ([Id]),
    CONSTRAINT [FK_Restaurant_MenuCategory_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id])
);

