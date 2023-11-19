CREATE TABLE [dbo].[Visits]
(
	[Id]				INT IDENTITY (1, 1)		NOT NULL,
	[Name]				NVARCHAR(50)				NULL,
	[WorkOrderId]		INT							NULL,		
	CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Visits_WorkOrders] FOREIGN KEY ([WorkOrderId]) REFERENCES [WorkOrders]([Id]) ON DELETE CASCADE
);