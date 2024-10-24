
CREATE TABLE [common].[Rodeo_Machine_Type_Positions](
	[IdMachineType] [int] NOT NULL,
	[Position] [smallint] NOT NULL,
	[XOffset] [int] NOT NULL,
	[YOffset] [int] NOT NULL,
	[ZOffset] [int] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Machine_Type_Positions] PRIMARY KEY CLUSTERED 
(
	[IdMachineType] ASC,
	[Position] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[Rodeo_Machine_Type_Positions] ADD  CONSTRAINT [DF_Rodeo_Machine_Type_Positions_XOffset]  DEFAULT ((0)) FOR [XOffset]
GO

ALTER TABLE [common].[Rodeo_Machine_Type_Positions] ADD  CONSTRAINT [DF_Rodeo_Machine_Type_Positions_YOffset]  DEFAULT ((0)) FOR [YOffset]
GO

ALTER TABLE [common].[Rodeo_Machine_Type_Positions] ADD  CONSTRAINT [DF_Rodeo_Machine_Type_Positions_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [common].[Rodeo_Machine_Type_Positions]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Machine_Type_Positions_Rodeo_Machine_Types] FOREIGN KEY([IdMachineType])
REFERENCES [common].[Rodeo_Machine_Types] ([IdMachineType])
GO

ALTER TABLE [common].[Rodeo_Machine_Type_Positions] CHECK CONSTRAINT [FK_Rodeo_Machine_Type_Positions_Rodeo_Machine_Types]
GO
