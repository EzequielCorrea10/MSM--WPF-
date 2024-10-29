CREATE PROCEDURE [tracking].[GetGHPNewSequence]
	@sequence int = NULL OUTPUT
AS
BEGIN

	SELECT @sequence = NEXT VALUE FOR [tracking].[HCM_GHP_Reference]
	RETURN @sequence

END