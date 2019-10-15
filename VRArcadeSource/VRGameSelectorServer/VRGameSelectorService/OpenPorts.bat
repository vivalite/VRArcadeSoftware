@echo off
setlocal
set RULENAME="VR Arcade Management System - Protocol 0"
netsh advfirewall firewall show rule name=%RULENAME% >nul
if ERRORLEVEL 1 (
netsh advfirewall firewall add rule name="VR Arcade Management System - Protocol 0" dir=in action=allow protocol=TCP localport=20017
netsh advfirewall firewall add rule name="VR Arcade Management System - Protocol 0" dir=out action=allow protocol=TCP localport=20017
)
set RULENAME="VR Arcade Management System - Protocol 1"
netsh advfirewall firewall show rule name=%RULENAME% >nul
if ERRORLEVEL 1 (
netsh advfirewall firewall add rule name="VR Arcade Management System - Protocol 1" dir=in action=allow protocol=TCP localport=20018
netsh advfirewall firewall add rule name="VR Arcade Management System - Protocol 1" dir=out action=allow protocol=TCP localport=20018
)
set RULENAME="VR Arcade Management System - Protocol 2"
netsh advfirewall firewall show rule name=%RULENAME% >nul
if ERRORLEVEL 1 (
netsh advfirewall firewall add rule name="VR Arcade Management System - Protocol 2" dir=in action=allow protocol=TCP localport=20019
netsh advfirewall firewall add rule name="VR Arcade Management System - Protocol 2" dir=out action=allow protocol=TCP localport=20019
)