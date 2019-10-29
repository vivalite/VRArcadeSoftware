############################################################################################
#      NSIS Installation Script created by NSIS Quick Setup Script Generator v1.09.18
#               Entirely Edited with NullSoft Scriptable Installation System                
#              by Vlasis K. Barkas aka Red Wine red_wine@freemail.gr Sep 2006               
############################################################################################

!define APP_NAME "VR Arcade Server"
!define COMP_NAME "21code"
!define VERSION "01.00.00.00"
!define COPYRIGHT "2017 Wei Shi"
!define DESCRIPTION ""
!define INSTALLER_NAME "..\NSISFinalInstallPackage\Server\VRArcadeServerInstaller.exe"
!define MAIN_APP_EXE "VRArcadeServerService.exe"
!define INSTALL_TYPE "SetShellVarContext all"
!define REG_ROOT "HKLM"
!define LICENSE_TXT "License.txt"
!define REG_APP_PATH "Software\Microsoft\Windows\CurrentVersion\App Paths\${MAIN_APP_EXE}"
!define UNINSTALL_PATH "Software\Microsoft\Windows\CurrentVersion\Uninstall\${APP_NAME}"

######################################################################

VIProductVersion  "${VERSION}"
VIAddVersionKey "ProductName"  "${APP_NAME}"
VIAddVersionKey "CompanyName"  "${COMP_NAME}"
VIAddVersionKey "LegalCopyright"  "${COPYRIGHT}"
VIAddVersionKey "FileDescription"  "${DESCRIPTION}"
VIAddVersionKey "FileVersion"  "${VERSION}"

######################################################################

RequestExecutionLevel admin

SetCompressor ZLIB
Name "${APP_NAME}"
Caption "${APP_NAME}"
OutFile "${INSTALLER_NAME}"
BrandingText "${APP_NAME}"
XPStyle on
InstallDirRegKey "${REG_ROOT}" "${REG_APP_PATH}" ""
InstallDir "$PROGRAMFILES64\${APP_NAME}"

######################################################################
var /GLOBAL WithOption

!include "MUI.nsh"
!include "DotNetChecker.nsh"
!include LogicLib.nsh

!define MUI_ABORTWARNING
!define MUI_UNABORTWARNING

!insertmacro MUI_PAGE_WELCOME

!ifdef LICENSE_TXT
!insertmacro MUI_PAGE_LICENSE "${LICENSE_TXT}"
!endif

!ifdef REG_START_MENU
!define MUI_STARTMENUPAGE_NODISABLE
!define MUI_STARTMENUPAGE_DEFAULTFOLDER "${APP_NAME}"
!define MUI_STARTMENUPAGE_REGISTRY_ROOT "${REG_ROOT}"
!define MUI_STARTMENUPAGE_REGISTRY_KEY "${UNINSTALL_PATH}"
!define MUI_STARTMENUPAGE_REGISTRY_VALUENAME "${REG_START_MENU}"
!insertmacro MUI_PAGE_STARTMENU Application $SM_Folder
!endif
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_INSTFILES

#!define MUI_FINISHPAGE_RUN "$INSTDIR\${MAIN_APP_EXE}"
!insertmacro MUI_PAGE_FINISH

!insertmacro MUI_UNPAGE_CONFIRM

!insertmacro MUI_UNPAGE_INSTFILES

!insertmacro MUI_UNPAGE_FINISH

!insertmacro MUI_LANGUAGE "English"

Function .onInit
UserInfo::GetAccountType
pop $0
${If} $0 != "admin" ;Require admin rights on NT4+
    MessageBox mb_iconstop "Administrator rights required!"
    SetErrorLevel 740 ;ERROR_ELEVATION_REQUIRED
    Quit
${EndIf}
FunctionEnd

######################################################################
SectionGroup /e "VR Arcade Server"
Section "" sec1

${INSTALL_TYPE}
!insertmacro CheckNetFramework 46

SimpleSC::StopService "VRArcadeServerService" 1 30
SimpleSC::RemoveService "VRArcadeServerService"

ReadEnvStr $0 COMSPEC
nsExec::Exec '$0 /c "TaskKill /IM VRArcadeServerService.exe /F"'

