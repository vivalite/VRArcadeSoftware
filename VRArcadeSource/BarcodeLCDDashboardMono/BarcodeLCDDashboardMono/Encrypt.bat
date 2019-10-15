"C:\Program Files (x86)\Eziriz\IntelliLock\INTELLILOCK.exe" -q -project LockSolutionOnlyEncrypt.ilproj
xcopy .\BarcodeLCDDashboardMono\bin\Release\Encrypted\* .\BarcodeLCDDashboardMono\bin\Release\ /y
del .\BarcodeLCDDashboardMono\bin\Release\*.ilmap