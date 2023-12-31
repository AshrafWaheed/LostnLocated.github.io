USE [LostnFoundDB]
GO
/****** Object:  Table [dbo].[EnquiryMaster]    Script Date: 03-09-2023 15:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnquiryMaster](
	[EnquiryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[EmailId] [varchar](150) NULL,
	[MobileNo] [varchar](50) NULL,
	[Message] [varchar](max) NULL,
	[EnquityDT] [datetime] NULL,
 CONSTRAINT [PK_EnquiryMaster] PRIMARY KEY CLUSTERED 
(
	[EnquiryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackMaster]    Script Date: 03-09-2023 15:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackMaster](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](100) NOT NULL,
	[FeedTitle] [varchar](50) NULL,
	[FeedText] [varchar](max) NULL,
	[FeedDate] [datetime] NULL,
 CONSTRAINT [PK_FeedbackMaster] PRIMARY KEY CLUSTERED 
(
	[FeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginMaster]    Script Date: 03-09-2023 15:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginMaster](
	[UserId] [varchar](150) NOT NULL,
	[Pass] [varchar](100) NULL,
	[UserType] [varchar](40) NULL,
 CONSTRAINT [PK_LoginMaster] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationMaster]    Script Date: 03-09-2023 15:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationMaster](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[NotificationText] [varchar](max) NULL,
	[NotificationDT] [datetime] NULL,
 CONSTRAINT [PK_NotificationMaster] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostMaster]    Script Date: 03-09-2023 15:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostMaster](
	[LFId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](100) NULL,
	[PostType] [varchar](10) NULL,
	[GoodsCategory] [varchar](50) NULL,
	[DateOfFoundLost] [datetime] NULL,
	[TimeOfFoundLost] [varchar](50) NULL,
	[SpecifyAddress] [varchar](max) NULL,
	[Pincode] [int] NULL,
	[Description] [varchar](max) NULL,
	[GoodsPicName] [varchar](200) NULL,
	[CurrentDate] [date] NULL,
 CONSTRAINT [PK_PostMaster] PRIMARY KEY CLUSTERED 
(
	[LFId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RewardMaster]    Script Date: 03-09-2023 15:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RewardMaster](
	[RewardId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](100) NULL,
	[RewardAmount] [int] NULL,
	[Description] [varchar](max) NULL,
	[DDNumber] [varchar](40) NULL,
	[DDFilePic] [varchar](200) NULL,
 CONSTRAINT [PK_RewardMaster] PRIMARY KEY CLUSTERED 
(
	[RewardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 03-09-2023 15:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[Name] [varchar](100) NULL,
	[Gender] [varchar](10) NULL,
	[DOB] [varchar](30) NULL,
	[MobileNo] [varchar](15) NULL,
	[EmailId] [varchar](100) NOT NULL,
	[FatherName] [varchar](100) NULL,
	[CurrAddress] [varchar](200) NULL,
	[PerAddress] [varchar](200) NULL,
	[RegDate] [datetime] NULL,
 CONSTRAINT [PK_UserMaster] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[EnquiryMaster] ON 

INSERT [dbo].[EnquiryMaster] ([EnquiryId], [Name], [EmailId], [MobileNo], [Message], [EnquityDT]) VALUES (1, N'Namesad', N'asdhf@dskjddh.in', N'1234234', N'asdfasdfadf', CAST(N'2023-08-22T12:48:23.123' AS DateTime))
INSERT [dbo].[EnquiryMaster] ([EnquiryId], [Name], [EmailId], [MobileNo], [Message], [EnquityDT]) VALUES (2, N'Namesad', N'asdhf@dskjddh.in', N'1234234', N'asdfasdfadf', CAST(N'2023-08-22T12:49:29.010' AS DateTime))
INSERT [dbo].[EnquiryMaster] ([EnquiryId], [Name], [EmailId], [MobileNo], [Message], [EnquityDT]) VALUES (3, N'Namesad', N'asdhf@dah.in', N'23423423', N'jjjjjjjjjjjjjjjjjjjjjjjjjjjj', CAST(N'2023-08-22T13:22:00.080' AS DateTime))
INSERT [dbo].[EnquiryMaster] ([EnquiryId], [Name], [EmailId], [MobileNo], [Message], [EnquityDT]) VALUES (4, N'Name9ku66t', N'shhhhhhh@mkl.in', N'1234567890', N'1234567890qwertyuiopasdfghjklzxcvbnm,', CAST(N'2023-08-22T14:55:38.717' AS DateTime))
INSERT [dbo].[EnquiryMaster] ([EnquiryId], [Name], [EmailId], [MobileNo], [Message], [EnquityDT]) VALUES (5, N'Nameds dsk klsdf fd', N'asdhf@dskjdh.in', N'234234423', N'sajas  asjhsd lksjnjh ldkvhekefkh eek belkjelk klef  ef lf ', CAST(N'2023-08-22T14:59:16.717' AS DateTime))
INSERT [dbo].[EnquiryMaster] ([EnquiryId], [Name], [EmailId], [MobileNo], [Message], [EnquityDT]) VALUES (6, N'Namesdvc ', N'jhjhgjhgjh@gdhgf.com', N'123456789', N'asdrtyuiowerthjqwefghnm', CAST(N'2023-08-22T15:30:36.817' AS DateTime))
INSERT [dbo].[EnquiryMaster] ([EnquiryId], [Name], [EmailId], [MobileNo], [Message], [EnquityDT]) VALUES (1002, N'Ashraf Waheed ANsari', N'ale@qdkj.in', N'92384982', N'kjf dkn alkl test enuiry', CAST(N'2023-08-28T20:44:39.240' AS DateTime))
SET IDENTITY_INSERT [dbo].[EnquiryMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedbackMaster] ON 

INSERT [dbo].[FeedbackMaster] ([FeedbackId], [UserId], [FeedTitle], [FeedText], [FeedDate]) VALUES (1, N'alexmurcerr@gmail.com', N'THIS WEBSITE IS COOL', N'THank yyou this is just a test feedback form and im saying to you that i hate my human form of demon i need to get out of this body and go into my own world i cant breath here', CAST(N'2023-08-26T15:25:19.447' AS DateTime))
SET IDENTITY_INSERT [dbo].[FeedbackMaster] OFF
GO
INSERT [dbo].[LoginMaster] ([UserId], [Pass], [UserType]) VALUES (N'admin@gmail.com', N'2345', N'ADMIN')
INSERT [dbo].[LoginMaster] ([UserId], [Pass], [UserType]) VALUES (N'alexmurcerr@gmail.com', N'234567', N'USER')
INSERT [dbo].[LoginMaster] ([UserId], [Pass], [UserType]) VALUES (N'ashraf@as.in', N'Z(3@2345', N'USER')
INSERT [dbo].[LoginMaster] ([UserId], [Pass], [UserType]) VALUES (N'ashrafbatman@bruce.in', N'R@.9:8.:-', N'USER')
INSERT [dbo].[LoginMaster] ([UserId], [Pass], [UserType]) VALUES (N'ashrafhero@superman.in', N'Z(3):5@89:', N'USER')
INSERT [dbo].[LoginMaster] ([UserId], [Pass], [UserType]) VALUES (N'ashrafsuperstar@king.com', N'P2-4@234', N'USER')
GO
SET IDENTITY_INSERT [dbo].[NotificationMaster] ON 

INSERT [dbo].[NotificationMaster] ([NotificationId], [NotificationText], [NotificationDT]) VALUES (18, N'A Jwellery worth RS. 20,00,000 has been lost near Chitrakoot 210204', CAST(N'2023-09-02T01:43:07.067' AS DateTime))
INSERT [dbo].[NotificationMaster] ([NotificationId], [NotificationText], [NotificationDT]) VALUES (19, N'A suitcase has been LOST near Ramayan Mela with important documents- 210204', CAST(N'2023-09-02T01:45:36.883' AS DateTime))
SET IDENTITY_INSERT [dbo].[NotificationMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[PostMaster] ON 

INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1006, N'alexmurcerr@gmail.com', N'LOST', N'Phone', CAST(N'2023-08-15T00:00:00.000' AS DateTime), N'12:48', N'Near Ramayan Mela Maidan Chitrakoot', 210204, N'A blue Samsung Galaxy S20 ', N'malj5i55.e00s20_grey.png', CAST(N'2023-09-03' AS Date))
INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1007, N'alexmurcerr@gmail.com', N'FOUND', N'Keys', CAST(N'2023-07-06T00:00:00.000' AS DateTime), N'12:53', N'Near Kamadgiri Software Solutions', 210204, N'Car Keys Hyundai.', N'finwfjxv.przkeys.jpeg', CAST(N'2023-09-03' AS Date))
INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1008, N'ashraf@as.in', N'LOST', N'Documents', CAST(N'2023-08-10T00:00:00.000' AS DateTime), N'14:54', N'near ramghat first stairs', 210205, N'A green case file, filled with documents', N'43gxcyhm.2xodocument.jpeg', CAST(N'2023-09-03' AS Date))
INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1009, N'ashraf@as.in', N'FOUND', N'Bags', CAST(N'2023-08-30T00:00:00.000' AS DateTime), N'12:57', N'Near Tiraha of Bedi puliya', 210207, N'A brown School bag filled with document and tiffin', N'okkki1lv.wv3bags.jpeg', CAST(N'2023-09-03' AS Date))
INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1010, N'ashrafhero@superman.in', N'LOST', N'Watches', CAST(N'2023-08-27T00:00:00.000' AS DateTime), N'23:02', N'Near Rain Basera Board Fell from the bike', 210204, N'A BeatXp Smart Watch Worth 2000 rupess', N'4c3hicwy.uebwatch.jpeg', CAST(N'2023-09-03' AS Date))
INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1011, N'ashrafhero@superman.in', N'FOUND', N'Clothes', CAST(N'2023-08-18T00:00:00.000' AS DateTime), N'17:03', N'Near CKTD Railway Station Platform 3', 230204, N'Brown Stuffed Jacket Size XXL', N'0up5xrsh.ki5jacket.jpg', CAST(N'2023-09-03' AS Date))
INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1012, N'ashrafsuperstar@king.com', N'LOST', N'Fashion Accessories', CAST(N'2023-08-09T00:00:00.000' AS DateTime), N'16:08', N'Near Mandagini Bhawan, Chitrakoot', 210204, N'Earring Golden, Curvy Looking', N'rxzgislr.nb4earring.jpeg', CAST(N'2023-09-03' AS Date))
INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1013, N'ashrafsuperstar@king.com', N'FOUND', N'Pets', CAST(N'2023-08-16T00:00:00.000' AS DateTime), N'23:22', N'Near Gate of JagatGuru Divyang University', 210204, N'Black German Shepheard, BIg in size and aggressive', N'mjhn05ix.1qodog.jpeg', CAST(N'2023-09-03' AS Date))
INSERT [dbo].[PostMaster] ([LFId], [UserId], [PostType], [GoodsCategory], [DateOfFoundLost], [TimeOfFoundLost], [SpecifyAddress], [Pincode], [Description], [GoodsPicName], [CurrentDate]) VALUES (1014, N'ashrafbatman@bruce.in', N'LOST', N'Automobile', CAST(N'2023-09-02T00:00:00.000' AS DateTime), N'13:11', N'Near Nizami Tire Shop, Ramayan Mela Maidan', 210204, N'Black Passion Pro Number - UP71-AB-2211', N'vpnqu5il.xerbike.jpeg', CAST(N'2023-09-03' AS Date))
SET IDENTITY_INSERT [dbo].[PostMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[RewardMaster] ON 

INSERT [dbo].[RewardMaster] ([RewardId], [UserId], [RewardAmount], [Description], [DDNumber], [DDFilePic]) VALUES (1, N'alexmurcerr@gmail.com', 123, N'A green file case filled with birth certificate, TC and few marksheets.', N'123', N'vedho55l.fkeHackfuel-Digital_Marketing.jpg')
SET IDENTITY_INSERT [dbo].[RewardMaster] OFF
GO
INSERT [dbo].[UserMaster] ([Name], [Gender], [DOB], [MobileNo], [EmailId], [FatherName], [CurrAddress], [PerAddress], [RegDate]) VALUES (N'Ashraf Waheed Ansari', N'Male', N'2022-07-08', N'9142055421', N'alexmurcerr@gmail.com', N'Sarwar Waheed', N'asdsfgdhfjg', N'asdsfgdhfjg', CAST(N'2023-08-26T15:23:53.010' AS DateTime))
INSERT [dbo].[UserMaster] ([Name], [Gender], [DOB], [MobileNo], [EmailId], [FatherName], [CurrAddress], [PerAddress], [RegDate]) VALUES (N'Pro Max Ashraf', N'Male', N'2023-08-31', N'9140220235', N'ashraf@as.in', N'asdasdf', N'asdasd', N'asdasd', CAST(N'2023-09-02T19:03:04.667' AS DateTime))
INSERT [dbo].[UserMaster] ([Name], [Gender], [DOB], [MobileNo], [EmailId], [FatherName], [CurrAddress], [PerAddress], [RegDate]) VALUES (N'Bruce Wayne', N'Male', N'2023-04-06', N'9191919191', N'ashrafbatman@bruce.in', N'THomas Wayne', N'Batcave', N'Batcave', CAST(N'2023-09-03T12:44:50.383' AS DateTime))
INSERT [dbo].[UserMaster] ([Name], [Gender], [DOB], [MobileNo], [EmailId], [FatherName], [CurrAddress], [PerAddress], [RegDate]) VALUES (N'Super Ashraf Waheed', N'Male', N'2023-08-15', N'9140220236', N'ashrafhero@superman.in', N'Father of Superman', N'Krypton', N'Krypton', CAST(N'2023-09-03T12:41:46.173' AS DateTime))
INSERT [dbo].[UserMaster] ([Name], [Gender], [DOB], [MobileNo], [EmailId], [FatherName], [CurrAddress], [PerAddress], [RegDate]) VALUES (N'Ashraf King', N'Male', N'2023-07-19', N'9142022345', N'ashrafsuperstar@king.com', N'Super Father', N'Logo ke Dilo me', N'Logo ke Dilo me', CAST(N'2023-09-03T12:43:33.163' AS DateTime))
GO
ALTER TABLE [dbo].[FeedbackMaster]  WITH CHECK ADD  CONSTRAINT [FK_FeedbackMaster_UserMaster] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([EmailId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeedbackMaster] CHECK CONSTRAINT [FK_FeedbackMaster_UserMaster]
GO
ALTER TABLE [dbo].[PostMaster]  WITH CHECK ADD  CONSTRAINT [FK_PostMaster_UserMaster] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([EmailId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PostMaster] CHECK CONSTRAINT [FK_PostMaster_UserMaster]
GO
ALTER TABLE [dbo].[RewardMaster]  WITH CHECK ADD  CONSTRAINT [FK_RewardMaster_UserMaster] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserMaster] ([EmailId])
GO
ALTER TABLE [dbo].[RewardMaster] CHECK CONSTRAINT [FK_RewardMaster_UserMaster]
GO
