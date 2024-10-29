CREATE TABLE [system].[HCM_PLC_Modules](
	[IdPLCModule] [int] NOT NULL,
	[IdPLCRack] [int] NOT NULL,
	[Slot] [int] NULL,
	[Position] [int] NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[IPAddress] [varchar](20) NULL,
	[NAT] [varchar](20) NULL,
	[ConnectivityAlarmname] [varchar](60) NULL,
	[ImageWidth] [float] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HCM_PLC_Modules] PRIMARY KEY CLUSTERED 
(
	[IdPLCModule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HCM_PLC_Modules] UNIQUE NONCLUSTERED 
(
	[IdPLCRack] ASC,
	[Slot] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [system].[HCM_PLC_Modules]  WITH CHECK ADD  CONSTRAINT [FK_HCM_PLC_Modules_HCM_PLC_Racks] FOREIGN KEY([IdPLCRack]) REFERENCES [system].[HCM_PLC_Racks] ([IdPLCRack])

GO

ALTER TABLE [system].[HCM_PLC_Modules] CHECK CONSTRAINT [FK_HCM_PLC_Modules_HCM_PLC_Racks]

GO 

ALTER TABLE [system].[HCM_PLC_Modules] ADD  CONSTRAINT [DF_HCM_PLC_Modules_Active]  DEFAULT ((1)) FOR [Active]
