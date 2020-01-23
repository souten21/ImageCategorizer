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
	public partial class FrmFolderManager : Form
	{
		public event EventHandler FolderChanged;
		private void OnFolderChanged()
		{
			FolderChanged?.Invoke(this, EventArgs.Empty);
		}

		public FolderListFile ListFile { get; set; }

		public FrmFolderManager(FolderListFile file)
		{
			InitializeComponent();
			ListFile = file;
			Init();
		}

		private void Init()
		{
			SetEventHandler();
			InitListView();
			SetFolderToListView();
		}

		private void SetEventHandler()
		{
			lvFolders.AllowDrop = true;
			btnAdd.Click += BtnAdd_Click;
			btnRemove.Click += BtnRemove_Click;
			lvFolders.DoubleClick += LvFolders_DoubleClick;
			lvFolders.DragEnter += LvFolders_DragEnter;
			lvFolders.DragDrop += LvFolders_DragDrop;
		}

		private void LvFolders_DragEnter(object sender, DragEventArgs e)
		{
			var dirs = (e.Data.GetData(DataFormats.FileDrop) as string[])?.Where(i => Directory.Exists(i));
			e.Effect = dirs.Any() ? DragDropEffects.Copy : DragDropEffects.None;
		}

		private void LvFolders_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Effect == DragDropEffects.Copy)
			{
				var dirs = (e.Data.GetData(DataFormats.FileDrop) as string[])?.
					Where(i => Directory.Exists(i)).
					Select(i => new FolderButton(i, ""));
				if (dirs != null)
				{
					ListFile.FolderButtons.AddRange(dirs);
					SetFolderToListView();
					OnFolderChanged();
				}
			}
		}

		//リスト項目ダブルクリック時
		private void LvFolders_DoubleClick(object sender, EventArgs e)
		{
			var item = lvFolders.SelectedItems.OfType<ListViewItem>()?.FirstOrDefault();
			if (item == null || !(item.Tag is FolderButton btn)) { return; }
			EditFolder(btn);
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			AddFolder();
		}


		private void BtnRemove_Click(object sender, EventArgs e)
		{
			var items = lvFolders.SelectedItems.OfType<ListViewItem>().
				Select(i => i.Tag as FolderButton).
				Where(i => i != null);
			if (!items.Any()) { return; }
			foreach (var item in items)
			{
				ListFile.FolderButtons.Remove(item);
			}
			SetFolderToListView();
			OnFolderChanged();
		}

		private void InitListView()
		{
			lvFolders.Columns.Clear();
			lvFolders.Columns.AddRange(
				new string[] { "表示名", "パス", "色" }.
				Select(i => new ColumnHeader() { Text = i }).ToArray());
		}

		private void SetFolderToListView()
		{
			lvFolders.Items.Clear();
			lvFolders.Items.AddRange(
				ListFile.FolderButtons.
					Select(i =>
						new ListViewItem(
							new string[] 
							{
								i.ViewName,
								i.DirPath,
								i.BackColor.ToString()
							}
						){ Tag = i}).
					ToArray());
			AdjustColumnsWidth();
		}

		private void AdjustColumnsWidth()
		{
			foreach (ColumnHeader col in lvFolders.Columns)
			{
				col.Width = -2;
			}	
		}

		//フォルダの編集
		private void EditFolder(FolderButton btn)
		{
			using (var dialog = new AddFolderDialog(btn))
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					SetFolderToListView();
					ListFile.Save();
					OnFolderChanged();
				}
			}
		}

		//フォルダの追加
		private void AddFolder()
		{
			using (var dialog = new AddFolderDialog())
			{
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					ListFile.FolderButtons.Add(dialog.FolderButton);
					SetFolderToListView();
					OnFolderChanged();
				}
			}
		}

	}
}
