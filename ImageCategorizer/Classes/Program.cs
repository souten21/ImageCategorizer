using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImageCategorizer
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			var bootLoader = new BootLoader(args);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmMain(bootLoader));
		}
	}
}
