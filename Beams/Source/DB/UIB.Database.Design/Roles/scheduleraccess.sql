CREATE ROLE [scheduleraccess]

GO

GRANT SELECT ON SCHEMA::[tracking] TO [scheduleraccess]

GO

GRANT SELECT ON SCHEMA::[common] TO [scheduleraccess]

GO
