using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibFFR;

namespace PresetManager
{
    public partial class fPresetList : Form
    {
        private SettingsInterface Settings;
        public List<fPresetEditor> OpenPresetEditors;

        public fPresetList()
        {
            InitializeComponent();
            OpenPresetEditors = new List<fPresetEditor>();
            Settings = new SettingsInterface();
            ResetLbPresets();
            lbPresets_SelectedIndexChanged(null, null);
        }

        public void ResetLbPresets()
        {
            // sort list before adding to UI
            List<Preset> p = new List<Preset>(Settings.Presets());
            p.Sort((Preset i, Preset j) =>
            {
                return i.Name.CompareTo(j.Name);
            });
            lbPresets.Items.Clear();
            lbPresets.Items.AddRange(p.ToArray());
        }

        private void OpenPresetEditor(Preset preset, bool New=false)
        {
            fPresetEditor ed = new fPresetEditor(preset, this, Settings, New);
            ed.Show();
            OpenPresetEditors.Add(ed);
        }

        private void lbPresets_DoubleClick(object sender, EventArgs e)
        {
            if (lbPresets.SelectedIndex == -1) return;
            EditSelectedItem(null, null);
        }

        private void cmsPreset_Opening(object sender, CancelEventArgs e)
        {
            if (lbPresets.SelectedIndex == -1)
            {
                e.Cancel = true;
                return;
            }
            cmsPreset.Items.Clear();
            cmsPreset.Items.Add("Edit", null, EditSelectedItem);
            cmsPreset.Items.Add("Edit copy", null, EditCopyOfSelectedItem);
            cmsPreset.Items.Add("Delete", null, DeleteSelectedItem);
            //if (((Preset)lbPresets.SelectedItem).Enabled)
            //{
            //    cmsPreset.Items.Add("Disable");
            //} else
            //{
            //    cmsPreset.Items.Add("Enable");
            //}
        }

        private void EditCopyOfSelectedItem(object sender, EventArgs e)
        {
            // The Preset Editor makes a copy of the preset anyway,
            // so to make a copy we only have to toggle the flag
            // that makes it not remove the preset from the Settings Interface.
            OpenPresetEditor((Preset)lbPresets.SelectedItem, true);
        }

        private void EditSelectedItem(object sender, EventArgs e)
        {
            OpenPresetEditor((Preset)lbPresets.SelectedItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbPresets.SelectedIndex == -1) return;

        }

        private void lbPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lbPresets.SelectedIndex == -1)
            //{
            //    btnDelete.Enabled = false;
            //} else
            //{
            //    btnDelete.Enabled = true;
            //}
        }

        private void DeleteSelectedItem(object sender, EventArgs e)
        {
            Settings.RemovePreset(((Preset)lbPresets.SelectedItem).Name);
            ResetLbPresets();
        }

        private void btnResetShortcuts_Click(object sender, EventArgs e)
        {
            Settings.RecreateShortcuts();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fPresetEditor editor = new fPresetEditor(new Preset(), this, Settings, true);
            editor.Show();
        }

        private void fPresetList_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (fPresetEditor ed in OpenPresetEditors.ToArray())
            {
                try
                {
                    ed.Close();
                }
                catch { }
            }
        }
    }
}
