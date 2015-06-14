using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chapter1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Enterキー
            if (e.KeyCode == Keys.Return)
            {
                // ツリービューを開く
                ivTreeView1.SelectDirectory(textBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ファイルオープンダイアログボックスの表示
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 入力ファイル名を取得
                string path = openFileDialog1.FileName;

                // テキストボックスに表示
                textBox1.Text = path;

                // ツリービューに反映
                ivTreeView1.SelectDirectory(path);
            }
        }
    }
}
