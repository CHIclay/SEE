USE [master]
GO
/****** Object:  Database [SEE]    Script Date: 2018/6/20 13:04:11 ******/
CREATE DATABASE [SEE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SEE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SEE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SEE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\SEE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SEE] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SEE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SEE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SEE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SEE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SEE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SEE] SET ARITHABORT OFF 
GO
ALTER DATABASE [SEE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SEE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SEE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SEE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SEE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SEE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SEE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SEE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SEE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SEE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SEE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SEE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SEE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SEE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SEE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SEE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SEE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SEE] SET RECOVERY FULL 
GO
ALTER DATABASE [SEE] SET  MULTI_USER 
GO
ALTER DATABASE [SEE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SEE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SEE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SEE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SEE] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SEE', N'ON'
GO
ALTER DATABASE [SEE] SET QUERY_STORE = OFF
GO
USE [SEE]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [SEE]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album](
	[Alb_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Alb_Name] [nvarchar](50) NULL,
	[Alb_Pic] [nvarchar](50) NOT NULL,
	[Alb_Mes] [nvarchar](max) NOT NULL,
	[Alb_Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[Alb_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album_Comment]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album_Comment](
	[AC_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Alb_ID] [int] NOT NULL,
	[AC_Mes] [nvarchar](max) NOT NULL,
	[AC_Time] [datetime] NULL,
 CONSTRAINT [PK_Album_Comment] PRIMARY KEY CLUSTERED 
(
	[AC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album_Point]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album_Point](
	[AP_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Alb_ID] [int] NOT NULL,
	[AP_Time] [datetime] NULL,
 CONSTRAINT [PK_Album_Point] PRIMARY KEY CLUSTERED 
(
	[AP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Album_Save]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Album_Save](
	[AS_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Alb_ID] [int] NOT NULL,
	[AS_Time] [datetime] NULL,
 CONSTRAINT [PK_Album_Save] PRIMARY KEY CLUSTERED 
(
	[AS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attention]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attention](
	[Att_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[To_User_ID] [int] NOT NULL,
	[Att_Time] [datetime] NULL,
 CONSTRAINT [PK_Attention] PRIMARY KEY CLUSTERED 
(
	[Att_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[Man_ID] [int] IDENTITY(1,1) NOT NULL,
	[Man_Name] [nvarchar](50) NOT NULL,
	[Man_Pas] [nvarchar](50) NOT NULL,
	[Man_Time] [datetime] NULL,
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[Man_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[News_ID] [int] IDENTITY(1,1) NOT NULL,
	[Man_ID] [int] NOT NULL,
	[News_Name] [nvarchar](50) NULL,
	[News_Pic] [nvarchar](50) NOT NULL,
	[News_Mes] [nvarchar](max) NOT NULL,
	[News_Time] [datetime] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[News_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News_Comment]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News_Comment](
	[NC_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[News_ID] [int] NOT NULL,
	[NC_Mes] [nvarchar](max) NOT NULL,
	[NC_Time] [datetime] NULL,
 CONSTRAINT [PK_News_Comment] PRIMARY KEY CLUSTERED 
(
	[NC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pic_Comment]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pic_Comment](
	[PC_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Pic_ID] [int] NOT NULL,
	[PC_Mes] [nvarchar](max) NOT NULL,
	[PC_Time] [datetime] NULL,
 CONSTRAINT [PK_Pic_Comment] PRIMARY KEY CLUSTERED 
(
	[PC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pic_Comment_Comment]    Script Date: 2018/6/20 13:04:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pic_Comment_Comment](
	[PCC_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[PC_ID] [int] NOT NULL,
	[PCC_Mes] [nvarchar](max) NOT NULL,
	[PCC_Time] [datetime] NULL,
 CONSTRAINT [PK_Pic_Comment_Comment] PRIMARY KEY CLUSTERED 
(
	[PCC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pic_Point]    Script Date: 2018/6/20 13:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pic_Point](
	[PP_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Pic_ID] [int] NOT NULL,
	[PP_Time] [datetime] NULL,
 CONSTRAINT [PK_Pic_Point] PRIMARY KEY CLUSTERED 
(
	[PP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Picture]    Script Date: 2018/6/20 13:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture](
	[Pic_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_ID] [int] NOT NULL,
	[Pic_Pic] [nvarchar](50) NOT NULL,
	[Type_ID] [int] NOT NULL,
	[Pic_Mes] [nvarchar](max) NULL,
	[Pic_Time] [datetime] NULL,
 CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED 
(
	[Pic_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Picture_In_Album]    Script Date: 2018/6/20 13:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture_In_Album](
	[PIA_ID] [int] IDENTITY(1,1) NOT NULL,
	[Alb_ID] [int] NOT NULL,
	[Pic_ID] [int] NOT NULL,
	[PIA_Time] [datetime] NULL,
 CONSTRAINT [PK_Picture_In_Album] PRIMARY KEY CLUSTERED 
(
	[PIA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Picture_Type]    Script Date: 2018/6/20 13:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Picture_Type](
	[Type_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Type_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2018/6/20 13:04:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Img] [nvarchar](50) NULL,
	[User_Name] [nvarchar](50) NOT NULL,
	[User_Pwd] [char](20) NOT NULL,
	[User_ConPwd] [char](20) NOT NULL,
	[User_Sex] [char](20) NOT NULL,
	[User_Ema] [nvarchar](50) NULL,
	[User_Pho] [nvarchar](50) NULL,
	[User_Time] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Album] ON 

INSERT [dbo].[Album] ([Alb_ID], [User_ID], [Alb_Name], [Alb_Pic], [Alb_Mes], [Alb_Time]) VALUES (7, 9, N'范德萨范德萨', N'/images/albums/42314324.jpg', N'士大夫大', CAST(N'2018-06-20T00:10:46.893' AS DateTime))
SET IDENTITY_INSERT [dbo].[Album] OFF
SET IDENTITY_INSERT [dbo].[Attention] ON 

INSERT [dbo].[Attention] ([Att_ID], [User_ID], [To_User_ID], [Att_Time]) VALUES (23, 10, 9, CAST(N'2018-06-18T23:29:48.417' AS DateTime))
INSERT [dbo].[Attention] ([Att_ID], [User_ID], [To_User_ID], [Att_Time]) VALUES (25, 14, 9, CAST(N'2018-06-19T00:08:48.580' AS DateTime))
SET IDENTITY_INSERT [dbo].[Attention] OFF
SET IDENTITY_INSERT [dbo].[Manager] ON 

INSERT [dbo].[Manager] ([Man_ID], [Man_Name], [Man_Pas], [Man_Time]) VALUES (2, N'程小二', N'1', CAST(N'2018-05-29T22:37:02.000' AS DateTime))
INSERT [dbo].[Manager] ([Man_ID], [Man_Name], [Man_Pas], [Man_Time]) VALUES (6, N'张小三', N'1', CAST(N'2018-06-20T10:26:28.897' AS DateTime))
SET IDENTITY_INSERT [dbo].[Manager] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([News_ID], [Man_ID], [News_Name], [News_Pic], [News_Mes], [News_Time]) VALUES (6, 2, N'7534和规范合法', N'/images/news/IMG_20160416_135112.jpg', N'很过分的华国锋的', CAST(N'2018-06-11T09:49:30.407' AS DateTime))
INSERT [dbo].[News] ([News_ID], [Man_ID], [News_Name], [News_Pic], [News_Mes], [News_Time]) VALUES (19, 2, N'恶趣味无群二群无', N'/images/news/3253252.jpg', N'<p>他范德萨范德萨范德萨范德萨范德萨范德萨</p>', CAST(N'2018-06-19T19:29:35.157' AS DateTime))
INSERT [dbo].[News] ([News_ID], [Man_ID], [News_Name], [News_Pic], [News_Mes], [News_Time]) VALUES (22, 6, N'范德萨范德萨', N'/images/news/33324324.jpg', N'<p>范德萨范德萨范德萨范德萨范德萨</p>', CAST(N'2018-06-20T12:33:07.007' AS DateTime))
INSERT [dbo].[News] ([News_ID], [Man_ID], [News_Name], [News_Pic], [News_Mes], [News_Time]) VALUES (23, 6, N'12312312321', N'/images/news/42314324.jpg', N'<p>214112421</p>', CAST(N'2018-06-20T12:50:39.270' AS DateTime))
INSERT [dbo].[News] ([News_ID], [Man_ID], [News_Name], [News_Pic], [News_Mes], [News_Time]) VALUES (24, 6, N'213213213213', N'/images/news/33324324.jpg', N'<p>5432543254324325345325432543太热污染天仍发的割发代首<img src="/ueditor/net/upload/image/20180620/6366509585675265839246732.jpg" title="3253252.jpg" alt="3253252.jpg"/></p>', CAST(N'2018-06-20T12:50:57.447' AS DateTime))
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[Pic_Comment] ON 

INSERT [dbo].[Pic_Comment] ([PC_ID], [User_ID], [Pic_ID], [PC_Mes], [PC_Time]) VALUES (28, 9, 33, N'31231', CAST(N'2018-06-20T00:10:30.513' AS DateTime))
INSERT [dbo].[Pic_Comment] ([PC_ID], [User_ID], [Pic_ID], [PC_Mes], [PC_Time]) VALUES (29, 9, 33, N'fuck 有
', CAST(N'2018-06-20T11:23:06.677' AS DateTime))
SET IDENTITY_INSERT [dbo].[Pic_Comment] OFF
SET IDENTITY_INSERT [dbo].[Pic_Comment_Comment] ON 

INSERT [dbo].[Pic_Comment_Comment] ([PCC_ID], [User_ID], [PC_ID], [PCC_Mes], [PCC_Time]) VALUES (15, 9, 29, N'范德萨发到付', CAST(N'2018-06-20T11:23:12.343' AS DateTime))
SET IDENTITY_INSERT [dbo].[Pic_Comment_Comment] OFF
SET IDENTITY_INSERT [dbo].[Pic_Point] ON 

INSERT [dbo].[Pic_Point] ([PP_ID], [User_ID], [Pic_ID], [PP_Time]) VALUES (16, 9, 33, CAST(N'2018-06-20T00:10:34.177' AS DateTime))
SET IDENTITY_INSERT [dbo].[Pic_Point] OFF
SET IDENTITY_INSERT [dbo].[Picture] ON 

INSERT [dbo].[Picture] ([Pic_ID], [User_ID], [Pic_Pic], [Type_ID], [Pic_Mes], [Pic_Time]) VALUES (33, 9, N'/images/pictures/33324324.jpg', 10, N'怎么办，我忘不了他', CAST(N'2018-06-20T00:10:23.550' AS DateTime))
SET IDENTITY_INSERT [dbo].[Picture] OFF
SET IDENTITY_INSERT [dbo].[Picture_In_Album] ON 

INSERT [dbo].[Picture_In_Album] ([PIA_ID], [Alb_ID], [Pic_ID], [PIA_Time]) VALUES (15, 7, 33, CAST(N'2018-06-20T00:10:56.343' AS DateTime))
SET IDENTITY_INSERT [dbo].[Picture_In_Album] OFF
SET IDENTITY_INSERT [dbo].[Picture_Type] ON 

INSERT [dbo].[Picture_Type] ([Type_ID], [Name]) VALUES (10, N'表情包')
INSERT [dbo].[Picture_Type] ([Type_ID], [Name]) VALUES (12, N'艺术')
INSERT [dbo].[Picture_Type] ([Type_ID], [Name]) VALUES (13, N'黑白')
INSERT [dbo].[Picture_Type] ([Type_ID], [Name]) VALUES (14, N'建筑')
INSERT [dbo].[Picture_Type] ([Type_ID], [Name]) VALUES (15, N'唯美')
INSERT [dbo].[Picture_Type] ([Type_ID], [Name]) VALUES (16, N'儿童')
INSERT [dbo].[Picture_Type] ([Type_ID], [Name]) VALUES (17, N'宠物')
SET IDENTITY_INSERT [dbo].[Picture_Type] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([User_ID], [User_Img], [User_Name], [User_Pwd], [User_ConPwd], [User_Sex], [User_Ema], [User_Pho], [User_Time]) VALUES (9, N'/images/users/watch.jpg', N'张三', N'123                 ', N'123                 ', N'女                  ', N'22@qq.com', N'1245', CAST(N'2018-06-05T14:00:17.153' AS DateTime))
INSERT [dbo].[User] ([User_ID], [User_Img], [User_Name], [User_Pwd], [User_ConPwd], [User_Sex], [User_Ema], [User_Pho], [User_Time]) VALUES (10, N'/images/users/IMG_20160101_200008_HDR.jpg', N'程二', N'1                   ', N'1                   ', N'男                  ', N'223343@qq.com', N'123213', CAST(N'2018-06-08T02:25:57.853' AS DateTime))
INSERT [dbo].[User] ([User_ID], [User_Img], [User_Name], [User_Pwd], [User_ConPwd], [User_Sex], [User_Ema], [User_Pho], [User_Time]) VALUES (14, N'/images/users/IMG_20160715_115112.jpg', N'李四', N'123                 ', N'123                 ', N'男                  ', N'23423423@qq.com', N'12312141', CAST(N'2018-06-11T00:04:58.883' AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Album] FOREIGN KEY([Alb_ID])
REFERENCES [dbo].[Album] ([Alb_ID])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Album]
GO
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_User]
GO
ALTER TABLE [dbo].[Album_Comment]  WITH CHECK ADD  CONSTRAINT [FK_Album_Comment_Album] FOREIGN KEY([Alb_ID])
REFERENCES [dbo].[Album] ([Alb_ID])
GO
ALTER TABLE [dbo].[Album_Comment] CHECK CONSTRAINT [FK_Album_Comment_Album]
GO
ALTER TABLE [dbo].[Album_Comment]  WITH CHECK ADD  CONSTRAINT [FK_Album_Comment_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Album_Comment] CHECK CONSTRAINT [FK_Album_Comment_User]
GO
ALTER TABLE [dbo].[Album_Point]  WITH CHECK ADD  CONSTRAINT [FK_Album_Point_Album] FOREIGN KEY([Alb_ID])
REFERENCES [dbo].[Album] ([Alb_ID])
GO
ALTER TABLE [dbo].[Album_Point] CHECK CONSTRAINT [FK_Album_Point_Album]
GO
ALTER TABLE [dbo].[Album_Point]  WITH CHECK ADD  CONSTRAINT [FK_Album_Point_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Album_Point] CHECK CONSTRAINT [FK_Album_Point_User]
GO
ALTER TABLE [dbo].[Album_Save]  WITH CHECK ADD  CONSTRAINT [FK_Album_Save_Album] FOREIGN KEY([Alb_ID])
REFERENCES [dbo].[Album] ([Alb_ID])
GO
ALTER TABLE [dbo].[Album_Save] CHECK CONSTRAINT [FK_Album_Save_Album]
GO
ALTER TABLE [dbo].[Album_Save]  WITH CHECK ADD  CONSTRAINT [FK_Album_Save_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Album_Save] CHECK CONSTRAINT [FK_Album_Save_User]
GO
ALTER TABLE [dbo].[Attention]  WITH CHECK ADD  CONSTRAINT [FK_Attention_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Attention] CHECK CONSTRAINT [FK_Attention_User]
GO
ALTER TABLE [dbo].[Attention]  WITH CHECK ADD  CONSTRAINT [FK_Attention_User1] FOREIGN KEY([To_User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Attention] CHECK CONSTRAINT [FK_Attention_User1]
GO
ALTER TABLE [dbo].[News]  WITH CHECK ADD  CONSTRAINT [FK_News_Manager] FOREIGN KEY([Man_ID])
REFERENCES [dbo].[Manager] ([Man_ID])
GO
ALTER TABLE [dbo].[News] CHECK CONSTRAINT [FK_News_Manager]
GO
ALTER TABLE [dbo].[News_Comment]  WITH CHECK ADD  CONSTRAINT [FK_News_Comment_News] FOREIGN KEY([News_ID])
REFERENCES [dbo].[News] ([News_ID])
GO
ALTER TABLE [dbo].[News_Comment] CHECK CONSTRAINT [FK_News_Comment_News]
GO
ALTER TABLE [dbo].[News_Comment]  WITH CHECK ADD  CONSTRAINT [FK_News_Comment_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[News_Comment] CHECK CONSTRAINT [FK_News_Comment_User]
GO
ALTER TABLE [dbo].[Pic_Comment]  WITH CHECK ADD  CONSTRAINT [FK_Pic_Comment_Picture] FOREIGN KEY([Pic_ID])
REFERENCES [dbo].[Picture] ([Pic_ID])
GO
ALTER TABLE [dbo].[Pic_Comment] CHECK CONSTRAINT [FK_Pic_Comment_Picture]
GO
ALTER TABLE [dbo].[Pic_Comment]  WITH CHECK ADD  CONSTRAINT [FK_Pic_Comment_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Pic_Comment] CHECK CONSTRAINT [FK_Pic_Comment_User]
GO
ALTER TABLE [dbo].[Pic_Comment_Comment]  WITH CHECK ADD  CONSTRAINT [FK_Pic_Comment_Comment_Pic_Comment] FOREIGN KEY([PC_ID])
REFERENCES [dbo].[Pic_Comment] ([PC_ID])
GO
ALTER TABLE [dbo].[Pic_Comment_Comment] CHECK CONSTRAINT [FK_Pic_Comment_Comment_Pic_Comment]
GO
ALTER TABLE [dbo].[Pic_Comment_Comment]  WITH CHECK ADD  CONSTRAINT [FK_Pic_Comment_Comment_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Pic_Comment_Comment] CHECK CONSTRAINT [FK_Pic_Comment_Comment_User]
GO
ALTER TABLE [dbo].[Pic_Point]  WITH CHECK ADD  CONSTRAINT [FK_Pic_Point_Picture] FOREIGN KEY([Pic_ID])
REFERENCES [dbo].[Picture] ([Pic_ID])
GO
ALTER TABLE [dbo].[Pic_Point] CHECK CONSTRAINT [FK_Pic_Point_Picture]
GO
ALTER TABLE [dbo].[Pic_Point]  WITH CHECK ADD  CONSTRAINT [FK_Pic_Point_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Pic_Point] CHECK CONSTRAINT [FK_Pic_Point_User]
GO
ALTER TABLE [dbo].[Picture]  WITH CHECK ADD  CONSTRAINT [FK_Picture_Picture] FOREIGN KEY([Pic_ID])
REFERENCES [dbo].[Picture] ([Pic_ID])
GO
ALTER TABLE [dbo].[Picture] CHECK CONSTRAINT [FK_Picture_Picture]
GO
ALTER TABLE [dbo].[Picture]  WITH CHECK ADD  CONSTRAINT [FK_Picture_Picture_Type] FOREIGN KEY([Type_ID])
REFERENCES [dbo].[Picture_Type] ([Type_ID])
GO
ALTER TABLE [dbo].[Picture] CHECK CONSTRAINT [FK_Picture_Picture_Type]
GO
ALTER TABLE [dbo].[Picture]  WITH CHECK ADD  CONSTRAINT [FK_Picture_User] FOREIGN KEY([User_ID])
REFERENCES [dbo].[User] ([User_ID])
GO
ALTER TABLE [dbo].[Picture] CHECK CONSTRAINT [FK_Picture_User]
GO
ALTER TABLE [dbo].[Picture_In_Album]  WITH CHECK ADD  CONSTRAINT [FK_Picture_In_Album_Album] FOREIGN KEY([Alb_ID])
REFERENCES [dbo].[Album] ([Alb_ID])
GO
ALTER TABLE [dbo].[Picture_In_Album] CHECK CONSTRAINT [FK_Picture_In_Album_Album]
GO
ALTER TABLE [dbo].[Picture_In_Album]  WITH CHECK ADD  CONSTRAINT [FK_Picture_In_Album_Picture] FOREIGN KEY([Pic_ID])
REFERENCES [dbo].[Picture] ([Pic_ID])
GO
ALTER TABLE [dbo].[Picture_In_Album] CHECK CONSTRAINT [FK_Picture_In_Album_Picture]
GO
USE [master]
GO
ALTER DATABASE [SEE] SET  READ_WRITE 
GO
