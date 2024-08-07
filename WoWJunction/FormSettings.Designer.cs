﻿namespace WoWJunction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.lblWoWRootPath = new System.Windows.Forms.Label();
            this.txtBoxWoWRootPath = new System.Windows.Forms.TextBox();
            this.btnBrowseWoWRootPath = new System.Windows.Forms.Button();
            this.lblTip1 = new System.Windows.Forms.Label();
            this.lblWoWClassicPath = new System.Windows.Forms.Label();
            this.txtBoxWoWClassicPath = new System.Windows.Forms.TextBox();
            this.lblTipWoWClassicPath = new System.Windows.Forms.Label();
            this.lblWoWClassicPathCN = new System.Windows.Forms.Label();
            this.txtBoxWoWClassicPathCN = new System.Windows.Forms.TextBox();
            this.btnBrowseWoWClassicPathCN = new System.Windows.Forms.Button();
            this.lblTipWoWClassicPathCN = new System.Windows.Forms.Label();
            this.lblWoWClassicPathTW = new System.Windows.Forms.Label();
            this.txtBoxWoWClassicPathTW = new System.Windows.Forms.TextBox();
            this.btnBrowseWoWClassicPathTW = new System.Windows.Forms.Button();
            this.lblTipWoWClassicPathTW = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDefaultValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblWoWRootPath
            //
            this.lblWoWRootPath.AutoSize = true;
            this.lblWoWRootPath.Location = new System.Drawing.Point(20, 19);
            this.lblWoWRootPath.Name = "lblWoWRootPath";
            this.lblWoWRootPath.Size = new System.Drawing.Size(98, 13);
            this.lblWoWRootPath.TabIndex = 0;
            this.lblWoWRootPath.Text = "魔兽世界路径：";
            //
            // txtBoxWoWRootPath
            //
            this.txtBoxWoWRootPath.Location = new System.Drawing.Point(23, 38);
            this.txtBoxWoWRootPath.Name = "txtBoxWoWRootPath";
            this.txtBoxWoWRootPath.Size = new System.Drawing.Size(456, 22);
            this.txtBoxWoWRootPath.TabIndex = 1;
            //
            // btnBrowseWoWRootPath
            //
            this.btnBrowseWoWRootPath.Location = new System.Drawing.Point(497, 33);
            this.btnBrowseWoWRootPath.Name = "btnBrowseWoWRootPath";
            this.btnBrowseWoWRootPath.Size = new System.Drawing.Size(72, 29);
            this.btnBrowseWoWRootPath.TabIndex = 2;
            this.btnBrowseWoWRootPath.Text = "浏览...";
            this.btnBrowseWoWRootPath.UseVisualStyleBackColor = true;
            this.btnBrowseWoWRootPath.Click += new System.EventHandler(this.btnBrowseWoWRootPath_Click);
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
            // btnDefaultValue
            //
            this.btnDefaultValue.Location = new System.Drawing.Point(214, 110);
            this.btnDefaultValue.Name = "btnDefaultValue";
            this.btnDefaultValue.Size = new System.Drawing.Size(128, 29);
            this.btnDefaultValue.TabIndex = 6;
            this.btnDefaultValue.Text = "恢复为默认值(&D)";
            this.btnDefaultValue.UseVisualStyleBackColor = true;
            this.btnDefaultValue.Click += new System.EventHandler(this.btnDefaultValue_Click);
            //
            // lblTipWoWClassicPath
            //
            this.lblTipWoWClassicPath.AutoSize = true;
            this.lblTipWoWClassicPath.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTipWoWClassicPath.Location = new System.Drawing.Point(23, 145);
            this.lblTipWoWClassicPath.Name = "lblTipWoWClassicPath";
            this.lblTipWoWClassicPath.Size = new System.Drawing.Size(332, 13);
            this.lblTipWoWClassicPath.TabIndex = 7;
            this.lblTipWoWClassicPath.Text = "默认值为 \"\\_classic_\"，相对路径，建议不要修改此值";
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
            // txtBoxWoWClassicPathCN
            //
            this.txtBoxWoWClassicPathCN.Location = new System.Drawing.Point(23, 194);
            this.txtBoxWoWClassicPathCN.Name = "txtBoxWoWClassicPathCN";
            this.txtBoxWoWClassicPathCN.Size = new System.Drawing.Size(456, 22);
            this.txtBoxWoWClassicPathCN.TabIndex = 9;
            //
            // btnBrowseWoWClassicPathCN
            //
            this.btnBrowseWoWClassicPathCN.Location = new System.Drawing.Point(497, 189);
            this.btnBrowseWoWClassicPathCN.Name = "btnBrowseWoWClassicPathCN";
            this.btnBrowseWoWClassicPathCN.Size = new System.Drawing.Size(72, 29);
            this.btnBrowseWoWClassicPathCN.TabIndex = 10;
            this.btnBrowseWoWClassicPathCN.Text = "浏览...";
            this.btnBrowseWoWClassicPathCN.UseVisualStyleBackColor = true;
            this.btnBrowseWoWClassicPathCN.Click += new System.EventHandler(this.btnBrowseWoWClassicPathCN_Click);
            //
            // lblTipWoWClassicPathCN
            //
            this.lblTipWoWClassicPathCN.AutoSize = true;
            this.lblTipWoWClassicPathCN.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTipWoWClassicPathCN.Location = new System.Drawing.Point(24, 224);
            this.lblTipWoWClassicPathCN.Name = "lblTipWoWClassicPathCN";
            this.lblTipWoWClassicPathCN.Size = new System.Drawing.Size(372, 13);
            this.lblTipWoWClassicPathCN.TabIndex = 11;
            this.lblTipWoWClassicPathCN.Text = "默认值为 \"\\_classic_cn\"，可使用绝对路径，推荐使用默认值";
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
            // txtBoxWoWClassicPathTW
            //
            this.txtBoxWoWClassicPathTW.Location = new System.Drawing.Point(23, 272);
            this.txtBoxWoWClassicPathTW.Name = "txtBoxWoWClassicPathTW";
            this.txtBoxWoWClassicPathTW.Size = new System.Drawing.Size(456, 22);
            this.txtBoxWoWClassicPathTW.TabIndex = 13;
            //
            // btnBrowseWoWClassicPathTW
            //
            this.btnBrowseWoWClassicPathTW.Location = new System.Drawing.Point(497, 267);
            this.btnBrowseWoWClassicPathTW.Name = "btnBrowseWoWClassicPathTW";
            this.btnBrowseWoWClassicPathTW.Size = new System.Drawing.Size(72, 29);
            this.btnBrowseWoWClassicPathTW.TabIndex = 14;
            this.btnBrowseWoWClassicPathTW.Text = "浏览...";
            this.btnBrowseWoWClassicPathTW.UseVisualStyleBackColor = true;
            this.btnBrowseWoWClassicPathTW.Click += new System.EventHandler(this.btnBrowseWoWClassicPathTW_Click);
            //
            // lblTipWoWClassicPathTW
            //
            this.lblTipWoWClassicPathTW.AutoSize = true;
            this.lblTipWoWClassicPathTW.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTipWoWClassicPathTW.Location = new System.Drawing.Point(24, 301);
            this.lblTipWoWClassicPathTW.Name = "lblTipWoWClassicPathTW";
            this.lblTipWoWClassicPathTW.Size = new System.Drawing.Size(372, 13);
            this.lblTipWoWClassicPathTW.TabIndex = 15;
            this.lblTipWoWClassicPathTW.Text = "默认值为 \"\\_classic_tw\"，可使用绝对路径，推荐使用默认值";
            //
            // btnApply
            //
            this.btnApply.Location = new System.Drawing.Point(196, 331);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(86, 29);
            this.btnApply.TabIndex = 16;
            this.btnApply.Text = "确定(&A)";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            //
            // btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(318, 331);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 29);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // FormSettings
            //
            this.AcceptButton = this.btnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(590, 375);

            this.Controls.Add(this.lblWoWRootPath);
            this.Controls.Add(this.txtBoxWoWRootPath);
            this.Controls.Add(this.btnBrowseWoWRootPath);
            this.Controls.Add(this.lblTip1);
            this.Controls.Add(this.lblWoWClassicPath);
            this.Controls.Add(this.txtBoxWoWClassicPath);
            this.Controls.Add(this.lblTipWoWClassicPath);
            this.Controls.Add(this.lblWoWClassicPathCN);
            this.Controls.Add(this.txtBoxWoWClassicPathCN);
            this.Controls.Add(this.btnBrowseWoWClassicPathCN);
            this.Controls.Add(this.lblTipWoWClassicPathCN);
            this.Controls.Add(this.lblWoWClassicPathTW);
            this.Controls.Add(this.txtBoxWoWClassicPathTW);
            this.Controls.Add(this.btnBrowseWoWClassicPathTW);
            this.Controls.Add(this.lblTipWoWClassicPathTW);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDefaultValue);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "《魔兽世界》怀旧服路径设置";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.Shown += new System.EventHandler(this.FormSettings_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label lblWoWRootPath;
        private System.Windows.Forms.TextBox txtBoxWoWRootPath;
        private System.Windows.Forms.Button btnBrowseWoWRootPath;
        private System.Windows.Forms.Label lblTip1;
        private System.Windows.Forms.Label lblWoWClassicPath;
        private System.Windows.Forms.TextBox txtBoxWoWClassicPath;
        private System.Windows.Forms.Label lblTipWoWClassicPath;
        private System.Windows.Forms.Label lblWoWClassicPathCN;
        private System.Windows.Forms.TextBox txtBoxWoWClassicPathCN;
        private System.Windows.Forms.Button btnBrowseWoWClassicPathCN;
        private System.Windows.Forms.Label lblTipWoWClassicPathCN;
        private System.Windows.Forms.Label lblWoWClassicPathTW;
        private System.Windows.Forms.TextBox txtBoxWoWClassicPathTW;
        private System.Windows.Forms.Button btnBrowseWoWClassicPathTW;
        private System.Windows.Forms.Label lblTipWoWClassicPathTW;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDefaultValue;
    }
}