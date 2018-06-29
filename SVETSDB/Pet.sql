CREATE TABLE [dbo].[Pet]
(
	[PetName] NCHAR(6) NOT NULL, 
    [Type] NCHAR(6) NOT NULL, 
    [OwnerId] INT NOT NULL,

	FOREIGN KEY ([OwnerId]) REFERENCES [Owner]([OwnerId]),

	PRIMARY KEY ([PetName], [OwnerId]),

	CHECK([Type] = 'Dog' OR [Type] = 'Cat' OR [Type] = 'Rabbit')
)
