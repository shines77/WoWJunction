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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnSwitchToCN = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSwitchToTW = new System.Windows.Forms.Button();
            this.btnOpenSettings = new System.Windows.Forms.Button();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lnkMountFrom = new System.Windows.Forms.LinkLabel();
            this.lblLinkTo = new System.Windows.Forms.Label();
            this.lnkMountTo = new System.Windows.Forms.LinkLabel();
            this.txtBoxMountFrom = new System.Windows.Forms.TextBox();
            this.txtBoxMountTo = new System.Windows.Forms.TextBox();
            this.lblMountInfo = new System.Windows.Forms.Label();
            this.btnUnmount = new System.Windows.Forms.Button();
            this.lblWoWClassicPathTip = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.tdBtnSwitchToCN = new System.Windows.Forms.RadioButton();
            this.tdBtnSwitchToTW = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnSwitchToCN
            // 
            this.btnSwitchToCN.Location = new System.Drawing.Point(141, 194);
            this.btnSwitchToCN.Name = "btnSwitchToCN";
            this.btnSwitchToCN.Size = new System.Drawing.Size(129, 32);
            this.btnSwitchToCN.TabIndex = 0;
            this.btnSwitchToCN.Text = "切换到国服";
            this.btnSwitchToCN.UseVisualStyleBackColor = true;
            this.btnSwitchToCN.Click += new System.EventHandler(this.btnSwitchToCN_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(141, 306);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(129, 30);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSwitchToTW
            // 
            this.btnSwitchToTW.Location = new System.Drawing.Point(141, 232);
            this.btnSwitchToTW.Name = "btnSwitchToTW";
            this.btnSwitchToTW.Size = new System.Drawing.Size(129, 31);
            this.btnSwitchToTW.TabIndex = 2;
            this.btnSwitchToTW.Text = "切换到亚服";
            this.btnSwitchToTW.UseVisualStyleBackColor = true;
            this.btnSwitchToTW.Click += new System.EventHandler(this.btnSwitchToTW_Click);
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.Location = new System.Drawing.Point(299, 9);
            this.btnOpenSettings.Name = "btnOpenSettings";
            this.btnOpenSettings.Size = new System.Drawing.Size(102, 31);
            this.btnOpenSettings.TabIndex = 3;
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
            this.lblCurrentStatus.TabIndex = 4;
            this.lblCurrentStatus.Text = "当前状态：";
            // 
            // lnkMountFrom
            // 
            this.lnkMountFrom.AutoSize = true;
            this.lnkMountFrom.Location = new System.Drawing.Point(123, 43);
            this.lnkMountFrom.Name = "lnkMountFrom";
            this.lnkMountFrom.Size = new System.Drawing.Size(63, 13);
            this.lnkMountFrom.TabIndex = 5;
            this.lnkMountFrom.TabStop = true;
            this.lnkMountFrom.Text = "\\classic";
            // 
            // lblLinkTo
            // 
            this.lblLinkTo.AutoSize = true;
            this.lblLinkTo.ForeColor = System.Drawing.Color.Red;
            this.lblLinkTo.Location = new System.Drawing.Point(192, 43);
            this.lblLinkTo.Name = "lblLinkTo";
            this.lblLinkTo.Size = new System.Drawing.Size(28, 13);
            this.lblLinkTo.TabIndex = 6;
            this.lblLinkTo.Text = "==>";
            // 
            // lnkMountTo
            // 
            this.lnkMountTo.AutoSize = true;
            this.lnkMountTo.Location = new System.Drawing.Point(226, 43);
            this.lnkMountTo.Name = "lnkMountTo";
            this.lnkMountTo.Size = new System.Drawing.Size(84, 13);
            this.lnkMountTo.TabIndex = 7;
            this.lnkMountTo.TabStop = true;
            this.lnkMountTo.Text = "\\classic_cn";
            // 
            // txtBoxMountFrom
            // 
            this.txtBoxMountFrom.Location = new System.Drawing.Point(21, 92);
            this.txtBoxMountFrom.Name = "txtBoxMountFrom";
            this.txtBoxMountFrom.Size = new System.Drawing.Size(380, 22);
            this.txtBoxMountFrom.TabIndex = 8;
            // 
            // txtBoxMountTo
            // 
            this.txtBoxMountTo.Location = new System.Drawing.Point(21, 148);
            this.txtBoxMountTo.Name = "txtBoxMountTo";
            this.txtBoxMountTo.Size = new System.Drawing.Size(380, 22);
            this.txtBoxMountTo.TabIndex = 9;
            // 
            // lblMountInfo
            // 
            this.lblMountInfo.AutoSize = true;
            this.lblMountInfo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMountInfo.Location = new System.Drawing.Point(176, 125);
            this.lblMountInfo.Name = "lblMountInfo";
            this.lblMountInfo.Size = new System.Drawing.Size(59, 13);
            this.lblMountInfo.TabIndex = 10;
            this.lblMountInfo.Text = "软链接到";
            // 
            // btnUnmount
            // 
            this.btnUnmount.Location = new System.Drawing.Point(141, 269);
            this.btnUnmount.Name = "btnUnmount";
            this.btnUnmount.Size = new System.Drawing.Size(129, 31);
            this.btnUnmount.TabIndex = 11;
            this.btnUnmount.Text = "解除软链接绑定";
            this.btnUnmount.UseVisualStyleBackColor = true;
            // 
            // lblWoWClassicPathTip
            // 
            this.lblWoWClassicPathTip.AutoSize = true;
            this.lblWoWClassicPathTip.Location = new System.Drawing.Point(18, 72);
            this.lblWoWClassicPathTip.Name = "lblWoWClassicPathTip";
            this.lblWoWClassicPathTip.Size = new System.Drawing.Size(137, 13);
            this.lblWoWClassicPathTip.TabIndex = 12;
            this.lblWoWClassicPathTip.Text = "《魔兽世界》怀旧服：";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(141, 342);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(129, 30);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退 出(&E)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tdBtnSwitchToCN
            // 
            this.tdBtnSwitchToCN.AutoSize = true;
            this.tdBtnSwitchToCN.Checked = true;
            this.tdBtnSwitchToCN.Location = new System.Drawing.Point(111, 204);
            this.tdBtnSwitchToCN.Name = "tdBtnSwitchToCN";
            this.tdBtnSwitchToCN.Size = new System.Drawing.Size(14, 13);
            this.tdBtnSwitchToCN.TabIndex = 14;
            this.tdBtnSwitchToCN.TabStop = true;
            this.tdBtnSwitchToCN.UseVisualStyleBackColor = true;
            this.tdBtnSwitchToCN.Visible = false;
            // 
            // tdBtnSwitchToTW
            // 
            this.tdBtnSwitchToTW.AutoSize = true;
            this.tdBtnSwitchToTW.Checked = true;
            this.tdBtnSwitchToTW.Location = new System.Drawing.Point(111, 241);
            this.tdBtnSwitchToTW.Name = "tdBtnSwitchToTW";
            this.tdBtnSwitchToTW.Size = new System.Drawing.Size(14, 13);
            this.tdBtnSwitchToTW.TabIndex = 15;
            this.tdBtnSwitchToTW.TabStop = true;
            this.tdBtnSwitchToTW.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 385);
            this.Controls.Add(this.tdBtnSwitchToTW);
            this.Controls.Add(this.tdBtnSwitchToCN);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblWoWClassicPathTip);
            this.Controls.Add(this.btnUnmount);
            this.Controls.Add(this.lblMountInfo);
            this.Controls.Add(this.txtBoxMountTo);
            this.Controls.Add(this.txtBoxMountFrom);
            this.Controls.Add(this.lnkMountTo);
            this.Controls.Add(this.lblLinkTo);
            this.Controls.Add(this.lnkMountFrom);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.btnOpenSettings);
            this.Controls.Add(this.btnSwitchToTW);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnSwitchToCN);
            this.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "《魔兽世界》怀旧服（国服/亚服）切换器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSwitchToCN;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSwitchToTW;
        private System.Windows.Forms.Button btnOpenSettings;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.LinkLabel lnkMountFrom;
        private System.Windows.Forms.Label lblLinkTo;
        private System.Windows.Forms.LinkLabel lnkMountTo;
        private System.Windows.Forms.TextBox txtBoxMountFrom;
        private System.Windows.Forms.TextBox txtBoxMountTo;
        private System.Windows.Forms.Label lblMountInfo;
        private System.Windows.Forms.Button btnUnmount;
        private System.Windows.Forms.Label lblWoWClassicPathTip;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.RadioButton tdBtnSwitchToCN;
        private System.Windows.Forms.RadioButton tdBtnSwitchToTW;
    }
}

