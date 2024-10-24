CREATE PROCEDURE [rodeo].[GetUserLogs]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
 
	SELECT 
		HU.IdUserLogHistory,
		HU.IdClient,
		HU.IdSession,
		HU.[UserName],
		HU.TimeIN,
		HU.[TimeOUT],
		HU.AuthorIN,
		HU.AuthorOUT 
	FROM [rodeo].[Rodeo_UserLogs_History] HU
	WHERE HU.[TimeOUT] IS NULL    
	ORDER BY HU.[TimeIN] DESC	
END