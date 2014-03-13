using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using SpeechLib;
using Microsoft.Win32;

namespace SimpleTTSReader
{
	public partial class MainForm : Form
	{
		private SpVoice _voice;
		private IntPtr _nextClipboardViewer; // HWND returned from SetClipboardViewer().
		private bool _firstRun = true; // Helps to avoid reading when launched.
		private string _regKeyName = "Software\\{85CBCC28-E397-4fcd-802E-100BE5F064A2}"; // Registry key name to store settings (GUID not to bother other keys).

		public MainForm()
		{
			InitializeComponent();
			_voice = new SpVoice();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.lbVoices.BeginUpdate();
			this.lbVoices.Items.Clear();
			foreach (ISpeechObjectToken token in _voice.GetVoices(null, null))
			{
				this.lbVoices.Items.Add(token.GetDescription(0));
			}
			this.lbVoices.EndUpdate();
			// Quit if no engines found:
			if (lbVoices.Items.Count == 0)
			{
				MessageBox.Show("Sorry, but no speech engines were found on this machine.", "Simple TTS Reader",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}
			// Register:
			_nextClipboardViewer = Program.SetClipboardViewer(this.Handle);
			// Load settings:
			RegistryKey key = Registry.CurrentUser.OpenSubKey(_regKeyName, false);
			if (key == null)
			{
				key = Registry.CurrentUser.CreateSubKey(_regKeyName);
				key.SetValue("Voice", this.lbVoices.Items[0].ToString());
				key.SetValue("Rate", 0);
				key.SetValue("Volume", 100);
				this.lbVoices.SelectedIndex = 0;
			}
			else
			{
				string voice = (string)key.GetValue("Voice");
				int index = this.lbVoices.Items.IndexOf(voice);
				if (index < 0)
					index = 0;
				this.lbVoices.SelectedIndex = index;
				this.trbRate.Value = (int)key.GetValue("Rate");
				this.trbVolume.Value = (int)key.GetValue("Volume");
			}
			key.Close();
		}

		private void lbVoices_SelectedIndexChanged(object sender, EventArgs e)
		{
			_voice.Voice = _voice.GetVoices(null, null).Item(this.lbVoices.SelectedIndex);
			RegistryKey key = Registry.CurrentUser.OpenSubKey(_regKeyName, true);
			if (key != null)
			{
				key.SetValue("Voice", _voice.Voice.GetDescription(0));
				key.Close();
			}
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			_voice.Speak(this.tbTest.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync);
		}

		private void trbRate_ValueChanged(object sender, EventArgs e)
		{
			_voice.Rate = this.trbRate.Value;
			RegistryKey key = Registry.CurrentUser.OpenSubKey(_regKeyName, true);
			if (key != null)
			{
				key.SetValue("Rate", this.trbRate.Value);
				key.Close();
			}
		}

		private void trbVolume_ValueChanged(object sender, EventArgs e)
		{
			_voice.Volume = this.trbVolume.Value;
			RegistryKey key = Registry.CurrentUser.OpenSubKey(_regKeyName, true);
			if (key != null)
			{
				key.SetValue("Volume", this.trbVolume.Value);
				key.Close();
			}
		}

		private void tsmiResetRate_Click(object sender, EventArgs e)
		{
			this.trbRate.Value = 0;
		}

    enum EnablerKey {
      CapsLock, WindowsMenu
    };

    bool enabled () {
      switch ((EnablerKey) lbEnablers.TopIndex) {
        case EnablerKey.WindowsMenu:
          return Keyboard.IsKeyDown (Key.LWin);
        case EnablerKey.CapsLock:          
          return Keyboard.IsKeyToggled (Key.CapsLock);
      }
      return false;
    }

    
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 0x0308: // WM_DRAWCLIPBOARD:
          bool    passFurther = true;

          if (this.cb_Active.Checked && !_firstRun && enabled()) {

            if ( (_voice.Status.RunningState == SpeechRunState.SRSEIsSpeaking) || (btnPause.Text != "Pause") )
              btnPause_Click (null, null);
            else {
              IDataObject ido = Clipboard.GetDataObject ();
              if (ido.GetDataPresent (DataFormats.UnicodeText)) {
                string text = (string) ido.GetData (DataFormats.UnicodeText);
                _voice.Speak (null, SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
                _voice.Speak (text, SpeechVoiceSpeakFlags.SVSFlagsAsync);

                btnPause.Text = "Pause";
                _voice.Resume ();
              }
            }

            passFurther = false;
          }

          if ( passFurther && (_nextClipboardViewer != IntPtr.Zero) && (_nextClipboardViewer != this.Handle) )
					  Program.SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);

					_firstRun = false;
					break;

        case 0x030D:  //WM_CHANGECBCHAIN:          
          if (m.WParam == _nextClipboardViewer) // If the next window is closing, repair the chain. 
            _nextClipboardViewer = m.LParam;          
          else 
            if ( (_nextClipboardViewer != IntPtr.Zero) && (_nextClipboardViewer != this.Handle) )  // Otherwise, pass the message to the next link. 
              Program.SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
          break;

        case 0x0002:  //WM_DESTROY:
          Program.ChangeClipboardChain (this.Handle, _nextClipboardViewer);
          Program.PostQuitMessage (0);
          break;

				default:
					base.WndProc(ref m);
					break;
			}
		}

		private void notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.Visible = true;
			this.WindowState = FormWindowState.Normal;
		}

		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.Visible = false;
			}
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			string text = "Simple TTS Reader v" + Application.ProductVersion + "\r\n\r\nCopyright (C) 2008-2010 Dmitry Maluev\r\n\r\n";
			string desc = "Simple TTS Reader is a small clipboard reader based on Microsoft SAPI.\r\n" +
				"Just Ctrl+C the text you want to read aloud.\r\n" +
				"Use /hidden argument to start in tray-only mode.";
			MessageBox.Show(text + desc, "Simple TTS Reader", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void tsslLink_Click(object sender, EventArgs e)
		{
			Process.Start("http://simplettsreader.sourceforge.net/", null);
		}

    private void tssGitLink_Click (object sender, EventArgs e) {
      Process.Start("https://github.com/revitalyr/simple-tts-reader.git", null);
    }

		private void MainForm_Shown(object sender, EventArgs e)
		{
			if (Program._hidden)
				this.WindowState = FormWindowState.Minimized;
		}

    private void checkBox1_CheckedChanged (object sender, EventArgs e) {
      if (this.cb_Active.Checked) {
        Clipboard.Clear ();
        Program.SetClipboardViewer (this.Handle);
      }
      else {
        Program.ChangeClipboardChain(this.Handle, _nextClipboardViewer);
      }
    }

    private void btnPause_Click (object sender, EventArgs e) {
      if (btnPause.Text == "Pause") {
        _voice.Pause ();
        btnPause.Text = "Resume";
      }
      else {
        _voice.Resume ();
        btnPause.Text = "Pause";
      }
    }

	}
}
