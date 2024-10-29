CREATE TABLE [safety].[HSM_Zone_Dependencies](
	[IdZoneParent] [int] NOT NULL,
	[IdZoneChild] [int] NOT NULL,
	[ValidateAlwaysOnDisable] [bit] NOT NULL,
	[ValidateRequestOnlyOnDisable] [bit] NOT NULL,
	[DisableOnCascade] [bit] NOT NULL,
	[EnableOnCascade] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Zone_Dependencies] PRIMARY KEY CLUSTERED 
(
	[IdZoneParent] ASC,
	[IdZoneChild] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
    CONSTRAINT [CK_HSM_Zone_Dependencies] CHECK ([IdZoneParent] <> [IdZoneChild]),
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[HSM_Zone_Dependencies]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Dependencies_Parent_HSM_Zones] FOREIGN KEY([IdZoneParent]) REFERENCES [safety].[HSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[HSM_Zone_Dependencies] CHECK CONSTRAINT [FK_HSM_Zone_Dependencies_Parent_HSM_Zones]

GO

ALTER TABLE [safety].[HSM_Zone_Dependencies]  WITH CHECK ADD  CONSTRAINT [FK_HSM_Zone_Dependencies_Child_HSM_Zones] FOREIGN KEY([IdZoneChild]) REFERENCES [safety].[HSM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[HSM_Zone_Dependencies] CHECK CONSTRAINT [FK_HSM_Zone_Dependencies_Child_HSM_Zones]

GO

ALTER TABLE [safety].[HSM_Zone_Dependencies] ADD  CONSTRAINT [DF_HSM_Zone_Dependencies_Active]  DEFAULT ((1)) FOR [Active]
