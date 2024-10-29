CREATE TABLE [tracking].[HCM_Pick_Lists_Filters](
	[IdPickList] [int] NOT NULL,
	[IdPickListGroup] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Position] [int] NOT NULL,
	[BackgroundColor] [varchar](10) NOT NULL,
	[ForegroundColor] [varchar](10) NOT NULL,
	[PlcValue] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_Pick_Lists_Filters] PRIMARY KEY CLUSTERED 
(
	[IdPickList] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_Pick_Lists_Filters_PlcValue] UNIQUE NONCLUSTERED 
(
	[PlcValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [tracking].[HCM_Pick_Lists_Filters] ADD  CONSTRAINT [DF_HCM_Pick_Lists_Filters_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [tracking].[HCM_Pick_Lists_Filters]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Pick_Lists_Filters_HCM_Pick_List_Groups_Filters] FOREIGN KEY([IdPickListGroup])
REFERENCES [tracking].[HCM_Pick_List_Groups_Filters] ([IdPickListGroup])
GO

ALTER TABLE [tracking].[HCM_Pick_Lists_Filters] CHECK CONSTRAINT [FK_HCM_Pick_Lists_Filters_HCM_Pick_List_Groups_Filters]
GO
