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
        private static string frmCaption = "WoWJunction";
        private static string xmlConfigFile = "WoWJunction.exe.config.xml";
        private static string xmlConfigRoot = ""; // "configuration";
        private bool xmlConfigFileExists = false;
        private volatile bool hasException = true;
        private WoWConfig wowConfig = new WoWConfig();
        private WoWConfig wowConfigFromFile = new WoWConfig();

        public FormMain()
        {
            InitializeComponent();
        }

        public WoWConfig GetWoWConfig()
        {
            return wowConfigFromFile;
        }

        private void MountJunctionPoint(string junctionPoint, string targetDirectory, bool overwrite = true)
        {
            string targetVolume = Path.GetPathRoot(targetDirectory);

            bool result = JunctionPoint.PathIsSupportReparsePoint(targetDirectory);
            if (!result) {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point!", frmCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
#if (USE_TRY)
                hasException = true;
                try {
                    JunctionPoint.Create(junctionPoint, targetDirectory, overwrite);
                    hasException = false;
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
                hasException = true;
                JunctionPoint.Create(junctionPoint, targetDirectory, overwrite);
                hasException = false;
#endif
                if (!hasException) {
                    MessageBox.Show(this, $"目录 \"{targetDirectory}\" 软链接到 \"{junctionPoint}\" 成功!", frmCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_cn";
            string targetVolume = Path.GetPathRoot(targetDirectory);
            bool result = JunctionPoint.PathIsSupportReparsePoint(targetDirectory);
            if (result) {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 支持 Reparse Point!", frmCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point!", frmCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMountCN_Click(object sender, EventArgs e)
        {
            string junctionPoint = @"C:\Blizzard\World of Warcraft\_classic_";
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_cn";

            MountJunctionPoint(junctionPoint, targetDirectory, true);
        }

        private void btnMountTW_Click(object sender, EventArgs e)
        {
            string junctionPoint = @"C:\Blizzard\World of Warcraft\_classic_";
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_tw";

            MountJunctionPoint(junctionPoint, targetDirectory, true);
        }

        private bool ReadConfigFromXml()
        {
            xmlConfigFileExists = false;
            string strAppPath = Path.GetDirectoryName(Application.ExecutablePath);
            string xmlFile = strAppPath + @"\" + xmlConfigFile;
            if (File.Exists(xmlFile)) {
                //MessageBox.Show(this, $"xmlFile = \"{xmlFile}\"", frmCaption,
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                WoWConfig xmlWoWConfig = XmlHelper.LoadFromXML<WoWConfig>(xmlFile, xmlConfigRoot);
                if (xmlWoWConfig != null) {
                    wowConfigFromFile = xmlWoWConfig;
                    xmlConfigFileExists = true;
                    return true;
                }
            }
            else {
                MessageBox.Show(this, $"xmlFile = \"{xmlFile}\" 不存在!", frmCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void SaveConfigToXml()
        {
            string strAppPath = Path.GetDirectoryName(Application.ExecutablePath);
            string xmlFile = strAppPath + @"\" + xmlConfigFile;
            XmlHelper.SaveToXML<WoWConfig>(wowConfigFromFile, xmlFile, xmlConfigRoot);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReadConfigFromXml();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            //
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfigToXml();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings frmSettings = new FormSettings(this);
            frmSettings.ShowDialog();
        }
    }
}
