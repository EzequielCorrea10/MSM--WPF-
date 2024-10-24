CREATE PROCEDURE [rodeo].[UpdHistoricUserLog]
	@IdClient int,
	@IdSession int,
	@UserName varchar(20),
	@TimeIN datetimeoffset(7) = NULL,
	@TimeOUT datetimeoffset(7) = NULL,
	@AuthorIN varchar(20) = NULL,
	@AuthorOUT varchar(20) = NULL,
	@IsForced bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [rodeo].[Rodeo_UserLogs_History]
	SET	[UserName] = @UserName,
		[TimeOUT] = @TimeOUT,
		AuthorIN = @AuthorIN,
		AuthorOUT = @AuthorOUT,
		[IsCloseForced] = @IsForced,
		UpdDateTime = SYSDATETIMEOFFSET()
	WHERE IdClient = @IdClient 
	AND IdSession = @IdSession
	AND TimeIN = @TimeIN
END