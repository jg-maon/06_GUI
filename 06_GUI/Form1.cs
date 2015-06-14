using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chapter1
{
    public partial class Form1 : Form
    {
        private static readonly List<string> ImageFormats = new List<string>() { "*.bmp", "*.gif", "*.png" };


        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // ファイルオープンダイアログボックスの表示
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 入力ファイル名を取得
                string path = openFileDialog1.FileName;

                // ツリービューに反映
                ivTreeView1.SelectDirectory(path);
                // リストビューに反映
                ivListView1.ShowList(ivTreeView1.SelectedNode.FullPath + Path.DirectorySeparatorChar, ImageFormats.ToArray());

            }
        }
        /// <summary>
        /// ツリービューの値が変更されたイベント
        /// </summary>
        private void ivTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // リストビューに反映
            ivListView1.ShowList(ivTreeView1.SelectedNode.FullPath + Path.DirectorySeparatorChar, ImageFormats.ToArray());
        }
    }
}
