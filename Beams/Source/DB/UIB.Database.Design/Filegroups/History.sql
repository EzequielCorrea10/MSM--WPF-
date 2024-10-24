/*
Do not change the database path or name variables.
Any sqlcmd variables will be properly substituted during 
build and deployment.
*/
ALTER DATABASE [$(DatabaseName)]
	ADD FILEGROUP [HISTORY]

GO

ALTER DATABASE [$(DatabaseName)]
	ADD FILE
	(
		NAME = N'History',
		FILENAME = '$(DefaultDataPath)$(DefaultFilePrefix)_hist.ndf',
		SIZE = 139264KB,
		MAXSIZE = UNLIMITED, 
		FILEGROWTH = 65536KB
	)
TO FILEGROUP [HISTORY];