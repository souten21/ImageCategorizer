using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ImageCategorizer
{
	//フォルダ追加ダイアログ
	public partial class AddFolderDialog : Form
	{
		/// <summary>
		/// フォルダボタンを取得設定します。
		/// </summary>
		public FolderButton FolderButton { get; set; }

		/// <summary>
		/// フォルダを追加するダイアログを生成します。
		/// </summary>
		public AddFolderDialog()
		{
			InitializeComponent();
			SetEventHandler();
		}

		/// <summary>
		/// フォルダを編集するダイアログを生成します。
		/// </summary>
		/// <param name="btn">編集するフォルダボタン</param>
		public AddFolderDialog(FolderButton btn)
		{
			InitializeComponent();
			SetEventHandler();
			this.FolderButton = btn;
			SetValueToControls();
		}

		//セット
		private void SetEventHandler()
		{
			btnBrowse.Click += BtnBrowse_Click;
			btnOk.Click += BtnOk_Click;
			btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
			btnColor.Click += BtnColor_Click;
			tbPath.DragEnter += TbPath_DragEnter;
			tbPath.DragDrop += TbPath_DragDrop;
		}

		//パスにフォルダをドラッグエンター
		private void TbPath_DragEnter(object sender, DragEventArgs e)
		{
			var dir = (e.Data.GetData(DataFormats.FileDrop) as string[])?.FirstOrDefault();
			e.Effect = dir != null && Directory.Exists(dir)
				? DragDropEffects.Copy
				: DragDropEffects.None;
		}

		//パスにフォルダをドラッグドロップ
		private void TbPath_DragDrop(object sender, DragEventArgs e)
		{
			var dir = (e.Data.GetData(DataFormats.FileDrop) as string[])?.FirstOrDefault();
			if(e.Effect == DragDropEffects.Copy)
			{
				tbPath.Text = dir;
			}
		}

		//色参照ボタン
		private void BtnBrowse_Click(object sender, EventArgs e)
		{
			using (var ofd = new OpenFileDialog() { CheckFileExists = false, Filter = "Folder|.", FileName = "SelectFolder" })
			{
				if(ofd.ShowDialog() == DialogResult.OK) { tbPath.Text = Path.GetDirectoryName(ofd.FileName); }
			}
		}

		//色ボタン
		private void BtnColor_Click(object sender, EventArgs e)
		{
			using (var dialog = new ColorDialog()
			{
				Color = btnColor.BackColor,
				AllowFullOpen = true,
				CustomColors = FolderButton.SampleColors.Select(i => ColorTranslator.ToOle(i)).ToArray() })
			{
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					btnColor.BackColor = dialog.Color;
				}
			}
		}

		//OKボタン
		private void BtnOk_Click(object sender, EventArgs e)
		{
			if (!IsValidInputs()) { return; }
			if (FolderButton != null)
			{
				FolderButton.DirPath = tbPath.Text;
				if (!string.IsNullOrWhiteSpace(tbName.Text))
				{
					FolderButton.ViewName = tbName.Text;
				}
				FolderButton.BackColor = btnColor.BackColor;
			}
			else { CreateNew(); }
			DialogResult = DialogResult.OK;
		}

		//入力検証
		private bool IsValidInputs()
		{
			if (string.IsNullOrWhiteSpace(tbPath.Text))
			{
				MessageBox.Show("パスが指定されていません。");
				return false;
			}
			if (!Directory.Exists(tbPath.Text))
			{
				MessageBox.Show("フォルダが存在しません。");
				return false;
			}
			if (!tbName.Text.IsValidName())
			{
				MessageBox.Show("名前に使用できない記号が含まれています。");
				return false;
			}
			return true;
		}

		//新しくインスタンスを生成します。
		private void CreateNew()
		{
			FolderButton = new FolderButton(tbPath.Text, tbName.Text) {BackColor = btnColor.BackColor };
		}

		//コントロールに値を代入
		private void SetValueToControls()
		{
			if (FolderButton == null) { return; }
			tbPath.Text = FolderButton?.DirPath ?? "";
			tbName.Text = FolderButton?.ViewName ?? "";
			btnColor.BackColor = FolderButton?.BackColor ?? Color.White;
		}
	}
}
