--USE [$(DatabaseName)]

--GO

CREATE ROLE [l2_pltcmaccess]

GO

GRANT DELETE, EXECUTE, INSERT, UPDATE, SELECT ON SCHEMA::[l2_pltcm] TO [l2_pltcmaccess]

GO