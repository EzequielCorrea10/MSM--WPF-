CREATE TABLE [tracking].[MSM_Pick_Lists](
	[IdPickList] [int] NOT NULL,
	[IdPickListGroup] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Position] [int] NOT NULL,
	[BackgroundColor] [varchar](10) NOT NULL,
	[ForegroundColor] [varchar](10) NOT NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Pick_Lists] PRIMARY KEY CLUSTERED 
(
	[IdPickList] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_MSM_Pick_Lists_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_MSM_Pick_Lists_Name] ON [tracking].[MSM_Pick_Lists]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [tracking].[MSM_Pick_Lists]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Pick_Lists_MSM_Pick_List_Groups] FOREIGN KEY([IdPickListGroup]) REFERENCES [tracking].[MSM_Pick_List_Groups] ([IdPickListGroup])

GO

ALTER TABLE [tracking].[MSM_Pick_Lists] CHECK CONSTRAINT [FK_MSM_Pick_Lists_MSM_Pick_List_Groups]

GO

ALTER TABLE [tracking].[MSM_Pick_Lists] ADD  CONSTRAINT [DF_MSM_Pick_Lists_Active]  DEFAULT ((1)) FOR [Active]
