--USE [$(DatabaseName)]

--GO

CREATE USER [clientuser]
	FOR LOGIN [clientuser]
	WITH DEFAULT_SCHEMA = [common]
GO

GRANT CONNECT TO [clientuser]

GO

ALTER ROLE [clientaccess] ADD MEMBER [clientuser]