CREATE PROCEDURE [rodeo].[GetHistoricCommands]
	-- Add the parameters for the stored procedure here
	@Description VARCHAR(200) = NULL,
	@PlcId int = NULL,
	@Address VARCHAR(50) = NULL,
	@Tag varchar(60) = NULL,
	@BeginDate datetimeoffset(7),
	@EndDate datetimeoffset(7),
	@UserName VARCHAR(40) = NULL,
	@AppName VARCHAR(60) = NULL,
	@LocName VARCHAR(60) = NULL,
	@Island varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF CHARINDEX('%', @Tag) <= 0
	BEGIN
		SET @Tag = '%' + @Tag + '%'
	END
	
	SELECT 
		 TagName
		,SetPoint
		,SentValue
		,PreviousValue
		,SentTime
		,AnswerTime
		,AnswerCode
		,UserName
		,AppName
		,LocName
	FROM [rodeo].[Rodeo_Commands_History] HC
	WHERE HC.[SentTime] BETWEEN @BeginDate AND @EndDate
	AND (@Tag IS NULL OR HC.[TagName] LIKE @Tag)
	AND (@UserName IS NULL OR HC.[UserName] LIKE @UserName)
	AND (@AppName IS NULL OR HC.[AppName] LIKE @AppName)
	AND (@LocName IS NULL OR HC.[LocName] LIKE @LocName)
	ORDER BY HC.[SentTime] DESC        
END