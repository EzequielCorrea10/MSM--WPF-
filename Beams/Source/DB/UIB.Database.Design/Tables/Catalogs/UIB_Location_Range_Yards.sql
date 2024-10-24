CREATE TABLE [common].[MSM_Location_Range_Yards](
	[IdLocationRange] [int] NOT NULL,
	[IdYard] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_MSM_Location_Range_Yards] PRIMARY KEY CLUSTERED 
(
	[IdLocationRange] ASC,
	[IdYard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[MSM_Location_Range_Yards] ADD  CONSTRAINT [DF_MSM_Location_Range_Yards_Active]  DEFAULT ((1)) FOR [Active]
GO

ALTER TABLE [common].[MSM_Location_Range_Yards]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Location_Range_Yards_MSM_Location_Ranges] FOREIGN KEY([IdLocationRange]) REFERENCES [common].[MSM_Location_Ranges] ([IdLocationRange])
GO

ALTER TABLE [common].[MSM_Location_Range_Yards] CHECK CONSTRAINT [FK_MSM_Location_Range_Yards_MSM_Location_Ranges]
GO

ALTER TABLE [common].[MSM_Location_Range_Yards]  WITH CHECK ADD  CONSTRAINT [FK_MSM_Location_Range_Yards_Rodeo_Yards] FOREIGN KEY([IdYard]) REFERENCES [common].[Rodeo_Yards] ([IdYard])
GO

ALTER TABLE [common].[MSM_Location_Range_Yards] CHECK CONSTRAINT [FK_MSM_Location_Range_Yards_Rodeo_Yards]
GO
