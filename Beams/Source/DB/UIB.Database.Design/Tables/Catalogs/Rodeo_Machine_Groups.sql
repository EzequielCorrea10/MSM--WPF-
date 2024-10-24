CREATE TABLE [common].[Rodeo_Machine_Groups](
	[IdMachineGroup] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Rodeo_Machine_Groups] PRIMARY KEY CLUSTERED 
(
	[IdMachineGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[Rodeo_Machine_Groups] ADD  CONSTRAINT [DF_Rodeo_Machine_Groups_Active]  DEFAULT ((1)) FOR [Active]
GO

