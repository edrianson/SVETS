CREATE TABLE [dbo].[Owner]
(
	[OwnerId] INT NOT NULL PRIMARY KEY, 
    [SurName] NCHAR(10) NOT NULL, 
    [GivenName] NCHAR(5) NOT NULL, 
    [Phone] TEXT NOT NULL,

	UNIQUE([SurName], [GivenName])
)
