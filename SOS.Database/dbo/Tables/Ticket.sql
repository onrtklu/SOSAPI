CREATE TABLE [dbo].[Ticket] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [EventID]           INT            NULL,
    [NameSurname]       NVARCHAR (100) NULL,
    [ReservationTypeID] INT            NULL,
    [PaymentTypeID]     INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

