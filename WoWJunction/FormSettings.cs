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

        // wow_classic_path
        public const int ERR_WOW_CLASSIC_PATH_IS_NOT_A_RELATIVE_PATH = -11;
        public const int ERR_WOW_CLASSIC_PATH_MUST_START_WITH_PATH_SEPARATOR = -12;

        // wow_classic_path_cn
        public const int ERR_WOW_CLASSIC_CN_PATH_MUST_START_WITH_PATH_SEPARATOR = -21;
        public const int ERR_WOW_CLASSIC_CN_PATH_NO_EXISTS = -22;

        // wow_classic_path_tw
        public const int ERR_WOW_CLASSIC_TW_PATH_MUST_START_WITH_PATH_SEPARATOR = -31;
        public const int ERR_WOW_CLASSIC_TW_PATH_NO_EXISTS = -32;

        private FormMain parent = null;
        private WoWConfig wowConfig = new WoWConfig();

        public FormSettings(FormMain parent)
        {
            InitializeComponent();
            this.parent = parent;
            wowConfig = parent.GetWoWConfig();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LoadUIData();
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            btnBrowseWoWRootPath.Focus();
        }

        private void LoadUIData()
        {
            txtBoxWoWRootPath.Text = wowConfig.folders.wow_root_path;
            txtBoxWoWClassicPath.Text = wowConfig.folders.wow_classic_path;
            txtBoxWoWClassicPathCN.Text = wowConfig.folders.wow_classic_path_cn;
            txtBoxWoWClassicPathTW.Text = wowConfig.folders.wow_classic_path_tw;
        }

        private bool UIDataExchange()
        {
            wowConfig.folders.wow_root_path = txtBoxWoWRootPath.Text.Trim();
            wowConfig.folders.wow_classic_path = txtBoxWoWClassicPath.Text.Trim();
            wowConfig.folders.wow_classic_path_cn = txtBoxWoWClassicPathCN.Text.Trim();
            wowConfig.folders.wow_classic_path_tw = txtBoxWoWClassicPathTW.Text.Trim();
            return false;
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

                // wow_classic_path
                case ERR_WOW_CLASSIC_PATH_IS_NOT_A_RELATIVE_PATH:
                    return "《魔兽世界》怀旧服目录必须是一个相对路径，不能使用绝对路径。";
                case ERR_WOW_CLASSIC_PATH_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服目录名必须以 '\\' 或 '/' 字符开头。";

                // wow_classic_path_cn
                case ERR_WOW_CLASSIC_CN_PATH_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服（国服）目录为相对路径时，必须以 '\\' 或 '/' 字符开头。";
                case ERR_WOW_CLASSIC_CN_PATH_NO_EXISTS:
                    return "《魔兽世界》怀旧服（国服）目录不存在，请检查设置。";

                // wow_classic_path_tw
                case ERR_WOW_CLASSIC_TW_PATH_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服（亚服）目录为相对路径时，必须以 '\\' 或 '/' 字符开头。";
                case ERR_WOW_CLASSIC_TW_PATH_NO_EXISTS:
                    return "《魔兽世界》怀旧服（亚服）目录不存在，请检查设置。";

                default:
                    return "未知错误，请检查设置。";
            }
        }

        private ValidateResult ValidateUIData()
        {
            ValidateResult result = new ValidateResult();

            // wow_root_path: 必须是一个绝对路径, 且必须是一个目录, 且必须存在.
            string wowRootPath = txtBoxWoWRootPath.Text.Trim();
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

            // wow_classic_path: 必须是一个相对路径, 且以"\"开头, 可以不存在.
            string wowClassicPath = txtBoxWoWClassicPath.Text.Trim();
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

            // wow_classic_path_cn: 值为相对路径时, 必须以"\"开头, 该相对路径或绝对路径必须存在.
            string wowClassicPathCN = txtBoxWoWClassicPathCN.Text.Trim();
            if (PathUtils.IsRelativePath(wowClassicPathCN)) {
                if (!(wowClassicPathCN.StartsWith("\\") | wowClassicPathCN.StartsWith("/"))) {
                    result.err_no = ERR_WOW_CLASSIC_CN_PATH_MUST_START_WITH_PATH_SEPARATOR;
                } else {
                    // 拼接相对路径
                    wowClassicPathCN = PathUtils.CombinePath(wowRootDirName, wowClassicPathCN);
                }
            }
            if (!Directory.Exists(wowClassicPathCN)) {
                result.err_no = ERR_WOW_CLASSIC_CN_PATH_NO_EXISTS;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // wow_classic_path_cn: 值为相对路径时, 必须以"\"开头, 该相对路径或绝对路径必须存在.
            string wowClassicPathTW = txtBoxWoWClassicPathTW.Text.Trim();
            if (PathUtils.IsRelativePath(wowClassicPathTW)) {
                if (!(wowClassicPathTW.StartsWith("\\") | wowClassicPathTW.StartsWith("/"))) {
                    result.err_no = ERR_WOW_CLASSIC_TW_PATH_MUST_START_WITH_PATH_SEPARATOR;
                }
                else {
                    // 拼接相对路径
                    wowClassicPathTW = PathUtils.CombinePath(wowRootDirName, wowClassicPathTW);
                }
            }
            if (!Directory.Exists(wowClassicPathTW)) {
                result.err_no = ERR_WOW_CLASSIC_TW_PATH_NO_EXISTS;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

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

            var openFolderDialog = new Utils.FolderSelectDialog {
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

        private void btnApply_Click(object sender, EventArgs e)
        {
            ValidateResult result = ValidateUIData();
            if (!result.success) {
                string message = FormatValidateError(result.err_no);
                MessageBox.Show(message, "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
