@echo off
setlocal
set RULENAME="VR Arcade Game Station Client - Headset UI"
netsh advfirewall firewall show rule name=%RULENAME% >nul
if ERRORLEVEL 1 (
netsh advfirewall firewall add rule name="VR Arcade Game Station Client - Headset UI" dir=in action=allow program="C:\Program Files\VR Arcade Game Station Client\VRGameSelector.exe" enable=yes
netsh advfirewall firewall add rule name="VR Arcade Game Station Client - Headset UI" dir=out action=allow program="C:\Program Files\VR Arcade Game Station Client\VRGameSelector.exe" enable=yes
)
set RULENAME="VR Arcade Game Station Client - Daemon"
netsh advfirewall firewall show rule name=%RULENAME% >nul
if ERRORLEVEL 1 (
netsh advfirewall firewall add rule name="VR Arcade Game Station Client - Daemon" dir=in action=allow program="C:\Program Files\VR Arcade Game Station Client\VRGameSelectorClientDaemon.exe" enable=yes
netsh advfirewall firewall add rule name="VR Arcade Game Station Client - Daemon" dir=out action=allow program="C:\Program Files\VR Arcade Game Station Client\VRGameSelectorClientDaemon.exe" enable=yes
)
set RULENAME="VR Arcade Game Station Client - Headset Dashboard"
netsh advfirewall firewall show rule name=%RULENAME% >nul
if ERRORLEVEL 1 (
netsh advfirewall firewall add rule name="VR Arcade Game Station Client - Headset Dashboard" dir=in action=allow program="C:\Program Files\VR Arcade Game Station Client\VRGameSelectorDashboard.exe" enable=yes
netsh advfirewall firewall add rule name="VR Arcade Game Station Client - Headset Dashboard" dir=out action=allow program="C:\Program Files\VR Arcade Game Station Client\VRGameSelectorDashboard.exe" enable=yes
)