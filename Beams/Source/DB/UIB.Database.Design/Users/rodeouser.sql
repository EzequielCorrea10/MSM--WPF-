--USE [$(DatabaseName)]

--GO

CREATE USER [rodeouser]
	FOR LOGIN [rodeouser]
	WITH DEFAULT_SCHEMA = [rodeo]
GO

GRANT CONNECT TO [rodeouser]

GO

--ALTER AUTHORIZATION ON SCHEMA::[rodeo] TO [rodeouser]
ALTER ROLE [rodeoaccess] ADD MEMBER [rodeouser]