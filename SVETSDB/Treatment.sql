CREATE TABLE [dbo].[Treatment]
(
	[PetName] NCHAR(6) NOT NULL,
	[OwnerId] INT NOT NULL,
    [ProcedureId] INT NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [Notes] TEXT NOT NULL,

	FOREIGN KEY ([PetName], [OwnerId]) REFERENCES [Pet]([PetName], [OwnerId]),
	FOREIGN KEY ([ProcedureId]) REFERENCES [Procedure]([ProcedureId]),

	PRIMARY KEY ([PetName], [OwnerId], [Date])
)
