using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace WoWJunction
{
    public partial class FormSettings : Form
    {
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
            txtBoxWoWRootPath.Text = wowConfig.folders.wow_root_path;
            txtBoxWoWClassicPath.Text = wowConfig.folders.wow_classic_path;
            txtBoxWoWClassicPathCN.Text = wowConfig.folders.wow_classic_path_cn;
            txtBoxWoWClassicPathTW.Text = wowConfig.folders.wow_classic_path_tw;
        }

        private void FormSettings_Shown(object sender, EventArgs e)
        {
            btnBrowseWoWRootPath.Focus();
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
                Title = "请选择《魔兽世界》怀旧服（国服）的路径：",
                IsFolderPicker = true,
                InitialDirectory = Environment.SpecialFolder.Desktop.ToString()
            };
            if (openFolderDialog.ShowDialog(this.Handle) == CommonFileDialogResult.Ok) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWClassicPathCN.Text = selectFolder;
            }
            //*/
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
                Title = "请选择《魔兽世界》怀旧服（亚服）的路径：",
                IsFolderPicker = true,
                InitialDirectory = Environment.SpecialFolder.Desktop.ToString()
            };
            if (openFolderDialog.ShowDialog(this.Handle) == CommonFileDialogResult.Ok) {
                var selectFolder = openFolderDialog.FileName;
                txtBoxWoWClassicPathTW.Text = selectFolder;
            }
            //*/

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
    }
}
