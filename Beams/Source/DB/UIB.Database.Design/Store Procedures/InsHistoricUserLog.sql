CREATE PROCEDURE [rodeo].[InsHistoricUserLog]
	@IdClient int,
	@IdSession int,
	@UserName varchar(20),
	@TimeIN datetimeoffset(7),
	@TimeOUT datetimeoffset(7) = NULL,
	@AuthorIN varchar(20) = NULL,
	@AuthorOUT varchar(20) = NULL,
	@IsForced bit,
	@IdUserLogHistory bigint = NULL OUTPUT
AS
BEGIN

	BEGIN TRY
		BEGIN TRANSACTION;

		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		INSERT INTO [rodeo].[Rodeo_UserLogs_History]
			(IdClient,
			 IdSession,
			 [UserName],
			 TimeIN,
			 [TimeOUT],
			 AuthorIN,
			 AuthorOUT,
			 [IsCloseForced])
		VALUES
			(@IdClient,
			 @IdSession,
			 @UserName,
			 @TimeIN,
			 @TimeOUT,
			 @AuthorIN,
			 @AuthorOUT,
			 @IsForced)

		COMMIT TRANSACTION;

		SELECT @IdUserLogHistory = SCOPE_IDENTITY();

	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		DECLARE @ErrorMessage NVARCHAR(4000);  
		DECLARE @ErrorSeverity INT;  
		DECLARE @ErrorState INT;  
		DECLARE @ErrorNumber INT;
  
		SELECT   
			@ErrorMessage = ERROR_MESSAGE(),  
			@ErrorSeverity = ERROR_SEVERITY(),  
			@ErrorState = ERROR_STATE(),
			@ErrorNumber = ERROR_NUMBER();  
  
		IF @ErrorNumber = 2627 OR @ErrorNumber = 2601 
		BEGIN
			UPDATE [rodeo].[Rodeo_UserLogs_History]
			SET	[UserName] = @UserName,
				[TimeOUT] = @TimeOUT,
				AuthorIN = @AuthorIN,
				AuthorOUT = @AuthorOUT,
				[IsCloseForced] = @IsForced,
				UpdDateTime = SYSDATETIMEOFFSET(),
				@IdUserLogHistory = IdUserLogHistory
			WHERE IdClient = @IdClient 
			AND IdSession = @IdSession
			AND TimeIN = @TimeIN
		END
		ELSE
		BEGIN
			-- Use RAISERROR inside the CATCH block to return error  
			-- information about the original error that caused  
			-- execution to jump to the CATCH block.  
			RAISERROR (@ErrorMessage, -- Message text.  
					   @ErrorSeverity, -- Severity.  
					   @ErrorState -- State.  
					   );  
		END;
	END CATCH

	RETURN @IdUserLogHistory;

END
