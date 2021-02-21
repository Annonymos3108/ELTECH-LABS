BACKUP DATABASE Avtopark
TO DISK = 'C:\SQLdata\BACKUPS\Avtopark_FullDbBkup.bak'


RESTORE DATABASE Avtopark
FROM DISK = 'C:\SQLdata\BACKUPS\Avtopark_FullDbBkup.bak'
WITH REPLACE