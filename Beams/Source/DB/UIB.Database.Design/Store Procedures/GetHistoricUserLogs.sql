CREATE PROCEDURE [rodeo].[GetHistoricUserLogs]
	-- Add the parameters for the stored procedure here
	@IdClient int = null,
	@IdSession int = null,
	@UserName varchar(200) = null,
	@BeginDate datetimeoffset(7) = null,
	@EndDate datetimeoffset(7) = null,
	@IsShowingCurrent bit = 1,
	@Island varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 
	SELECT 
		IdUserLogHistory,
		IdClient,
		IdSession,
		[UserName],
		TimeIN,
		[TimeOUT],
		AuthorIN,
		AuthorOUT 
	FROM [rodeo].[Rodeo_UserLogs_History] HU
	WHERE HU.[TimeIN] BETWEEN @BeginDate AND @EndDate
	AND ((@IdClient IS NULL) OR HU.[IdClient] = @IdClient)
	AND ((@IdSession IS NULL) OR HU.[IdSession] = @IdSession)
	AND ((@UserName IS NULL) OR HU.[UserName] LIKE @UserName)
	AND ((@IsShowingCurrent = 0) OR HU.[TimeOUT] IS NULL)
	ORDER BY HU.[TimeIN] DESC	
END