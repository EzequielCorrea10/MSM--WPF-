CREATE TABLE [common].[Rodeo_Clients](
	[IdClient] [int] NOT NULL,
	[IdClientType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[IPAddress] [varchar](20) NULL,
	[NAT] [varchar](20) NULL,
	[ConnectivityAlarmname] [varchar](60) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Clients] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[Rodeo_Clients] ADD  CONSTRAINT [DF_Rodeo_Clients_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [common].[Rodeo_Clients]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Clients_Rodeo_Client_Types] FOREIGN KEY([IdClientType])
REFERENCES [common].[Rodeo_Client_Types] ([IdClientType])
GO

ALTER TABLE [common].[Rodeo_Clients] CHECK CONSTRAINT [FK_Rodeo_Clients_Rodeo_Client_Types]
GO


