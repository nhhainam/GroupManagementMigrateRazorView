USE [master]
GO
/****** Object:  Database [GroupManagement]    Script Date: 1/31/2023 10:16:44 AM ******/
CREATE DATABASE [GroupManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GroupManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GroupManagement.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GroupManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\GroupManagement_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GroupManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GroupManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GroupManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GroupManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GroupManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GroupManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GroupManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [GroupManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [GroupManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GroupManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GroupManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GroupManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GroupManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GroupManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GroupManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GroupManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GroupManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GroupManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GroupManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GroupManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GroupManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GroupManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GroupManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GroupManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GroupManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GroupManagement] SET  MULTI_USER 
GO
ALTER DATABASE [GroupManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GroupManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GroupManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GroupManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GroupManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [GroupManagement]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 1/31/2023 10:16:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[groupId] [int] IDENTITY(1,1) NOT NULL,
	[groupName] [nvarchar](255) NULL,
	[description] [nvarchar](255) NULL,
	[purpose] [nvarchar](255) NULL,
	[state] [int] NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invitation]    Script Date: 1/31/2023 10:16:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invitation](
	[userId] [int] NOT NULL,
	[groupId] [int] NOT NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Issues]    Script Date: 1/31/2023 10:16:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Issues](
	[issueId] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NOT NULL,
	[dueDate] [datetime] NULL,
	[startDate] [datetime] NULL,
	[description] [nvarchar](255) NULL,
	[content] [varchar](255) NULL,
	[state] [int] NULL,
	[creator] [int] NULL,
	[assignee] [int] NULL,
	[projectId] [int] NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[issueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MemberIssues]    Script Date: 1/31/2023 10:16:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberIssues](
	[userId] [int] NOT NULL,
	[issueId] [int] NOT NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[issueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Members]    Script Date: 1/31/2023 10:16:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[userID] [int] NOT NULL,
	[groupId] [int] NOT NULL,
	[roleId] [int] NULL,
	[state] [int] NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC,
	[groupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 1/31/2023 10:16:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[projectId] [int] IDENTITY(1,1) NOT NULL,
	[projectName] [nvarchar](255) NULL,
	[description] [nvarchar](255) NULL,
	[createdate] [datetime] NULL,
	[groupId] [int] NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[projectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 1/31/2023 10:16:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [nvarchar](255) NOT NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/31/2023 10:16:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[fullname] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([groupId], [groupName], [description], [purpose], [state], [status]) VALUES (1, N'Bmazon', N'Team Bmazon', N'Develop project with team Bmazon', 1, 1)
INSERT [dbo].[Groups] ([groupId], [groupName], [description], [purpose], [state], [status]) VALUES (2, N'LilLab', N'Team LilLab', N'Develop project with team LilLab', 1, 1)
INSERT [dbo].[Groups] ([groupId], [groupName], [description], [purpose], [state], [status]) VALUES (3, N'DemoTest', N'DemoTest', N'I want to store my activity in project', 0, 1)
INSERT [dbo].[Groups] ([groupId], [groupName], [description], [purpose], [state], [status]) VALUES (4, N'PRN221', N'PRN221', N'I want to store my activity in project', 0, 1)
INSERT [dbo].[Groups] ([groupId], [groupName], [description], [purpose], [state], [status]) VALUES (5, N'linh', N'linh', N'I want to manage my projects well', 0, 1)
SET IDENTITY_INSERT [dbo].[Groups] OFF
SET IDENTITY_INSERT [dbo].[Issues] ON 

INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (1, N'Exception 1', CAST(N'2022-11-12 14:16:56.560' AS DateTime), CAST(N'2022-11-05 14:16:56.560' AS DateTime), N'There is an error about NullPointerException at line 1311 at Controller x', N'Should be fixed in 7 days after release issues', 1, 1, 2, 1, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (2, N'Exception 2', CAST(N'2022-11-12 14:16:56.560' AS DateTime), CAST(N'2022-11-05 14:16:56.560' AS DateTime), N'There is 2 errors about ArithmethicException at line 2001 at Controller y', N'Should be fixed in 7 days after release issues', 1, 1, 2, 1, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (3, N'Exception 1', CAST(N'2022-11-12 14:16:56.560' AS DateTime), CAST(N'2022-11-05 14:16:56.560' AS DateTime), N'There is an error about NullPointerException at line 1311 at Controller x', N'Should be fixed in 7 days after release issues', 1, 1, 2, 2, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (4, N'Exception 2', CAST(N'2022-11-12 14:16:56.560' AS DateTime), CAST(N'2022-11-05 14:16:56.560' AS DateTime), N'There is 2 errors about ArithmethicException at line 2001 at Controller y', N'Should be fixed in 7 days after release issues', 1, 1, 2, 2, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (5, N'Exception 1', CAST(N'2022-11-12 14:16:56.563' AS DateTime), CAST(N'2022-11-05 14:16:56.563' AS DateTime), N'There is an error about NullPointerException at line 1311 at Controller x', N'Should be fixed in 7 days after release issues', 1, 1, 2, 3, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (6, N'Exception 2', CAST(N'2022-11-12 14:16:56.563' AS DateTime), CAST(N'2022-11-05 14:16:56.563' AS DateTime), N'There is 2 errors about ArithmethicException at line 2001 at Controller y', N'Should be fixed in 7 days after release issues', 1, 1, 2, 3, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (7, N'Exception 1', CAST(N'2022-11-12 14:16:56.563' AS DateTime), CAST(N'2022-11-05 14:16:56.563' AS DateTime), N'There is an error about NullPointerException at line 1311 at Controller x', N'Should be fixed in 7 days after release issues', 1, 1, 2, 4, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (8, N'Exception 2', CAST(N'2022-11-12 14:16:56.563' AS DateTime), CAST(N'2022-11-05 14:16:56.563' AS DateTime), N'There is 2 errors about ArithmethicException at line 2001 at Controller y', N'Should be fixed in 7 days after release issues', 1, 1, 2, 4, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (9, N'Nuget packet cannot downloadddddd', CAST(N'2022-11-14 00:00:00.000' AS DateTime), CAST(N'2022-11-12 00:00:00.000' AS DateTime), N'Nuget packet cannot downloadddddd', N'Nuget packet cannot downloadddddd', 0, 7, 4, 5, 1)
INSERT [dbo].[Issues] ([issueId], [title], [dueDate], [startDate], [description], [content], [state], [creator], [assignee], [projectId], [status]) VALUES (10, N'Fixing nuget install', CAST(N'2022-11-14 00:00:00.000' AS DateTime), CAST(N'2022-11-13 00:00:00.000' AS DateTime), N'Fixing nuget install', N'Fixing nuget install', 1, 7, 2, 6, 1)
SET IDENTITY_INSERT [dbo].[Issues] OFF
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (1, 1, 1, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (2, 1, 2, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (2, 4, 3, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (3, 2, 1, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (4, 1, 3, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (4, 3, 3, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (5, 2, 2, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (7, 3, 1, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (7, 4, 1, 1, 1)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (7, 5, 1, 0, 0)
INSERT [dbo].[Members] ([userID], [groupId], [roleId], [state], [status]) VALUES (8, 5, 1, 0, 1)
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([projectId], [projectName], [description], [createdate], [groupId], [status]) VALUES (1, N'Ecommerce', N'An ecommerce website for technology buyer and seller', CAST(N'2022-11-12 14:16:56.557' AS DateTime), 1, 1)
INSERT [dbo].[Projects] ([projectId], [projectName], [description], [createdate], [groupId], [status]) VALUES (2, N'B-Ecommerce', N'An backup ecommerce website for technology buyer and seller', CAST(N'2022-11-12 14:16:56.557' AS DateTime), 1, 1)
INSERT [dbo].[Projects] ([projectId], [projectName], [description], [createdate], [groupId], [status]) VALUES (3, N'LilLab', N'An LilLab website for group management', CAST(N'2022-11-12 14:16:56.560' AS DateTime), 1, 1)
INSERT [dbo].[Projects] ([projectId], [projectName], [description], [createdate], [groupId], [status]) VALUES (4, N'B-LilLab', N'An backup LilLab website for group management', CAST(N'2022-11-12 14:16:56.560' AS DateTime), 1, 1)
INSERT [dbo].[Projects] ([projectId], [projectName], [description], [createdate], [groupId], [status]) VALUES (5, N'DemoTest', N'DemoTest', CAST(N'2022-11-12 14:21:32.210' AS DateTime), 3, 1)
INSERT [dbo].[Projects] ([projectId], [projectName], [description], [createdate], [groupId], [status]) VALUES (6, N'Assignment', N'Assignment ', CAST(N'2022-11-12 15:00:51.710' AS DateTime), 4, 1)
SET IDENTITY_INSERT [dbo].[Projects] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([roleId], [roleName], [status]) VALUES (1, N'Project Manager', 1)
INSERT [dbo].[Roles] ([roleId], [roleName], [status]) VALUES (2, N'Leader', 1)
INSERT [dbo].[Roles] ([roleId], [roleName], [status]) VALUES (3, N'Developer', 1)
INSERT [dbo].[Roles] ([roleId], [roleName], [status]) VALUES (4, N'Tester', 1)
INSERT [dbo].[Roles] ([roleId], [roleName], [status]) VALUES (5, N'BA', 1)
INSERT [dbo].[Roles] ([roleId], [roleName], [status]) VALUES (6, N'QA', 1)
INSERT [dbo].[Roles] ([roleId], [roleName], [status]) VALUES (7, N'Client', 1)
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([userID], [username], [password], [fullname], [email], [status]) VALUES (1, N'nam', N'123', N'Hai Nam', N'namnhh@gmail.com', 1)
INSERT [dbo].[Users] ([userID], [username], [password], [fullname], [email], [status]) VALUES (2, N'flower', N'123', N'Flower', N'flower@gmail.com', 1)
INSERT [dbo].[Users] ([userID], [username], [password], [fullname], [email], [status]) VALUES (3, N'hehe', N'123', N'Hehe', N'hehe@gmail.com', 1)
INSERT [dbo].[Users] ([userID], [username], [password], [fullname], [email], [status]) VALUES (4, N'hihi', N'123', N'Hihi', N'hihi@gmail.com', 1)
INSERT [dbo].[Users] ([userID], [username], [password], [fullname], [email], [status]) VALUES (5, N'kaka', N'123', N'Kaka', N'kaka@gmail.com', 1)
INSERT [dbo].[Users] ([userID], [username], [password], [fullname], [email], [status]) VALUES (6, N'user1', N'1', N'User Test', N'test@gmail.com', 1)
INSERT [dbo].[Users] ([userID], [username], [password], [fullname], [email], [status]) VALUES (7, N'nhhainam', N'123', N'nhhainam', N'nhhainam@gmail.com', 1)
INSERT [dbo].[Users] ([userID], [username], [password], [fullname], [email], [status]) VALUES (8, N'linhle', N'linhpro9x', N'linhle', N'linhkidno1@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Invitation]  WITH CHECK ADD FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([groupId])
GO
ALTER TABLE [dbo].[Invitation]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Issues]  WITH CHECK ADD FOREIGN KEY([assignee])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Issues]  WITH CHECK ADD FOREIGN KEY([creator])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Issues]  WITH CHECK ADD FOREIGN KEY([projectId])
REFERENCES [dbo].[Projects] ([projectId])
GO
ALTER TABLE [dbo].[MemberIssues]  WITH CHECK ADD FOREIGN KEY([issueId])
REFERENCES [dbo].[Issues] ([issueId])
GO
ALTER TABLE [dbo].[MemberIssues]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([groupId])
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD FOREIGN KEY([roleId])
REFERENCES [dbo].[Roles] ([roleId])
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD FOREIGN KEY([groupId])
REFERENCES [dbo].[Groups] ([groupId])
GO
USE [master]
GO
ALTER DATABASE [GroupManagement] SET  READ_WRITE 
GO
