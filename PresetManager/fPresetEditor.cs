using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibFFR;

namespace PresetManager
{
    public partial class fPresetEditor : Form
    {
        Preset Preset;
        string OriginalName;
        fPresetList OpenedFrom;
        SettingsInterface Settings;
        bool DiscardPreset = false;

        public fPresetEditor(Preset p, fPresetList parent, SettingsInterface si, bool New=false)
        {
            Settings = si;
            OpenedFrom = parent;
            // Do not modify the 'original' preset in-place (the Settings can't auto-save)
            Preset = (LibFFR.Preset)p.Clone(); 
            OriginalName = Preset.Name;

            // Remove the original preset from the list (don't if this is supposed to be a new preset)
            if (!New && Settings.PresetByName(OriginalName) != null)
            {
                Settings.RemovePreset(OriginalName);
            }
            OpenedFrom.ResetLbPresets(); // Update listbox in main form since we modified the list
            InitializeComponent();

            // Copy Preset data into form fields
            tbPresetName.Text = Preset.Name;
            tbFileExtension.Text = Preset.FileExtension;
            tbArguments.Text = Preset.FFmpegArguments;
            cbEnabled.Checked = Preset.Enabled;
        }

        private void fPresetEditor_Shown(object sender, EventArgs e)
        {
            //OpenedFrom.Hide();
        }

        private void fPresetEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            SyncPresetToForm();
            // Add preset
            Settings.AddPreset(Preset);
            //OpenedFrom.Show();
            OpenedFrom.ResetLbPresets(); // Update listbox in main form since the list was modified
            Dispose(); // mark this object for deletion
        }

        private void SyncPresetToForm()
        {
            // set Preset options to the one in the form
            Preset.Enabled = cbEnabled.Checked;
            Preset.Name = tbPresetName.Text;
            Preset.FileExtension = tbFileExtension.Text;
            // build textbox line list into space-seperated string
            Preset.FFmpegArguments = "";
            for (int i = 0; i < tbArguments.Lines.Length; i++)
            {
                Preset.FFmpegArguments += tbArguments.Lines[i];
                // add a space
                // (don't if this is the last loop, so there isn't a trailing space at the end.)
                if (i != tbArguments.Lines.Length - 1)
                {
                    Preset.FFmpegArguments += " ";
                }
            }
        }

        private void tbFileExtension_TextChanged(object sender, EventArgs e)
        {
            // update example text
            lbExample.Text = $"Example: somemediafile.mp4 => mediafile.{tbFileExtension.Text}";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCopyJSON_Click(object sender, EventArgs e)
        {
            SyncPresetToForm();
            Clipboard.SetText(Preset.ToJson());
            MessageBox.Show("Copied to clipboard");
        }

        private void btnPasteJSON_Click(object sender, EventArgs e)
        {
            Preset presetFromJson;
            try
            {
                presetFromJson = LibFFR.Preset.FromJson(Clipboard.GetText());
            } catch
            {
                MessageBox.Show("Unable to parse the JSON in the clipboard.");
                return;
            }
            (new fPresetEditor(
                presetFromJson,
                OpenedFrom,
                Settings
            )).Show();
            DiscardPreset = true;
            Close();
        }
    }
}
