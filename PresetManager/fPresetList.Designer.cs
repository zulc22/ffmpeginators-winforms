namespace PresetManager
{
    partial class fPresetList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPresetList));
            this.lbPresets = new System.Windows.Forms.ListBox();
            this.cmsPreset = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnResetShortcuts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbPresets
            // 
            this.lbPresets.ContextMenuStrip = this.cmsPreset;
            this.lbPresets.FormattingEnabled = true;
            this.lbPresets.Location = new System.Drawing.Point(13, 26);
            this.lbPresets.Name = "lbPresets";
            this.lbPresets.Size = new System.Drawing.Size(332, 173);
            this.lbPresets.TabIndex = 0;
            this.lbPresets.SelectedIndexChanged += new System.EventHandler(this.lbPresets_SelectedIndexChanged);
            this.lbPresets.DoubleClick += new System.EventHandler(this.lbPresets_DoubleClick);
            // 
            // cmsPreset
            // 
            this.cmsPreset.Name = "cmsPreset";
            this.cmsPreset.Size = new System.Drawing.Size(61, 4);
            this.cmsPreset.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPreset_Opening);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(13, 205);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(49, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New...";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(289, 205);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Done";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnResetShortcuts
            // 
            this.btnResetShortcuts.Location = new System.Drawing.Point(190, 205);
            this.btnResetShortcuts.Name = "btnResetShortcuts";
            this.btnResetShortcuts.Size = new System.Drawing.Size(93, 23);
            this.btnResetShortcuts.TabIndex = 6;
            this.btnResetShortcuts.Text = "Reset Shortcuts";
            this.btnResetShortcuts.UseVisualStyleBackColor = true;
            this.btnResetShortcuts.Click += new System.EventHandler(this.btnResetShortcuts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select an item and right-click for more options";
            // 
            // fPresetList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 236);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnResetShortcuts);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lbPresets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fPresetList";
            this.Text = "FFmpeginator Preset Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fPresetList_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPresets;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnResetShortcuts;
        private System.Windows.Forms.ContextMenuStrip cmsPreset;
        private System.Windows.Forms.Label label1;
    }
}

