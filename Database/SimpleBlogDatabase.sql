
USE [SimpleBlog]
GO
/****** Object:  Table [dbo].[BlogPosts]    Script Date: 6/10/2019 12:04:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogPosts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](800) NOT NULL,
	[BannerImage] [nvarchar](800) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[PublishedToDate] [datetime] NULL,
	[IsArchived] [bit] NOT NULL,
	[WorkFlowId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_BlogPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogUsers]    Script Date: 6/10/2019 12:04:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogUsers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_BlogUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 6/10/2019 12:04:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserWorkFlowRoles]    Script Date: 6/10/2019 12:04:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserWorkFlowRoles](
	[UserRoleId] [int] NOT NULL,
	[WorkFlowStepId] [int] NOT NULL,
 CONSTRAINT [PK_UserWorkFlowRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC,
	[WorkFlowStepId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkFlowSteps]    Script Date: 6/10/2019 12:04:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkFlowSteps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkFlow] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_WorkFlow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BlogUsers] ON 
GO
INSERT [dbo].[BlogUsers] ([Id], [Name], [Email], [UserName], [Password], [RoleId], [IsActive]) VALUES (2, N'Admin User', N'admin@localhost.com', N'adminuser', N'pass123@', 1, 1)
GO
INSERT [dbo].[BlogUsers] ([Id], [Name], [Email], [UserName], [Password], [RoleId], [IsActive]) VALUES (3, N'Editor', N'editor@localhost.com', N'editingnuser', N'pass123@', 2, 1)
GO
SET IDENTITY_INSERT [dbo].[BlogUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
GO
INSERT [dbo].[UserRoles] ([Id], [RoleName]) VALUES (1, N'ADMIN')
GO
INSERT [dbo].[UserRoles] ([Id], [RoleName]) VALUES (2, N'EDITOR')
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
INSERT [dbo].[UserWorkFlowRoles] ([UserRoleId], [WorkFlowStepId]) VALUES (1, 1)
GO
INSERT [dbo].[UserWorkFlowRoles] ([UserRoleId], [WorkFlowStepId]) VALUES (1, 2)
GO
INSERT [dbo].[UserWorkFlowRoles] ([UserRoleId], [WorkFlowStepId]) VALUES (1, 3)
GO
INSERT [dbo].[UserWorkFlowRoles] ([UserRoleId], [WorkFlowStepId]) VALUES (1, 4)
GO
INSERT [dbo].[UserWorkFlowRoles] ([UserRoleId], [WorkFlowStepId]) VALUES (1, 5)
GO
INSERT [dbo].[UserWorkFlowRoles] ([UserRoleId], [WorkFlowStepId]) VALUES (2, 1)
GO
INSERT [dbo].[UserWorkFlowRoles] ([UserRoleId], [WorkFlowStepId]) VALUES (2, 2)
GO
SET IDENTITY_INSERT [dbo].[WorkFlowSteps] ON 
GO
INSERT [dbo].[WorkFlowSteps] ([Id], [WorkFlow]) VALUES (1, N'DRAFT')
GO
INSERT [dbo].[WorkFlowSteps] ([Id], [WorkFlow]) VALUES (2, N'READY TO PUBLISH')
GO
INSERT [dbo].[WorkFlowSteps] ([Id], [WorkFlow]) VALUES (3, N'REJECT')
GO
INSERT [dbo].[WorkFlowSteps] ([Id], [WorkFlow]) VALUES (4, N'PUBLISH')
GO
INSERT [dbo].[WorkFlowSteps] ([Id], [WorkFlow]) VALUES (5, N'ARCHIVED')
GO
SET IDENTITY_INSERT [dbo].[WorkFlowSteps] OFF
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_BlogUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[BlogUsers] ([Id])
GO
ALTER TABLE [dbo].[BlogPosts] CHECK CONSTRAINT [FK_BlogPost_BlogUsers]
GO
ALTER TABLE [dbo].[BlogPosts]  WITH CHECK ADD  CONSTRAINT [FK_BlogPost_WorkFlowStep] FOREIGN KEY([WorkFlowId])
REFERENCES [dbo].[WorkFlowSteps] ([Id])
GO
ALTER TABLE [dbo].[BlogPosts] CHECK CONSTRAINT [FK_BlogPost_WorkFlowStep]
GO
ALTER TABLE [dbo].[BlogUsers]  WITH CHECK ADD  CONSTRAINT [FK_BlogUsers_Profiles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[UserRoles] ([Id])
GO
ALTER TABLE [dbo].[BlogUsers] CHECK CONSTRAINT [FK_BlogUsers_Profiles]
GO
ALTER TABLE [dbo].[UserWorkFlowRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserWorkFlowRole_UserRole] FOREIGN KEY([UserRoleId])
REFERENCES [dbo].[UserRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserWorkFlowRoles] CHECK CONSTRAINT [FK_UserWorkFlowRole_UserRole]
GO
ALTER TABLE [dbo].[UserWorkFlowRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserWorkFlowRole_WorkFlowStep] FOREIGN KEY([WorkFlowStepId])
REFERENCES [dbo].[WorkFlowSteps] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserWorkFlowRoles] CHECK CONSTRAINT [FK_UserWorkFlowRole_WorkFlowStep]
GO
