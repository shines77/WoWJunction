namespace WoWJunction
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnMountCN = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnMountTW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMountCN
            // 
            this.btnMountCN.Location = new System.Drawing.Point(124, 123);
            this.btnMountCN.Name = "btnMountCN";
            this.btnMountCN.Size = new System.Drawing.Size(107, 44);
            this.btnMountCN.TabIndex = 0;
            this.btnMountCN.Text = "Mount CN";
            this.btnMountCN.UseVisualStyleBackColor = true;
            this.btnMountCN.Click += new System.EventHandler(this.btnMountCN_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(124, 67);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(105, 39);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnMountTW
            // 
            this.btnMountTW.Location = new System.Drawing.Point(124, 184);
            this.btnMountTW.Name = "btnMountTW";
            this.btnMountTW.Size = new System.Drawing.Size(107, 44);
            this.btnMountTW.TabIndex = 2;
            this.btnMountTW.Text = "Mount TW";
            this.btnMountTW.UseVisualStyleBackColor = true;
            this.btnMountTW.Click += new System.EventHandler(this.btnMountTW_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 311);
            this.Controls.Add(this.btnMountTW);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnMountCN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WoW Junction";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMountCN;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnMountTW;
    }
}

