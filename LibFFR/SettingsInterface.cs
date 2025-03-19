using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using File = System.IO.File;

namespace LibFFR
{
    public class Preset
    {
        // the name put before each entry in the Send To menu
        public static string ShortcutNamePrefix = "[FF] ";

        // actual stored information (JSON)
        public bool Enabled = true;
        public string Name = "Example Preset";
        public string FileExtension = "480p.mp4";
        public string FFmpegArguments = "-hide_banner -c:v h264 -c:a aac -pix_fmt yuv420p -vf scale=-1:480 -y";

        // generate a new shortcut
        public void CreateShortcut()
        {
            if (!Enabled) return;
            WshShell shell = new WshShell();
            string shortcutAddress = SpecialLocations.SendTo() + @"\" + ShortcutNamePrefix + Name + ".lnk";
            Console.WriteLine("Creating new shortcut at " + shortcutAddress + ":");
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            // assumedly, FFmpeginatorCLI will be in the same directory as this executable.
            string wd = SpecialLocations.ExeDir();
            Console.WriteLine("WD = " + wd);
            shortcut.WorkingDirectory = wd;
            string tp = $"{wd}\\FFmpeginatorCLI.exe";
            Console.WriteLine("Target = " + tp);
            shortcut.TargetPath = tp;
            string a = $"-p \"{Name}\"";
            Console.WriteLine("Arguments = "+a);
            shortcut.Arguments = a;
            shortcut.Save();
            Console.WriteLine();
        }
    }

    public class Settings
    {
        public List<Preset> Presets;

        public Settings()
        {
            Presets = new List<Preset>();
        }
    }

    public class SettingsInterface
    {
        private Settings settings;
        private bool CurrentlySaving = false;
        private bool QueuedSaveOp = false;
        private string FilePath;
        public SettingsInterface()
        {
            FilePath = SpecialLocations.Roaming() + @"\ffmpeginators.json";
            if (File.Exists(FilePath)) { LoadJson(); return; }
            FilePath = SpecialLocations.ExeDir() + @"\ffmpeginators.json";
            if (File.Exists(FilePath)) { LoadJson(); return; }
            InitJson();
        }
        private void LoadJson()
        {
            settings = JsonConvert.DeserializeObject<Settings>(
                File.ReadAllText(FilePath)
            );
        }
        private void InitJson()
        {
            settings = new Settings();
            settings.Presets.Add(new Preset());
            QueueJsonSave();
        }
        private void QueueJsonSave()
        {
            if (QueuedSaveOp) return;
            if (CurrentlySaving) { QueuedSaveOp = true; return; }
            QueuedSaveOp = true;
            Parallel.Invoke(() =>
            {
                while (QueuedSaveOp) { 
                    CurrentlySaving = true;
                    QueuedSaveOp = false;
                    File.WriteAllText(
                        FilePath,
                        JsonConvert.SerializeObject(settings, Formatting.Indented)
                    );
                    CurrentlySaving = false;
                }
            });
        }
        public Preset[] Presets() => settings.Presets.ToArray();
        public void AddPreset(Preset preset)
        {
            settings.Presets.Add(preset);
            QueueJsonSave();
        }

        public void RemovePreset(Preset preset)
        {
            settings.Presets.Remove(preset);
            QueueJsonSave();
        }

        public void RecreateShortcuts()
        {
            Console.WriteLine("Removing shortcuts...");
            // Remove all existing shortcuts
            foreach (string filePath in Directory.GetFiles(SpecialLocations.SendTo()))
            {
                var fileName = new FileInfo(filePath).Name;
                if (
                    fileName.StartsWith(Preset.ShortcutNamePrefix,true,CultureInfo.CurrentCulture) &&
                    fileName.EndsWith(".lnk",true,CultureInfo.CurrentCulture))
                {
                    File.Delete(filePath);
                }
            }
            Console.WriteLine("Creating shortcuts...");
            // Create new ones
            foreach (var p in settings.Presets) p.CreateShortcut();
        }

        public Preset PresetByName(string name)
        {
            foreach (var p in settings.Presets)
            {
                if (p.Name == name) return p;
            }
            return null;
        }

        public void TogglePreset(string name, bool enabled)
        {
            PresetByName(name).Enabled = enabled;
            QueueJsonSave();
        }

        public void EnablePreset(string name) => TogglePreset(name, true);
        public void DisablePreset(string name) => TogglePreset(name, false);

        public void RemovePreset(string name)
        {
            settings.Presets.Remove(PresetByName(name));
            QueueJsonSave();
        }
    }
}
