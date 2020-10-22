================================================================================
EPSON Advanced Printer Driver for TM-T20II Ver.5

                                Copyright (c) 2013-2016 SEIKO EPSON CORPORATION
================================================================================

1. About this software
    This package includes the following two software programs to use with an EPSON TM series printer.

    1) Windows Printer Driver
        This driver is a Windows Printer Driver for the TM printer.
        This driver makes it possible to print from a Windows application.

    2) StatusAPI
        StatusAPI is a program that works in conjunction with the TM printer driver.
        It offers an Application Program Interface for obtaining the printer status 
        whether or not the printer is printing.  This API makes integrating printer
        status handling functions with applications more simple.

        For detailed information, please see each reference manual.

    3) OS
        The driver operation has been verified with the following operating systems. 

        Windows 10 Pro 64bit
        Windows 8.1 Pro 32/64bit
        Windows 8 Pro 32/64bit
        Windows 7 Ultimate SP1 32/64bit
        Windows Vista Ultimate SP2 32/64bit
        Windows Server 2012 R2 64bit
        Windows Server 2012 64bit
        Windows Server 2008 R2 Enterprise SP1 64bit
        Windows Server 2008 Standard/DataCenter SP2 32bit
        Windows Server 2008 Standard SP2 64bit
        Windows Server 2003 R2 Enterprise SP2 32bit
        Windows Server 2003 R2 Standard SP2 64bit
        Windows XP Embedded SP2 32bit
        Windows Embedded Standard 2009 32bit
        Windows Embedded POSReady 2009 32bit
        Windows Embedded POSReady 7

        This driver is not supported by Windows 95/98/NT/2000 and Windows XP 64bit.

        EPSON IM series PC or IBM compatible PC
 
    4) Supported Printers
        EPSON TM-T20II

        The printer driver operates regardless of the pritner firmware version.


2. Supplied Files
    - APD_507_PT20II_EWM.zip  : Printer Driver, StatusAPI installer with manuals

    Refer to the installation manual APD5_Install_en_revF.pdf.


3. Remarks
    1) For detailed information, please read each manual that is created by the installation
       APD5_MAN_T20II_EN_D.exe.

    2) When an error message is displayed during installation, the following procedure may enable to
       recover from the error.
       1) Specify the uninstall option, and execute the installer "APD_507_T20II.exe /uninstall".
       2) Remove the error factor.
       3) Execute the installer "APD_507_T20II.exe".

    3) Characters may not be printed correctly when using Easy Print of Windows Server 2008.
       For detailed information of this problem arising from the operating system,
       see the following web page provided by Microsoft Corporation.
       http://support.microsoft.com/kb/946411/

    4) In the Easy Print environment of Windows Server 2008, you cannot print the printer device font
       directly.
       However, you can print the device font converted from the True Type font by using
       "Font Substitution" of APD.
       For more information, see "Character Printing (Device Font)" in Printer Manual.

    5) When using Terminal Service and Remote Desktop, interactive communication becomes unavailable
       between the PC and the printer, prohibiting displaying the printer status and obtaining printer
       information using the Status API.

    6) The port redirection function is unavailable for a client when using Terminal Service or
       Remote Desktop.

    7) At times, the status of the shared printer may not be displayed correctly or the Status API may not
       be opened.
       These problems arise from the security policy settings of the operating system.
       Although changing the settings of the operating system is possible by the following steps, it lowers
       the security policy.
       (1) Go to [Start] - [Administrative tool] - [Local Security Policy].
       (2) [Security Option] - [Network Access (Set "Limit anonymous sccesses to the named pipe and shared
           printer" to "Invalid".)]
       However, you do not have to change the settings when a client PC is connected to the domain
       environment and when the same user name as a user name that is logged on a client is existing."

    8) Please use the same version of EPSON Advanced Printer Driver for each host when a network printer
       is shared among two or more hosts.

    9) About how to use .Net module on Windows7/8.
        <In case of Visual Basic .NET (Windows7/8)>
            Example of Visual Basic .NET environment.
            1 Execute Microsoft Visual Basic and and run project window.
            2 Right click for [Reference settings] on Solution explorer and select [add reference].
            3 "Add reference" window is shown and click [Reference] tab.
            4 Select "C:\Programfiles\Epson\Advanced Printer Tool\StatusAPI" in  [File location] and open.
              -In case of 64bitOS, specify "C:\Program Files(x86)\Epson\Advanced Printer Tool\StatusAPI".
            5 Input "EpsonStatusAPI.dll" in [file] menu and click [OK] to select.
            6 Select [ Reference setting ] - [EpsonStatusAPI] in solution explorer.
              And set "False" on [specific version] property.
            7 Add following description in the source code using Imports statement.
              Imports com.epson.pos.driver
            8 Visual Basic .NET is now ready. You can develop application development using Status API.
        <In case of Visual C# (Windows7/8)>
            Following is example of Visual C# development.
            1 Execute Microsoft Visual C# and run project window.
            2 Right click for [Reference settings] on Solution explorer and select [add reference].
            3 "Add reference" window is shown and click [Reference] tab.
            4 Select "C:\Programfiles\Epson\Advanced Printer Tool\StatusAPI" in [File location] and open.
              -In case of 64bitOS, specify "C:\Program Files(x86)\Epson\Advanced Printer Tool\StatusAPI".
            5 Input "EpsonStatusAPI.dll" in [file] menu and click [OK] to select.
            6 Select [ Reference setting ] - [EpsonStatusAPI] in solution explorer.
              And set "False" on [specific version] property.
            7 Add following description in the source code using "using" keyward.
              using com.epson.pos.driver
            8 Visual Basic .NET is now ready. You can develop application development using Status API.


