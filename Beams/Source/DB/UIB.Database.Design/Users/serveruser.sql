--USE [$(DatabaseName)]

--GO

CREATE USER [serveruser]
	FOR LOGIN [serveruser]
	WITH DEFAULT_SCHEMA = [common]
GO

GRANT CONNECT TO [serveruser]

GO

--ALTER ROLE [db_owner] ADD MEMBER [serveruser]
ALTER ROLE [serveraccess] ADD MEMBER [serveruser]