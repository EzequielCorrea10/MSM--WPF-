--USE [$(DatabaseName)]

--GO

CREATE ROLE [l2_ppplaccess]

GO

GRANT DELETE, EXECUTE, INSERT, UPDATE, SELECT ON SCHEMA::[l2_pppl] TO [l2_ppplaccess]

GO