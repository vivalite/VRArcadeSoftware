rd /S /Q .\Bin
"C:\Program Files\Unity\Editor\Unity.exe" -quit -batchmode -buildTarget win64  -logFile stdout.log -projectPath "%CD%" -buildWindows64Player "Bin\VRGameSelector.exe"
@if errorlevel 1 goto ERR
del .\Bin\*.pdb
goto END
:ERR
@echo ERROR!
@pause
rd /S /Q .\Temp
:END