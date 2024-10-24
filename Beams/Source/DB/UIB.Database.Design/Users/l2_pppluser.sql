--USE [$(DatabaseName)]

--GO

CREATE USER [l2_pppluser]
	FOR LOGIN [l2_pppluser]
	WITH DEFAULT_SCHEMA = [l2_pppl]
GO

GRANT CONNECT TO [l2_pppluser]

GO

ALTER ROLE [l2_ppplaccess] ADD MEMBER [l2_pppluser]