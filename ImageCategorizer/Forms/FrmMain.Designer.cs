namespace ImageCategorizer
{
	partial class FrmMain
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pbMain = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnFileRoot = new System.Windows.Forms.ToolStripMenuItem();
			this.mnOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.mnSetting = new System.Windows.Forms.ToolStripMenuItem();
			this.mnClose = new System.Windows.Forms.ToolStripMenuItem();
			this.mnHelpRoot = new System.Windows.Forms.ToolStripMenuItem();
			this.mnAbout = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.pbMain);
			this.splitContainer1.Panel1MinSize = 100;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.AutoScroll = true;
			this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
			this.splitContainer1.Panel2MinSize = 100;
			this.splitContainer1.Size = new System.Drawing.Size(784, 537);
			this.splitContainer1.SplitterDistance = 398;
			this.splitContainer1.TabIndex = 0;
			// 
			// pbMain
			// 
			this.pbMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbMain.Location = new System.Drawing.Point(0, 0);
			this.pbMain.Name = "pbMain";
			this.pbMain.Size = new System.Drawing.Size(784, 398);
			this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbMain.TabIndex = 0;
			this.pbMain.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFileRoot,
            this.mnHelpRoot});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(784, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnFileRoot
			// 
			this.mnFileRoot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnOpenFolder,
            this.mnSetting,
            this.mnClose});
			this.mnFileRoot.Name = "mnFileRoot";
			this.mnFileRoot.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mnFileRoot.Size = new System.Drawing.Size(53, 20);
			this.mnFileRoot.Text = "ファイル";
			// 
			// mnOpenFolder
			// 
			this.mnOpenFolder.Name = "mnOpenFolder";
			this.mnOpenFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mnOpenFolder.Size = new System.Drawing.Size(179, 22);
			this.mnOpenFolder.Text = "フォルダを開く";
			// 
			// mnSetting
			// 
			this.mnSetting.Name = "mnSetting";
			this.mnSetting.ShortcutKeys = System.Windows.Forms.Keys.F12;
			this.mnSetting.Size = new System.Drawing.Size(179, 22);
			this.mnSetting.Text = "環境設定";
			// 
			// mnClose
			// 
			this.mnClose.Name = "mnClose";
			this.mnClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.mnClose.Size = new System.Drawing.Size(179, 22);
			this.mnClose.Text = "閉じる";
			// 
			// mnHelpRoot
			// 
			this.mnHelpRoot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnAbout});
			this.mnHelpRoot.Name = "mnHelpRoot";
			this.mnHelpRoot.Size = new System.Drawing.Size(48, 20);
			this.mnHelpRoot.Text = "ヘルプ";
			// 
			// mnAbout
			// 
			this.mnAbout.Name = "mnAbout";
			this.mnAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.mnAbout.Size = new System.Drawing.Size(221, 22);
			this.mnAbout.Text = "ImageCategorizerについて";
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.Name = "FrmMain";
			this.Text = "ImageCategorizer";
			this.splitContainer1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PictureBox pbMain;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnFileRoot;
		private System.Windows.Forms.ToolStripMenuItem mnOpenFolder;
		private System.Windows.Forms.ToolStripMenuItem mnSetting;
		private System.Windows.Forms.ToolStripMenuItem mnClose;
		private System.Windows.Forms.ToolStripMenuItem mnHelpRoot;
		private System.Windows.Forms.ToolStripMenuItem mnAbout;
	}
}

