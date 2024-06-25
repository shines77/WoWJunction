﻿using System;
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
    public struct ValidateResult
    {
        public bool success { get; set; }
        public int err_no { get; set; }
    }

    public partial class FormSettings : Form
    {
        // ValidateError

        // wow_root_path
        public const int ERR_WOW_ROOT_PATH_IS_NOT_A_ABSOLUTE_PATH = -1;
        public const int ERR_WOW_ROOT_PATH_IS_NOT_A_DIRECTORY = -2;
        public const int ERR_WOW_ROOT_PATH_NO_EXISTS = -3;
        public const int ERR_WOW_ROOT_PATH_IS_EMPTY = -4;

        // wow_classic_path
        public const int ERR_WOW_CLASSIC_PATH_IS_NOT_A_RELATIVE_PATH = -11;
        public const int ERR_WOW_CLASSIC_PATH_MUST_START_WITH_PATH_SEPARATOR = -12;
        public const int ERR_WOW_CLASSIC_PATH_IS_EMPTY = -13;

        // wow_classic_path_cn
        public const int ERR_WOW_CLASSIC_PATH_CN_MUST_START_WITH_PATH_SEPARATOR = -21;
        public const int ERR_WOW_CLASSIC_PATH_CN_NO_EXISTS = -22;
        public const int ERR_WOW_CLASSIC_PATH_CN_IS_EMPTY = -23;

        // wow_classic_path_tw
        public const int ERR_WOW_CLASSIC_PATH_TW_MUST_START_WITH_PATH_SEPARATOR = -31;
        public const int ERR_WOW_CLASSIC_PATH_TW_NO_EXISTS = -32;
        public const int ERR_WOW_CLASSIC_PATH_TW_IS_EMPTY = -33;

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

        private string FormatValidateError(int err_no)
        {
            switch (err_no) {
                // wow_root_path
                case ERR_WOW_ROOT_PATH_IS_NOT_A_ABSOLUTE_PATH:
                    return "《魔兽世界》主目录必须是一个绝对路径。";
                case ERR_WOW_ROOT_PATH_IS_NOT_A_DIRECTORY:
                    return "《魔兽世界》主目录必须是一个文件夹，而不是文件。";
                case ERR_WOW_ROOT_PATH_NO_EXISTS:
                    return "指定的《魔兽世界》主目录不存在或者不是文件夹，请检查设置。";
                case ERR_WOW_ROOT_PATH_IS_EMPTY:
                    return "《魔兽世界》主目录不能为空！";

                // wow_classic_path
                case ERR_WOW_CLASSIC_PATH_IS_NOT_A_RELATIVE_PATH:
                    return "《魔兽世界》怀旧服目录必须是一个相对路径，不能使用绝对路径。";
                case ERR_WOW_CLASSIC_PATH_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服目录名必须以 '\\' 或 '/' 字符开头。";
                case ERR_WOW_CLASSIC_PATH_IS_EMPTY:
                    return "《魔兽世界》怀旧服目录名不能为空！";

                // wow_classic_path_cn
                case ERR_WOW_CLASSIC_PATH_CN_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服（国服）目录为相对路径时，必须以 '\\' 或 '/' 字符开头。";
                case ERR_WOW_CLASSIC_PATH_CN_NO_EXISTS:
                    return "《魔兽世界》怀旧服（国服）目录不存在，请检查设置。";
                case ERR_WOW_CLASSIC_PATH_CN_IS_EMPTY:
                    return "《魔兽世界》怀旧服（国服）目录名不能为空！";

                // wow_classic_path_tw
                case ERR_WOW_CLASSIC_PATH_TW_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服（亚服）目录为相对路径时，必须以 '\\' 或 '/' 字符开头。";
                case ERR_WOW_CLASSIC_PATH_TW_NO_EXISTS:
                    return "《魔兽世界》怀旧服（亚服）目录不存在，请检查设置。";
                case ERR_WOW_CLASSIC_PATH_TW_IS_EMPTY:
                    return "《魔兽世界》怀旧服（亚服）目录名不能为空！";

                default:
                    return "未知错误，请检查设置。";
            }
        }

        private ValidateResult ValidateUIData(WoWConfig outWoWConfig)
        {
            // 先把输入数据的前后空格去掉
            TrimUIData();

            ValidateResult result = new ValidateResult();

            // wow_root_path: 必须是一个绝对路径, 且必须是一个目录, 且必须存在.
            string wowRootPath = txtBoxWoWRootPath.Text;
            if (String.IsNullOrEmpty(wowRootPath)) {
                result.err_no = ERR_WOW_ROOT_PATH_IS_EMPTY;
                result.success = false;
                return result;
            }
            // 转化为完整的路径(移除相对路径标识)
            wowRootPath = Path.GetFullPath(wowRootPath);
            // 不带目录分隔符的完整路径
            string wowRootPathNoSep = PathUtils.RemoveFullPathTailSeparator(wowRootPath);
            // 带目录分隔符的完整路径
            string wowRootFullPathWithSep = PathUtils.NormalizeFullPathWithSep(wowRootPath);
            string wowRootDirName = Path.GetDirectoryName(wowRootFullPathWithSep);
            if (Path.IsPathRooted(wowRootPath)) {
                if (wowRootDirName == wowRootPathNoSep) {
                    if (!Directory.Exists(wowRootPath)) {
                        if (File.Exists(wowRootPath))
                            result.err_no = ERR_WOW_ROOT_PATH_IS_NOT_A_DIRECTORY;
                        else
                            result.err_no = ERR_WOW_ROOT_PATH_NO_EXISTS;
                    }
                } else {
                    result.err_no = ERR_WOW_ROOT_PATH_IS_NOT_A_DIRECTORY;
                }
            } else {
                result.err_no = ERR_WOW_ROOT_PATH_IS_NOT_A_ABSOLUTE_PATH;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // 取不带 Separator 的完全路径
            outWoWConfig.folders.wow_root_path = wowRootPathNoSep;

            // wow_classic_path: 必须是一个相对路径, 且以"\"开头, 可以不存在.
            string wowClassicPath = txtBoxWoWClassicPath.Text;
            if (String.IsNullOrEmpty(wowClassicPath)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_IS_EMPTY;
                result.success = false;
                return result;
            }
            if (PathUtils.IsRelativePath(wowClassicPath)) {
                if (!(wowClassicPath.StartsWith("\\") | wowClassicPath.StartsWith("/"))) {
                    result.err_no = ERR_WOW_CLASSIC_PATH_MUST_START_WITH_PATH_SEPARATOR;
                }
            }
            else {
                result.err_no = ERR_WOW_CLASSIC_PATH_IS_NOT_A_RELATIVE_PATH;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // 保存合并后的 _classic_ 目录
            outWoWConfig.folders.wow_classic_path = PathUtils.CombinePath(wowRootDirName, wowClassicPath);

            // wow_classic_path_cn: 值为相对路径时, 必须以"\"开头, 该相对路径或绝对路径必须存在.
            string wowClassicPathCN = txtBoxWoWClassicPathCN.Text;
            if (String.IsNullOrEmpty(wowClassicPathCN)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_CN_IS_EMPTY;
                result.success = false;
                return result;
            }
            if (PathUtils.IsRelativePath(wowClassicPathCN)) {
                if (!(wowClassicPathCN.StartsWith("\\") | wowClassicPathCN.StartsWith("/"))) {
                    result.err_no = ERR_WOW_CLASSIC_PATH_CN_MUST_START_WITH_PATH_SEPARATOR;
                } else {
                    // 拼接相对路径
                    wowClassicPathCN = PathUtils.CombinePath(wowRootDirName, wowClassicPathCN);
                }
            }
            if (!Directory.Exists(wowClassicPathCN)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_CN_NO_EXISTS;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // 保存合并后的 _classic_cn 目录
            outWoWConfig.folders.wow_classic_path_cn = wowClassicPathCN;

            // wow_classic_path_cn: 值为相对路径时, 必须以"\"开头, 该相对路径或绝对路径必须存在.
            string wowClassicPathTW = txtBoxWoWClassicPathTW.Text;
            if (String.IsNullOrEmpty(wowClassicPathTW)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_TW_IS_EMPTY;
                result.success = false;
                return result;
            }
            if (PathUtils.IsRelativePath(wowClassicPathTW)) {
                if (!(wowClassicPathTW.StartsWith("\\") | wowClassicPathTW.StartsWith("/"))) {
                    result.err_no = ERR_WOW_CLASSIC_PATH_TW_MUST_START_WITH_PATH_SEPARATOR;
                }
                else {
                    // 拼接相对路径
                    wowClassicPathTW = PathUtils.CombinePath(wowRootDirName, wowClassicPathTW);
                }
            }
            if (!Directory.Exists(wowClassicPathTW)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_TW_NO_EXISTS;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // 保存合并后的 _classic_tw 目录
            outWoWConfig.folders.wow_classic_path_tw = wowClassicPathTW;

            result.success = true;
            return result;
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
            if (openFolderDialog.ShowSelectDialog(this.Handle)) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWRootPath.Text = selectFolder;
            }
        }

        private void btnBrowseWoWClassicPathCN_Click(object sender, EventArgs e)
        {
            var openFolderDialog = new Utils.FolderSelectDialog
            {
                Title = "请选择《魔兽世界》怀旧服（国服）的路径：",
                InitialDirectory = Environment.CurrentDirectory
            };
            if (openFolderDialog.ShowSelectDialog(this.Handle)) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWClassicPathCN.Text = selectFolder;
            }
        }

        private void btnBrowseWoWClassicPathTW_Click(object sender, EventArgs e)
        {
            var openFolderDialog = new Utils.FolderSelectDialog
            {
                Title = "请选择《魔兽世界》怀旧服（亚服）的路径：",
                InitialDirectory = Environment.CurrentDirectory
            };
            if (openFolderDialog.ShowSelectDialog(this.Handle)) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWClassicPathTW.Text = selectFolder;
            }
        }

        private void btnDefaultValue_Click(object sender, EventArgs e)
        {
            RestoreToDefaultValue();
        }

        private void ApplyCurrentSettings()
        {
            WoWConfig outWoWConfig = new WoWConfig();
            ValidateResult result = ValidateUIData(outWoWConfig);
            if (!result.success) {
                string message = FormatValidateError(result.err_no);
                MessageBox.Show(message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                UIDataExchange();
                wowConfig = outWoWConfig;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
