using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;


namespace ImageCategorizer
{
	static class Util
	{

		public static string StartupPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

		/// <summary>
		/// 画像ファイルかどうか
		/// </summary>
		/// <param name="filePath">ファイルパス</param>
		/// <returns></returns>
		public static bool IsImageFile(this string filePath)
		{
			return filePath.ToLower().EndsWith(".jpg")
				|| filePath.ToLower().EndsWith(".jpeg")
				|| filePath.ToLower().EndsWith(".png")
				|| filePath.ToLower().EndsWith(".gif")
				|| filePath.ToLower().EndsWith(".bmp");
		}

		/// <summary>
		/// 有効なファイル名かどうか
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		/// <returns></returns>
		public static bool IsValidFileName(this string fileName)
		{
			var invalidChars = Path.GetInvalidFileNameChars();
			return !invalidChars.Any(i => fileName.Contains(i));
		}

		/// <summary>
		/// 有効な名前かどうか
		/// </summary>
		/// <param name="name">名前</param>
		/// <returns></returns>
		public static bool IsValidName(this string name)
		{
			var invalidChars = Path.GetInvalidFileNameChars().Concat(new char[] { ',', ':' });
			return !invalidChars.Any(i => name.Contains(i));
		}

		/// <summary>
		/// 縁取り文字を描画します。
		/// </summary>
		/// <param name="g">対象のグラフィックス</param>
		/// <param name="text">描画する文字</param>
		/// <param name="f">描画フォント</param>
		/// <param name="p">描画位置</param>
		public static void DrawOutlineString(this Graphics g, string text, Font f, Point p)
		{
			using (var gp = new GraphicsPath())
			using (var pen = new Pen(Color.Black, 4) { LineJoin = LineJoin.Round })
			{
				gp.AddString(text, f.FontFamily, 0, f.Size, p, StringFormat.GenericDefault);
				g.DrawPath(pen, gp);
				g.FillPath(Brushes.White, gp);
			}
		}

		/// <summary>
		/// アンチエイリアスなどをグラフィックに設定します。
		/// </summary>
		/// <param name="g">対象のグラフィックス</param>
		public static void SetImageQuality(this Graphics g)
		{
			if (g.PixelOffsetMode != PixelOffsetMode.HighQuality)
			{ g.PixelOffsetMode = PixelOffsetMode.HighQuality; }
			if (g.InterpolationMode != InterpolationMode.HighQualityBicubic)
			{ g.InterpolationMode = InterpolationMode.HighQualityBicubic; }
			if (g.TextRenderingHint != TextRenderingHint.AntiAlias)
			{ g.TextRenderingHint = TextRenderingHint.AntiAlias; }
			if (g.SmoothingMode != SmoothingMode.HighQuality)
			{ g.SmoothingMode = SmoothingMode.HighQuality; }
		}

		/// <summary>
		/// 文字列中のある文字列より後ろを取得します。
		/// </summary>
		/// <param name="value">文字列</param>
		/// <param name="keyString">ある文字列</param>
		/// <returns></returns>
		public static string AfterKeyString(this string value, string keyString)
		{
			return value.Contains(keyString) 
				? value.Substring(value.IndexOf(keyString) + keyString.Length) 
				: value;
		}
	}
}
