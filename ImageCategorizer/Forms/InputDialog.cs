using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageCategorizer
{
	public partial class InputDialog : Form
	{

		public string FileNameWithoutExt { get; set; }

		public InputDialog()
		{
			InitializeComponent();
			tbInput.KeyDown += TbInput_KeyDown;
			btnOK.Click += BtnOK_Click;
			btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;
			tbInput.Text = FileNameWithoutExt;
		}

		private void BtnOK_Click(object sender, EventArgs e)
		{
			if (!tbInput.Text.IsValidFileName())
			{
				MessageBox.Show("使用できない文字が含まれているので違う名前にしてください。");
				return;
			}
			if (string.IsNullOrWhiteSpace(tbInput.Text))
			{
				MessageBox.Show("ファイル名を空白にすることはできません。");
				return;
			}
			FileNameWithoutExt = tbInput.Text;
			DialogResult = DialogResult.OK;
		}

		private void TbInput_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter) { BtnOK_Click(btnOK, EventArgs.Empty); }
			else if(e.KeyCode == Keys.Escape) { DialogResult = DialogResult.Cancel; }
		}
	}
}
