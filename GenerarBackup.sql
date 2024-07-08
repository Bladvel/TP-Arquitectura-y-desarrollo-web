BACKUP DATABASE [MOODFLIX] 
TO DISK = N'C:\\Users\\Dan\\Desktop\\Moodflix.bak' 
WITH NOFORMAT, NOINIT, 
NAME = N'MOODFLIX-Completa Base de datos Copia de seguridad', 
SKIP, NOREWIND, NOUNLOAD,  
STATS = 10;