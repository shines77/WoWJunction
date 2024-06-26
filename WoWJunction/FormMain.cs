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

namespace WoWJunction
{
    public partial class FormMain : Form
    {
        enum XmlFileStatus : int
        {
            Unknown,
            FileIsNotExists,
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

        public FormMain()
        {
            InitializeComponent();
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
            ReadConfigFromXml();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            txtBoxMountFrom.Text = wowConfig.folders.wow_classic_path;
            txtBoxMountTo.Text = wowConfig.folders.wow_classic_path_tw;

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
            else if (xmlConfigFileStatus == XmlFileStatus.FileIsNotExists) {
                //MessageBox.Show(this, "您是第一次运行该程序，请先设置《魔兽世界》的主目录！", FORM_CAPTION,
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xmlConfigFileStatus == XmlFileStatus.FileIsNotExists) {
                SaveConfigToXml();
            }
        }

        public bool ReadConfigFromXml()
        {
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
                        var result = WoWConfigManager.ValidateConfig(xmlWoWConfig, outWoWConfig);
                        if (( result.success && result.err_no == 0) ||
                            (!result.success && result.err_no == WoWConfigManager.ERR_WOW_ROOT_PATH_IS_EMPTY)) {
                            wowConfig = outWoWConfig;
                        }
                        xmlValidateResult = result;
                        return true;
                    }
                }
                catch (Exception ex) {
                    xmlConfigFileStatus = XmlFileStatus.Error;
                }
            }
            else {
                xmlConfigFileStatus = XmlFileStatus.FileIsNotExists;
                MessageBox.Show(this, "您是第一次运行该程序，请先设置《魔兽世界》的主目录！", FORM_CAPTION,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }

        public void SaveConfigToXml()
        {
            string strAppPath = Path.GetDirectoryName(Application.ExecutablePath);
            string xmlFile = Path.Combine(strAppPath, XML_CONFIG_FILENAME);
            XmlHelper.SaveToXML<WoWConfig>(wowConfigFromFile, xmlFile, XML_CONFIG_ROOT);
            xmlConfigFileStatus = XmlFileStatus.OK;
        }

        private void MountJunctionPoint(string junctionPoint, string targetDirectory, bool overwrite = true)
        {
            string targetVolume = Path.GetPathRoot(targetDirectory);

            bool result = JunctionPoint.PathIsSupportReparsePoint(targetDirectory);
            if (!result) {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point!", FORM_CAPTION,
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
                    MessageBox.Show(this, $"目录 \"{targetDirectory}\" 软链接到 \"{junctionPoint}\" 成功!", FORM_CAPTION,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UpdateMountStatus()
        {
            UpdateMountLinkStatus();
            UpdateMountLinkDetailStatus();
            UpdateWoWVersion();
            UpdateSwitchToStatus();
        }

        private void UpdateMountLinkStatus()
        {
            //
        }

        private void UpdateMountLinkDetailStatus()
        {
            //
        }

        private void UpdateWoWVersion()
        {
            //
        }

        private void UpdateSwitchToStatus()
        {
            //
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

        private void btnSwitchToCN_Click(object sender, EventArgs e)
        {
            string junctionPoint = @"C:\Blizzard\World of Warcraft\_classic_";
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_cn";

            MountJunctionPoint(junctionPoint, targetDirectory, true);
        }

        private void btnSwitchToTW_Click(object sender, EventArgs e)
        {
            string junctionPoint = @"C:\Blizzard\World of Warcraft\_classic_";
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_tw";

            MountJunctionPoint(junctionPoint, targetDirectory, true);
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
