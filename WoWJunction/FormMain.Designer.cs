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
            this.btnMountToCN = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnMountToTW = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMountToCN
            // 
            this.btnMountToCN.Location = new System.Drawing.Point(140, 219);
            this.btnMountToCN.Name = "btnMountToCN";
            this.btnMountToCN.Size = new System.Drawing.Size(129, 32);
            this.btnMountToCN.TabIndex = 0;
            this.btnMountToCN.Text = "切换到国服";
            this.btnMountToCN.UseVisualStyleBackColor = true;
            this.btnMountToCN.Click += new System.EventHandler(this.btnMountToCN_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(140, 127);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(129, 30);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnMountToTW
            // 
            this.btnMountToTW.Location = new System.Drawing.Point(140, 267);
            this.btnMountToTW.Name = "btnMountToTW";
            this.btnMountToTW.Size = new System.Drawing.Size(129, 31);
            this.btnMountToTW.TabIndex = 2;
            this.btnMountToTW.Text = "切换到亚服";
            this.btnMountToTW.UseVisualStyleBackColor = true;
            this.btnMountToTW.Click += new System.EventHandler(this.btnMountToTW_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(140, 173);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(129, 31);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "WoW 路径设置";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 329);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnMountToTW);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnMountToCN);
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

        }

        #endregion

        private System.Windows.Forms.Button btnMountToCN;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnMountToTW;
        private System.Windows.Forms.Button btnSettings;
    }
}

