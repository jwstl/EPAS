USE [K2ApplicationData]
GO
/****** Object:  Table [MasterData].[DTechGroup]    Script Date: 12/30/2016 3:41:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MasterData].[DTechGroup](
	[Group_ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_DTechGroup] PRIMARY KEY CLUSTERED 
(
	[Group_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MasterData].[DTechHierarchy]    Script Date: 12/30/2016 3:41:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MasterData].[DTechHierarchy](
	[AD_Name] [nvarchar](50) NOT NULL,
	[DTechGroup_ID] [int] NULL,
	[Location] [nvarchar](50) NULL,
	[State] [nvarchar](2) NULL,
	[Name] [nvarchar](50) NULL,
	[Title] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL,
	[PerfManagerName] [nvarchar](50) NULL,
	[PerfManagerAD] [nvarchar](50) NULL,
	[CompManagerName] [nvarchar](50) NULL,
	[CompManagerAD] [nvarchar](50) NULL,
	[Start_Date] [date] NULL,
	[LastReviewDate] [date] NULL,
	[eMail_Address] [nvarchar](100) NULL,
	[ID] [nvarchar](5) NULL,
	[Number] [int] NULL,
	[AnnualReview_IsActive] [bit] NULL,
	[Active_Flag] [bit] NULL,
	[Employee_Flag] [bit] NULL,
	[TimeOffApprover] [nvarchar](50) NULL,
	[TimeOffAccrualAmount] [decimal](4, 2) NULL,
 CONSTRAINT [PK_DTechHierarchy] PRIMARY KEY CLUSTERED 
(
	[AD_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [MasterData].[DTechGroup] ON 

INSERT [MasterData].[DTechGroup] ([Group_ID], [Name]) VALUES (1, N'N/A')
INSERT [MasterData].[DTechGroup] ([Group_ID], [Name]) VALUES (2, N'BPMS')
INSERT [MasterData].[DTechGroup] ([Group_ID], [Name]) VALUES (3, N'ECM')
INSERT [MasterData].[DTechGroup] ([Group_ID], [Name]) VALUES (4, N'G&A')
INSERT [MasterData].[DTechGroup] ([Group_ID], [Name]) VALUES (5, N'Sales')
INSERT [MasterData].[DTechGroup] ([Group_ID], [Name]) VALUES (6, N'Services')
SET IDENTITY_INSERT [MasterData].[DTechGroup] OFF
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Anthony', 2, N'NYC', N'NY', N'Anthony Petro', N'Finance - Assistant Manager', N'Finance', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2014-02-10' AS Date), CAST(N'2016-02-10' AS Date), N'anthony@denallix.com', N'ID5', 5, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Ashley', 2, N'SF', N'CA', N'Ashely Evans', N'Sales Officer', N'Sales', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2016-08-25' AS Date), CAST(N'2016-08-25' AS Date), N'ashley@denallix.com', N'ID15', 15, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Blake', 2, N'Richmond', N'VA', N'Blake Carrigan', N'Finance - Officer', N'Finance', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2015-07-04' AS Date), CAST(N'2016-07-04' AS Date), N'blake@denallix.com', N'ID8', 8, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Bob', 2, N'NYC', N'NY', N'Bob Maggio', N'Finance Manager', N'Finance', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2014-03-12' AS Date), CAST(N'2016-03-12' AS Date), N'bob@denallix.com', N'ID6', 6, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Brandon', 2, N'Reston', N'VA', N'Brandon Brown', N'Director of Finance', N'Operations', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2013-02-01' AS Date), CAST(N'2016-02-01' AS Date), N'brandon@denallix.com', N'ID1', 1, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Chad', 2, N'Cincinnati', N'OH', N'Chad Creew', N'Operations, Support Officer', N'Operations', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2013-03-16' AS Date), CAST(N'2016-03-16' AS Date), N'chad@denallix.com', N'ID2', 2, 1, 1, 1, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Codi', 2, N'Richmond', N'VA', N'Codi Kaji', N'Human Resources - Officer', N'Human Resources', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2015-09-26' AS Date), CAST(N'2016-09-26' AS Date), N'codi@denallix.com', N'ID10', 10, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Debbie', 2, N'Miami', N'FL', N'Debbie Kirchan', N'Legal - Assistant Manager', N'Legal', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2016-03-20' AS Date), CAST(N'2016-03-20' AS Date), N'debbie@denallix.com', N'ID12', 12, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Erica', 2, N'SF', N'CA', N'Erica Ford', N'Chief Operations Officer', N'Operations', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2016-07-24' AS Date), CAST(N'2016-07-24' AS Date), N'erica@denallix.com', N'ID14', 14, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Holly', 2, N'Dallas', N'TX', N'Holly Anderson', N'Sales - Assistant Manager', N'Sales', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2013-10-03' AS Date), CAST(N'2016-10-03' AS Date), N'holly@denallix.com', N'ID3', 3, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Julie', 2, N'SF', N'CA', N'Julie Ambrose', N'Human Resources - Officer', N'Human Resources', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2016-01-15' AS Date), CAST(N'2016-01-15' AS Date), N'julie@denallix.com', N'ID11', 11, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Mark', 2, N'Dallas', N'TX', N'Mark Green', N'K2 Developer', N'BPMS', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2014-01-04' AS Date), CAST(N'2016-01-04' AS Date), N'mark@denallix.com', N'ID4', 4, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Mike', 2, N'NYC', N'NY', N'Mike Talley', N'Finance - Officer', N'Finance', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2014-05-26' AS Date), CAST(N'2016-05-26' AS Date), N'mike@denallix.com', N'ID7', 7, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Rick', 2, N'Richmond', N'VA', N'Rick Cowan', N'Finance - Officer', N'Finance ', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2015-08-15' AS Date), CAST(N'2016-08-15' AS Date), N'rick@denallix.com', N'ID9', 9, 1, NULL, NULL, NULL, NULL)
INSERT [MasterData].[DTechHierarchy] ([AD_Name], [DTechGroup_ID], [Location], [State], [Name], [Title], [Department], [PerfManagerName], [PerfManagerAD], [CompManagerName], [CompManagerAD], [Start_Date], [LastReviewDate], [eMail_Address], [ID], [Number], [AnnualReview_IsActive], [Active_Flag], [Employee_Flag], [TimeOffApprover], [TimeOffAccrualAmount]) VALUES (N'DENALLIX\Sean', 2, N'Miami', N'FL', N'Sean Henderson', N'Operating Officer', N'Operations', N'Rob Joy', N'denallix\rob', N'John Martin', N'denallix\john', CAST(N'2016-05-22' AS Date), CAST(N'2016-12-29' AS Date), N'sean@denallix.com', N'ID13', 12, 0, NULL, NULL, NULL, NULL)