#SimpleFC::RemoveApplication "$INSTDIR\VRArcadeServerService.exe"

SetOverwrite on
SetOutPath "$INSTDIR"
File /r "..\BuildTemp\Server\*"
File /r ".\SupportingFiles\mariadb-10.4.8-winx64.msi"
File /r ".\SupportingFiles\mysql-connector-net-8.0.15.msi"
File /r ".\SupportingFiles\SETUP.sql"
File /r ".\SupportingFiles\SQL.sql"

SimpleSC::InstallService "VRArcadeServerService" "VR Arcade Server Service" "16" "2" "$INSTDIR\VRArcadeServerService.exe" "" "" ""
SimpleSC::SetServiceDescription "VRArcadeServerService" "VR Arcade Server Service"

CreateDirectory $APPDATA\VRArcade\Server

CopyFiles $EXEDIR\config.xml $APPDATA\VRArcade\Server

AccessControl::GrantOnFile "$APPDATA\VRArcade" "(BU)" "FullAccess"
AccessControl::GrantOnFile "$APPDATA\VRArcade\*" "(BU)" "FullAccess"
AccessControl::GrantOnFile "$APPDATA\VRArcade" "(S-1-5-32-545)" "FullAccess"
AccessControl::GrantOnFile "$APPDATA\VRArcade\*" "(S-1-5-32-545)" "FullAccess"

ReadEnvStr $0 COMSPEC
nsExec::Exec  '$0 /c "$INSTDIR\FixPermission.bat"'
nsExec::Exec  '$0 /c "$INSTDIR\OpenPorts.bat"'

ExecWait 'msiexec /i "mariadb-10.4.8-winx64.msi" PASSWORD=Dfsa3@4SFdA#dssaEi SERVICENAME=MariaDBServer /qb'
ExecWait 'msiexec /i "mysql-connector-net-8.0.15.msi" /qb'

nsExec::Exec '$0 /c "$PROGRAMFILES64\MariaDB 10.4\bin\mysql.exe" --user=root --password=Dfsa3@4SFdA#dssaEi mysql < SETUP.sql'
nsExec::Exec '$0 /c "$PROGRAMFILES64\MariaDB 10.4\bin\mysql.exe" --user=root --password=Dfsa3@4SFdA#dssaEi vrarcade < SQL.sql'

SimpleSC::StartService "VRArcadeServerService" "" 30

SectionEnd

Section /o "Install Examples" sec2

SimpleSC::StopService "VRArcadeServerService" 1 30

SetOutPath "$INSTDIR"
File /r ".\SupportingFiles\Example.sql"
ReadEnvStr $0 COMSPEC
nsExec::Exec '$0 /c "$PROGRAMFILES64\MariaDB 10.4\bin\mysql.exe" --user=root --password=Dfsa3@4SFdA#dssaEi vrarcade < Example.sql'

SimpleSC::StartService "VRArcadeServerService" "" 30

SectionEnd

SectionGroupEnd

######################################################################

Section -Icons_Reg
SetOutPath "$INSTDIR"
WriteUninstaller "$INSTDIR\uninstall.exe"

!ifdef REG_START_MENU
!insertmacro MUI_STARTMENU_WRITE_BEGIN Application
CreateDirectory "$SMPROGRAMS\$SM_Folder"
#CreateShortCut "$SMPROGRAMS\$SM_Folder\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"
#CreateShortCut "$DESKTOP\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"
CreateShortCut "$SMPROGRAMS\$SM_Folder\Uninstall ${APP_NAME}.lnk" "$INSTDIR\uninstall.exe"

!ifdef WEB_SITE
WriteIniStr "$INSTDIR\${APP_NAME} website.url" "InternetShortcut" "URL" "${WEB_SITE}"
CreateShortCut "$SMPROGRAMS\$SM_Folder\${APP_NAME} Website.lnk" "$INSTDIR\${APP_NAME} website.url"
!endif
!insertmacro MUI_STARTMENU_WRITE_END
!endif

!ifndef REG_START_MENU
CreateDirectory "$SMPROGRAMS\${APP_NAME}"
#CreateShortCut "$SMPROGRAMS\${APP_NAME}\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"
#CreateShortCut "$DESKTOP\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"
CreateShortCut "$SMPROGRAMS\${APP_NAME}\Uninstall ${APP_NAME}.lnk" "$INSTDIR\uninstall.exe"
#CreateShortCut "$SMPROGRAMS\Startup\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"

