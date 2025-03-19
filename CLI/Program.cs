using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using LibFFR;

namespace CLI
{

    internal class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0) { PrintHelp(); return; }
            int argindex = 0;
            var settings = new LibFFR.SettingsInterface();
            bool helpNeedsToBePrinted = true;
            bool commandRecognized;
            while (argindex < args.Length)
            {
                commandRecognized = false;
                if (args[argindex] == "-h" || args[argindex] == "--help")
                {
                    commandRecognized = true;
                    PrintHelp(); return;
                }
                if (args[argindex] == "-p" || args[argindex] == "--preset")
                {
                    commandRecognized = true;
                    string presetName;
                    try
                    {
                        presetName = args[++argindex];
                    }
                    catch
                    {
                        PrintHelp(); return;
                    }
                    RunPreset(presetName, args.Skip(argindex+1).ToArray(), settings); return;
                }
                if (args[argindex] == "-ap" || args[argindex] == "--add-preset")
                {
                    commandRecognized = true;
                    string presetName, presetExt, presetArgs;
                    try
                    {
                        presetName = args[++argindex];
                        presetExt = args[++argindex];
                        presetArgs = args[++argindex];
                    } catch
                    {
                        PrintHelp(); return;
                    }
                    settings.AddPreset(new LibFFR.Preset
                    {
                        Name = presetName,
                        FFmpegArguments = presetArgs,
                        FileExtension = presetExt
                    });
                    settings.RecreateShortcuts();
                }
                if (args[argindex] == "-ep" || args[argindex] == "--enable-preset")
                {
                    commandRecognized = true;
                    string presetName;
                    try { presetName = args[++argindex]; }
                    catch { PrintHelp(); return; }
                    settings.EnablePreset(presetName);
                    settings.RecreateShortcuts();
                }
                if (args[argindex] == "-dp" || args[argindex] == "--disable-preset")
                {
                    commandRecognized = true;
                    string presetName;
                    try { presetName = args[++argindex]; }
                    catch { PrintHelp(); return; }
                    settings.DisablePreset(presetName);
                    settings.RecreateShortcuts();
                }
                if (args[argindex] == "-rp" || args[argindex] == "--remove-preset")
                {
                    commandRecognized = true;
                    string presetName;
                    try { presetName = args[++argindex]; }
                    catch { PrintHelp(); return; }
                    settings.RemovePreset(presetName);
                    settings.RecreateShortcuts();
                }
                if (args[argindex] == "-lp" || args[argindex] == "--list-preset" || args[argindex] == "--list-presets")
                {
                    commandRecognized = true;
                    Console.WriteLine("Presets list:");
                    Console.WriteLine();
                    foreach (var p in settings.Presets())
                    {
                        string enabled = p.Enabled ? "enabled" : "disabled";
                        Console.WriteLine($"Preset \"{p.Name}\" ({enabled})");
                        Console.WriteLine("FFmpeg arguments: " + p.FFmpegArguments);
                        Console.WriteLine("File extension: " + p.FileExtension);
                        Console.WriteLine();
                    }
                }
                if (args[argindex] == "-rs" || args[argindex] == "--recreate-shortcuts")
                {
                    settings.RecreateShortcuts();
                }
                if (commandRecognized) helpNeedsToBePrinted = false;
                else
                {
                    PrintHelp(); return;
                }
                argindex++;
            }
            if (helpNeedsToBePrinted) PrintHelp();
        }

        static void RunPreset(string presetName, string[] files, SettingsInterface settings)
        {
            var preset = settings.PresetByName(presetName);
            if (preset == null) { PrintHelp(); return; }
            int filesComplete = 0;
            foreach (string file in files)
            {
                var fnNoExt = Path.GetFileNameWithoutExtension(file);
                var filePath = Path.GetDirectoryName(file);
                var p = new Process();
                p.StartInfo.FileName = "ffmpeg";
                p.StartInfo.Arguments = $"-i \"{file}\" {preset.FFmpegArguments} \"{filePath}\\{fnNoExt}.{preset.FileExtension}\"";
                Console.WriteLine($"> {p.StartInfo.FileName} {p.StartInfo.Arguments}");
                //p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                Console.Title = $"FFmpeginator: {presetName} - Processing {filesComplete+1}/{files.Length} files...";
                p.Start();
                p.WaitForExit();
                if (p.ExitCode != 0)
                {
                    Console.WriteLine("FFmpeg reported error! Press any key to continue...");
                    Console.ReadKey();
                }
                filesComplete++;
            }
        }

        static void PrintHelp()
        {
            Console.Write(@"FFmpeginatorCLI <options...>

options:
    (-h || --help) -> Print help
    (-p || --preset) [preset name] [files...] -> Convert files with preset
    (-ap || --add-preset) [preset name] [extension] [ffmpeg args] -> Create new preset
    (-rp || --remove-preset) [preset name] -> Delete preset
    (-ep || --enable-preset) [preset name] -> Enable preset (show in Send To menu)
    (-dp || --disable-preset) [preset name] -> Disable preset (hide from Send To menu)
    (-lp || --list-preset || --list-presets) -> List presets
    (-rs || --recreate-shortcuts) -> Recreate Send To shortcuts
    (unknown argument || missing parameter) -> Print help

");
        }
    }
}
