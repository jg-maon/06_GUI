using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace chapter1
{
    /// <summary>
    /// エクスプローラー風リストビュー
    /// </summary>
    /// <remark>
    /// 指定の画像ファイルの表示を行う
    /// </remark>
    public partial class IVListView : ListBox
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IVListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ディレクトリ内の画像ファイルの表示
        /// </summary>
        /// <param name="directoryPath">表示するディレクトリ</param>
        /// <param name="formatPattern">表示させるフォーマット</param>
        /// <returns>
        /// true    : 成功
        /// false   : ディレクトリのパスが不正
        /// </returns>
        public bool ShowList(string directoryPath, string[] formatPattern)
        {
            string directory = Path.GetFullPath(directoryPath);
            // 存在しないディレクトリ
            if(!Directory.Exists(directory))
            {
                return false;
            }

            // それまで表示していたファイルのクリア
            this.Items.Clear();
            // ファイル一覧の表示
            try
            {
                // パターンに一致するファイルの取得
                foreach (string pattern in formatPattern)
                {
                    string[] paths = Directory.GetFiles(directory, pattern);
                    foreach (string path in paths)
                    {
                        // ファイル名の抽出
                        string file = Path.GetFileName(path);

                        // 追加
                        this.Items.Add(file);
                    }
                }
            }
            catch(Exception ex)
            {
                // アクセス権のないファイル
                // 例外情報の出力
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                System.Diagnostics.StackFrame frame = trace.GetFrame(trace.FrameCount - 1);
                string fileName = Path.GetFileName(frame.GetFileName());
                int line = frame.GetFileLineNumber();
                Console.WriteLine(fileName + ":" + line + " " + ex.Message);
            }

            return true;
        }
    }
}
