set startTime=%time%
del .\NSISFinalInstallPackage\Client\VRGameStationClientInstaller.exe
del .\NSISFinalInstallPackage\Server\VRArcadeServerInstaller.exe
del .\NSISFinalInstallPackage\ManagingSystem\VRManagingClientInstaller.exe

cd NSISInstallerProject
call Build
@echo off
echo Start Time: %startTime%
echo Finish Time: %time%
pause
