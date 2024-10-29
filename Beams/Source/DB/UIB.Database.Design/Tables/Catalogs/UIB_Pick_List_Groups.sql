CREATE TABLE [tracking].[HCM_Pick_List_Groups](
	[IdPickListGroup] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Position] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[IdPickListGroupParent] INT NULL, 
    CONSTRAINT [PK_HCM_Pick_List_Groups] PRIMARY KEY CLUSTERED 
(
	[IdPickListGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_HCM_Pick_List_Groups_Name] ON [tracking].[HCM_Pick_List_Groups]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [tracking].[HCM_Pick_List_Groups] ADD  CONSTRAINT [DF_HCM_Pick_List_Groups_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [tracking].[HCM_Pick_List_Groups] ADD CONSTRAINT [FK_HCM_Pick_Lists_Groups_HCM_Pick_List_Groups] FOREIGN KEY([IdPickListGroupParent]) REFERENCES [tracking].[HCM_Pick_List_Groups] ([IdPickListGroup])
GO

ALTER TABLE [tracking].[HCM_Pick_List_Groups] CHECK CONSTRAINT [FK_HCM_Pick_Lists_Groups_HCM_Pick_List_Groups]
GO

