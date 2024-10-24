--USE [$(DatabaseName)]

--GO

CREATE USER [l2_espuser]
	FOR LOGIN [l2_espuser]
	WITH DEFAULT_SCHEMA = [l2_esp]
GO

GRANT CONNECT TO [l2_espuser]

GO

ALTER ROLE [l2_espaccess] ADD MEMBER [l2_espuser]