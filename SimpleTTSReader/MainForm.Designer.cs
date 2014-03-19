namespace SimpleTTSReader
{
	partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.lblRate = new System.Windows.Forms.Label();
      this.lblVolume = new System.Windows.Forms.Label();
      this.btnTest = new System.Windows.Forms.Button();
      this.lbVoices = new System.Windows.Forms.ListBox();
      this.trbRate = new System.Windows.Forms.TrackBar();
      this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsmiResetRate = new System.Windows.Forms.ToolStripMenuItem();
      this.trbVolume = new System.Windows.Forms.TrackBar();
      this.tbTest = new System.Windows.Forms.TextBox();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.btnAbout = new System.Windows.Forms.Button();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.tsslLink = new System.Windows.Forms.ToolStripStatusLabel();
      this.tssGitLink = new System.Windows.Forms.ToolStripStatusLabel();
      this.cb_Active = new System.Windows.Forms.CheckBox();
      this.btnPause = new System.Windows.Forms.Button();
      this.lbEnablers = new System.Windows.Forms.ListBox();
      ((System.ComponentModel.ISupportInitialize)(this.trbRate)).BeginInit();
      this.cms.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.trbVolume)).BeginInit();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblRate
      // 
      this.lblRate.AutoSize = true;
      this.lblRate.Location = new System.Drawing.Point(16, 123);
      this.lblRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblRate.Name = "lblRate";
      this.lblRate.Size = new System.Drawing.Size(42, 17);
      this.lblRate.TabIndex = 3;
      this.lblRate.Text = "Rate:";
      // 
      // lblVolume
      // 
      this.lblVolume.AutoSize = true;
      this.lblVolume.Location = new System.Drawing.Point(15, 155);
      this.lblVolume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblVolume.Name = "lblVolume";
      this.lblVolume.Size = new System.Drawing.Size(59, 17);
      this.lblVolume.TabIndex = 4;
      this.lblVolume.Text = "Volume:";
      // 
      // btnTest
      // 
      this.btnTest.Location = new System.Drawing.Point(124, 246);
      this.btnTest.Margin = new System.Windows.Forms.Padding(4);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(100, 28);
      this.btnTest.TabIndex = 0;
      this.btnTest.Text = "Test";
      this.btnTest.UseVisualStyleBackColor = true;
      this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // lbVoices
      // 
      this.lbVoices.FormattingEnabled = true;
      this.lbVoices.ItemHeight = 16;
      this.lbVoices.Location = new System.Drawing.Point(16, 15);
      this.lbVoices.Margin = new System.Windows.Forms.Padding(4);
      this.lbVoices.Name = "lbVoices";
      this.lbVoices.Size = new System.Drawing.Size(492, 100);
      this.lbVoices.TabIndex = 1;
      this.lbVoices.SelectedIndexChanged += new System.EventHandler(this.lbVoices_SelectedIndexChanged);
      // 
      // trbRate
      // 
      this.trbRate.ContextMenuStrip = this.cms;
      this.trbRate.Location = new System.Drawing.Point(136, 123);
      this.trbRate.Margin = new System.Windows.Forms.Padding(4);
      this.trbRate.Minimum = -10;
      this.trbRate.Name = "trbRate";
      this.trbRate.Size = new System.Drawing.Size(373, 56);
      this.trbRate.TabIndex = 2;
      this.trbRate.ValueChanged += new System.EventHandler(this.trbRate_ValueChanged);
      // 
      // cms
      // 
      this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiResetRate});
      this.cms.Name = "cms";
      this.cms.Size = new System.Drawing.Size(145, 28);
      // 
      // tsmiResetRate
      // 
      this.tsmiResetRate.Name = "tsmiResetRate";
      this.tsmiResetRate.Size = new System.Drawing.Size(144, 24);
      this.tsmiResetRate.Text = "Reset rate";
      this.tsmiResetRate.Click += new System.EventHandler(this.tsmiResetRate_Click);
      // 
      // trbVolume
      // 
      this.trbVolume.Location = new System.Drawing.Point(135, 155);
      this.trbVolume.Margin = new System.Windows.Forms.Padding(4);
      this.trbVolume.Maximum = 100;
      this.trbVolume.Name = "trbVolume";
      this.trbVolume.Size = new System.Drawing.Size(373, 56);
      this.trbVolume.TabIndex = 5;
      this.trbVolume.TickStyle = System.Windows.Forms.TickStyle.None;
      this.trbVolume.Value = 100;
      this.trbVolume.ValueChanged += new System.EventHandler(this.trbVolume_ValueChanged);
      // 
      // tbTest
      // 
      this.tbTest.Location = new System.Drawing.Point(232, 249);
      this.tbTest.Margin = new System.Windows.Forms.Padding(4);
      this.tbTest.MaxLength = 200;
      this.tbTest.Name = "tbTest";
      this.tbTest.Size = new System.Drawing.Size(276, 22);
      this.tbTest.TabIndex = 6;
      this.tbTest.Text = "This is a test string.";
      // 
      // notifyIcon
      // 
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "Simple TTS Reader";
      this.notifyIcon.Visible = true;
      this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
      // 
      // btnAbout
      // 
      this.btnAbout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnAbout.Location = new System.Drawing.Point(16, 246);
      this.btnAbout.Margin = new System.Windows.Forms.Padding(4);
      this.btnAbout.Name = "btnAbout";
      this.btnAbout.Size = new System.Drawing.Size(100, 28);
      this.btnAbout.TabIndex = 7;
      this.btnAbout.Text = "About";
      this.btnAbout.UseVisualStyleBackColor = true;
      this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
      // 
      // statusStrip
      // 
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslLink,
            this.tssGitLink});
      this.statusStrip.Location = new System.Drawing.Point(0, 293);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
      this.statusStrip.Size = new System.Drawing.Size(525, 25);
      this.statusStrip.SizingGrip = false;
      this.statusStrip.TabIndex = 8;
      this.statusStrip.Text = "statusStrip";
      // 
      // tsslLink
      // 
      this.tsslLink.IsLink = true;
      this.tsslLink.Name = "tsslLink";
      this.tsslLink.Size = new System.Drawing.Size(218, 20);
      this.tsslLink.Text = "simplettsreader.sourceforge.net";
      this.tsslLink.Click += new System.EventHandler(this.tsslLink_Click);
      // 
      // tssGitLink
      // 
      this.tssGitLink.IsLink = true;
      this.tssGitLink.Name = "tssGitLink";
      this.tssGitLink.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
      this.tssGitLink.Size = new System.Drawing.Size(233, 20);
      this.tssGitLink.Text = "github.com.simple-tts-reader.git";
      this.tssGitLink.Click += new System.EventHandler(this.tssGitLink_Click);
      // 
      // cb_Active
      // 
      this.cb_Active.AutoSize = true;
      this.cb_Active.Checked = true;
      this.cb_Active.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cb_Active.Location = new System.Drawing.Point(19, 218);
      this.cb_Active.Name = "cb_Active";
      this.cb_Active.Size = new System.Drawing.Size(68, 21);
      this.cb_Active.TabIndex = 9;
      this.cb_Active.Text = "Active";
      this.cb_Active.UseVisualStyleBackColor = true;
      this.cb_Active.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
      // 
      // btnPause
      // 
      this.btnPause.Location = new System.Drawing.Point(124, 218);
      this.btnPause.Name = "btnPause";
      this.btnPause.Size = new System.Drawing.Size(75, 23);
      this.btnPause.TabIndex = 10;
      this.btnPause.Text = "Pause";
      this.btnPause.UseVisualStyleBackColor = true;
      this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
      // 
      // lbEnablers
      // 
      this.lbEnablers.FormattingEnabled = true;
      this.lbEnablers.ItemHeight = 16;
      this.lbEnablers.Items.AddRange(new object[] {
            "Space",
            "CapsLock",
            "WindowsMenu"});
      this.lbEnablers.Location = new System.Drawing.Point(232, 218);
      this.lbEnablers.Name = "lbEnablers";
      this.lbEnablers.Size = new System.Drawing.Size(276, 20);
      this.lbEnablers.TabIndex = 11;
      // 
      // MainForm
      // 
      this.AcceptButton = this.btnTest;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnAbout;
      this.ClientSize = new System.Drawing.Size(525, 318);
      this.Controls.Add(this.lbEnablers);
      this.Controls.Add(this.btnPause);
      this.Controls.Add(this.cb_Active);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.trbVolume);
      this.Controls.Add(this.tbTest);
      this.Controls.Add(this.btnAbout);
      this.Controls.Add(this.trbRate);
      this.Controls.Add(this.lblVolume);
      this.Controls.Add(this.lblRate);
      this.Controls.Add(this.btnTest);
      this.Controls.Add(this.lbVoices);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Simple TTS Reader";
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.Shown += new System.EventHandler(this.MainForm_Shown);
      this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
      ((System.ComponentModel.ISupportInitialize)(this.trbRate)).EndInit();
      this.cms.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.trbVolume)).EndInit();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.ListBox lbVoices;
		private System.Windows.Forms.TrackBar trbRate;
		private System.Windows.Forms.TrackBar trbVolume;
		private System.Windows.Forms.TextBox tbTest;
		private System.Windows.Forms.ContextMenuStrip cms;
		private System.Windows.Forms.ToolStripMenuItem tsmiResetRate;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.Label lblRate;
		private System.Windows.Forms.Label lblVolume;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel tsslLink;
    private System.Windows.Forms.CheckBox cb_Active;
    private System.Windows.Forms.Button btnPause;
    private System.Windows.Forms.ListBox lbEnablers;
    private System.Windows.Forms.ToolStripStatusLabel tssGitLink;
	}
}
