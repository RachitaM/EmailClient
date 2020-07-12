

Create Database KENEForms
Go

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'UserLogin')
BEGIN
CREATE TABLE [dbo].[UserLogin]
(
[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[UserName] nvarchar(500) NOT NULL,
[Password] nvarchar(500) NOT NULL,
[IsDeleted] [bit] NOT NULL default(0),
[CreatedDate] [datetime] NOT NULL,
[UpdatedDate] [datetime] NULL
)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Profile')
BEGIN
CREATE TABLE [dbo].[Profile]
(
[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[FName] nvarchar(500) NULL,
[MName] nvarchar(500) NULL,
[LName] nvarchar(500) NULL,
[Address] nvarchar(500) NULL,
[UserId] bigint foreign key references dbo.[UserLogin](id),
[IsDeleted] [bit] NOT NULL default(0),
[CreatedDate] [datetime] NOT NULL,
[UpdatedDate] [datetime] NULL
)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'EmailFolderType')
BEGIN
CREATE TABLE [dbo].[EmailFolderType]
(
[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[Name] nvarchar(500) NOT NULL,
[Description] nvarchar(1000) NULL,
[InUse] [bit] NOT NULL default(1),
)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'EmailMessage')
BEGIN
CREATE TABLE [dbo].[EmailMessage]
(
[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[Body] nvarchar(max) NOT NULL,
[Subject] nvarchar(1000) NULL,
[EmailFolderType] bigint foreign key references dbo.[EmailFolderType](id),
[UserId] bigint foreign key references dbo.[UserLogin](id),
[InDeleted] [bit] NOT NULL default(0),
)
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'EmailRecipient')
BEGIN
CREATE TABLE [dbo].[EmailRecipient]
(
[ID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[EmailMessageId] bigint foreign key references dbo.[EmailMessage](id),
[Recipient] nvarchar(max) NOT NULL,
[IsDeleted] [bit] NOT NULL default(0),
)
END