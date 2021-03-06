USE [registrar]
GO
/****** Object:  Table [dbo].[courses]    Script Date: 2/28/2017 4:40:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[course_number] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[students]    Script Date: 2/28/2017 4:40:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[date_of_enrollment] [date] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[students_courses]    Script Date: 2/28/2017 4:40:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students_courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[students_id] [int] NULL,
	[courses_id] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[courses] ON 

INSERT [dbo].[courses] ([id], [name], [course_number]) VALUES (1, N'Intro to Cats', N'CATS101')
INSERT [dbo].[courses] ([id], [name], [course_number]) VALUES (2, N'Intro to Cats', N'CATS101')
INSERT [dbo].[courses] ([id], [name], [course_number]) VALUES (3, N'Geometry', N'MATH204')
INSERT [dbo].[courses] ([id], [name], [course_number]) VALUES (4, N'Crawling', N'PE 101')
SET IDENTITY_INSERT [dbo].[courses] OFF
SET IDENTITY_INSERT [dbo].[students] ON 

INSERT [dbo].[students] ([id], [name], [date_of_enrollment]) VALUES (1, N'Marc Larkin', CAST(N'2017-02-28' AS Date))
INSERT [dbo].[students] ([id], [name], [date_of_enrollment]) VALUES (2, N'Marc Larkin', CAST(N'2017-02-28' AS Date))
INSERT [dbo].[students] ([id], [name], [date_of_enrollment]) VALUES (3, N'Allie Holcombe', CAST(N'2017-03-28' AS Date))
SET IDENTITY_INSERT [dbo].[students] OFF
SET IDENTITY_INSERT [dbo].[students_courses] ON 

INSERT [dbo].[students_courses] ([id], [students_id], [courses_id]) VALUES (1, 1, 1)
INSERT [dbo].[students_courses] ([id], [students_id], [courses_id]) VALUES (2, 1, 1)
INSERT [dbo].[students_courses] ([id], [students_id], [courses_id]) VALUES (3, 1, 1)
INSERT [dbo].[students_courses] ([id], [students_id], [courses_id]) VALUES (4, 1, 1)
INSERT [dbo].[students_courses] ([id], [students_id], [courses_id]) VALUES (5, 1, 1)
INSERT [dbo].[students_courses] ([id], [students_id], [courses_id]) VALUES (6, 3, 1)
INSERT [dbo].[students_courses] ([id], [students_id], [courses_id]) VALUES (7, 1, 3)
INSERT [dbo].[students_courses] ([id], [students_id], [courses_id]) VALUES (8, 3, 3)
SET IDENTITY_INSERT [dbo].[students_courses] OFF
