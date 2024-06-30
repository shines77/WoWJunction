namespace WoWJunction
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnOpenSettings = new System.Windows.Forms.Button();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lnkLinkToSource = new System.Windows.Forms.LinkLabel();
            this.lblLinkTo = new System.Windows.Forms.Label();
            this.lnkLinkToTarget = new System.Windows.Forms.LinkLabel();
            this.lblWoWClassicPathTip = new System.Windows.Forms.Label();
            this.txtBoxMountFrom = new System.Windows.Forms.TextBox();
            this.lblMountInfo = new System.Windows.Forms.Label();
            this.txtBoxMountTo = new System.Windows.Forms.TextBox();
            this.btnRefreshStatus = new System.Windows.Forms.Button();
            this.tdBtnSwitchToCN = new System.Windows.Forms.RadioButton();
            this.btnSwitchToCN = new System.Windows.Forms.Button();
            this.tdBtnSwitchToTW = new System.Windows.Forms.RadioButton();
            this.btnSwitchToTW = new System.Windows.Forms.Button();
            this.btnUnmount = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.chkBoxMinimizeToTaskbarWhenExiting = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTaskBar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHideMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTaskBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.Location = new System.Drawing.Point(299, 9);
            this.btnOpenSettings.Name = "btnOpenSettings";
            this.btnOpenSettings.Size = new System.Drawing.Size(102, 31);
            this.btnOpenSettings.TabIndex = 0;
            this.btnOpenSettings.Text = "WoW 路径设置";
            this.btnOpenSettings.UseVisualStyleBackColor = true;
            this.btnOpenSettings.Click += new System.EventHandler(this.btnOpenSettings_Click);
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Location = new System.Drawing.Point(174, 21);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(72, 13);
            this.lblCurrentStatus.TabIndex = 1;
            this.lblCurrentStatus.Text = "当前状态：";
            // 
            // lnkLinkToSource
            // 
            this.lnkLinkToSource.AutoSize = true;
            this.lnkLinkToSource.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLinkToSource.Location = new System.Drawing.Point(109, 43);
            this.lnkLinkToSource.Name = "lnkLinkToSource";
            this.lnkLinkToSource.Size = new System.Drawing.Size(77, 13);
            this.lnkLinkToSource.TabIndex = 2;
            this.lnkLinkToSource.TabStop = true;
            this.lnkLinkToSource.Text = "\\_classic_";
            // 
            // lblLinkTo
            // 
            this.lblLinkTo.AutoSize = true;
            this.lblLinkTo.ForeColor = System.Drawing.Color.Red;
            this.lblLinkTo.Location = new System.Drawing.Point(192, 43);
            this.lblLinkTo.Name = "lblLinkTo";
            this.lblLinkTo.Size = new System.Drawing.Size(28, 13);
            this.lblLinkTo.TabIndex = 3;
            this.lblLinkTo.Text = "==>";
            // 
            // lnkLinkToTarget
            // 
            this.lnkLinkToTarget.AutoSize = true;
            this.lnkLinkToTarget.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLinkToTarget.Location = new System.Drawing.Point(226, 43);
            this.lnkLinkToTarget.Name = "lnkLinkToTarget";
            this.lnkLinkToTarget.Size = new System.Drawing.Size(84, 13);
            this.lnkLinkToTarget.TabIndex = 4;
            this.lnkLinkToTarget.TabStop = true;
            this.lnkLinkToTarget.Text = "\\classic_cn";
            // 
            // lblWoWClassicPathTip
            // 
            this.lblWoWClassicPathTip.AutoSize = true;
            this.lblWoWClassicPathTip.Location = new System.Drawing.Point(18, 72);
            this.lblWoWClassicPathTip.Name = "lblWoWClassicPathTip";
            this.lblWoWClassicPathTip.Size = new System.Drawing.Size(137, 13);
            this.lblWoWClassicPathTip.TabIndex = 5;
            this.lblWoWClassicPathTip.Text = "《魔兽世界》怀旧服：";
            // 
            // txtBoxMountFrom
            // 
            this.txtBoxMountFrom.Location = new System.Drawing.Point(21, 92);
            this.txtBoxMountFrom.Name = "txtBoxMountFrom";
            this.txtBoxMountFrom.Size = new System.Drawing.Size(380, 22);
            this.txtBoxMountFrom.TabIndex = 6;
            this.txtBoxMountFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxMountFrom_KeyDown);
            // 
            // lblMountInfo
            // 
            this.lblMountInfo.AutoSize = true;
            this.lblMountInfo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMountInfo.Location = new System.Drawing.Point(176, 125);
            this.lblMountInfo.Name = "lblMountInfo";
            this.lblMountInfo.Size = new System.Drawing.Size(59, 13);
            this.lblMountInfo.TabIndex = 7;
            this.lblMountInfo.Text = "软链接到";
            // 
            // txtBoxMountTo
            // 
            this.txtBoxMountTo.Location = new System.Drawing.Point(21, 148);
            this.txtBoxMountTo.Name = "txtBoxMountTo";
            this.txtBoxMountTo.Size = new System.Drawing.Size(380, 22);
            this.txtBoxMountTo.TabIndex = 8;
            this.txtBoxMountTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxMountTo_KeyDown);
            // 
            // btnRefreshStatus
            // 
            this.btnRefreshStatus.Location = new System.Drawing.Point(130, 190);
            this.btnRefreshStatus.Name = "btnRefreshStatus";
            this.btnRefreshStatus.Size = new System.Drawing.Size(149, 32);
            this.btnRefreshStatus.TabIndex = 9;
            this.btnRefreshStatus.Text = "刷新当前状态";
            this.btnRefreshStatus.UseVisualStyleBackColor = true;
            this.btnRefreshStatus.Click += new System.EventHandler(this.btnRefreshStatus_Click);
            // 
            // tdBtnSwitchToCN
            // 
            this.tdBtnSwitchToCN.AutoSize = true;
            this.tdBtnSwitchToCN.Checked = true;
            this.tdBtnSwitchToCN.Location = new System.Drawing.Point(105, 238);
            this.tdBtnSwitchToCN.Name = "tdBtnSwitchToCN";
            this.tdBtnSwitchToCN.Size = new System.Drawing.Size(14, 13);
            this.tdBtnSwitchToCN.TabIndex = 10;
            this.tdBtnSwitchToCN.TabStop = true;
            this.tdBtnSwitchToCN.UseVisualStyleBackColor = true;
            this.tdBtnSwitchToCN.Visible = false;
            // 
            // btnSwitchToCN
            // 
            this.btnSwitchToCN.Location = new System.Drawing.Point(130, 228);
            this.btnSwitchToCN.Name = "btnSwitchToCN";
            this.btnSwitchToCN.Size = new System.Drawing.Size(149, 32);
            this.btnSwitchToCN.TabIndex = 11;
            this.btnSwitchToCN.Text = "切换到国服(CN)";
            this.btnSwitchToCN.UseVisualStyleBackColor = true;
            this.btnSwitchToCN.Click += new System.EventHandler(this.btnSwitchToCN_Click);
            // 
            // tdBtnSwitchToTW
            // 
            this.tdBtnSwitchToTW.AutoSize = true;
            this.tdBtnSwitchToTW.Checked = true;
            this.tdBtnSwitchToTW.Location = new System.Drawing.Point(105, 275);
            this.tdBtnSwitchToTW.Name = "tdBtnSwitchToTW";
            this.tdBtnSwitchToTW.Size = new System.Drawing.Size(14, 13);
            this.tdBtnSwitchToTW.TabIndex = 12;
            this.tdBtnSwitchToTW.TabStop = true;
            this.tdBtnSwitchToTW.UseVisualStyleBackColor = true;
            // 
            // btnSwitchToTW
            // 
            this.btnSwitchToTW.Location = new System.Drawing.Point(130, 266);
            this.btnSwitchToTW.Name = "btnSwitchToTW";
            this.btnSwitchToTW.Size = new System.Drawing.Size(149, 31);
            this.btnSwitchToTW.TabIndex = 13;
            this.btnSwitchToTW.Text = "切换到亚服(TW)";
            this.btnSwitchToTW.UseVisualStyleBackColor = true;
            this.btnSwitchToTW.Click += new System.EventHandler(this.btnSwitchToTW_Click);
            // 
            // btnUnmount
            // 
            this.btnUnmount.Location = new System.Drawing.Point(130, 303);
            this.btnUnmount.Name = "btnUnmount";
            this.btnUnmount.Size = new System.Drawing.Size(149, 31);
            this.btnUnmount.TabIndex = 14;
            this.btnUnmount.Text = "解除软链接绑定";
            this.btnUnmount.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(130, 340);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(149, 30);
            this.btnCheck.TabIndex = 15;
            this.btnCheck.Text = "检测是否支持软链接";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(130, 376);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(149, 30);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "退 出(&E)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkBoxMinimizeToTaskbarWhenExiting
            // 
            this.chkBoxMinimizeToTaskbarWhenExiting.AutoSize = true;
            this.chkBoxMinimizeToTaskbarWhenExiting.Location = new System.Drawing.Point(130, 422);
            this.chkBoxMinimizeToTaskbarWhenExiting.Name = "chkBoxMinimizeToTaskbarWhenExiting";
            this.chkBoxMinimizeToTaskbarWhenExiting.Size = new System.Drawing.Size(156, 17);
            this.chkBoxMinimizeToTaskbarWhenExiting.TabIndex = 17;
            this.chkBoxMinimizeToTaskbarWhenExiting.Text = "关闭时最小化到任务栏";
            this.chkBoxMinimizeToTaskbarWhenExiting.UseVisualStyleBackColor = true;
            this.chkBoxMinimizeToTaskbarWhenExiting.CheckedChanged += new System.EventHandler(this.chkBoxMinimizeToTaskbarWhenExiting_CheckedChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripTaskBar;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "WoWJunction";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStripTaskBar
            // 
            this.contextMenuStripTaskBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowMain,
            this.toolStripMenuItemHideMain,
            this.toolStripSeparator1,
            this.toolStripMenuItemExit});
            this.contextMenuStripTaskBar.Name = "contextMenuStripTaskBar";
            this.contextMenuStripTaskBar.Size = new System.Drawing.Size(154, 76);
            // 
            // toolStripMenuItemShowMain
            // 
            this.toolStripMenuItemShowMain.Name = "toolStripMenuItemShowMain";
            this.toolStripMenuItemShowMain.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItemShowMain.Text = "显示主窗口(&S)";
            this.toolStripMenuItemShowMain.Click += new System.EventHandler(this.toolStripMenuItemShowMain_Click);
            // 
            // toolStripMenuItemHideMain
            // 
            this.toolStripMenuItemHideMain.Name = "toolStripMenuItemHideMain";
            this.toolStripMenuItemHideMain.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItemHideMain.Text = "隐藏主窗口(&H)";
            this.toolStripMenuItemHideMain.Click += new System.EventHandler(this.toolStripMenuItemHideMain_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItemExit.Text = "退出(&E)";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 452);
            this.Controls.Add(this.chkBoxMinimizeToTaskbarWhenExiting);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.lnkLinkToTarget);
            this.Controls.Add(this.lblLinkTo);
            this.Controls.Add(this.lnkLinkToSource);
            this.Controls.Add(this.lblWoWClassicPathTip);
            this.Controls.Add(this.txtBoxMountFrom);
            this.Controls.Add(this.lblMountInfo);
            this.Controls.Add(this.txtBoxMountTo);
            this.Controls.Add(this.btnOpenSettings);
            this.Controls.Add(this.btnRefreshStatus);
            this.Controls.Add(this.tdBtnSwitchToTW);
            this.Controls.Add(this.btnSwitchToCN);
            this.Controls.Add(this.tdBtnSwitchToCN);
            this.Controls.Add(this.btnSwitchToTW);
            this.Controls.Add(this.btnUnmount);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "《魔兽世界》怀旧服（国服/亚服）切换器 v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.contextMenuStripTaskBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenSettings;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.LinkLabel lnkLinkToSource;
        private System.Windows.Forms.Label lblLinkTo;
        private System.Windows.Forms.LinkLabel lnkLinkToTarget;
        private System.Windows.Forms.Label lblWoWClassicPathTip;
        private System.Windows.Forms.TextBox txtBoxMountFrom;
        private System.Windows.Forms.Label lblMountInfo;
        private System.Windows.Forms.TextBox txtBoxMountTo;
        private System.Windows.Forms.Button btnRefreshStatus;
        private System.Windows.Forms.RadioButton tdBtnSwitchToCN;
        private System.Windows.Forms.Button btnSwitchToCN;
        private System.Windows.Forms.RadioButton tdBtnSwitchToTW;
        private System.Windows.Forms.Button btnSwitchToTW;
        private System.Windows.Forms.Button btnUnmount;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkBoxMinimizeToTaskbarWhenExiting;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTaskBar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHideMain;
    }
}

