using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace ClipboardMonitor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		[DllImport("User32.dll")]
		protected static extern int SetClipboardViewer(int hWndNewViewer);

		[DllImport("User32.dll", CharSet=CharSet.Auto)]
		public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

		private System.Windows.Forms.RichTextBox richTextBox1;
        

		IntPtr nextClipboardViewer;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			nextClipboardViewer = (IntPtr)SetClipboardViewer((int) this.Handle);
            richTextBox1.Clear();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			ChangeClipboardChain(this.Handle, nextClipboardViewer);
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(510, 421);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "richTextBox1";
            this.richTextBox1.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(510, 421);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Clipboard Monitor Example";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
<<<<<<< HEAD
		/// The main entry point for the application.123
        /// 456
=======
		/// The main entry point for the application. 1
>>>>>>> aaa53a1570e34959a6023c893f8dd9f4c98700b0
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			// defined in winuser.h
			const int WM_DRAWCLIPBOARD = 0x308;
			const int WM_CHANGECBCHAIN = 0x030D;

			switch(m.Msg)
			{
				case WM_DRAWCLIPBOARD:
					DisplayClipboardData();
					SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
					break;

				case WM_CHANGECBCHAIN:
					if (m.WParam == nextClipboardViewer)
						nextClipboardViewer = m.LParam;
					else
						SendMessage(nextClipboardViewer, m.Msg, m.WParam, m.LParam);
					break;

				default:
					base.WndProc(ref m);
					break;
			}	
		}

		void DisplayClipboardData()		
		{
			try
			{
                //richTextBox1.LoadFile(@"C:\users\nherre\desktop\test.rtf");
                IDataObject iData = new DataObject();  
				iData = Clipboard.GetDataObject();
                richTextBox1.AppendText("\r\n");
                richTextBox1.Paste();
                richTextBox1.SaveFile(@"C:\users\nherre\desktop\test.rtf");

                #region IF Logic
                //If logic
                //string[] formatsReturned = Clipboard.GetDataObject().GetFormats();
                //for (int i = 0; i < formatsReturned.Length; i++)
                //{
                //    richTextBox1.AppendText(formatsReturned[i]+"\r\n");
                //}

                //if (iData.GetDataPresent(DataFormats.Rtf))
                //{
                //    richTextBox1.Paste (DataFormats.GetFormat(DataFormats.Rtf));
                //}
                //else if (iData.GetDataPresent(DataFormats.Text))
                //{
                //    richTextBox1.Paste(DataFormats.GetFormat(DataFormats.Text));
                //}
                //else if (iData.GetDataPresent(DataFormats.Bitmap))
                //{
                //    richTextBox1.Paste();//DataFormats.GetFormat(DataFormats.Bitmap));
                //}
                //else if (iData.GetDataPresent(DataFormats.FileDrop))
                //{
                //    //richTextBox1
                //    richTextBox1.Paste(); //(DataFormats.GetFormat(DataFormats.FileDrop));
                //}
                //else
                //{
                //    richTextBox1.Text = "[Clipboard data is not RTF or ASCII Text or a Bitmap]";
                //}
#endregion
            }
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}
		}
	}
}
