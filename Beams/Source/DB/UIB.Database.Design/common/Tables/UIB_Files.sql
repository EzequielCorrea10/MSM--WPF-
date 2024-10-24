CREATE TABLE [common].[UIB_Files] (
    [IdFile]          INT           NOT NULL,
    [IdFileType]      INT           NOT NULL,
    [FileName]        VARCHAR (100) NOT NULL,
    [FullDescription] VARCHAR (100) NULL,
    [Order]           SMALLINT      NOT NULL,
    [Active]          BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdFile] ASC),
    FOREIGN KEY ([IdFileType]) REFERENCES [common].[UIB_File_Types] ([IdFileType])
);

