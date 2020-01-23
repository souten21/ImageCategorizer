using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ImageCategorizer
{
	public partial class DiffDialog : Form
	{
		//単位換算用
		private static readonly int UnitCoef = 1024;

		#region プロパティ
		//送り元ファイル
		private string SrcFile { get; set; }

		//送り先ファイル
		private string DstFile { get; set; }

		/// <summary>
		/// リネームによって変更された新しいファイル名（拡張子を除く）を取得します。
		/// </summary>
		public string NewNameWithoutExt { get; private set; } = "";
		#endregion

		#region コンストラクタ
		public DiffDialog(string src, string dst)
		{
			InitializeComponent();
			SrcFile = src;
			DstFile = dst;
			SetEventHandler();
			SetImage();
		}
		#endregion

		#region イベントハンドラ
		//イベントハンドラセット
		private void SetEventHandler()
		{
			pbSrc.Paint += PB_Paint;
			pbDst.Paint += PB_Paint;
			btnOverwrite.Click += BtnOverwrite_Click;
			btnRename.Click += BtnRename_Click;
			btnCancel.Click += BtnCancel_Click;
		}

		//キャンセルボタン
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		//リネームボタン
		private void BtnRename_Click(object sender, EventArgs e)
		{
			var dstDir = Path.GetDirectoryName(DstFile);
			var ext = Path.GetExtension(SrcFile);
			string newName = "";
			using (var dialog = new InputDialog())
			{
				while (true)//確定かキャンセルまでループ
				{
					var result = dialog.ShowDialog(this);
					if (result != DialogResult.OK) { return; }
					newName = dialog.FileNameWithoutExt;
					var newFilePath = Path.Combine(dstDir, newName + ext);
					if (!File.Exists(newFilePath))
					{
						NewNameWithoutExt = newName;
						break;
					}
					else { MessageBox.Show("送り先に同名ファイルがあるので違う名前を入力してください。"); }
				}
			}
			DialogResult = DialogResult.OK;
		}

		//上書きボタン
		private void BtnOverwrite_Click(object sender, EventArgs e)
		{
			NewNameWithoutExt = Path.GetFileNameWithoutExtension(SrcFile);
			DialogResult = DialogResult.OK;
		}

		//画像描画時に容量を描画する
		private void PB_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SetImageQuality();
			var pb = sender as PictureBox;
			using (var gp = new GraphicsPath())
			using (var p = new Pen(Color.Black, 4) { LineJoin = LineJoin.Round })
			using (var f = new Font("Meiryo", 16))
			{
				gp.AddString(pb == pbSrc ? "Source" : "Destination", f.FontFamily, 0, f.Size, new Point(10, 5), StringFormat.GenericDefault);
				if (pb.Tag != null)
				{
					var size = (long)pb.Tag;
					gp.AddString(GetSizeString(size), f.FontFamily, 0, f.Size, new Point(10, 30), StringFormat.GenericDefault);
				}
				e.Graphics.DrawPath(p, gp);
				e.Graphics.FillPath(Brushes.White, gp);
			}
		}
		#endregion

		#region メソッド
		//画像をセットする。
		private void SetImage()
		{
			var srcImage = GetImageAndCapacity(SrcFile);
			var dstImage = GetImageAndCapacity(DstFile);
			if(srcImage != null)
			{
				pbSrc.Tag = srcImage.Item2;
				pbSrc.Image = srcImage.Item1;
			}
			if (dstImage != null)
			{
				pbDst.Tag = dstImage.Item2;
				pbDst.Image = dstImage.Item1;
			}
			pbSrc.Invalidate();
			pbDst.Invalidate();
		}


		//ファイルパスから画像と容量を取得する
		private Tuple<Image, long> GetImageAndCapacity(string filePath)
		{
			if (!File.Exists(filePath) || !filePath.IsImageFile()) { return null; }
			var info = new FileInfo(filePath);
			var size = info.Length;
			using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				var baseImg = Image.FromStream(fs);
				var ratio = (float)baseImg.Height / baseImg.Width;
				var img = new Bitmap(baseImg, 400, (int)(400 * ratio));
				baseImg.Dispose();
				fs.Close();
				return new Tuple<Image, long>(img, size);
			}
		}

		//ファイルサイズを単位付き文字列で返します
		private string GetSizeString(long size)
		{
			float tmpSize = size;
			var prefixes = new string[] { "", "K", "M", "G", "T" };
			int cnt = 0;
			while(UnitCoef < tmpSize)
			{
				tmpSize = tmpSize / UnitCoef;
				cnt++;
			}
			return tmpSize.ToString("#.##") + prefixes[cnt] + "B";
		}
		#endregion
	}
}
