CREATE TABLE [common].[Rodeo_Positions] (
    [IdLocation]  INT                NOT NULL,
    [Alias]       VARCHAR (50)       NULL,
    [X]           INT                NOT NULL,
    [Y]           INT                NOT NULL,
    [Z]           INT                NOT NULL,
    [Heading]     SMALLINT           NOT NULL,
    [Active]      BIT                CONSTRAINT [DF_Rodeo_Positions_Active] DEFAULT ((0)) NOT NULL,
    [UpdDateTime] DATETIMEOFFSET (7) CONSTRAINT [DF_Rodeo_Positions_UpdDateTime] DEFAULT (sysdatetimeoffset()) NOT NULL,
    CONSTRAINT [PK_Rodeo_Positions] PRIMARY KEY CLUSTERED ([IdLocation] ASC),
    CONSTRAINT [FK_Rodeo_Positions_Rodeo_Locations] FOREIGN KEY ([IdLocation]) REFERENCES [common].[Rodeo_Locations] ([IdLocation])
);

