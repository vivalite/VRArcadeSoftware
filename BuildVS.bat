cd VRArcadeSource
cd VRGameSelectorClientDaemon
call Build
xcopy .\VRGameSelectorClientDaemon\bin\Release\*.* ..\..\BuildTemp\Client\ /y
#xcopy .\VRGameSelectorClientDaemon\bin\Release\Encrypted\*.* ..\..\BuildTemp\Client\ /y
cd ..
cd VRArcadeHelper
call Build
xcopy .\VRArcadeHelper\bin\Release\*.* ..\..\BuildTemp\Client\ /y
#xcopy .\VRArcadeHelper\bin\Release\Encrypted\*.* ..\..\BuildTemp\Client\ /y
cd ..
cd VRGameSelectorServer
call Build
xcopy .\VRGameSelectorService\bin\Release\*.* ..\..\BuildTemp\Server\ /y
#xcopy .\VRGameSelectorService\bin\Release\Encrypted\*.* ..\..\BuildTemp\Server\ /y
cd ..
cd ManagingSystem
call Build
xcopy .\ManagingSystem\bin\Release\*.* ..\..\BuildTemp\ManagingSystem\ /y
xcopy .\BarcodePrintHelper\bin\Release\*.* ..\..\BuildTemp\ManagingSystem\ /y
#xcopy .\ManagingSystem\bin\Release\Encrypted\*.* ..\..\BuildTemp\ManagingSystem\ /y
cd ..\..
md .\BuildTemp\ILMaps
for /r .\ %%f in (*.ilmap) do @move /y "%%f" .\BuildTemp\ILMaps
del .\BuildTemp\ManagingSystem\*.license