@ECHO OFF
@ECHO Registrando Bases de datos necesaria...
CD /d %~dp0

:DATABASE
..\databases\installers\CamaraWebsiteDatabase.exe /server:.\SQLEXPRESS /database:CamaraWebsite /makedatabase /quiet
..\databases\installers\CamaraWebsiteErrorsDatabase.exe /server:.\SQLEXPRESS /database:CamaraWebsiteErrors /makedatabase /quiet
..\databases\installers\CamaraWebsiteAccountsDatabase.exe /server:.\SQLEXPRESS /database:CamaraWebsiteAccounts /makedatabase /quiet

:COMPILE
cd ..
REM @ECHO 
REM @ECHO Las Librerias han sido instaladas.
REM @ECHO Ahora se compilara la solucion para probar si todo esta en orden.
REM PAUSE
REM build.bat

:END




PAUSE
