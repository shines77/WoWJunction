#define USE_TRY
#undef USE_TRY

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace WoWJunction
{
    public partial class FormMain : Form
    {
        enum XmlFileStatus : int
        {
            Unknown,
            FileNotExist,
            OK,
            Error
        };

        public static string appVersion = "1.0.1";
        public static string App_Release_URL = @"https://gitee.com/shines77/WoWJunction/releases/tag/1.0";

        public static string NGA_BBS_Topic_URL = @"https://bbs.nga.cn/read.php?tid=40706494";

        public static string Gitee_Repository_URL = @"https://gitee.com/shines77/WoWJunction";
        public static string GitHub_Repository_URL = @"https://github.com/shines77/WoWJunction";

        public static string Author_Git_URL = @"https://gitee.com/shines77";

        private const string FORM_CAPTION = "WoWJunction";
        private const string XML_CONFIG_FILENAME = "WoWJunction.exe.config.xml";
        private const string XML_CONFIG_ROOT = ""; // "configuration";

        private volatile bool formUIInitialized = false;
        private volatile bool formForcedClosing = false;
        private XmlFileStatus xmlConfigFileStatus = XmlFileStatus.Unknown;
        private ValidateResult xmlValidateResult = new ValidateResult();
        private volatile bool hasMountException = true;
        private WoWConfig wowConfig = new WoWConfig();
        private WoWConfig wowConfigFromFile = new WoWConfig();

        private SymLinkChecker symLinkChecker = null; 

        public FormMain()
        {
            InitializeComponent();
            if (symLinkChecker == null) {
                symLinkChecker = new SymLinkChecker(this);
            }
        }

        public WoWConfig GetWoWConfig()
        {
            return wowConfig;
        }

        public WoWConfig GetWoWConfigFromFile()
        {
            return wowConfigFromFile;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "《魔兽世界》怀旧服（国服/亚服）切换器 v" + appVersion;
            toolStripVersionLabel.Text = "版本：" + appVersion;

            bool readOK = ReadConfigFromXml();

            // 检查当前的绑定状态
            symLinkChecker.CheckSymLink(wowConfig.folders.wow_classic_path);
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            UpdateMountStatus();

            UpdateMinimizeToTaskbarWhenExiting();

            if (xmlConfigFileStatus == XmlFileStatus.OK) {
                if (!xmlValidateResult.success && xmlValidateResult.err_no == WoWConfigManager.ERR_WOW_ROOT_PATH_IS_EMPTY) {
                    MessageBox.Show(this, "您尚未设置《魔兽世界》的相关路径！", FORM_CAPTION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(xmlConfigFileStatus == XmlFileStatus.Error) {
                MessageBox.Show(this, "您的配置文件有错误，请重新配置《魔兽世界》的相关路径！", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (xmlConfigFileStatus == XmlFileStatus.FileNotExist) {
                //MessageBox.Show(this, "您是第一次运行该程序，请先设置《魔兽世界》的主目录！", FORM_CAPTION,
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            formUIInitialized = true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!formForcedClosing) {
                if (wowConfig.minimize_to_taskbar_when_exiting) {
                    // 窗体关闭原因为: 单击" 关闭" 按钮 或 Alt+F4
                    if (e.CloseReason == CloseReason.UserClosing) {
                        e.Cancel = true;

                        this.WindowState = FormWindowState.Minimized;
                        notifyIcon.Visible = true;
                        this.Hide();
                        return;
                    }
                }
            }

            if (xmlConfigFileStatus == XmlFileStatus.FileNotExist) {
                SaveConfigToXml();
            }
        }

        private void UpdateMinimizeToTaskbarWhenExiting()
        {
            if (wowConfig.minimize_to_taskbar_when_exiting) {
                chkBoxMinimizeToTaskbarWhenExiting.Checked = true;
            } else {
                chkBoxMinimizeToTaskbarWhenExiting.Checked = false;
            }

            notifyIcon.Visible = wowConfig.minimize_to_taskbar_when_exiting;
        }

        private void UpdateMountStatus()
        {
            // 检查当前的绑定状态
            symLinkChecker.CheckSymLink(wowConfig.folders.wow_classic_path);

            UpdateMountLinkStatus();
            UpdateMountLinkDetailStatus();
            UpdateWoWVersion();
            UpdateSwitchToStatus();
        }

        private void UpdateMountLinkStatus()
        {
            string linkToPath = symLinkChecker.GetLinkToPath();
            LinkStatus linkStatus = symLinkChecker.GetLinkStatus();

            if (linkToPath != null && linkStatus == LinkStatus.Linked) {
                lnkLinkToSource.Text = symLinkChecker.GetSourceName();
                lnkLinkToTarget.LinkColor = Color.Blue;
                lnkLinkToTarget.ActiveLinkColor = Color.Red;
                lnkLinkToTarget.Text = symLinkChecker.GetTargetName();
            }
            else {
                lnkLinkToSource.Text = symLinkChecker.GetSourceName();
                lnkLinkToTarget.LinkColor = Color.Red;
                lnkLinkToTarget.ActiveLinkColor = Color.Orange;
                lnkLinkToTarget.Text = symLinkChecker.GetSimpleLinkErrorInfo();
            }

            const int paddingX = 6;
            int sourceWidth = lnkLinkToSource.Width;
            int linkToWidth = lblLinkTo.Width;

            lnkLinkToSource.Left = lblLinkTo.Left - sourceWidth - paddingX;
            lnkLinkToTarget.Left = lblLinkTo.Right + paddingX;
        }

        private void UpdateMountLinkDetailStatus()
        {
            string linkToPath = symLinkChecker.GetLinkToPath();
            LinkStatus linkStatus = symLinkChecker.GetLinkStatus();

            txtBoxMountFrom.Text = wowConfig.folders.wow_classic_path;
            if (linkToPath != null && linkStatus == LinkStatus.Linked) {
                txtBoxMountTo.ForeColor = Color.Black;
                txtBoxMountTo.Text = linkToPath;
            }
            else {
                txtBoxMountTo.ForeColor = Color.Red;
                txtBoxMountTo.Text = "错误：" + symLinkChecker.GetLinkErrorInfo();
            }
        }

        private void UpdateWoWVersion()
        {
            //
        }

        public SwitchStatus CheckSwitchStatus(string linkToPath)
        {
            SwitchStatus switchStatus = SwitchStatus.Error;
            if (!String.IsNullOrEmpty(linkToPath)) {
                linkToPath.Trim();
                if (!String.IsNullOrEmpty(linkToPath)) {
                    if (linkToPath == wowConfig.folders.wow_classic_path_cn)
                        switchStatus = SwitchStatus.SwitchToCN;
                    else if (linkToPath == wowConfig.folders.wow_classic_path_tw)
                        switchStatus = SwitchStatus.SwitchToTW;
                    else
                        switchStatus = SwitchStatus.Unknown;
                }
            }
            return switchStatus;
        }

        private void UpdateSwitchToStatus()
        {
            SwitchStatus switchStatus = symLinkChecker.GetSwitchStatus();
            if (switchStatus == SwitchStatus.SwitchToCN) {
                tdBtnSwitchToCN.Visible = true;
                tdBtnSwitchToTW.Visible = false;
                btnSwitchToCN.Focus();
            }
            else if (switchStatus == SwitchStatus.SwitchToTW) {
                tdBtnSwitchToCN.Visible = false;
                tdBtnSwitchToTW.Visible = true;
                btnSwitchToTW.Focus();
            }
            else {
                tdBtnSwitchToCN.Visible = false;
                tdBtnSwitchToTW.Visible = false;
            }
        }

        private string ReadInstallPathFromRegistry()
        {
            string wowInstallPath = string.Empty;
            try {
                using (RegistryKey rootKey = Registry.LocalMachine) {
                    if (rootKey != null) {
                        using (RegistryKey subKey = rootKey.OpenSubKey(@"Software\WOW6432Node\Blizzard Entertainment\World of Warcraft")) {
                            if (subKey != null) {
                                object objInstallPath = subKey.GetValue("InstallPath", null);
                                if (objInstallPath != null) {
                                    wowInstallPath = objInstallPath.ToString();
                                }
                                subKey.Close();
                            }
                        }
                        if (string.IsNullOrEmpty(wowInstallPath)) {
                            using (RegistryKey subKey2 = rootKey.OpenSubKey(@"Software\Blizzard Entertainment\World of Warcraft")) {
                                if (subKey2 != null) {
                                    object objInstallPath = subKey2.GetValue("InstallPath", null);
                                    if (objInstallPath != null) {
                                        wowInstallPath = objInstallPath.ToString();
                                    }
                                    subKey2.Close();
                                }
                            }
                        }
                        rootKey.Close();
                    }
                }
            }
            catch (Exception ex) {
                //
            }
            return wowInstallPath;
        }

        private string ScanWoWRootPathFromRegistry()
        {
            string wowRootPath = "";
            string wowInstallPath = ReadInstallPathFromRegistry();
            if (!String.IsNullOrEmpty(wowInstallPath)) {
                wowRootPath = PathUtils.ExtractWoWRootPath(wowInstallPath);
            }
            return wowRootPath;
        }

        public bool ReadConfigFromXml()
        {
            bool readSuccess = false;
            xmlConfigFileStatus = XmlFileStatus.Unknown;
            string strAppPath = Path.GetDirectoryName(Application.ExecutablePath);
            string xmlFile = Path.Combine(strAppPath, XML_CONFIG_FILENAME);
            if (File.Exists(xmlFile)) {
                xmlConfigFileStatus = XmlFileStatus.Error;
                //MessageBox.Show(this, $"xmlFile = \"{xmlFile}\"", frmCaption,
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                try {
                    WoWConfig xmlWoWConfig = XmlHelper.LoadFromXML<WoWConfig>(xmlFile, XML_CONFIG_ROOT);
                    if (xmlWoWConfig != null) {
                        wowConfigFromFile = xmlWoWConfig.TrimConfig();
                        xmlConfigFileStatus = XmlFileStatus.OK;

                        WoWConfig outWoWConfig = new WoWConfig();
                        var result = WoWConfigManager.ValidateConfig(xmlWoWConfig, outWoWConfig, false);
                        if (result.success && result.err_no == 0) {
                            wowConfig = outWoWConfig;
                        }
                        else if (!result.success && result.err_no == WoWConfigManager.ERR_WOW_ROOT_PATH_IS_EMPTY) {
                            wowConfig = outWoWConfig;
                            string wowRootPath = ScanWoWRootPathFromRegistry();
                            if (!String.IsNullOrEmpty(wowRootPath) && Directory.Exists(wowRootPath)) {
                                wowConfigFromFile.folders.wow_root_path = wowRootPath.Trim();
                                result = WoWConfigManager.ValidateConfig(wowConfigFromFile, outWoWConfig, false);
                                if (result.success && result.err_no == 0) {
                                    wowConfig = outWoWConfig;
                                    SaveConfigToXml();
                                }
                            }
                        }
                        xmlValidateResult = result;
                        readSuccess = true;
                    }
                }
                catch (Exception ex) {
                    xmlConfigFileStatus = XmlFileStatus.Error;
                }
            }
            else {
                xmlConfigFileStatus = XmlFileStatus.FileNotExist;
                string wowRootPath = ScanWoWRootPathFromRegistry();
                if (!String.IsNullOrEmpty(wowRootPath) && Directory.Exists(wowRootPath)) {
                    wowConfigFromFile.folders.wow_root_path = wowRootPath.Trim();
                    WoWConfig outWoWConfig = new WoWConfig();
                    var result = WoWConfigManager.ValidateConfig(wowConfigFromFile, outWoWConfig, false);
                    if (result.success && result.err_no == 0) {
                        wowConfig = outWoWConfig;
                        SaveConfigToXml();
                        readSuccess = true;
                        MessageBox.Show(this, $"您是第一次运行该程序，检测到《魔兽世界》的主目录为: \n“{wowRootPath}”,\n\n如果不正确，请重新设置！",
                            FORM_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    xmlValidateResult = result;
                }
                else {
                    MessageBox.Show(this, "您是第一次运行该程序，请先设置《魔兽世界》的主目录！", FORM_CAPTION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return readSuccess;
        }

        public void SaveConfigToXml()
        {
            string strAppPath = Path.GetDirectoryName(Application.ExecutablePath);
            string xmlFile = Path.Combine(strAppPath, XML_CONFIG_FILENAME);
            XmlHelper.SaveToXML<WoWConfig>(wowConfigFromFile, xmlFile, XML_CONFIG_ROOT);
            xmlConfigFileStatus = XmlFileStatus.OK;
        }

        private bool ScanWoWExeProcess()
        {
            bool exists = false;
            bool hasAnyExceptions = true;
            try {
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcesses()) {
                    if (process.Id == current.Id) continue;
                    if (PathUtils.IsWowExe(process.ProcessName)) {
                        string wowExePath = Path.GetDirectoryName(process.MainModule.FileName);
                        if (wowExePath == wowConfig.folders.wow_classic_path_cn ||
                            wowExePath == wowConfig.folders.wow_classic_path_tw) {
                            exists = true;
                            hasAnyExceptions = false;
                            break;
                        }
                    }
                }
            }
            catch (NotSupportedException ex) {
                //
            }
            catch (Exception ex) {
                //
            }

            if (hasAnyExceptions && !exists) {
                try {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcesses()) {
                        if (process.Id == current.Id) continue;
                        if (PathUtils.IsWowExeProcess(process.ProcessName)) {
                            exists = true;
                        }
                    }
                }
                catch (NotSupportedException ex) {
                    //
                }
                catch (Exception ex) {
                    //
                }
            }
            return exists;
        }

        private bool ScanBattleNetProcess()
        {
            bool exists = false;
            try {
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcesses()) {
                    if (process.Id == current.Id) continue;
                    string processName = process.ProcessName.ToLower();
                    if (processName == "battle.net") {
                        exists = true;
                        break;
                    }
                }
            }
            catch (NotSupportedException ex) {
                //
            }
            catch (Exception ex) {
                //
            }
            return exists;
        }

        private void MountJunctionPoint(string junctionPoint, string targetDirectory,
            SwitchStatus switchStatus, bool overwrite = true)
        {
            bool result = JunctionPoint.PathIsSupportReparsePoint(junctionPoint);
            if (!result) {
                string targetVolume = Path.GetPathRoot(junctionPoint);
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point，游戏必须安装在 NTFS 格式的磁盘!", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                string fJunctionPoint = Path.GetFullPath(junctionPoint);
                if (!Directory.Exists(fJunctionPoint)) {
                    if (File.Exists(fJunctionPoint)) {
                        MessageBox.Show(this, $"错误：要绑定的目录“{fJunctionPoint}”是一个文件！", FORM_CAPTION,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string fTargetDirectory = Path.GetFullPath(targetDirectory);
                if (!Directory.Exists(fTargetDirectory)) {
                    if (File.Exists(fTargetDirectory)) {
                        MessageBox.Show(this, $"错误：指定的目标绑定目录“{fTargetDirectory}”是一个文件！", FORM_CAPTION,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else {
                        MessageBox.Show(this, $"指定的目标绑定目录“{fTargetDirectory}”不存在！", FORM_CAPTION,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
#if (USE_TRY)
                hasMountException = true;
                try {
                    JunctionPoint.Create(junctionPoint, targetDirectory, overwrite);
                    hasMountException = false;
                }
                catch (IOException ex) {
                    throw new IOException(ex.Message, ex);
                }
                catch (Exception ex) {
                    throw new Exception(ex.Message, ex);
                }
                finally {
                    //
                }
#else
                hasMountException = true;
                JunctionPoint.Create(junctionPoint, targetDirectory, overwrite);
                hasMountException = false;
#endif
                if (!hasMountException) {
                    //MessageBox.Show(this, $"目录 \"{targetDirectory}\" 软链接到 \"{junctionPoint}\" 成功!", FORM_CAPTION,
                    //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string areaName = SymLinkChecker.GetSwitchAreaName(switchStatus);
                    MessageBox.Show(this, $"已成功切换至魔兽世界怀旧服{areaName}！", FORM_CAPTION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UnmountJunctionPoint(string junctionPoint)
        {
            bool result = JunctionPoint.PathIsSupportReparsePoint(junctionPoint);
            if (!result) {
                string targetVolume = Path.GetPathRoot(junctionPoint);
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point，游戏必须安装在 NTFS 格式的磁盘!", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                string fJunctionPoint = Path.GetFullPath(junctionPoint);
                if (!Directory.Exists(fJunctionPoint)) {
                    if (File.Exists(fJunctionPoint)) {
                        MessageBox.Show(this, $"错误：要绑定的目录“{fJunctionPoint}”是一个文件！", FORM_CAPTION,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                hasMountException = true;
                JunctionPoint.Delete(junctionPoint);
                hasMountException = false;

                if (!hasMountException) {
                    MessageBox.Show(this, "魔兽世界怀旧服软链接已解除绑定！", FORM_CAPTION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SwitchToClassicArea(SwitchStatus switchStatus)
        {
            // 刷新当前状态
            UpdateMountStatus();

            string linkToPath = symLinkChecker.GetLinkToPath();
            LinkStatus linkStatus = symLinkChecker.GetLinkStatus();
            if (linkToPath == null || linkStatus != LinkStatus.Linked) {
                string errorInfo = symLinkChecker.GetLinkErrorInfo();
                MessageBox.Show(this, $"软链接未成功，原因是：{errorInfo}", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SwitchStatus curSwitchStatus = symLinkChecker.GetSwitchStatus();
            if (switchStatus == curSwitchStatus) {
                string areaName = SymLinkChecker.GetSwitchAreaName(switchStatus);
                MessageBox.Show(this, $"当前已经是《魔兽世界》怀旧服{areaName}，无需切换！", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string junctionPoint = wowConfig.folders.wow_classic_path;
            string targetDirectory;
            if (switchStatus == SwitchStatus.SwitchToCN)
                targetDirectory = wowConfig.folders.wow_classic_path_cn;
            else if (switchStatus == SwitchStatus.SwitchToTW)
                targetDirectory = wowConfig.folders.wow_classic_path_tw;
            else {
                targetDirectory = "";
                MessageBox.Show(this, "未指定正确的要切换的怀旧服区域版本！", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ScanWoWExeProcess()) {
                MessageBox.Show(this, "检测到《魔兽世界》怀旧服游戏进程正在运行，请先关闭游戏再切换！", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ScanBattleNetProcess()) {
                MessageBox.Show(this, "检测到《暴雪》战网客户端正在运行，请先关闭战网客户端再切换！", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MountJunctionPoint(junctionPoint, targetDirectory, switchStatus, true);

            // 刷新当前状态
            UpdateMountStatus();
        }

        private void UnmountSymLink()
        {
            // 刷新当前状态
            UpdateMountStatus();

            string linkToPath = symLinkChecker.GetLinkToPath();
            LinkStatus linkStatus = symLinkChecker.GetLinkStatus();
            if (linkToPath == null || linkStatus != LinkStatus.Linked) {
                string errorInfo = symLinkChecker.GetLinkErrorInfo();
                MessageBox.Show(this, $"软链接未成功，原因是：{errorInfo}", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ScanWoWExeProcess()) {
                MessageBox.Show(this, "检测到《魔兽世界》怀旧服游戏进程正在运行，请先关闭游戏再解绑！", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ScanBattleNetProcess()) {
                MessageBox.Show(this, "检测到《暴雪》战网客户端正在运行，请先关闭战网客户端再解绑！", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string junctionPoint = wowConfig.folders.wow_classic_path;
            UnmountJunctionPoint(junctionPoint);

            // 刷新当前状态
            UpdateMountStatus();
        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            FormSettings frmSettings = new FormSettings(this);
            DialogResult result = frmSettings.ShowDialog();
            if (result == DialogResult.OK) {
                wowConfig = frmSettings.GetWoWConfig();
                wowConfigFromFile = frmSettings.GetWoWConfigToFile();

                SaveConfigToXml();

                // 刷新当前状态
                UpdateMountStatus();
            }
        }

        private void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            // 刷新当前状态
            UpdateMountStatus();
        }

        private void btnSwitchToCN_Click(object sender, EventArgs e)
        {
            SwitchToClassicArea(SwitchStatus.SwitchToCN);
        }

        private void btnSwitchToTW_Click(object sender, EventArgs e)
        {
            SwitchToClassicArea(SwitchStatus.SwitchToTW);
        }

        private void btnUnmount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this,
                "如无特殊情况，请勿轻易解除软链接的绑定，\n除非您在软链接的绑定上出现问题。\n\n确定要执行该操作吗？",
                FORM_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes) {
                UnmountSymLink();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxMountTo_KeyDown(object sender, KeyEventArgs e)
        {
            // 屏蔽任何按键, ReadOnly
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void txtBoxMountFrom_KeyDown(object sender, KeyEventArgs e)
        {
            // 屏蔽任何按键, ReadOnly
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void chkBoxMinimizeToTaskbarWhenExiting_CheckedChanged(object sender, EventArgs e)
        {
            if (formUIInitialized) {
                bool _checked = chkBoxMinimizeToTaskbarWhenExiting.Checked;
                wowConfig.minimize_to_taskbar_when_exiting = _checked;
                wowConfigFromFile.minimize_to_taskbar_when_exiting = _checked;

                notifyIcon.Visible = _checked;

                SaveConfigToXml();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private void toolStripMenuItemShowMain_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void toolStripMenuItemHideMain_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            formForcedClosing = true;
            this.Close();
            this.Dispose();

            Application.Exit();
        }

        private void OpenWoWClassicFolder()
        {
            string folderPath = wowConfig.folders.wow_classic_path;
            if (!String.IsNullOrEmpty(folderPath)) {
                ExplorerHelper.OpenFolder(folderPath);
            }
        }

        private void OpenWoWClassicLinkedFolder()
        {
            string folderPath = null;

            var switchStatus = symLinkChecker.GetSwitchStatus();
            if (switchStatus == SwitchStatus.SwitchToCN)
                folderPath = wowConfig.folders.wow_classic_path_cn;
            else if (switchStatus == SwitchStatus.SwitchToTW)
                folderPath = wowConfig.folders.wow_classic_path_tw;

            if (!String.IsNullOrEmpty(folderPath)) {
                ExplorerHelper.OpenFolder(folderPath);
            }
        }

        private void lnkLinkToSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenWoWClassicFolder();
        }

        private void btnOpenWoWClassicFolder_Click(object sender, EventArgs e)
        {
            OpenWoWClassicFolder();
        }

        private void lnkLinkToTarget_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenWoWClassicLinkedFolder();
        }

        private void btnOpenWoWClassicLinkedFolder_Click(object sender, EventArgs e)
        {
            OpenWoWClassicLinkedFolder();
        }

        private void toolStripVersionLabel_Click(object sender, EventArgs e)
        {
            ExplorerHelper.OpenUrl(App_Release_URL);
        }

        private void toolStripHelpLabel_Click(object sender, EventArgs e)
        {
            ExplorerHelper.OpenUrl(NGA_BBS_Topic_URL);
        }

        private void toolStripGiteeLabel_Click(object sender, EventArgs e)
        {
            ExplorerHelper.OpenUrl(Gitee_Repository_URL);
        }

        private void toolStripGitHubLabel_Click(object sender, EventArgs e)
        {
            ExplorerHelper.OpenUrl(GitHub_Repository_URL);
        }

        private void toolStripAuthorLabel_Click(object sender, EventArgs e)
        {
            //BrowserHelper.OpenUrlByDefaultBrowser(Author_Git_URL);
            //BrowserHelper.OpenUrlByChrome_FromChromeHTML(Author_Git_URL);
            //BrowserHelper.OpenUrl_FromClientInternet(BrowserId.GoogleChrome, Author_Git_URL);
            //BrowserHelper.OpenUrl_FromClientInternet(BrowserId.FireFox, Author_Git_URL);
            //BrowserHelper.OpenUrl_FromClientInternet(BrowserId.InterExplorer, Author_Git_URL);
            ExplorerHelper.OpenUrl(Author_Git_URL);
        }
    }
}
