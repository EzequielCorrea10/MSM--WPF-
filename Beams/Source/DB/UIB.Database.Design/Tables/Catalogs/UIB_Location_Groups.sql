CREATE TABLE [common].[HSM_Location_Groups](
	[IdLocationGroup] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Height] [int] NOT NULL,
	[AllowDisable] [bit] NOT NULL,
	[AllowDeparture] [bit] NOT NULL,
	[AllowArrival] [bit] NOT NULL,
	[L3Value] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Location_Groups] PRIMARY KEY CLUSTERED 
(
	[IdLocationGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HSM_Location_Groups] ADD  CONSTRAINT [DF_HSM_Location_Groups_Active]  DEFAULT ((1)) FOR [Active]
GO