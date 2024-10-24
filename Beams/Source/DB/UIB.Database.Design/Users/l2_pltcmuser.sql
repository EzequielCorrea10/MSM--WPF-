--USE [$(DatabaseName)]

--GO

CREATE USER [l2_pltcmuser]
	FOR LOGIN [l2_pltcmuser]
	WITH DEFAULT_SCHEMA = [l2_pltcm]
GO

GRANT CONNECT TO [l2_pltcmuser]

GO

ALTER ROLE [l2_pltcmaccess] ADD MEMBER [l2_pltcmuser]