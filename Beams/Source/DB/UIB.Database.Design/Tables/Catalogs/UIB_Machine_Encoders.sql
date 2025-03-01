﻿CREATE TABLE [common].[HSM_Machine_Encoders](
	[IdMachineEncoder] [int] NOT NULL,
	[IdEncoderType] [int] NOT NULL,
	[IdMachine] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[Alias] [varchar](20) NOT NULL,
	[SelectionTagname] [varchar](70) NULL,
	[SelectionBit] [int] NULL,
	[SelectionPlcValue] [int] NULL,
	[Order] [smallint] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Machine_Encoders] PRIMARY KEY CLUSTERED
(
	[IdMachineEncoder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_HSM_Machine_Encoders_Name] UNIQUE NONCLUSTERED 
(
	[IdMachine] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [common].[HSM_Machine_Encoders]  WITH CHECK ADD CONSTRAINT [FK_HSM_Machine_Encoders_HSM_Encoder_Types] FOREIGN KEY([IdEncoderType]) REFERENCES [common].[HSM_Encoder_Types] ([IdEncoderType])

GO

ALTER TABLE [common].[HSM_Machine_Encoders] CHECK CONSTRAINT [FK_HSM_Machine_Encoders_HSM_Encoder_Types]

GO

ALTER TABLE [common].[HSM_Machine_Encoders]  WITH CHECK ADD CONSTRAINT [FK_HSM_Machine_Encoders_Rodeo_Machines] FOREIGN KEY([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])

GO

ALTER TABLE [common].[HSM_Machine_Encoders] CHECK CONSTRAINT [FK_HSM_Machine_Encoders_Rodeo_Machines]

GO

ALTER TABLE [common].[HSM_Machine_Encoders] ADD  CONSTRAINT [DF_HSM_Machine_Encoders_Active]  DEFAULT ((1)) FOR [Active]
GO