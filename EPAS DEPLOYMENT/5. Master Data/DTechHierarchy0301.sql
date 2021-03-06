USE [K2ApplicationData]
GO
/****** Object:  Table [MasterData].[DTechHierarchy]    Script Date: 3/1/2017 3:57:34 PM ******/
DROP TABLE [MasterData].[DTechHierarchy]
GO
/****** Object:  Table [MasterData].[DTechHierarchy]    Script Date: 3/1/2017 3:57:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MasterData].[DTechHierarchy](
	[ID] [int] NULL,
	[AD_Name] [nvarchar](50) NOT NULL,
	[DTechGroup_ID] [int] NULL,
	[Location] [nvarchar](50) NULL,
	[State] [nvarchar](2) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Department] [int] NOT NULL,
	[PerfManagerName] [nvarchar](50) NOT NULL,
	[PerfManagerAD] [nvarchar](50) NOT NULL,
	[CompManagerName] [nvarchar](50) NOT NULL,
	[CompManagerAD] [nvarchar](50) NOT NULL,
	[Start_Date] [date] NOT NULL,
	[LastReviewDate] [date] NOT NULL,
	[eMail_Address] [nvarchar](100) NOT NULL,
	[Number] [int] NULL,
	[AnnualReview_IsActive] [bit] NOT NULL,
	[Active_Flag] [bit] NULL,
	[Employee_Flag] [bit] NULL,
	[TimeOffApprover] [nvarchar](50) NULL,
	[TimeOffAccrualAmount] [decimal](4, 2) NULL,
	[Locked] [bit] NULL,
	[NextReviewDate] [date] NULL,
 CONSTRAINT [PK_DTechHierarchy] PRIMARY KEY CLUSTERED 
(
	[AD_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [MasterData].[DTechHierarchy] ([ID], [AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount], [Locked], [NextReviewDate]) VALUES (1, N'DENALLIX\Anthony', 2, N'NYC', N'NY', N'Anthony Petro', N'Finance - Assistant Manager', 2, N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2014-02-10' AS Date), CAST(N'2016-02-10' AS Date), N'anthony@denallix.com', 5, 1, 1, NULL, NULL, NULL, 1, CAST(N'2018-02-10' AS Date))
INSERT [MasterData].[DTechHierarchy] ([ID], [AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount], [Locked], [NextReviewDate]) VALUES (2, N'DENALLIX\Ashley', 2, N'SF', N'CA', N'Ashely Evans', N'Sales Officer', 3, N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2016-08-25' AS Date), CAST(N'2016-08-25' AS Date), N'ashley@denallix.com', 15, 1, 1, NULL, NULL, NULL, 1, CAST(N'2018-08-25' AS Date))
INSERT [MasterData].[DTechHierarchy] ([ID], [AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount], [Locked], [NextReviewDate]) VALUES (3, N'DENALLIX\Blake', 2, N'Richmond', N'VA', N'Blake Carrigan', N'Officer', 5, N'Rob Joy', N'DENALLIX\Rob', N'John Martin', N'DENALLIX\John', CAST(N'2015-07-04' AS Date), CAST(N'2017-02-09' AS Date), N'Blake@denallix.com', 8, 0, 1, NULL, NULL, NULL, NULL, CAST(N'2017-07-04' AS Date))
INSERT [MasterData].[DTechHierarchy] ([ID], [AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount], [Locked], [NextReviewDate]) VALUES (NULL, N'Denallix\Bob', NULL, NULL, NULL, N'Bob Maggio', N'abc', 5, N'dfasdfasdf', N'asfasd', N'adfsdfa', N'adfadfasf', CAST(N'2017-02-23' AS Date), CAST(N'2017-02-14' AS Date), N'abc@gmail.com', NULL, 0, NULL, NULL, NULL, NULL, NULL, CAST(N'2017-02-23' AS Date))
INSERT [MasterData].[DTechHierarchy] ([ID], [AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount], [Locked], [NextReviewDate]) VALUES (NULL, N'DENALLIX\Erica', NULL, NULL, NULL, N'Erica Ford', N'Chief Executive Officer', 6, N'Bob Maggio', N'DENALLIX\Bob', N'John Martin', N'DENALLIX\John', CAST(N'2017-02-15' AS Date), CAST(N'2017-02-22' AS Date), N'Erica@denallix.com', NULL, 1, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-02-14' AS Date))
