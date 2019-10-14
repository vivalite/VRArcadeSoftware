cd VRArcadeSource
cd VRGameSelectorClientUI
call Build
xcopy .\Bin\*.* ..\..\BuildTemp\Client\ /y /S
cd ..
cd VRGameSelectorDashboardUnity
call Build
xcopy .\Bin\*.* ..\..\BuildTemp\Client\ /y /S
cd ..