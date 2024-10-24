CREATE PROCEDURE [rodeo].[InsHistoricCommand]
	-- Add the parameters for the stored procedure here
	@Tag varchar(60),
    @SetPoint smallint,
    @SentValue nvarchar(MAX),
    @PreviousValue nvarchar(MAX),
    @SentTime datetimeoffset(7),
    @AnswerTime datetimeoffset(7),
    @AnswerCode int,
    @UserName varchar(20),
    @AppName varchar(60),
    @LocName varchar(60),
	@IdCommandHistory bigint = NULL OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [rodeo].[Rodeo_Commands_History]
           ([TagName]
           ,[SetPoint]
           ,[SentValue]
           ,[PreviousValue]
           ,[SentTime]
           ,[AnswerTime]
           ,[AnswerCode]
           ,[UserName]
           ,[AppName]
           ,[LocName])
     VALUES
           (@Tag,
			@SetPoint ,
			@SentValue,
			@PreviousValue,
			@SentTime,
			@AnswerTime,
			@AnswerCode,
			@UserName,
			@AppName,
			@LocName)

	SELECT @IdCommandHistory = SCOPE_IDENTITY();
	RETURN SCOPE_IDENTITY();
END