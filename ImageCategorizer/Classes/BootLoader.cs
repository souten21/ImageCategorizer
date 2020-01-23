using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ImageCategorizer
{
	/// <summary>
	/// 起動オプションを処理してプロパティとして保持します。
	/// </summary>
	public class BootLoader
	{
		#region 定数
		private static readonly string HList = "/list:";
		private string DefaultListFile => Path.Combine(Util.StartupPath, FolderListFile.DefaultFileName);
		#endregion

		#region プロパティ
		/// <summary>
		/// フォルダリストファイルのパス
		/// </summary>
		public string ListFilePath { get; set; }

		/// <summary>
		/// 起動時に読み込むフォルダ
		/// </summary>
		public string LoadingFolder { get; set; }
		#endregion

		#region コンストラクタ
		/// <summary>
		/// 起動オプションを処理してプロパティとして保持します。
		/// </summary>
		/// <param name="args">起動オプション</param>
		public BootLoader(IEnumerable<string> args)
		{
			ListFilePath = args.FirstOrDefault(i => i.ToLower().StartsWith(HList))?.AfterKeyString(":") ?? DefaultListFile;
			LoadingFolder = args.FirstOrDefault(i => i.Contains(Path.DirectorySeparatorChar) && Directory.Exists(i));
		}
		#endregion
	}
}
