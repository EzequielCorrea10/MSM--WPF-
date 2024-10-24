CREATE TABLE [safety].[MSM_Zone_Dependencies](
	[IdZoneParent] [int] NOT NULL,
	[IdZoneChild] [int] NOT NULL,
	[ValidateAlwaysOnDisable] [bit] NOT NULL,
	[ValidateRequestOnlyOnDisable] [bit] NOT NULL,
	[DisableOnCascade] [bit] NOT NULL,
	[EnableOnCascade] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Zone_Dependencies] PRIMARY KEY CLUSTERED 
(
	[IdZoneParent] ASC,
	[IdZoneChild] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
    CONSTRAINT [CK_MSM_Zone_Dependencies] CHECK ([IdZoneParent] <> [IdZoneChild]),
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[MSM_Zone_Dependencies]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Zone_Dependencies_Parent_MSM_Zones] FOREIGN KEY([IdZoneParent]) REFERENCES [safety].[MSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[MSM_Zone_Dependencies] CHECK CONSTRAINT [FK_MSM_Zone_Dependencies_Parent_MSM_Zones]

GO

ALTER TABLE [safety].[MSM_Zone_Dependencies]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Zone_Dependencies_Child_MSM_Zones] FOREIGN KEY([IdZoneChild]) REFERENCES [safety].[MSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[MSM_Zone_Dependencies] CHECK CONSTRAINT [FK_MSM_Zone_Dependencies_Child_MSM_Zones]

GO

ALTER TABLE [safety].[MSM_Zone_Dependencies] ADD  CONSTRAINT [DF_MSM_Zone_Dependencies_Active]  DEFAULT ((1)) FOR [Active]
