--USE [$(DatabaseName)]

--GO

CREATE USER [globaluser]
	FOR LOGIN [globaluser]
	WITH DEFAULT_SCHEMA = [global]
GO

GRANT CONNECT TO [globaluser]

GO

ALTER ROLE [globalaccess] ADD MEMBER [globaluser]