:setvar DatabaseName "ProductionDatabase"
GO

Print "Attempting to create the Database."

CREATE DATABASE [$(DatabaseName)];
GO

ALTER AUTHORIZATION ON DATABASE::[$(DatabaseName)] TO sa
GO

Print "Database created successfully."

USE [$(DatabaseName)];

Print "Creating user table."

:setvar TableName "User"
GO

CREATE TABLE [dbo].[$(TableName)] (
    [Id]            INT           NOT NULL,
	[FirstName]     VARCHAR(50)   NOT NULL,
	[LastName]      VARCHAR(50)   COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
);

Print "Created the User table successfully."

INSERT INTO [dbo].[$(TableName)]
     (Id, FirstName, LastName)
VALUES 
	(1, "Jason", "Truong"),
	(7, "Neve", "Floyd"),
	(2, "Jane", "Smith"),
	(6, "Janelle", "Buxton"),
	(5, "Vanessa", "Calgary"),
	(4, "Theodor", "Tyson"),
	(3, "Corrie", "Steadman"),
	(8, "Bret", "Parks");
Print "Successfully added User data to the table."
GO

Print "Creating Project table."

:setvar TableName "Project"
GO

CREATE TABLE [dbo].[$(TableName)] (
	[Id]            INT           NOT NULL,
	[StartDate]     DATETIME      NOT NULL,
	[EndDate]       DATETIME      NOT NULL,
	[Credits]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
);

Print "Created the Project table successfully."

INSERT INTO [dbo].[$(TableName)]
     (Id, StartDate, EndDate, Credits)
VALUES 
	(1, '2019-03-19 01:30:00', '2019-05-06 23:30:00', 3),
	(2, '2019-03-15 16:30:00', '2019-08-12 09:00:00', 2),
	(3, '2019-04-08 07:00:00', '2019-05-15 11:30:00', 3),
	(4, '2019-05-09 04:00:00', '2019-06-23 19:30:00', 1),
	(5, '2019-02-17 19:00:00', '2019-05-17 07:00:00', 2),
	(6, '2019-03-21 12:30:00', '2019-04-27 01:30:00', 1),
	(7, '2019-10-18 00:30:00', '2019-12-11 04:30:00', 4),
	(8, '2019-09-18 11:30:00', '2019-11-09 17:30:00', 5),
	(9, '2019-04-22 10:00:00', '2019-06-10 14:00:00', 6),
	(10, '2019-07-10 14:30:00', '2019-10-29 02:30:00', 3),
	(11, '2019-09-23 23:00:00', '2019-12-20 16:30:00', 2),
	(12, '2019-05-14 21:30:00', '2019-08-06 16:00:00', 5),
	(13, '2019-03-01 15:00:00', '2019-06-19 05:30:00', 1),
	(14, '2019-06-22 13:30:00', '2019-10-18 02:30:00', 6),
	(15, '2019-09-04 08:00:00', '2019-12-24 00:30:00', 2),
	(16, '2019-03-30 10:30:00', '2019-07-09 11:00:00', 4),
	(17, '2019-02-28 09:30:00', '2019-11-19 13:30:00', 5),
	(18, '2019-08-08 18:00:00', '2019-11-18 17:00:00', 3),
	(19, '2019-03-21 05:30:00', '2019-06-11 09:30:00', 2),
	(20, '2019-04-15 03:30:00', '2019-07-15 12:30:00', 4);
Print "Successfully added Project data to the table."
GO

Print "Creating User Project table."

:setvar TableName "UserProject"
GO

CREATE TABLE [dbo].[$(TableName)] (
	[UserId]			 INT         NOT NULL,
	[ProjectId]			 INT		 NOT NULL,
    [IsActive]           BIT    	 NOT NULL,
    [AssignedDate]       DATETIME    NOT NULL,
	FOREIGN KEY(UserId) REFERENCES [User]([Id]),
	FOREIGN KEY(ProjectId) REFERENCES Project([Id])
);
GO

Print "Created the User project table successfully."

INSERT INTO [dbo].[$(TableName)]
     (UserId, ProjectId, IsActive, AssignedDate)
VALUES
	(1, 1, 1, '2019-11-18 12:00:00'),
	(1, 20, 1, '2019-02-28 09:30:00'),
	(1, 5, 1, '2019-04-29 18:30:00'),
	(1, 3, 0, '2019-02-25 21:00:00'),
	(1, 15, 1, '2019-07-06 17:30:00'),
	(1, 7, 0, '2019-12-04 05:00:00'),
	(1, 18, 0, '2019-02-15 02:30:00'),
	(1, 8, 1, '2019-03-05 22:00:00'),
	(2, 2, 1, '2019-03-10 04:30:00'),
	(2, 4, 1, '2019-04-12 12:00:00'),
	(2, 6, 0, '2019-12-18 19:30:00'),
	(2, 8, 0, '2019-02-12 01:30:00'),
	(2, 10, 0, '2019-05-07 22:30:00'),
	(3, 19, 1, '2019-01-04 12:30:00'),
	(4, 3, 1, '2019-02-24 07:30:00'),
	(4, 10, 0, '2019-07-22 15:00:00'),
	(4, 14, 1, '2019-06-08 10:30:00'),
	(5, 13, 1, '2019-02-14 00:00:00'),
	(5, 18, 1, '2019-04-20 17:00:00'),
	(5, 5, 1, '2019-09-01 12:00:00'),
	(5, 7, 1, '2019-11-11 22:30:00'),
	(6, 9, 0, '2019-01-01 08:30:00'),
	(6, 11, 0, '2019-02-02 11:30:00'),
	(7, 19, 0, '2019-05-20 03:30:00'),
	(7, 18, 0, '2019-03-14 17:00:00'),
	(7, 17, 1, '2019-07-27 14:00:00'),
	(7, 16, 1, '2019-01-21 23:00:00'),
	(7, 15, 1, '2019-06-18 12:30:00'),
	(8, 12, 0, '2019-07-07 18:00:00'),
	(8, 3, 1, '2019-08-14 02:30:00');
Print "Successfully added User Project data to the table."
GO