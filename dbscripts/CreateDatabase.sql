:setvar DatabaseName "ProductionDatabase"
GO

CREATE DATABASE [$(DatabaseName)];
GO

ALTER AUTHORIZATION ON DATABASE::[$(DatabaseName)] TO sa
GO

Print "Attempting to create the Database."

USE [$(DatabaseName)];

:setvar TableName "User"
GO

CREATE TABLE [dbo].[$(TableName)] (
    [Id]            INT           NOT NULL,
	[FirstName]     VARCHAR(50)   NOT NULL,
	[LastName]      VARCHAR(50)   COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
);

INSERT INTO [dbo].[$(TableName)]
     (Id, FirstName, LastName)
VALUES 
	(1, "Jason", "Truong"),
	(2, "Jane", "Smith"),
	(5, "Vanessa", "Calgary");
Print "Successfully added data to the table."
GO

:setvar TableName "Project"
GO

CREATE TABLE [dbo].[$(TableName)] (
	[Id]            INT           NOT NULL,
	[StartDate]     DATETIME      NOT NULL,
	[EndDate]       DATETIME      NOT NULL,
	[Credits]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id]),
);

Print "Created the table successfully."

INSERT INTO [dbo].[$(TableName)]
     (Id, StartDate, EndDate, Credits)
VALUES 
	(1, '2019-01-15 10:30:00', '2019-03-15 13:30:00',5),
	(2, '2019-02-15 10:30:00', '2019-05-15 13:30:00',3),
	(3, '2019-03-15 10:30:00', '2019-06-15 13:30:00',3),
	(4, '2019-04-15 10:30:00', '2019-07-15 13:30:00',4),
	(5, '2019-05-15 10:30:00', '2019-08-15 13:30:00',4);
Print "Successfully added data to the table."
GO

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

Print "Created the table successfully."

INSERT INTO [dbo].[$(TableName)]
     (UserId, ProjectId, IsActive, AssignedDate)
VALUES
	(1, 1, 1, '2019-03-15 13:30:00'),
	(1, 2, 1, '2019-03-15 13:30:00'),
	(1, 3, 1, '2019-03-15 13:30:00'),
	(1, 4, 1, '2019-03-15 13:30:00'),
	(1, 5, 1, '2019-03-15 13:30:00'),
	(2, 1, 1, '2019-03-15 13:30:00');