!ifdef WEB_SITE
WriteIniStr "$INSTDIR\${APP_NAME} website.url" "InternetShortcut" "URL" "${WEB_SITE}"
CreateShortCut "$SMPROGRAMS\${APP_NAME}\${APP_NAME} Website.lnk" "$INSTDIR\${APP_NAME} website.url"
!endif
!endif

#WriteRegStr ${REG_ROOT} "${REG_APP_PATH}" "" "$INSTDIR\${MAIN_APP_EXE}"
WriteRegStr ${REG_ROOT} "${UNINSTALL_PATH}"  "DisplayName" "${APP_NAME}"
WriteRegStr ${REG_ROOT} "${UNINSTALL_PATH}"  "UninstallString" "$INSTDIR\uninstall.exe"
WriteRegStr ${REG_ROOT} "${UNINSTALL_PATH}"  "DisplayIcon" "$INSTDIR\${MAIN_APP_EXE}"
WriteRegStr ${REG_ROOT} "${UNINSTALL_PATH}"  "DisplayVersion" "${VERSION}"
WriteRegStr ${REG_ROOT} "${UNINSTALL_PATH}"  "Publisher" "${COMP_NAME}"

!ifdef WEB_SITE
WriteRegStr ${REG_ROOT} "${UNINSTALL_PATH}"  "URLInfoAbout" "${WEB_SITE}"
!endif
SectionEnd

######################################################################

Section Uninstall
${INSTALL_TYPE}

SimpleSC::StopService "VRArcadeServerService" 1 30
SimpleSC::RemoveService "VRArcadeServerService"

ReadEnvStr $0 COMSPEC
nsExec::Exec '$0 /c "TaskKill /IM VRArcadeServerService.exe /F"'

#SimpleFC::RemoveApplication "$INSTDIR\VRArcadeServerService.exe"

Delete "$INSTDIR\*"
 
!ifdef WEB_SITE
Delete "$INSTDIR\${APP_NAME} website.url"
!endif

RmDir "$INSTDIR"

!ifdef REG_START_MENU
!insertmacro MUI_STARTMENU_GETFOLDER "Application" $SM_Folder
Delete "$SMPROGRAMS\$SM_Folder\${APP_NAME}.lnk"
Delete "$SMPROGRAMS\$SM_Folder\Uninstall ${APP_NAME}.lnk"
Delete "$SMPROGRAMS\Startup\${APP_NAME}.lnk"
!ifdef WEB_SITE
Delete "$SMPROGRAMS\$SM_Folder\${APP_NAME} Website.lnk"
!endif
Delete "$DESKTOP\${APP_NAME}.lnk"

RmDir "$SMPROGRAMS\$SM_Folder"
!endif

!ifndef REG_START_MENU
Delete "$SMPROGRAMS\${APP_NAME}\${APP_NAME}.lnk"
Delete "$SMPROGRAMS\${APP_NAME}\Uninstall ${APP_NAME}.lnk"
Delete "$SMPROGRAMS\Startup\${APP_NAME}.lnk"

!ifdef WEB_SITE
Delete "$SMPROGRAMS\${APP_NAME}\${APP_NAME} Website.lnk"
!endif
Delete "$DESKTOP\${APP_NAME}.lnk"

RmDir "$SMPROGRAMS\${APP_NAME}"
!endif

DeleteRegKey ${REG_ROOT} "${REG_APP_PATH}"
DeleteRegKey ${REG_ROOT} "${UNINSTALL_PATH}"
SectionEnd

Function .onSelChange
SectionGetFlags ${sec1} $R0
IntOp $R0 $R0 & ${SF_SELECTED}
 
${If} $R0 == ${SF_SELECTED}
    !insertmacro ClearSectionFlag ${sec2} ${SF_RO}
${ElseIf} $R0 != ${SF_SELECTED}
    !insertmacro UnSelectSection ${sec2}
    !insertmacro SetSectionFlag ${sec2} ${SF_RO}
${EndIf}
SectionGetFlags ${Sec2} $WithOption
FunctionEnd

######################################################################

