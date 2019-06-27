﻿CREATE TABLE [Restaurant].[RestaurantDetail] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Restaurant_Id] INT             NULL,
    [Description]   NVARCHAR (MAX)  NULL,
    [OpeningHours]  NVARCHAR (1000) NULL,
    [Smoking]       BIT             NULL,
    [Alcohol]       BIT             NULL,
    [Datetime]      DATETIME        NULL,
    CONSTRAINT [PK__Restaura__3214EC07557D71D8] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Restaurant_RestaurantDetail_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id])
);

