using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ImageCategorizer
{
	public class HelpHandler
	{
		private static string ManualFile => Path.Combine(Util.StartupPath, "manual", "index.html");

		public static void OpenManual()
		{
			Process.Start("explorer", ManualFile);
		}


	}
}
