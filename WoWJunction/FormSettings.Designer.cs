namespace WoWJunction
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtBoxWoWRootPath = new System.Windows.Forms.TextBox();
            this.lblWoWRootPath = new System.Windows.Forms.Label();
            this.btnBrowseWoWRootPath = new System.Windows.Forms.Button();
            this.lblTip1 = new System.Windows.Forms.Label();
            this.lblWoWClassicPath = new System.Windows.Forms.Label();
            this.txtBoxWoWClassicPath = new System.Windows.Forms.TextBox();
            this.lblTipWoWClassicPath = new System.Windows.Forms.Label();
            this.lblTipWoWClassicPathCN = new System.Windows.Forms.Label();
            this.btnBrowseWoWClassicPathCN = new System.Windows.Forms.Button();
            this.txtBoxWoWClassicPathCN = new System.Windows.Forms.TextBox();
            this.lblWoWClassicPathCN = new System.Windows.Forms.Label();
            this.lblTipWoWClassicPathTW = new System.Windows.Forms.Label();
            this.btnBrowseWoWClassicPathTW = new System.Windows.Forms.Button();
            this.txtBoxWoWClassicPathTW = new System.Windows.Forms.TextBox();
            this.lblWoWClassicPathTW = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxWoWRootPath
            // 
            this.txtBoxWoWRootPath.Location = new System.Drawing.Point(23, 38);
            this.txtBoxWoWRootPath.Name = "txtBoxWoWRootPath";
            this.txtBoxWoWRootPath.Size = new System.Drawing.Size(456, 22);
            this.txtBoxWoWRootPath.TabIndex = 0;
            // 
            // lblWoWRootPath
            // 
            this.lblWoWRootPath.AutoSize = true;
            this.lblWoWRootPath.Location = new System.Drawing.Point(20, 19);
            this.lblWoWRootPath.Name = "lblWoWRootPath";
            this.lblWoWRootPath.Size = new System.Drawing.Size(98, 13);
            this.lblWoWRootPath.TabIndex = 1;
            this.lblWoWRootPath.Text = "魔兽世界路径：";
            // 
            // btnBrowseWoWRootPath
            // 
            this.btnBrowseWoWRootPath.Location = new System.Drawing.Point(497, 33);
            this.btnBrowseWoWRootPath.Name = "btnBrowseWoWRootPath";
            this.btnBrowseWoWRootPath.Size = new System.Drawing.Size(72, 29);
            this.btnBrowseWoWRootPath.TabIndex = 2;
            this.btnBrowseWoWRootPath.Text = "浏览...";
            this.btnBrowseWoWRootPath.UseVisualStyleBackColor = true;
            // 
            // lblTip1
            // 
            this.lblTip1.AutoSize = true;
            this.lblTip1.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTip1.Location = new System.Drawing.Point(20, 68);
            this.lblTip1.Name = "lblTip1";
            this.lblTip1.Size = new System.Drawing.Size(526, 13);
            this.lblTip1.TabIndex = 3;
            this.lblTip1.Text = "请选择《魔兽世界》根目录，或《魔兽世界》怀旧服目录(_classic_)均可，会自动识别。";
            // 
            // lblWoWClassicPath
            // 
            this.lblWoWClassicPath.AutoSize = true;
            this.lblWoWClassicPath.Location = new System.Drawing.Point(20, 96);
            this.lblWoWClassicPath.Name = "lblWoWClassicPath";
            this.lblWoWClassicPath.Size = new System.Drawing.Size(137, 13);
            this.lblWoWClassicPath.TabIndex = 4;
            this.lblWoWClassicPath.Text = "魔兽世界怀旧服目录：";
            // 
            // txtBoxWoWClassicPath
            // 
            this.txtBoxWoWClassicPath.Location = new System.Drawing.Point(23, 115);
            this.txtBoxWoWClassicPath.Name = "txtBoxWoWClassicPath";
            this.txtBoxWoWClassicPath.Size = new System.Drawing.Size(175, 22);
            this.txtBoxWoWClassicPath.TabIndex = 5;
            // 
            // lblTipWoWClassicPath
            // 
            this.lblTipWoWClassicPath.AutoSize = true;
            this.lblTipWoWClassicPath.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTipWoWClassicPath.Location = new System.Drawing.Point(26, 144);
            this.lblTipWoWClassicPath.Name = "lblTipWoWClassicPath";
            this.lblTipWoWClassicPath.Size = new System.Drawing.Size(325, 13);
            this.lblTipWoWClassicPath.TabIndex = 7;
            this.lblTipWoWClassicPath.Text = "默认值为 \"_classic_\"，可修改，但不能选择本地路径";
            // 
            // lblTipWoWClassicPathCN
            // 
            this.lblTipWoWClassicPathCN.AutoSize = true;
            this.lblTipWoWClassicPathCN.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTipWoWClassicPathCN.Location = new System.Drawing.Point(26, 224);
            this.lblTipWoWClassicPathCN.Name = "lblTipWoWClassicPathCN";
            this.lblTipWoWClassicPathCN.Size = new System.Drawing.Size(352, 13);
            this.lblTipWoWClassicPathCN.TabIndex = 11;
            this.lblTipWoWClassicPathCN.Text = "默认值为 \"_classic_cn\"，路径可自定义，建议使用默认值";
            // 
            // btnBrowseWoWClassicPathCN
            // 
            this.btnBrowseWoWClassicPathCN.Location = new System.Drawing.Point(497, 189);
            this.btnBrowseWoWClassicPathCN.Name = "btnBrowseWoWClassicPathCN";
            this.btnBrowseWoWClassicPathCN.Size = new System.Drawing.Size(72, 29);
            this.btnBrowseWoWClassicPathCN.TabIndex = 10;
            this.btnBrowseWoWClassicPathCN.Text = "浏览...";
            this.btnBrowseWoWClassicPathCN.UseVisualStyleBackColor = true;
            // 
            // txtBoxWoWClassicPathCN
            // 
            this.txtBoxWoWClassicPathCN.Location = new System.Drawing.Point(23, 194);
            this.txtBoxWoWClassicPathCN.Name = "txtBoxWoWClassicPathCN";
            this.txtBoxWoWClassicPathCN.Size = new System.Drawing.Size(456, 22);
            this.txtBoxWoWClassicPathCN.TabIndex = 9;
            // 
            // lblWoWClassicPathCN
            // 
            this.lblWoWClassicPathCN.AutoSize = true;
            this.lblWoWClassicPathCN.Location = new System.Drawing.Point(20, 175);
            this.lblWoWClassicPathCN.Name = "lblWoWClassicPathCN";
            this.lblWoWClassicPathCN.Size = new System.Drawing.Size(189, 13);
            this.lblWoWClassicPathCN.TabIndex = 8;
            this.lblWoWClassicPathCN.Text = "魔兽世界怀旧服目录（国服）：";
            // 
            // lblTipWoWClassicPathTW
            // 
            this.lblTipWoWClassicPathTW.AutoSize = true;
            this.lblTipWoWClassicPathTW.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTipWoWClassicPathTW.Location = new System.Drawing.Point(26, 301);
            this.lblTipWoWClassicPathTW.Name = "lblTipWoWClassicPathTW";
            this.lblTipWoWClassicPathTW.Size = new System.Drawing.Size(352, 13);
            this.lblTipWoWClassicPathTW.TabIndex = 15;
            this.lblTipWoWClassicPathTW.Text = "默认值为 \"_classic_tw\"，路径可自定义，建议使用默认值";
            // 
            // btnBrowseWoWClassicPathTW
            // 
            this.btnBrowseWoWClassicPathTW.Location = new System.Drawing.Point(497, 267);
            this.btnBrowseWoWClassicPathTW.Name = "btnBrowseWoWClassicPathTW";
            this.btnBrowseWoWClassicPathTW.Size = new System.Drawing.Size(72, 29);
            this.btnBrowseWoWClassicPathTW.TabIndex = 14;
            this.btnBrowseWoWClassicPathTW.Text = "浏览...";
            this.btnBrowseWoWClassicPathTW.UseVisualStyleBackColor = true;
            // 
            // txtBoxWoWClassicPathTW
            // 
            this.txtBoxWoWClassicPathTW.Location = new System.Drawing.Point(23, 272);
            this.txtBoxWoWClassicPathTW.Name = "txtBoxWoWClassicPathTW";
            this.txtBoxWoWClassicPathTW.Size = new System.Drawing.Size(456, 22);
            this.txtBoxWoWClassicPathTW.TabIndex = 13;
            // 
            // lblWoWClassicPathTW
            // 
            this.lblWoWClassicPathTW.AutoSize = true;
            this.lblWoWClassicPathTW.Location = new System.Drawing.Point(20, 253);
            this.lblWoWClassicPathTW.Name = "lblWoWClassicPathTW";
            this.lblWoWClassicPathTW.Size = new System.Drawing.Size(189, 13);
            this.lblWoWClassicPathTW.TabIndex = 12;
            this.lblWoWClassicPathTW.Text = "魔兽世界怀旧服目录（亚服）：";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(196, 331);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(86, 29);
            this.btnApply.TabIndex = 16;
            this.btnApply.Text = "确定(&A)";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(318, 331);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 29);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 375);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblTipWoWClassicPathTW);
            this.Controls.Add(this.btnBrowseWoWClassicPathTW);
            this.Controls.Add(this.txtBoxWoWClassicPathTW);
            this.Controls.Add(this.lblWoWClassicPathTW);
            this.Controls.Add(this.lblTipWoWClassicPathCN);
            this.Controls.Add(this.btnBrowseWoWClassicPathCN);
            this.Controls.Add(this.txtBoxWoWClassicPathCN);
            this.Controls.Add(this.lblWoWClassicPathCN);
            this.Controls.Add(this.lblTipWoWClassicPath);
            this.Controls.Add(this.txtBoxWoWClassicPath);
            this.Controls.Add(this.lblWoWClassicPath);
            this.Controls.Add(this.lblTip1);
            this.Controls.Add(this.btnBrowseWoWRootPath);
            this.Controls.Add(this.lblWoWRootPath);
            this.Controls.Add(this.txtBoxWoWRootPath);
            this.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "《魔兽世界》怀旧服路径设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxWoWRootPath;
        private System.Windows.Forms.Label lblWoWRootPath;
        private System.Windows.Forms.Button btnBrowseWoWRootPath;
        private System.Windows.Forms.Label lblTip1;
        private System.Windows.Forms.Label lblWoWClassicPath;
        private System.Windows.Forms.TextBox txtBoxWoWClassicPath;
        private System.Windows.Forms.Label lblTipWoWClassicPath;
        private System.Windows.Forms.Label lblTipWoWClassicPathCN;
        private System.Windows.Forms.Button btnBrowseWoWClassicPathCN;
        private System.Windows.Forms.TextBox txtBoxWoWClassicPathCN;
        private System.Windows.Forms.Label lblWoWClassicPathCN;
        private System.Windows.Forms.Label lblTipWoWClassicPathTW;
        private System.Windows.Forms.Button btnBrowseWoWClassicPathTW;
        private System.Windows.Forms.TextBox txtBoxWoWClassicPathTW;
        private System.Windows.Forms.Label lblWoWClassicPathTW;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}