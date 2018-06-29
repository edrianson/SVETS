CREATE TABLE [dbo].[Procedure]
(
	[ProcedureId] INT NOT NULL PRIMARY KEY, 
    [Description] TEXT NOT NULL, 
    [Price] MONEY NOT NULL,

	CHECK ([Price] > 0)
)
