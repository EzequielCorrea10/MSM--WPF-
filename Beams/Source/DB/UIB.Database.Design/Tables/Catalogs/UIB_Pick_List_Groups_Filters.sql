CREATE TABLE [tracking].[HCM_Pick_List_Groups_Filters](
	[IdPickListGroup] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Position] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[IdPickListGroupParent] [int] NULL,
 CONSTRAINT [PK_HCM_Pick_List_Groups_Filters] PRIMARY KEY CLUSTERED 
(
	[IdPickListGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [tracking].[HCM_Pick_List_Groups_Filters] ADD  CONSTRAINT [DF_HCM_Pick_List_Groups_Filters_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [tracking].[HCM_Pick_List_Groups_Filters]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Pick_Lists_Groups_Filters_HCM_Pick_List_Groups_Filters] FOREIGN KEY([IdPickListGroupParent])
REFERENCES [tracking].[HCM_Pick_List_Groups_Filters] ([IdPickListGroup])
GO

ALTER TABLE [tracking].[HCM_Pick_List_Groups_Filters] CHECK CONSTRAINT [FK_HCM_Pick_Lists_Groups_Filters_HCM_Pick_List_Groups_Filters]
GO