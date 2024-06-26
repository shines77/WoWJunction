using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WoWJunction
{
    public partial class FormSettings : Form
    {
        private FormMain parent = null;
        private WoWConfig wowConfig = new WoWConfig();
        private WoWConfig wowConfigToFile = new WoWConfig();

        public FormSettings(FormMain parent)
        {
            InitializeComponent();
            this.parent = parent;
            wowConfig = parent.GetWoWConfig();
            wowConfigToFile = parent.GetWoWConfigFromFile();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadUIData();
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            btnBrowseWoWRootPath.Focus();
        }

        public WoWConfig GetWoWConfig()
        {
            return wowConfig;
        }

        public WoWConfig GetWoWConfigToFile()
        {
            return wowConfigToFile;
        }

        private void RestoreToDefaultValue()
        {
            txtBoxWoWClassicPath.Text = WoWConfig.DefaultWoWClassicPath;
            txtBoxWoWClassicPathCN.Text = WoWConfig.DefaultWoWClassicPathCN;
            txtBoxWoWClassicPathTW.Text = WoWConfig.DefaultWoWClassicPathTW;
        }

        private void LoadUIData()
        {
            txtBoxWoWRootPath.Text = wowConfigToFile.folders.wow_root_path;
            txtBoxWoWClassicPath.Text = wowConfigToFile.folders.wow_classic_path;
            txtBoxWoWClassicPathCN.Text = wowConfigToFile.folders.wow_classic_path_cn;
            txtBoxWoWClassicPathTW.Text = wowConfigToFile.folders.wow_classic_path_tw;
        }

        private bool UIDataExchange()
        {
            wowConfigToFile.folders.wow_root_path = txtBoxWoWRootPath.Text.Trim();
            wowConfigToFile.folders.wow_classic_path = txtBoxWoWClassicPath.Text.Trim();
            wowConfigToFile.folders.wow_classic_path_cn = txtBoxWoWClassicPathCN.Text.Trim();
            wowConfigToFile.folders.wow_classic_path_tw = txtBoxWoWClassicPathTW.Text.Trim();
            return false;
        }

        private void TrimUIData()
        {
            txtBoxWoWRootPath.Text = txtBoxWoWRootPath.Text.Trim();
            txtBoxWoWClassicPath.Text = txtBoxWoWClassicPath.Text.Trim();
            txtBoxWoWClassicPathCN.Text = txtBoxWoWClassicPathCN.Text.Trim();
            txtBoxWoWClassicPathTW.Text = txtBoxWoWClassicPathTW.Text.Trim();
        }

        private bool HasAnyConfigChanged()
        {
            bool changed = false;
            if (wowConfigToFile.folders.wow_root_path != txtBoxWoWRootPath.Text)
                return true;
            if (wowConfigToFile.folders.wow_classic_path != txtBoxWoWClassicPath.Text)
                return true;
            if (wowConfigToFile.folders.wow_classic_path_cn != txtBoxWoWClassicPathCN.Text)
                return true;
            if (wowConfigToFile.folders.wow_classic_path_tw != txtBoxWoWClassicPathTW.Text)
                return true;
            return changed;
        }

        private ValidateResult ValidateUIData(WoWConfig outWoWConfig)
        {
            // 先把输入数据的前后空格去掉
            TrimUIData();

            WoWConfig uiWoWConfig = new WoWConfig();
            uiWoWConfig.folders.wow_root_path = txtBoxWoWRootPath.Text;
            uiWoWConfig.folders.wow_classic_path = txtBoxWoWClassicPath.Text;
            uiWoWConfig.folders.wow_classic_path_cn = txtBoxWoWClassicPathCN.Text;
            uiWoWConfig.folders.wow_classic_path_tw = txtBoxWoWClassicPathTW.Text;

            return WoWConfigManager.ValidateConfig(uiWoWConfig, outWoWConfig);
        }

        private void ApplyCurrentSettings()
        {
            WoWConfig outWoWConfig = new WoWConfig();
            ValidateResult result = ValidateUIData(outWoWConfig);
            if (!result.success) {
                string message = WoWConfigManager.FormatValidateError(result.err_no);
                MessageBox.Show(message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                UIDataExchange();
                wowConfig = outWoWConfig;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnBrowseWoWRootPath_Click(object sender, EventArgs e)
        {
            // WinXP样式的目录选择框, 没那么好用
            /*
            string initialDirectory = Environment.CurrentDirectory;
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "请选择《魔兽世界》根目录的路径：";
            folderBrowser.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowser.SelectedPath = initialDirectory;
            if (folderBrowser.ShowDialog() == DialogResult.OK) {
                txtBoxWoWRootPath.Text = folderBrowser.SelectedPath;
            }
            //*/

            //
            // 需要使用 NuGet 安装以下依赖包, 也不够方便:
            // Microsoft-WindowsAPICodePack-Core, >= Version1.1.4
            // Microsoft-WindowsAPICodePack-Shell, >= Version1.1.4
            //
            // 使用: using Microsoft.WindowsAPICodePack.Dialogs;
            //
            /*
            CommonOpenFileDialog openFolderDialog = new CommonOpenFileDialog
            {
                Title = "请选择《魔兽世界》根目录的路径：",
                IsFolderPicker = true,
                InitialDirectory = Environment.SpecialFolder.Desktop.ToString()
            };
            if (openFolderDialog.ShowDialog(this.Handle) == CommonFileDialogResult.Ok) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWRootPath.Text = selectFolder;
            }
            //*/

            var openFolderDialog = new Utils.FolderSelectDialog
            {
                Title = "请选择《魔兽世界》根目录的路径：",
                InitialDirectory = Environment.CurrentDirectory
            };

            TrimUIData();
            bool folderIsExists = false;
            string wow_root_path = txtBoxWoWRootPath.Text;
            if (!string.IsNullOrEmpty(wow_root_path)) {
                if (Directory.Exists(wow_root_path)) {
                    openFolderDialog.InitialDirectory = wow_root_path;
                    folderIsExists = true;
                }
            }
            if (!folderIsExists) {
                if (!string.IsNullOrEmpty(wowConfig.folders.wow_root_path)) {
                    if (Directory.Exists(wowConfig.folders.wow_root_path)) {
                        openFolderDialog.InitialDirectory = wowConfig.folders.wow_root_path;
                    }
                }
            }
            if (openFolderDialog.ShowSelectDialog(this.Handle)) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWRootPath.Text = selectFolder.Trim();
            }
        }

        private void btnBrowseWoWClassicPathCN_Click(object sender, EventArgs e)
        {
            var openFolderDialog = new Utils.FolderSelectDialog
            {
                Title = "请选择《魔兽世界》怀旧服（国服）的路径：",
                InitialDirectory = Environment.CurrentDirectory
            };

            TrimUIData();
            string wow_classic_path_cn = PathUtils.CombinePath(txtBoxWoWRootPath.Text, txtBoxWoWClassicPathCN.Text);
            if (!string.IsNullOrEmpty(wow_classic_path_cn)) {
                if (Directory.Exists(wow_classic_path_cn)) {
                    openFolderDialog.InitialDirectory = wow_classic_path_cn;
                }
                else if (Directory.Exists(txtBoxWoWRootPath.Text)) {
                    openFolderDialog.InitialDirectory = txtBoxWoWRootPath.Text;
                }
                else if (Directory.Exists(wowConfig.folders.wow_root_path)) {
                    openFolderDialog.InitialDirectory = wowConfig.folders.wow_root_path;
                }
            }
            if (openFolderDialog.ShowSelectDialog(this.Handle)) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWClassicPathCN.Text = selectFolder.Trim();
            }
        }

        private void btnBrowseWoWClassicPathTW_Click(object sender, EventArgs e)
        {
            var openFolderDialog = new Utils.FolderSelectDialog
            {
                Title = "请选择《魔兽世界》怀旧服（亚服）的路径：",
                InitialDirectory = Environment.CurrentDirectory
            };

            TrimUIData();
            string wow_classic_path_tw = PathUtils.CombinePath(txtBoxWoWRootPath.Text, txtBoxWoWClassicPathTW.Text);
            if (!string.IsNullOrEmpty(wow_classic_path_tw)) {
                if (Directory.Exists(wow_classic_path_tw)) {
                    openFolderDialog.InitialDirectory = wow_classic_path_tw;
                }
                else if (Directory.Exists(txtBoxWoWRootPath.Text)) {
                    openFolderDialog.InitialDirectory = txtBoxWoWRootPath.Text;
                }
                else if (Directory.Exists(wowConfig.folders.wow_root_path)) {
                    openFolderDialog.InitialDirectory = wowConfig.folders.wow_root_path;
                }
            }
            if (openFolderDialog.ShowSelectDialog(this.Handle)) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWClassicPathTW.Text = selectFolder.Trim();
            }
        }

        private void btnDefaultValue_Click(object sender, EventArgs e)
        {
            RestoreToDefaultValue();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            TrimUIData();
            if (HasAnyConfigChanged()) {
                ApplyCurrentSettings();
            } else {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TrimUIData();
            if (HasAnyConfigChanged()) {
                var result = MessageBox.Show("设置已发生改变，是否要保存当前设置？", "提示...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    ApplyCurrentSettings();
                    return;
                }
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
