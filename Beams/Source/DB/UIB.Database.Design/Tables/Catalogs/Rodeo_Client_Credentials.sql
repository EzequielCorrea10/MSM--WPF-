CREATE TABLE [system].[Rodeo_Client_Credentials](
	[IdClient] [int] NOT NULL,
	[OSUsr] [varchar](50) NULL,
	[OSPwd] [varchar](250) NULL,
	[RDUsr] [varchar](50) NULL,
	[RDPwd] [varchar](250) NULL,
 CONSTRAINT [PK_Rodeo_Client_Credentials] PRIMARY KEY CLUSTERED 
(
	[IdClient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


GO 

ALTER TABLE [system].[Rodeo_Client_Credentials]  WITH CHECK ADD  CONSTRAINT [FK_Rodeo_Client_Credentials_Rodeo_Clients] FOREIGN KEY([IdClient]) REFERENCES [common].[Rodeo_Clients] ([IdClient])

GO

ALTER TABLE [system].[Rodeo_Client_Credentials] CHECK CONSTRAINT [FK_Rodeo_Client_Credentials_Rodeo_Clients]
