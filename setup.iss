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
Source: "bin/*.*"; DestDir: "{app}"; Components: main
Source: "external/gyan/ffmpeg-7.1.1-full_build/bin/ffmpeg.exe"; DestDir: "{app}"; Components: gyanffmpeg

[Components]
Name: "main"; Description: "FFmpeginator"; Types: full compact custom; Flags: fixed
Name: "gyanffmpeg"; Description: "Gyan.dev FFmpeg executable {code:ffmpegnotice}"; Types: custom;

[Icons]
Name: "{group}\Preset Manager"; Filename: "{app}\FFmpeginatorPresetManager.exe"

[Registry]
Root: HKCU; Subkey: "Environment"; \
    ValueType: expandsz; ValueName: "Path"; ValueData: "{olddata};{app}"

[Code]

function ffmpegnotice(p: String): String;
var ResultCode: Integer;
begin

if Exec('ffmpeg','-version','',SW_HIDE,ewWaitUntilTerminated,ResultCode) then begin
  (* ffmpeg ran successfully *)
  Result := '(FFmpeg found on system. not required)';
end else begin
  Result := '(Required. FFmpeg not in path)';
  WizardSelectComponents('gyanffmpeg');
end;

end;