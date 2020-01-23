using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageCategorizer
{
	public partial class FrmMain : Form
	{
		#region フィールド
		private string _SrcFolderPath;
		private ToolTip TT = new ToolTip();
		private FrmFolderManager FolderManagerForm;
		#endregion

		#region プロパティ
		/// <summary>
		/// コピー元のフォルダパス
		/// </summary>
		public string SrcFolderPath
		{
			get { return _SrcFolderPath; }
			set
			{
				_SrcFolderPath = value;
				LoadFolder();
			}
		}

		/// <summary>
		/// フォルダリストファイル
		/// </summary>
		public FolderListFile ListFile { get; set; }

		//画像ファイルリスト
		private List<string> ImageFiles { get; set; } = new List<string>();

		//表示中の画像番号
		private int ImageNumber { get; set; } = 0;

		//表示中の画像
		private string ViewingImage => ImageFiles?[ImageNumber];
		
		//ボタンを表示するパネル
		private Panel ButtonPanel => splitContainer1.Panel2;
		
		//起動オプション
		private BootLoader BootSetting { get; set; }
		#endregion

		#region コンストラクタ
		public FrmMain(BootLoader bootLoader)
		{
			BootSetting = bootLoader;
			InitializeComponent();
			SetEventHandler();
			LoadFolderList();
			if (!string.IsNullOrWhiteSpace(BootSetting.LoadingFolder))
			{
				SrcFolderPath = BootSetting.LoadingFolder;
			}
		}
		#endregion

		#region イベントハンドラ
		//イベントハンドラをセット
		private void SetEventHandler()
		{
			pbMain.AllowDrop = true;
			ButtonPanel.AllowDrop = true;

			this.KeyDown += Form1_KeyDown;
			mnOpenFolder.Click += (s, e) => BrowseFolder();
			mnSetting.Click += MnSetting_Click; ;
			mnClose.Click += (s, e) => this.Close();
			mnAbout.Click += MnAbout_Click;
			ButtonPanel.Resize += (s, e) => MarshalButtons();
			ButtonPanel.DragEnter += ButtonPanel_DragEnter;
			ButtonPanel.DragDrop += ButtonPanel_DragDrop;
			pbMain.Paint += PbMain_Paint;
			pbMain.DragEnter += PbMain_DragEnter;
			pbMain.DragDrop += PbMain_DragDrop;
		}

		//マニュアルを開く
		private void MnAbout_Click(object sender, EventArgs e)
		{
			try
			{
				HelpHandler.OpenManual();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		//ボタンパネル部にドラッグエンター
		private void ButtonPanel_DragEnter(object sender, DragEventArgs e)
		{
			var file = (e.Data.GetData(DataFormats.FileDrop) as string[])?.FirstOrDefault();
			e.Effect = !string.IsNullOrEmpty(file) &&
				(file.EndsWith(FolderListFile.Extension) && File.Exists(file)) || (Directory.Exists(file))
				? DragDropEffects.Copy
				: DragDropEffects.None;
		}

		//ボタンパネル部にドラッグドロップ
		private void ButtonPanel_DragDrop(object sender, DragEventArgs e)
		{
			var aPath = (e.Data.GetData(DataFormats.FileDrop) as string[])?.FirstOrDefault();
			if (e.Effect == DragDropEffects.Copy)
			{
				if (File.Exists(aPath) && aPath.EndsWith(FolderListFile.Extension))
				{
					ListFile.FilePath = aPath;
					LoadFolderList();
				}
				else if(Directory.Exists(aPath))
				{
					ListFile.FolderButtons.Add(new FolderButton(aPath, "") { BackColor = FolderButton.RandomSampleColor() });
					ListFile.Save();
					LoadFolderList();
				}
			}
		}

		//表示部にドラッグエンター
		private void PbMain_DragEnter(object sender, DragEventArgs e)
		{
			var dir = (e.Data.GetData(DataFormats.FileDrop) as string[])?.FirstOrDefault();
			e.Effect = !string.IsNullOrWhiteSpace(dir) && Directory.Exists(dir)
				? DragDropEffects.Copy
				: DragDropEffects.None;
		}

		//表示部にドラッグドロップ
		private void PbMain_DragDrop(object sender, DragEventArgs e)
		{
			var dir = (e.Data.GetData(DataFormats.FileDrop) as string[])?.FirstOrDefault();
			if (e.Effect == DragDropEffects.Copy)
			{
				SrcFolderPath = dir;
			}
		}

		//メニュー：設定クリック
		private void MnSetting_Click(object sender, EventArgs e)
		{
			if(FolderManagerForm == null || FolderManagerForm.IsDisposed)
			{
				FolderManagerForm = new FrmFolderManager(ListFile);
				FolderManagerForm.FolderChanged += (ss, ee) => 
				{
					ClearButtons();
					SetButtons();
				};
				FolderManagerForm.Show();
			}
			else
			{
				FolderManagerForm.Activate();
			}
		}

		//ピクチャー描画時
		private void PbMain_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SetImageQuality();
			var fileName = pbMain.Tag as string;
			if (string.IsNullOrWhiteSpace(fileName)) { return; }
			using (var f = new Font("Meiryo", 16)) 
			{
				e.Graphics.DrawOutlineString(fileName, f, new Point(0, 0));
			}
		}

		//キーダウン
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control == true)
			{
				if (e.KeyCode == Keys.Right) { UpImageNumber(); ViewImage(); }
				if (e.KeyCode == Keys.Left) { DownImageNumber(); ViewImage(); }
			}
		}

		//各ボタンクリック時
		private void ButtonClick(object sender, EventArgs e)
		{
			if (!ImageFiles.Any())
			{
				MessageBox.Show("画像がありません。");
				return;
			}
			if(sender is FolderButton btn)
			{
				try
				{
					if(ViewingImage == null) { return; }
					btn.SendFile(ViewingImage);
					LoadFolder();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
		#endregion

		#region メソッド
		//フォルダリストを読み込みます。
		private void LoadFolderList()
		{
			if (ListFile == null)
			{
				if (!string.IsNullOrWhiteSpace(BootSetting.ListFilePath))
				{
					ListFile = new FolderListFile(BootSetting.ListFilePath);
				}
				else
				{
					ListFile = new FolderListFile(Path.Combine(Util.StartupPath, "default" + FolderListFile.Extension));
				}
			}
			ListFile.Load();
			ClearButtons();
			SetButtons();
		}

		//画像の番号をインクリメント。Maxなら0に。
		private void UpImageNumber()
		{
			if(ImageFiles.Count - 1 < ImageNumber + 1) { ImageNumber = 0; }
			else { ImageNumber++; }
		}

		//画像の番号をデクリメント。0ならMaxに。
		private void DownImageNumber()
		{
			if(ImageNumber - 1 < 0) { ImageNumber = ImageFiles.Count - 1; }
			else { ImageNumber--; }
		}

		//フォルダを参照する。
		private void BrowseFolder()
		{
			using (var dialog = new OpenFileDialog(){
				Filter = "Folder|*.*",
				FileName = "SelectFolder",
				CheckFileExists = false,
				Multiselect = false })
			{
				if (dialog.ShowDialog() == DialogResult.OK) { SrcFolderPath = Path.GetDirectoryName(dialog.FileName); }
			}
		}

		//フォルダ内の画像を調べ先頭の画像を表示する
		private void LoadFolder()
		{
			if(string.IsNullOrWhiteSpace(SrcFolderPath) 
				|| !Directory.Exists(SrcFolderPath)) { return; }
			var files = Directory.EnumerateFiles(SrcFolderPath, "*.*").
				Where(i => i.IsImageFile()).ToList();
			ImageFiles = files;
			SetTopImage();
		}

		//先頭の画像を表示
		private void SetTopImage()
		{
			ImageNumber = 0;
			ViewImage();
		}

		//今の画像番号の画像を表示
		private void ViewImage()
		{
			if (ImageFiles == null || !ImageFiles.Any())
			{
				pbMain.Tag = "";
				pbMain.ImageLocation = "";
				pbMain.Image = ImageResource.NoImageInFolder();
			}
			else
			{
				pbMain.Tag = ImageFiles[ImageNumber];
				pbMain.ImageLocation = ImageFiles[ImageNumber];
			}
			UpdateTitle();
		}

		//タイトルバーにフォルダパスと画像番号と画像数を表示
		private void UpdateTitle()
		{
			this.Text = SrcFolderPath + $" ({(ImageNumber + 1).ToString()}/{ImageFiles?.Count.ToString() ?? ""})";
		}

		//ボタンをクリアする。
		private void ClearButtons()
		{
			foreach (var btn in ButtonPanel.Controls.OfType<FolderButton>())
			{
				btn.Click -= ButtonClick;
			}
			ButtonPanel.Controls.Clear();
		}

		//ボタンをセットする
		private void SetButtons()
		{
			foreach (var btn in ListFile.FolderButtons)
			{
				btn.Click += ButtonClick;
				TT.SetToolTip(btn, btn.DirPath);
				ButtonPanel.Controls.Add(btn);
			}
			MarshalButtons();
		}

		//ボタンの整列
		private void MarshalButtons()
		{
			int left = 0, top = 0;
			foreach (var btn in ButtonPanel.Controls.OfType<FolderButton>())
			{
				if (left + btn.Width > ButtonPanel.Width) { left = 0; top += btn.Height; }
				btn.Location = new Point(left, top);
				left += btn.Width;
			}
		}
		#endregion
	}
}
