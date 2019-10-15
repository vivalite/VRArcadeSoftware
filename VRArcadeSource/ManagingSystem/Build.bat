set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %msBuildDir%\msbuild.exe  ManagingSystem.sln /p:Configuration=Release /l:FileLogger,Microsoft.Build.Engine;logfile=Manual_MSBuild_ReleaseVersion_LOG.log /t:Clean,Build
@if errorlevel 1 goto ERR
set msBuildDir=
#"C:\Program Files (x86)\Eziriz\IntelliLock\INTELLILOCK.exe" -q -project LockSolution.ilproj
#"C:\Program Files (x86)\Eziriz\IntelliLock\INTELLILOCK.exe" -q -project LockSolutionOnlyEncrypt.ilproj
goto END
:ERR
@echo ERROR!
@pause
:END