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
            this.btnExit = new System.Windows.Forms.Button();
            this.chkBoxMinimizeToTaskbarWhenExiting = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripTaskBar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHideMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenWoWClassicFolder = new System.Windows.Forms.Button();
            this.btnOpenWoWClassicLinkedFolder = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripVersionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripAuthorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripPaddingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSourceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripGiteeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripGitHubLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripHelpLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AuthorInfoPanel = new System.Windows.Forms.Panel();
            this.lnkLabelAuthorInfoCN = new System.Windows.Forms.LinkLabel();
            this.lnkLabelAuthorInfoTW = new System.Windows.Forms.LinkLabel();
            this.contextMenuStripTaskBar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.AuthorInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.Location = new System.Drawing.Point(351, 12);
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
            this.lblCurrentStatus.Location = new System.Drawing.Point(199, 21);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(72, 13);
            this.lblCurrentStatus.TabIndex = 1;
            this.lblCurrentStatus.Text = "当前状态：";
            // 
            // lnkLinkToSource
            // 
            this.lnkLinkToSource.AutoSize = true;
            this.lnkLinkToSource.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLinkToSource.Location = new System.Drawing.Point(134, 43);
            this.lnkLinkToSource.Name = "lnkLinkToSource";
            this.lnkLinkToSource.Size = new System.Drawing.Size(77, 13);
            this.lnkLinkToSource.TabIndex = 2;
            this.lnkLinkToSource.TabStop = true;
            this.lnkLinkToSource.Text = "\\_classic_";
            this.lnkLinkToSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLinkToSource_LinkClicked);
            // 
            // lblLinkTo
            // 
            this.lblLinkTo.AutoSize = true;
            this.lblLinkTo.ForeColor = System.Drawing.Color.Red;
            this.lblLinkTo.Location = new System.Drawing.Point(217, 43);
            this.lblLinkTo.Name = "lblLinkTo";
            this.lblLinkTo.Size = new System.Drawing.Size(28, 13);
            this.lblLinkTo.TabIndex = 3;
            this.lblLinkTo.Text = "==>";
            // 
            // lnkLinkToTarget
            // 
            this.lnkLinkToTarget.AutoSize = true;
            this.lnkLinkToTarget.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLinkToTarget.Location = new System.Drawing.Point(251, 43);
            this.lnkLinkToTarget.Name = "lnkLinkToTarget";
            this.lnkLinkToTarget.Size = new System.Drawing.Size(84, 13);
            this.lnkLinkToTarget.TabIndex = 4;
            this.lnkLinkToTarget.TabStop = true;
            this.lnkLinkToTarget.Text = "\\classic_cn";
            this.lnkLinkToTarget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLinkToTarget_LinkClicked);
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
            this.lblMountInfo.Location = new System.Drawing.Point(198, 123);
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
            this.btnRefreshStatus.Location = new System.Drawing.Point(152, 190);
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
            this.tdBtnSwitchToCN.Location = new System.Drawing.Point(127, 238);
            this.tdBtnSwitchToCN.Name = "tdBtnSwitchToCN";
            this.tdBtnSwitchToCN.Size = new System.Drawing.Size(14, 13);
            this.tdBtnSwitchToCN.TabIndex = 10;
            this.tdBtnSwitchToCN.TabStop = true;
            this.tdBtnSwitchToCN.UseVisualStyleBackColor = true;
            this.tdBtnSwitchToCN.Visible = false;
            // 
            // btnSwitchToCN
            // 
            this.btnSwitchToCN.Location = new System.Drawing.Point(152, 228);
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
            this.tdBtnSwitchToTW.Location = new System.Drawing.Point(127, 275);
            this.tdBtnSwitchToTW.Name = "tdBtnSwitchToTW";
            this.tdBtnSwitchToTW.Size = new System.Drawing.Size(14, 13);
            this.tdBtnSwitchToTW.TabIndex = 12;
            this.tdBtnSwitchToTW.TabStop = true;
            this.tdBtnSwitchToTW.UseVisualStyleBackColor = true;
            // 
            // btnSwitchToTW
            // 
            this.btnSwitchToTW.Location = new System.Drawing.Point(152, 266);
            this.btnSwitchToTW.Name = "btnSwitchToTW";
            this.btnSwitchToTW.Size = new System.Drawing.Size(149, 31);
            this.btnSwitchToTW.TabIndex = 13;
            this.btnSwitchToTW.Text = "切换到亚服(TW)";
            this.btnSwitchToTW.UseVisualStyleBackColor = true;
            this.btnSwitchToTW.Click += new System.EventHandler(this.btnSwitchToTW_Click);
            // 
            // btnUnmount
            // 
            this.btnUnmount.Location = new System.Drawing.Point(152, 303);
            this.btnUnmount.Name = "btnUnmount";
            this.btnUnmount.Size = new System.Drawing.Size(149, 31);
            this.btnUnmount.TabIndex = 14;
            this.btnUnmount.Text = "解除软链接绑定";
            this.btnUnmount.UseVisualStyleBackColor = true;
            this.btnUnmount.Click += new System.EventHandler(this.btnUnmount_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(152, 340);
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
            this.chkBoxMinimizeToTaskbarWhenExiting.Location = new System.Drawing.Point(152, 386);
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
            // btnOpenWoWClassicFolder
            // 
            this.btnOpenWoWClassicFolder.Location = new System.Drawing.Point(409, 89);
            this.btnOpenWoWClassicFolder.Name = "btnOpenWoWClassicFolder";
            this.btnOpenWoWClassicFolder.Size = new System.Drawing.Size(44, 27);
            this.btnOpenWoWClassicFolder.TabIndex = 18;
            this.btnOpenWoWClassicFolder.Text = "打开";
            this.btnOpenWoWClassicFolder.UseVisualStyleBackColor = true;
            this.btnOpenWoWClassicFolder.Click += new System.EventHandler(this.btnOpenWoWClassicFolder_Click);
            // 
            // btnOpenWoWClassicLinkedFolder
            // 
            this.btnOpenWoWClassicLinkedFolder.Location = new System.Drawing.Point(409, 146);
            this.btnOpenWoWClassicLinkedFolder.Name = "btnOpenWoWClassicLinkedFolder";
            this.btnOpenWoWClassicLinkedFolder.Size = new System.Drawing.Size(44, 27);
            this.btnOpenWoWClassicLinkedFolder.TabIndex = 19;
            this.btnOpenWoWClassicLinkedFolder.Text = "打开";
            this.btnOpenWoWClassicLinkedFolder.UseVisualStyleBackColor = true;
            this.btnOpenWoWClassicLinkedFolder.Click += new System.EventHandler(this.btnOpenWoWClassicLinkedFolder_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripVersionLabel,
            this.toolStripHelpLabel,
            this.toolStripSourceLabel,
            this.toolStripGiteeLabel,
            this.toolStripGitHubLabel,
            this.toolStripPaddingLabel,
            this.toolStripAuthorLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 444);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(470, 26);
            this.statusStrip.TabIndex = 20;
            this.statusStrip.Text = "状态栏";
            // 
            // toolStripVersionLabel
            // 
            this.toolStripVersionLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripVersionLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripVersionLabel.IsLink = true;
            this.toolStripVersionLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolStripVersionLabel.Name = "toolStripVersionLabel";
            this.toolStripVersionLabel.Size = new System.Drawing.Size(78, 21);
            this.toolStripVersionLabel.Text = "版本：v1.01";
            this.toolStripVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripAuthorLabel
            // 
            this.toolStripAuthorLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripAuthorLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripAuthorLabel.IsLink = true;
            this.toolStripAuthorLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolStripAuthorLabel.Name = "toolStripAuthorLabel";
            this.toolStripAuthorLabel.Size = new System.Drawing.Size(72, 21);
            this.toolStripAuthorLabel.Text = "作者：郭子";
            this.toolStripAuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripPaddingLabel
            // 
            this.toolStripPaddingLabel.AutoSize = false;
            this.toolStripPaddingLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripPaddingLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripPaddingLabel.Name = "toolStripPaddingLabel";
            this.toolStripPaddingLabel.Size = new System.Drawing.Size(40, 21);
            // 
            // toolStripSourceLabel
            // 
            this.toolStripSourceLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripSourceLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripSourceLabel.Name = "toolStripSourceLabel";
            this.toolStripSourceLabel.Size = new System.Drawing.Size(36, 21);
            this.toolStripSourceLabel.Text = "源码";
            // 
            // toolStripGiteeLabel
            // 
            this.toolStripGiteeLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripGiteeLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripGiteeLabel.IsLink = true;
            this.toolStripGiteeLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolStripGiteeLabel.Name = "toolStripGiteeLabel";
            this.toolStripGiteeLabel.Size = new System.Drawing.Size(42, 21);
            this.toolStripGiteeLabel.Text = "Gitee";
            // 
            // toolStripGitHubLabel
            // 
            this.toolStripGitHubLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripGitHubLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripGitHubLabel.IsLink = true;
            this.toolStripGitHubLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolStripGitHubLabel.Name = "toolStripGitHubLabel";
            this.toolStripGitHubLabel.Size = new System.Drawing.Size(52, 21);
            this.toolStripGitHubLabel.Text = "GitHub";
            // 
            // toolStripHelpLabel
            // 
            this.toolStripHelpLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripHelpLabel.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripHelpLabel.IsLink = true;
            this.toolStripHelpLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.toolStripHelpLabel.Name = "toolStripHelpLabel";
            this.toolStripHelpLabel.Size = new System.Drawing.Size(127, 21);
            this.toolStripHelpLabel.Text = " 使用说明(NGA论坛) ";
            // 
            // AuthorInfoPanel
            // 
            this.AuthorInfoPanel.Controls.Add(this.lnkLabelAuthorInfoTW);
            this.AuthorInfoPanel.Controls.Add(this.lnkLabelAuthorInfoCN);
            this.AuthorInfoPanel.Location = new System.Drawing.Point(10, 412);
            this.AuthorInfoPanel.Name = "AuthorInfoPanel";
            this.AuthorInfoPanel.Size = new System.Drawing.Size(448, 28);
            this.AuthorInfoPanel.TabIndex = 21;
            // 
            // lnkLabelAuthorInfoCN
            // 
            this.lnkLabelAuthorInfoCN.AutoSize = true;
            this.lnkLabelAuthorInfoCN.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLabelAuthorInfoCN.Location = new System.Drawing.Point(3, 8);
            this.lnkLabelAuthorInfoCN.Name = "lnkLabelAuthorInfoCN";
            this.lnkLabelAuthorInfoCN.Size = new System.Drawing.Size(186, 13);
            this.lnkLabelAuthorInfoCN.TabIndex = 0;
            this.lnkLabelAuthorInfoCN.TabStop = true;
            this.lnkLabelAuthorInfoCN.Text = "国服/辛迪加/联盟/夏洛特(DK)";
            // 
            // lnkLabelAuthorInfoTW
            // 
            this.lnkLabelAuthorInfoTW.AutoSize = true;
            this.lnkLabelAuthorInfoTW.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLabelAuthorInfoTW.Location = new System.Drawing.Point(246, 8);
            this.lnkLabelAuthorInfoTW.Name = "lnkLabelAuthorInfoTW";
            this.lnkLabelAuthorInfoTW.Size = new System.Drawing.Size(199, 13);
            this.lnkLabelAuthorInfoTW.TabIndex = 1;
            this.lnkLabelAuthorInfoTW.TabStop = true;
            this.lnkLabelAuthorInfoTW.Text = "亚服/逐风者/部落/夏洛特丷(DK)";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 470);
            this.Controls.Add(this.AuthorInfoPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnOpenWoWClassicLinkedFolder);
            this.Controls.Add(this.btnOpenWoWClassicFolder);
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.AuthorInfoPanel.ResumeLayout(false);
            this.AuthorInfoPanel.PerformLayout();
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
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkBoxMinimizeToTaskbarWhenExiting;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTaskBar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHideMain;
        private System.Windows.Forms.Button btnOpenWoWClassicFolder;
        private System.Windows.Forms.Button btnOpenWoWClassicLinkedFolder;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripVersionLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripAuthorLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripPaddingLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSourceLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripGiteeLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripGitHubLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripHelpLabel;
        private System.Windows.Forms.Panel AuthorInfoPanel;
        private System.Windows.Forms.LinkLabel lnkLabelAuthorInfoTW;
        private System.Windows.Forms.LinkLabel lnkLabelAuthorInfoCN;
    }
}

