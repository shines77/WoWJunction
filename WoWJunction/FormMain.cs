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

        private const string FORM_CAPTION = "WoWJunction";
        private const string XML_CONFIG_FILENAME = "WoWJunction.exe.config.xml";
        private const string XML_CONFIG_ROOT = ""; // "configuration";

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
            bool readOK = ReadConfigFromXml();

            // 检查当前的绑定状态
            symLinkChecker.CheckSymLink(wowConfig.folders.wow_classic_path);
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            UpdateMountStatus();

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
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xmlConfigFileStatus == XmlFileStatus.FileNotExist) {
                SaveConfigToXml();
            }
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
                txtBoxMountTo.Text = linkToPath;
            }
            else {
                txtBoxMountTo.Text = symLinkChecker.GetLinkErrorInfo();
            }
        }

        private void UpdateWoWVersion()
        {
            //
        }

        public SwitchStatus CheckSwitchStatus(string linkToPath)
        {
            SwitchStatus switchStatus = SwitchStatus.Error;
            linkToPath.Trim();
            if (!String.IsNullOrEmpty(linkToPath)) {
                if (linkToPath == wowConfig.folders.wow_classic_path_cn)
                    switchStatus = SwitchStatus.SwitchToCN;
                else if (linkToPath == wowConfig.folders.wow_classic_path_tw)
                    switchStatus = SwitchStatus.SwitchToTW;
                else
                    switchStatus = SwitchStatus.Unknown;
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
            string wowInstallPath = "";
            try {
                using (RegistryKey rootKey = Registry.LocalMachine) {
                    if (rootKey != null) {
                        using (RegistryKey subKey = rootKey.OpenSubKey(@"Software\WOW6432Node\Blizzard Entertainment\World of Warcraft")) {
                            if (subKey != null) {
                                object objInstallPath = subKey.GetValue("InstallPath", "");
                                if (objInstallPath != null) {
                                    wowInstallPath = objInstallPath.ToString();
                                }
                                subKey.Close();
                            }
                        }
                        if (string.IsNullOrEmpty(wowInstallPath)) {
                            using (RegistryKey subKey2 = rootKey.OpenSubKey(@"Software\Blizzard Entertainment\World of Warcraft")) {
                                if (subKey2 != null) {
                                    object objInstallPath = subKey2.GetValue("InstallPath", "");
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

        private void MountJunctionPoint(string junctionPoint, string targetDirectory,
            SwitchStatus switchStatus, bool overwrite = true)
        {
            string targetVolume = Path.GetPathRoot(targetDirectory);

            bool result = JunctionPoint.PathIsSupportReparsePoint(targetDirectory);
            if (!result) {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point，游戏必须安装在 NTFS 格式的磁盘!", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
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
                    string areaName = "";
                    if (switchStatus == SwitchStatus.SwitchToCN) {
                        areaName = "（国服）";
                    }
                    else if (switchStatus == SwitchStatus.SwitchToTW) {
                        areaName = "（亚服）";
                    }
                    else {
                        areaName = "（未知）";
                    }
                    MessageBox.Show(this, $"已成功切换至魔兽世界怀旧服{areaName}！", FORM_CAPTION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            FormSettings frmSettings = new FormSettings(this);
            DialogResult result = frmSettings.ShowDialog();
            if (result == DialogResult.OK) {
                wowConfig = frmSettings.GetWoWConfig();
                wowConfigFromFile = frmSettings.GetWoWConfigToFile();

                SaveConfigToXml();
            }
        }

        private void btnRefreshStatus_Click(object sender, EventArgs e)
        {
            // 刷新当前状态
            UpdateMountStatus();
        }

        private void btnSwitchToCN_Click(object sender, EventArgs e)
        {
            string junctionPoint = @"C:\Blizzard\World of Warcraft\_classic_";
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_cn";

            MountJunctionPoint(junctionPoint, targetDirectory, SwitchStatus.SwitchToCN, true);

            // 刷新当前状态
            UpdateMountStatus();
        }

        private void btnSwitchToTW_Click(object sender, EventArgs e)
        {
            string junctionPoint = @"C:\Blizzard\World of Warcraft\_classic_";
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_tw";

            MountJunctionPoint(junctionPoint, targetDirectory, SwitchStatus.SwitchToTW, true);

            // 刷新当前状态
            UpdateMountStatus();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_cn";
            string targetVolume = Path.GetPathRoot(targetDirectory);
            bool result = JunctionPoint.PathIsSupportReparsePoint(targetDirectory);
            if (result) {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 支持 Reparse Point!", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point!", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
