namespace ImageCategorizer
{
	partial class DiffDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.pbSrc = new System.Windows.Forms.PictureBox();
			this.pbDst = new System.Windows.Forms.PictureBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnRename = new System.Windows.Forms.Button();
			this.btnOverwrite = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSrc)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDst)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel1MinSize = 100;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
			this.splitContainer1.Panel2.Controls.Add(this.btnRename);
			this.splitContainer1.Panel2.Controls.Add(this.btnOverwrite);
			this.splitContainer1.Panel2MinSize = 50;
			this.splitContainer1.Size = new System.Drawing.Size(784, 561);
			this.splitContainer1.SplitterDistance = 499;
			this.splitContainer1.TabIndex = 0;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.pbSrc);
			this.splitContainer2.Panel1MinSize = 100;
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.pbDst);
			this.splitContainer2.Panel2MinSize = 100;
			this.splitContainer2.Size = new System.Drawing.Size(784, 499);
			this.splitContainer2.SplitterDistance = 390;
			this.splitContainer2.TabIndex = 0;
			// 
			// pbSrc
			// 
			this.pbSrc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.pbSrc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbSrc.Location = new System.Drawing.Point(0, 0);
			this.pbSrc.Name = "pbSrc";
			this.pbSrc.Size = new System.Drawing.Size(390, 499);
			this.pbSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbSrc.TabIndex = 0;
			this.pbSrc.TabStop = false;
			// 
			// pbDst
			// 
			this.pbDst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.pbDst.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbDst.Location = new System.Drawing.Point(0, 0);
			this.pbDst.Name = "pbDst";
			this.pbDst.Size = new System.Drawing.Size(390, 499);
			this.pbDst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbDst.TabIndex = 0;
			this.pbDst.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(634, 0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(150, 58);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "キャンセル";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnRename
			// 
			this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRename.Location = new System.Drawing.Point(156, 0);
			this.btnRename.Name = "btnRename";
			this.btnRename.Size = new System.Drawing.Size(150, 58);
			this.btnRename.TabIndex = 1;
			this.btnRename.Text = "リネーム";
			this.btnRename.UseVisualStyleBackColor = true;
			// 
			// btnOverwrite
			// 
			this.btnOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOverwrite.Location = new System.Drawing.Point(0, 0);
			this.btnOverwrite.Name = "btnOverwrite";
			this.btnOverwrite.Size = new System.Drawing.Size(150, 58);
			this.btnOverwrite.TabIndex = 0;
			this.btnOverwrite.Text = "上書き";
			this.btnOverwrite.UseVisualStyleBackColor = true;
			// 
			// DiffDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.Controls.Add(this.splitContainer1);
			this.MinimumSize = new System.Drawing.Size(500, 300);
			this.Name = "DiffDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "比較";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbSrc)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDst)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.PictureBox pbSrc;
		private System.Windows.Forms.PictureBox pbDst;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnRename;
		private System.Windows.Forms.Button btnOverwrite;
	}
}