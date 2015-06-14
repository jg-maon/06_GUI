namespace chapter1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.ivListView1 = new chapter1.IVListView();
            this.ivTreeView1 = new chapter1.IVTreeView();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "画像ファイル|*.bmp;*.gif;*.png|すべてのファイル|*.*";
            this.openFileDialog1.Title = "開く";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 184);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "開く";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.Control;
            this.splitter1.Location = new System.Drawing.Point(121, 88);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 191);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.SystemColors.Control;
            this.splitter2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(124, 88);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(435, 3);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // ivListView1
            // 
            this.ivListView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ivListView1.HorizontalScrollbar = true;
            this.ivListView1.ItemHeight = 12;
            this.ivListView1.Location = new System.Drawing.Point(121, 0);
            this.ivListView1.Name = "ivListView1";
            this.ivListView1.Size = new System.Drawing.Size(438, 88);
            this.ivListView1.TabIndex = 4;
            // 
            // ivTreeView1
            // 
            this.ivTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ivTreeView1.Location = new System.Drawing.Point(0, 0);
            this.ivTreeView1.Name = "ivTreeView1";
            this.ivTreeView1.Size = new System.Drawing.Size(121, 279);
            this.ivTreeView1.TabIndex = 0;
            this.ivTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ivTreeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 279);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ivListView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ivTreeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private IVTreeView ivTreeView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private IVListView ivListView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
    }
}

