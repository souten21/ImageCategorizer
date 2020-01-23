using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace ImageCategorizer
{
	/// <summary>
	/// フォルダボタンの一覧を記憶しているファイル
	/// </summary>
	public class FolderListFile
	{
		#region 定数
		/// <summary>
		/// ファイル拡張子
		/// </summary>
		public static readonly string Extension = ".list";
		
		/// <summary>
		/// 既定のファイル名
		/// </summary>
		public static string DefaultFileName => "default" + Extension;
		#endregion

		#region プロパティ
		/// <summary>
		/// ファイルパス
		/// </summary>
		public string FilePath { get; set; }

		/// <summary>
		/// 読み込んだフォルダボタン一覧
		/// </summary>
		public List<FolderButton> FolderButtons { get; set; } = new List<FolderButton>();
		#endregion

		#region コンストラクタ
		/// <summary>
		/// フォルダボタンの一覧を管理するオブジェクトを生成します。
		/// </summary>
		/// <param name="filePath">フォルダボタン一覧ファイル</param>
		public FolderListFile(string filePath)
		{
			this.FilePath = filePath;
		}
		#endregion

		#region メソッド
		/// <summary>
		/// 指定されている設定ファイルを読み込みます。
		/// </summary>
		public void Load()
		{
			if (!File.Exists(FilePath)) { return; }
			FolderButtons = File.ReadLines(FilePath, Encoding.Unicode).
				Where(i => !string.IsNullOrWhiteSpace(i)).
				Select(i => FolderButton.LineToFolderPath(i)).ToList();
		}

		/// <summary>
		/// 指定されている設定ファイルに設定値を書き込みます。
		/// </summary>
		public void Save()
		{
			using (var sw = new StreamWriter(FilePath, false, Encoding.Unicode))
			{
				foreach (var folder in FolderButtons)
				{
					sw.WriteLine(folder.ToSaveString());
				}
			}
		}
		#endregion
	}
}
