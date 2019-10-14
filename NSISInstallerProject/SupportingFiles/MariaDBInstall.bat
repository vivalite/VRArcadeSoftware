@echo off
call %SystemRoot%\System32\msiexec.exe /l*v "%~dp0DBInstallLog.log" /i "%~dp0mariadb-10.3.15-winx64.msi" ALLOWREMOTEROOTACCESS=0 PASSWORD=Dfsa3@4SFdA#dssaEi SERVICENAME=MariaDBServer /qb
call %SystemRoot%\System32\msiexec.exe /l*v "%~dp0ConnectInstallLog.log" /i "%~dp0mysql-connector-net-8.0.15.msi" /qb
