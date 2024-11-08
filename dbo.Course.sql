CREATE TABLE [dbo].[Course] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [Subject ]     NVARCHAR (MAX) NULL,
    [CourseNumber] NCHAR (10)     NULL, 
    [Prerequisite1] NVARCHAR(MAX) NOT NULL, 
    [Prerequisite2] NVARCHAR(MAX) NOT NULL
);

