CREATE TABLE [common].[HSM_File_Types] (
    [IdFileType]      INT           NOT NULL,
    [Name]            VARCHAR (50)  NOT NULL,
    [FullDescription] VARCHAR (100) NULL,
    [Active]          BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdFileType] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);
GO