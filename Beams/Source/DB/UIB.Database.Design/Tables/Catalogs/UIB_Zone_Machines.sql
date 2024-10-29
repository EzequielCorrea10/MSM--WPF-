CREATE TABLE [safety].[HCM_Zone_Machines](
	[IdZone] [int] NOT NULL,
	[IdMachineGroup] [int] NOT NULL,
	[CanBeAccessed] [bit] NOT NULL,	
	[AllowTravelAnytime] [bit] NULL,
	[AllowTravelForParking] [bit] NULL,
	[ForbiddenTravelAnytime] [bit] NULL,
	[Active] [bit] NOT NULL,	
 CONSTRAINT [PK_HCM_Zone_Machines] PRIMARY KEY CLUSTERED 
(
	[IdZone] ASC,
	[IdMachineGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

ALTER TABLE [safety].[HCM_Zone_Machines]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Zone_Machines_HCM_Zones] FOREIGN KEY([IdZone]) REFERENCES [safety].[HCM_Zones] ([IdZone])

GO

ALTER TABLE [safety].[HCM_Zone_Machines] CHECK CONSTRAINT [FK_HCM_Zone_Machines_HCM_Zones]

GO

ALTER TABLE [safety].[HCM_Zone_Machines]  WITH CHECK ADD  CONSTRAINT [FK_HCM_Zone_Machines_Rodeo_Machine_Groups] FOREIGN KEY([IdMachineGroup]) REFERENCES [common].[Rodeo_Machine_Groups] ([IdMachineGroup])

GO

ALTER TABLE [safety].[HCM_Zone_Machines] CHECK CONSTRAINT [FK_HCM_Zone_Machines_Rodeo_Machine_Groups]

GO

ALTER TABLE [safety].[HCM_Zone_Machines] ADD  CONSTRAINT [DF_HCM_Zone_Machines_Active]  DEFAULT ((1)) FOR [Active]
