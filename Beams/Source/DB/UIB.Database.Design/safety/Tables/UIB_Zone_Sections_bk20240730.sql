CREATE TABLE [safety].[UIB_Zone_Sections_bk20240730] (
    [IdZone]                 INT                NOT NULL,
    [Section]                SMALLINT           NOT NULL,
    [IdYard]                 INT                NULL,
    [X1Pos]                  INT                NULL,
    [Y1Pos]                  INT                NULL,
    [X2Pos]                  INT                NULL,
    [Y2Pos]                  INT                NULL,
    [SafeRunwayInsideX1Pos]  INT                NULL,
    [SafeRunwayInsideX2Pos]  INT                NULL,
    [SafeRunwayInsideY1Pos]  INT                NULL,
    [SafeRunwayInsideY2Pos]  INT                NULL,
    [SafeRunwayOutsideX1Pos] INT                NULL,
    [SafeRunwayOutsideX2Pos] INT                NULL,
    [SafeRunwayOutsideY1Pos] INT                NULL,
    [SafeRunwayOutsideY2Pos] INT                NULL,
    [IsAxisX]                BIT                NULL,
    [TextDisplayed]          VARCHAR (20)       NULL,
    [IsTransportArea]        BIT                NULL,
    [ColorShown]             VARCHAR (20)       NULL,
    [Active]                 BIT                NOT NULL,
    [UpdDateTime]            DATETIMEOFFSET (7) NOT NULL
);

