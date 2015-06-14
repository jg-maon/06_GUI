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
    /// エクスプローラー風ツリービュークラス
    /// </summary>
    /// <remark>
    /// フォルダ一覧の表示
    /// ノードが展開される際に配下のサブディレクトリの追加を行う
    /// 選択したフォルダのファイルをリストビューに表示させる
    /// </remark>
    public partial class IVTreeView : TreeView
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IVTreeView()
        {
            InitializeComponent();
            // ドライブ一覧の追加
            _LoadDrives();
        }

        /// <summary>
        /// ドライブ一覧の読み込みと追加
        /// </summary>
        private void _LoadDrives()
        {
            // ノードのクリア
            this.Nodes.Clear();
            // 論理ドライブの取得
            string[] drives = Directory.GetLogicalDrives();
            // 全ての論理ドライブに対して
            foreach (string drive in drives)
            {
                // ドライブのルートノード追加
                _AddSubDirectories(drive, this.Nodes);
            }
        }

        /// <summary>
        /// サブディレクトリの読み込みと追加
        /// </summary>
        /// <remark>
        /// パスの配下にサブディレクトリが存在する場合、ノードに追加をする。
        /// 追加したサブディレクトリの配下にディレクトリが存在する場合は、
        /// 展開できるようにダミーノードを追加する
        /// </remark>
        /// <param name="directoryName">ディレクトリ名</param>
        /// <param name="topNode">ノード</param>
        /// <returns>
        /// トップノードに追加したディレクトリのノード
        /// </returns>
        private TreeNode _AddSubDirectories(string directoryName, TreeNodeCollection topNode)
        {

            // トップノードにディレクトリ名のノード追加
            TreeNode node = topNode.Add(directoryName, directoryName);
            try
            {
                // 配下にサブディレクトリが存在する場合
                if (Directory.GetDirectories(node.FullPath).Length != 0)
                {
                    // フォルダが展開できるようにダミーノードを追加する
                    node.Nodes.Add("dummy");
                }
            }
            catch (Exception ex)
            {
                _DumpException(ex);
            }
            return node;
        }

        /// <summary>
        /// ノードが展開されようとした時のイベント
        /// </summary>
        /// <remark>
        /// 配下のサブディレクトリのをノードに追加する
        /// </remark>
        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            _ShowSubTree(e.Node);
            base.OnBeforeExpand(e);
        }

        /// <summary>
        /// サブディレクトリの展開
        /// </summary>
        private void _ShowSubTree(TreeNode selectedNode)
        {
            try
            {
                // ダミーノードのクリア
                selectedNode.Nodes.Clear();

                // 選択したノードのディレクトリ情報取得
                DirectoryInfo selectedDirectory = new DirectoryInfo(selectedNode.FullPath);
                selectedDirectory.Refresh();

                // ディレクトリとして存在すればノードの追加
                if (selectedDirectory.Exists)
                {
                    DirectoryInfo[] subDirectories = selectedDirectory.GetDirectories();
                    // 全てのサブディレクトリに対して
                    foreach (DirectoryInfo subDirectory in subDirectories)
                    {
                        // 配下にノードとダミーノードの追加
                        _AddSubDirectories(subDirectory.Name, selectedNode.Nodes);
                    }
                }

            }
            catch (Exception ex)
            {
                _DumpException(ex);
            }

            
        }

        /// <summary>
        /// パスのディレクトリを選択する
        /// </summary>
        /// <remark>
        /// 指定されたパスの階層まで順次展開を行う
        /// 存在しないパスが渡された場合は何も行わない
        /// </remark>
        /// <param name="path">展開するパス</param>
        /// <returns>
        /// true    : 成功
        /// false   : 失敗(パスが不正)
        /// </returns>
        public bool SelectDirectory(string path)
        {
            // フルパスの取得
            string fullPath = Path.GetFullPath(path);
            // 実際に存在するパスなのか確認
            // ファイル名でなければ
            if (!File.Exists(fullPath))
            {
                // ディレクトリ名でも無ければ
                if (!Directory.Exists(fullPath))
                {
                    return false;
                }
            }


            // パスをディレクトリごとに分解
            List<string> directories = fullPath.Split(Path.DirectorySeparatorChar).ToList<string>();
            // 最後の要素はファイル名なので削除
            directories.Remove(directories.Last());

            // ルートディレクトリ名の設定
            directories[0] = Path.GetPathRoot(fullPath);

            // 展開するディレクトリパス
            string expandDirectory = "";

            try
            {
                // ツリーのノードにディレクトリが存在するか確認する先頭ノード
                TreeNodeCollection nodes = this.Nodes;

                TreeNode node = nodes[0];  // ディレクトリ名に対応したノード

                // ルートディレクトリから順次展開
                foreach (string directoryName in directories)
                {
                    // 展開するノード名の結合
                    expandDirectory = Path.Combine(expandDirectory, directoryName);

                    // ノードの検索
                    node = nodes.Find(directoryName, false)[0];
                    // ノードの展開
                    node.Expand();

                    // トップノードの更新
                    nodes = node.Nodes;
                }
                // リストビューのノードを選択
                this.SelectedNode = node;
            }
            catch(Exception ex)
            {
                System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
                // 例外発生箇所の情報を取得
                System.Diagnostics.StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
                string filePath = stackFrame.GetFileName();
                int line = stackFrame.GetFileLineNumber();
                MessageBox.Show(ex.Message + Environment.NewLine + expandDirectory, filePath + ":" + line, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }


            return true;
        }

        /// <summary>
        /// 例外の詳細を出力
        /// </summary>
        /// <param name="ex">例外</param>
        private void _DumpException(Exception ex)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(ex, true);
            // 例外発生箇所の情報を取得
            System.Diagnostics.StackFrame stackFrame = trace.GetFrame(trace.FrameCount - 1);
            string filePath = stackFrame.GetFileName();     // ファイルパス
            string fileName = Path.GetFileName(filePath);   // パス→ファイル名のみ
            int line = stackFrame.GetFileLineNumber();      // 行数
            // 出力
            Console.WriteLine(fileName + ":" + line + " " + ex.Message);
            
        }

    }
}
