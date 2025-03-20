namespace PresetManager
{
    partial class fPresetEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPresetEditor));
            this.btnOK = new System.Windows.Forms.Button();
            this.lbPresetName = new System.Windows.Forms.Label();
            this.tbPresetName = new System.Windows.Forms.TextBox();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.tbArguments = new System.Windows.Forms.TextBox();
            this.lbNewlines = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFileExt = new System.Windows.Forms.Label();
            this.tbFileExtension = new System.Windows.Forms.TextBox();
            this.lbExample = new System.Windows.Forms.Label();
            this.btnCopyJSON = new System.Windows.Forms.Button();
            this.btnPasteJSON = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(236, 225);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(42, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbPresetName
            // 
            this.lbPresetName.AutoSize = true;
            this.lbPresetName.Location = new System.Drawing.Point(9, 13);
            this.lbPresetName.Name = "lbPresetName";
            this.lbPresetName.Size = new System.Drawing.Size(71, 13);
            this.lbPresetName.TabIndex = 1;
            this.lbPresetName.Text = "Preset Name:";
            // 
            // tbPresetName
            // 
            this.tbPresetName.Location = new System.Drawing.Point(90, 10);
            this.tbPresetName.Name = "tbPresetName";
            this.tbPresetName.Size = new System.Drawing.Size(185, 20);
            this.tbPresetName.TabIndex = 2;
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(12, 202);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(137, 17);
            this.cbEnabled.TabIndex = 3;
            this.cbEnabled.Text = "Show in Send To menu";
            this.cbEnabled.UseVisualStyleBackColor = true;
            // 
            // tbArguments
            // 
            this.tbArguments.Location = new System.Drawing.Point(90, 87);
            this.tbArguments.Multiline = true;
            this.tbArguments.Name = "tbArguments";
            this.tbArguments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbArguments.Size = new System.Drawing.Size(185, 96);
            this.tbArguments.TabIndex = 4;
            // 
            // lbNewlines
            // 
            this.lbNewlines.AutoSize = true;
            this.lbNewlines.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbNewlines.Location = new System.Drawing.Point(87, 186);
            this.lbNewlines.Name = "lbNewlines";
            this.lbNewlines.Size = new System.Drawing.Size(189, 13);
            this.lbNewlines.TabIndex = 5;
            this.lbNewlines.Text = "(newlines will be replaced with spaces)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "FFmpeg Args:";
            // 
            // lbFileExt
            // 
            this.lbFileExt.AutoSize = true;
            this.lbFileExt.Location = new System.Drawing.Point(9, 39);
            this.lbFileExt.Name = "lbFileExt";
            this.lbFileExt.Size = new System.Drawing.Size(75, 13);
            this.lbFileExt.TabIndex = 7;
            this.lbFileExt.Text = "File Extension:";
            // 
            // tbFileExtension
            // 
            this.tbFileExtension.Location = new System.Drawing.Point(90, 36);
            this.tbFileExtension.Name = "tbFileExtension";
            this.tbFileExtension.Size = new System.Drawing.Size(185, 20);
            this.tbFileExtension.TabIndex = 8;
            this.tbFileExtension.TextChanged += new System.EventHandler(this.tbFileExtension_TextChanged);
            // 
            // lbExample
            // 
            this.lbExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExample.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbExample.Location = new System.Drawing.Point(12, 65);
            this.lbExample.Name = "lbExample";
            this.lbExample.Size = new System.Drawing.Size(263, 19);
            this.lbExample.TabIndex = 9;
            this.lbExample.Text = "Example";
            this.lbExample.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCopyJSON
            // 
            this.btnCopyJSON.Location = new System.Drawing.Point(12, 225);
            this.btnCopyJSON.Name = "btnCopyJSON";
            this.btnCopyJSON.Size = new System.Drawing.Size(75, 23);
            this.btnCopyJSON.TabIndex = 10;
            this.btnCopyJSON.Text = "Copy JSON";
            this.btnCopyJSON.UseVisualStyleBackColor = true;
            this.btnCopyJSON.Click += new System.EventHandler(this.btnCopyJSON_Click);
            // 
            // btnPasteJSON
            // 
            this.btnPasteJSON.Location = new System.Drawing.Point(90, 225);
            this.btnPasteJSON.Name = "btnPasteJSON";
            this.btnPasteJSON.Size = new System.Drawing.Size(75, 23);
            this.btnPasteJSON.TabIndex = 11;
            this.btnPasteJSON.Text = "Paste JSON";
            this.btnPasteJSON.UseVisualStyleBackColor = true;
            this.btnPasteJSON.Click += new System.EventHandler(this.btnPasteJSON_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(171, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fPresetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 258);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPasteJSON);
            this.Controls.Add(this.btnCopyJSON);
            this.Controls.Add(this.lbExample);
            this.Controls.Add(this.tbFileExtension);
            this.Controls.Add(this.lbFileExt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNewlines);
            this.Controls.Add(this.tbArguments);
            this.Controls.Add(this.cbEnabled);
            this.Controls.Add(this.tbPresetName);
            this.Controls.Add(this.lbPresetName);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fPresetEditor";
            this.Text = "Preset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fPresetEditor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fPresetEditor_FormClosed);
            this.Shown += new System.EventHandler(this.fPresetEditor_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbPresetName;
        private System.Windows.Forms.TextBox tbPresetName;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.Windows.Forms.TextBox tbArguments;
        private System.Windows.Forms.Label lbNewlines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbFileExt;
        private System.Windows.Forms.TextBox tbFileExtension;
        private System.Windows.Forms.Label lbExample;
        private System.Windows.Forms.Button btnCopyJSON;
        private System.Windows.Forms.Button btnPasteJSON;
        private System.Windows.Forms.Button btnCancel;
    }
}