using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CLI
{

    internal class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 0) { PrintHelp(); return; }
            string presetName;
            int argindex = 0;
            while (argindex < args.Length)
            {
                if (args[argindex] == "-h" || args[argindex] == "--help")
                {
                    PrintHelp(); return;
                }
                if (args[argindex] == "-p" || args[argindex] == "--preset")
                {
                    try
                    {
                        presetName = args[++argindex];
                    }
                    catch
                    {
                        PrintHelp(); return;
                    }
                    RunPreset(presetName, args.Skip(argindex+1).ToArray()); return;
                }
                argindex++;
            }
            PrintHelp(); return;
        }

        static void RunPreset(string presetName, string[] files)
        {
            var settings = new LibFFR.SettingsInterface();
            var preset = settings.PresetByName(presetName);
            if (preset == null) { PrintHelp(); return; }
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
                p.Start();
                p.WaitForExit();
            }
        }

        static void PrintHelp()
        {
            throw new NotImplementedException();
        }
    }
}
