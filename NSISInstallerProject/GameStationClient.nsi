############################################################################################
#      NSIS Installation Script created by NSIS Quick Setup Script Generator v1.09.18
#               Entirely Edited with NullSoft Scriptable Installation System                
#              by Vlasis K. Barkas aka Red Wine red_wine@freemail.gr Sep 2006               
############################################################################################

!define APP_NAME "VR Arcade Game Station Client"
!define COMP_NAME "21code"
!define VERSION "01.00.00.00"
!define COPYRIGHT "2017 Wei Shi"
!define DESCRIPTION ""
!define INSTALLER_NAME "..\NSISFinalInstallPackage\Client\VRGameStationClientInstaller.exe"
!define MAIN_APP_EXE "VRGameSelectorClientDaemon.exe"
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

!insertmacro MUI_PAGE_INSTFILES

!define MUI_FINISHPAGE_RUN "$INSTDIR\${MAIN_APP_EXE}"
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
Section -MainProgram
	
${INSTALL_TYPE}
!insertmacro CheckNetFramework 46

SimpleSC::StopService "VRArcadeHelper" 1 30
SimpleSC::RemoveService "VRArcadeHelper"

ReadEnvStr $0 COMSPEC
nsExec::Exec '$0 /c "TaskKill /IM VRGameSelectorClientDaemon.exe /F"'
nsExec::Exec '$0 /c "TaskKill /IM VRGameSelector.exe /F"'
nsExec::Exec '$0 /c "TaskKill /IM VRGameSelectorDashboard.exe /F"'

SimpleFC::RemoveApplication "$INSTDIR\VRGameSelectorClientDaemon.exe"
SimpleFC::RemoveApplication "$INSTDIR\VRGameSelector.exe"
SimpleFC::RemoveApplication "$INSTDIR\VRGameSelectorDashboard.exe"

SetOverwrite on
SetOutPath "$INSTDIR"
File /r "..\BuildTemp\Client\*"

SimpleSC::InstallService "VRArcadeHelper" "VR Arcade Game Station Client Helper Service" "16" "2" "$INSTDIR\VRArcadeHelper.exe" "" "" ""
SimpleSC::SetServiceDescription "VRArcadeHelper" "VR Arcade Game Station Client Helper Service"
SimpleSC::StartService "VRArcadeHelper" "" 30

CreateDirectory $APPDATA\VRArcade\Client

CopyFiles $EXEDIR\config.xml $APPDATA\VRArcade\Client

SetOutPath $APPDATA\VRArcade\Client\images
File ".\SupportingFiles\Instructions.png"

AccessControl::GrantOnFile "$APPDATA\VRArcade" "(BU)" "FullAccess"
AccessControl::GrantOnFile "$APPDATA\VRArcade\*" "(BU)" "FullAccess"
AccessControl::GrantOnFile "$APPDATA\VRArcade" "(S-1-5-32-545)" "FullAccess"
AccessControl::GrantOnFile "$APPDATA\VRArcade\*" "(S-1-5-32-545)" "FullAccess"

ReadEnvStr $0 COMSPEC
nsExec::Exec '$0 /c "$INSTDIR\FixPermission.bat"'
nsExec::Exec '$0 /c "$INSTDIR\OpenFirewall.bat"'

SectionEnd
######################################################################

Section -Icons_Reg
SetOutPath "$INSTDIR"
WriteUninstaller "$INSTDIR\uninstall.exe"

!ifdef REG_START_MENU
!insertmacro MUI_STARTMENU_WRITE_BEGIN Application
CreateDirectory "$SMPROGRAMS\$SM_Folder"
CreateShortCut "$SMPROGRAMS\$SM_Folder\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"
CreateShortCut "$DESKTOP\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"
CreateShortCut "$SMPROGRAMS\$SM_Folder\Uninstall ${APP_NAME}.lnk" "$INSTDIR\uninstall.exe"

!ifdef WEB_SITE
WriteIniStr "$INSTDIR\${APP_NAME} website.url" "InternetShortcut" "URL" "${WEB_SITE}"
CreateShortCut "$SMPROGRAMS\$SM_Folder\${APP_NAME} Website.lnk" "$INSTDIR\${APP_NAME} website.url"
!endif
!insertmacro MUI_STARTMENU_WRITE_END
!endif

!ifndef REG_START_MENU
CreateDirectory "$SMPROGRAMS\${APP_NAME}"
CreateShortCut "$SMPROGRAMS\${APP_NAME}\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"
CreateShortCut "$DESKTOP\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"
CreateShortCut "$SMPROGRAMS\${APP_NAME}\Uninstall ${APP_NAME}.lnk" "$INSTDIR\uninstall.exe"
CreateShortCut "$SMPROGRAMS\Startup\${APP_NAME}.lnk" "$INSTDIR\${MAIN_APP_EXE}"

!ifdef WEB_SITE
WriteIniStr "$INSTDIR\${APP_NAME} website.url" "InternetShortcut" "URL" "${WEB_SITE}"
CreateShortCut "$SMPROGRAMS\${APP_NAME}\${APP_NAME} Website.lnk" "$INSTDIR\${APP_NAME} website.url"
!endif
!endif

WriteRegStr ${REG_ROOT} "${REG_APP_PATH}" "" "$INSTDIR\${MAIN_APP_EXE}"
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

SimpleSC::StopService "VRArcadeHelper" 1 30
SimpleSC::RemoveService "VRArcadeHelper"

ReadEnvStr $0 COMSPEC
nsExec::Exec '$0 /c "TaskKill /IM VRGameSelectorClientDaemon.exe /F"'
nsExec::Exec '$0 /c "TaskKill /IM VRGameSelector.exe /F"'
nsExec::Exec '$0 /c "TaskKill /IM VRGameSelectorDashboard.exe /F"'

SimpleFC::RemoveApplication "$INSTDIR\VRGameSelectorClientDaemon.exe"
SimpleFC::RemoveApplication "$INSTDIR\VRGameSelector.exe"
SimpleFC::RemoveApplication "$INSTDIR\VRGameSelectorDashboard.exe"

Delete "$INSTDIR\*"
 
!ifdef WEB_SITE
Delete "$INSTDIR\${APP_NAME} website.url"
!endif

RmDir /r "$INSTDIR"

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

######################################################################

