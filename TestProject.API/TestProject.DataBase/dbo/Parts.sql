CREATE TABLE [dbo].[Parts]
(
	[Id]				INT IDENTITY (1, 1)		NOT NULL,
	[Name]				NVARCHAR(50)				NULL,
	[Quantity]			INT					NOT NULL,
	[Price]				DECIMAL(10, 2)			NOT NULL	DEFAULT 0.0,
	[VisitId]			INT							NULL,		
	CONSTRAINT [PK_Partss] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Parts_Visits] FOREIGN KEY ([VisitId]) REFERENCES [Visits]([Id]) 	ON DELETE CASCADE
);