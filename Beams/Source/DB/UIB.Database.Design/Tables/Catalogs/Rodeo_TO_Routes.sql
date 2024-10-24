CREATE TABLE [to].[Rodeo_TO_Routes] (
    [IdTORoute]       BIGINT NOT NULL,
    [IdLocationBegin] INT    NOT NULL,
    [IdLocationEnd]   INT    NOT NULL,
    [IdMachine]       INT    NOT NULL,
    [Active]          BIT    NOT NULL,
    CONSTRAINT [PK_Rodeo_TO_Routes] PRIMARY KEY CLUSTERED ([IdTORoute] ASC),
    CONSTRAINT [FK_Rodeo_TO_Routes_Rodeo_Locations] FOREIGN KEY ([IdLocationBegin]) REFERENCES [common].[Rodeo_Locations] ([IdLocation]),
    CONSTRAINT [FK_Rodeo_TO_Routes_Rodeo_Locations1] FOREIGN KEY ([IdLocationEnd]) REFERENCES [common].[Rodeo_Locations] ([IdLocation]),
    CONSTRAINT [FK_Rodeo_TO_Routes_Rodeo_Machines] FOREIGN KEY ([IdMachine]) REFERENCES [common].[Rodeo_Machines] ([IdMachine])
);
GO