4.Modification from the old version
    Ver5.07
        - Improve the printing performance of the networked printer.
        - Following bugs were fixed
            - Can not use device font when set the barcode font to alias.
            - The driver can not silent install when integrate utility installed.
            - It takes time to job cancel when the printer execute continuous printing.
    Ver5.05r1
        - Improve the printing quality of the bluetooth-connected printer.
    Ver5.04
        - Following functions were added
            - User defined paper is copy installed, if that selected by the driver.
        - Following bugs were fixed
            - PDF417, QRCode and MaxiCode does not support multi byte character input.
            - The printer can not execute print when the driver was silent installed with connect printers to the PC.
            - A networked printer cannot print from the PC that booted while printing from another PC to same printer.
            - If the application uses undefined paper size then the driver uses default paper size.
            - If you print to two printers at the same time, the application crash.
            - The printer may not print when BiCloseMonPrinter of StatusAPI is executed.
            - Processing of BiOpenMonPrinter of StatusAPI takes time.
            - The installer may crash.
    Ver5.01
        - Bluetooth model was supported
        - Following values were changed
            Aquisition interval of status        3000(ms)
            Aquision time out of status          2000(ms)
            Aquisition interval of electrical power supply status    1000(ms)
            Aquisition time out of electrical power supply status    1000(ms)
            Aquisition retry cycle of electrical power supply status  3(times)
            Offline cycle of wireless          1(time)
            Power off cycle of wireless        3(times)
            Offline cycle of wired             1(time)
            Power off cycle of wired           3(times)
        - Following bugs were fixed
            - The spooler crash
            - Printed characters are garbled
            - The application use MFC on Visual Studio6.0 crash
            - Left margine of APD5 is larger than that of APD4
            - The printer can not execute a print because of a port of deletion
            - The printer can not execute a print, because the printer status is not change from "Initialize"
            - The printer can not execute a print from Internet Exploler
            - The networked printer can not execute a print
            - The print stop from the application use StatusAPI (only networked printer)
            - The printer can not execute a print when BiOpenMonPrinter is executed by the application use StatusAPI
            - BiDirectIO send previous data to the printer, when that API is executed
            - The application use StatusAPI crash, when shut down that application
    Ver5.00
        - New release.
