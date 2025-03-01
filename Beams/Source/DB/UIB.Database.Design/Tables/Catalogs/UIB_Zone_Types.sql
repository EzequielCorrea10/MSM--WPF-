﻿CREATE TABLE [safety].[HSM_Zone_Types](
	[IdZoneType] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FullDescription] [varchar](100) NULL,
	[ColorShown] [varchar](20) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_HSM_Zone_Types] PRIMARY KEY CLUSTERED 
(
	[IdZoneType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO 

CREATE UNIQUE NONCLUSTERED INDEX [IX_HSM_Zone_Types_Name] ON [safety].[HSM_Zone_Types]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

ALTER TABLE [safety].[HSM_Zone_Types] ADD  CONSTRAINT [DF_HSM_Zone_Types_Active]  DEFAULT ((1)) FOR [Active]
