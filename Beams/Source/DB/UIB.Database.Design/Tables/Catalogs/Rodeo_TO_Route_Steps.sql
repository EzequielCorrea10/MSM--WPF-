CREATE TABLE [to].[Rodeo_TO_Route_Steps] (
    [IdTORoute]       BIGINT   NOT NULL,
    [Step]            SMALLINT NOT NULL,
    [IdLocationBegin] INT      NOT NULL,
    [IdLocationEnd]   INT      NOT NULL,
    CONSTRAINT [PK_to.Rodeo_TO_Route_Steps] PRIMARY KEY CLUSTERED ([IdTORoute] ASC, [Step] ASC),
    CONSTRAINT [FK_Rodeo_TO_Route_Steps_Rodeo_Locations_From] FOREIGN KEY ([IdLocationBegin]) REFERENCES [common].[Rodeo_Locations] ([IdLocation]),
    CONSTRAINT [FK_Rodeo_TO_Route_Steps_Rodeo_Locations_To] FOREIGN KEY ([IdLocationEnd]) REFERENCES [common].[Rodeo_Locations] ([IdLocation]),
    CONSTRAINT [FK_Rodeo_TO_Route_Steps_Rodeo_TO_Routes] FOREIGN KEY ([IdTORoute]) REFERENCES [to].[Rodeo_TO_Routes] ([IdTORoute])
);
GO