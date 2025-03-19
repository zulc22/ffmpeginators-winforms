[Setup]
AppName=FFmpeginator
AppVersion=0.2
WizardStyle=modern
DefaultDirName={autopf}\FFmpeginator
DefaultGroupName=FFmpeginator
Compression=lzma2
SolidCompression=yes
OutputDir="."
OutputBaseFilename="setup-ffmpeginator"

SetupIconFile="icons/ff_install.ico"
UninstallIconFile="icons/ff_uninstall.ico"

PrivilegesRequired=lowest
ChangesEnvironment=yes

; "ArchitecturesAllowed=x64compatible" specifies that Setup cannot run
; on anything but x64 and Windows 11 on Arm.
ArchitecturesAllowed=x64compatible
; "ArchitecturesInstallIn64BitMode=x64compatible" requests that the
; install be done in "64-bit mode" on x64 or Windows 11 on Arm,
; meaning it should use the native 64-bit Program Files directory and
; the 64-bit view of the registry.
ArchitecturesInstallIn64BitMode=x64compatible

[Files]
Source: "bin/*.*"; DestDir: "{app}"

[Icons]
Name: "{group}\Preset Manager"; Filename: "{app}\FFmpeginatorPresetManager.exe"
