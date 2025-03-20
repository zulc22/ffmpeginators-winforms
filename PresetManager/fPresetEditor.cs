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

            PresetToForm();
        }

        private void PresetToForm()
        {
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
            if (!DiscardPreset) { 
                FormToPreset();
                // Add preset
                Settings.AddPreset(Preset);
                //OpenedFrom.Show();
                OpenedFrom.ResetLbPresets(); // Update listbox in main form since the list was modified
            }
            // try to remove ourselves from the preset list's list of open preset editors
            try
            {
                OpenedFrom.OpenPresetEditors.Remove(this);
            } catch { }
            Dispose(); // mark this object for deletion
        }

        private void FormToPreset()
        {
            // set Preset options to the one in the form
            Preset.Enabled = cbEnabled.Checked;
            Preset.Name = tbPresetName.Text;
            Preset.FileExtension = tbFileExtension.Text;
            // turn newlines into spaces
            Preset.FFmpegArguments = tbArguments.Text.Replace("\r\n", " ");
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
            FormToPreset();
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
            Preset = presetFromJson;
            PresetToForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DiscardPreset = true;
            Close();
        }

        private void fPresetEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // no name collisions! blehh!!
            while (Settings.PresetByName(tbPresetName.Text) != null)
            {
                tbPresetName.Text += " (copy)";
            }
        }
    }
}
