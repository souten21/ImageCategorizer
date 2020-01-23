using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageCategorizer
{
	class ImageResource
	{
		private static Image _NoImageInFolder;

		public static Image NoImageInFolder()
		{
			if(_NoImageInFolder != null) { return _NoImageInFolder; }
			_NoImageInFolder = new Bitmap(800, 600);
			using (var g = Graphics.FromImage(_NoImageInFolder))
			using (var f = new Font("Meiryo", 30))
			{
				string txt = "ファイルはありません";
				g.SetImageQuality();
				var txtSize = g.MeasureString(txt, f);
				g.DrawString(txt, f, Brushes.White, new Point(400 - (int)(txtSize.Width / 2), 300 - (int)(txtSize.Height / 2)));
			}
			return _NoImageInFolder;
		}
	}
}
