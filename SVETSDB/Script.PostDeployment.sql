/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF '$(LoadTestData)' = 'true' BEGIN
	DELETE FROM [Owner];
	DELETE FROM [Pet];
	DELETE FROM [Procedure];
	DELETE FROM [Treatment];

	INSERT INTO [Owner]([OwnerId], [SurName], [GivenName], [Phone]) VALUES
		(1, 'Sinatra', 'Frank', '400111222'),
		(2, 'Ellington', 'Duke', '400222333'),
		(3, 'Fitzgerald', 'Ella', '400333444');

	INSERT INTO [Pet]([PetName], [Type], [OwnerId]) VALUES
		('Buster', 'Dog', 1),
		('Fluffy', 'Cat', 1),
		('Stew', 'Rabbit', 2),
		('Buster', 'Dog', 3),
		('Pooper', 'Dog', 3);

	INSERT INTO [Procedure]([ProcedureId], [Description], [Price]) VALUES
		(1, 'Rabies Vaccination', 24),
		(10, 'Examine and Treat Wound', 30),
		(5, 'Heart Worm Test', 25),
		(8, 'Tetnus Vaccination', 17);

	INSERT INTO [Treatment]([PetName], [OwnerId], [ProcedureId], [Date], [Notes]) VALUES
		('Buster', 1, 1, 20-6-17, 'Routine Vaccination'),
		('Buster', 1, 1, 15-5-18, 'Booster Shot'),
		('Fluffy', 1, 10, 10-5-18, 'Wounds sustained in apparent cat fight.'),
		('Stew', 2, 10, 10-5-18, 'Wounds sustained during attemot to cook the stew.'),
		('Pooper', 3, 5, 18-5-18, 'Routine Test');
END;