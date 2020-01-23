using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace ImageCategorizer
{
	public class FolderButton : Button
	{
		#region 定数
		//ランダム
		private static readonly Random Random = new Random();

		//サンプルカラー
		public static Color[] SampleColors = new Color[]
		{
			Color.FromArgb(255,212,100),
			Color.FromArgb(242,105,100),
			Color.FromArgb(18,83,164),
			Color.FromArgb(47,205,180),
			Color.FromArgb(54,57,71),
			Color.FromArgb(2,174,220),
			Color.FromArgb(235,33,66),
			Color.FromArgb(39,60,117),
			Color.FromArgb(140,122,230)
		};
		#endregion

		#region プロパティ
		private string _ViewName;
		/// <summary>
		/// 表示名
		/// </summary>
		public string ViewName
		{
			get { return _ViewName; }
			set
			{
				_ViewName = value;
				this.Text = _ViewName;
			}
		}

		/// <summary>
		/// フォルダパス
		/// </summary>
		public string DirPath { get; set; }

		/// <summary>
		/// 背景色
		/// </summary>
		public override Color BackColor
		{
			get => base.BackColor;
			set
			{
				base.BackColor = value;
				SetPoliticForeColor();
			}
		}
		#endregion

		#region コンストラクタ
		/// <summary>
		/// フォルダボタンを生成します。
		/// </summary>
		/// <param name="folder">フォルダパス</param>
		public FolderButton(string dir, string viewName)
		{
			DirPath = dir;
			ViewName = string.IsNullOrWhiteSpace(viewName) ? Path.GetFileName(dir) : viewName;
			Init();
		}
		#endregion

		#region メソッド
		private void Init()
		{
			Size = new Size(180, 50);
			Font = new Font("Meiryo", 12);
		}
		#endregion

		/// <summary>
		/// 背景色の明度を見て適切な文字色をセットします。
		/// </summary>
		public void SetPoliticForeColor()
		{
			this.ForeColor = BackColor.GetBrightness() > 0.5f ? Color.Black : Color.White;
		}

		/// <summary>
		/// srcのファイルをこのボタンのフォルダに移動する
		/// </summary>
		/// <param name="src">送り元ファイル</param>
		/// <returns></returns>
		public bool SendFile(string src)
		{
			if (string.IsNullOrWhiteSpace(src)) { throw new ArgumentException(); }
			var dst = Path.Combine(DirPath, Path.GetFileName(src));
			if (File.Exists(dst))//すでに送り先にある場合。
			{
				if(OpenDiffDialog(src, dst, out string newName) != DialogResult.OK) { return false; }
				dst = Path.Combine(DirPath, newName + Path.GetExtension(src));
			}
			File.Copy(src, dst, true);
			File.Delete(src);
			return true;
		}

		//上書き比較ダイアログ
		private DialogResult OpenDiffDialog(string src, string dst, out string newName)
		{
			using (var dialog = new DiffDialog(src, dst))
			{
				if(dialog.ShowDialog(this) == DialogResult.OK)
				{
					newName = dialog.NewNameWithoutExt;
					return DialogResult.OK;
				}
				else
				{
					newName = Path.GetFileNameWithoutExtension(src);
					return DialogResult.Cancel;
				}
			}
		}

		/// <summary>
		/// 設定ファイルの行からフォルダを生成します。
		/// </summary>
		/// <param name="line">設定ファイルの行</param>
		/// <returns></returns>
		public static FolderButton LineToFolderPath(string line)
		{
			FolderButton result;
			Color bgColor;
			if (line.Contains(','))
			{
				var spl = line.Split(',');
				result = new FolderButton(spl[0], spl[1]);
				try
				{
					bgColor = spl.Length > 2 && int.TryParse(spl[2], out int colorNo)
							? ColorTranslator.FromOle(colorNo)
							: RandomSampleColor();

				}
				catch (Exception)
				{
					bgColor = RandomSampleColor();
				}
			}
			else
			{
				result = new FolderButton(line, "");
				bgColor = RandomSampleColor();
			}
			result.BackColor = bgColor;
			return result;
		}

		/// <summary>
		/// サンプルにある色からランダムに色を選択します。
		/// </summary>
		/// <returns></returns>
		public static Color RandomSampleColor()
		{
			var index = Random.Next(0, SampleColors.Length - 1);
			return SampleColors[index];
		}

		//保存時の文字列
		public string ToSaveString()
		{
			return $"{DirPath},{ViewName},{ColorTranslator.ToOle(BackColor)}";
		}
	}
}
