/*******************************************************************************
*
*	Copyright (c) 2008-2010, Dmitry Maluev.
*	All rights reserved.
*
*	Redistribution and use in source and binary forms, with or without
*	modification, are permitted provided that the following conditions are met:
*	- Redistributions of source code must retain the above copyright notice,
*	this list of conditions and the following disclaimer.
*	- Redistributions in binary form must reproduce the above copyright notice,
*	this list of conditions and the following disclaimer in the documentation
*	and/or other materials provided with the distribution.
*	- Neither the name of the author nor the names of its contributors may be used
*	to endorse or promote products derived from this software without specific
*	prior written permission.
*	THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
*	AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
*	IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
*	ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
*	LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
*	CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
*	SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
*	INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
*	CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
*	ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
*	POSSIBILITY OF SUCH DAMAGE.
*
*******************************************************************************/

/*******************************************************************************
*
*	Install Microsoft SAPI v5.1 SDK.
*	Add Reference -> COM -> Microsoft Speech Object Library.
*
*******************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SimpleTTSReader
{
	static class Program
	{
		public static bool _hidden = false;

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool ChangeClipboardChain([In] IntPtr hWndRemove, [In] IntPtr hWndNewNext);        
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern void PostQuitMessage([In] int nExitCode);

		[STAThread]
		static void Main(string[] args)
		{
			bool isNew = false;
			Mutex mutex = new Mutex(true, "SimpleTTSReader-{85CBCC28-E397-4fcd-802E-100BE5F064A2}", out isNew);
			if (!isNew)
				return; // This app is already running.

			foreach (string arg in args)
			{
				if (arg == "/hidden")
				{
					_hidden = true;
				}
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());

			GC.KeepAlive(mutex);
		}
	}
}
