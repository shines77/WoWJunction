#define USE_TRY
#undef USE_TRY

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWJunction
{
    public partial class frmMain : Form
    {
        private static string frmCaption = "WoWJunction";
        private volatile bool hasException = true;

        public frmMain()
        {
            InitializeComponent();
        }

        private void MountJunctionPoint(string junctionPoint, string targetDirectory, bool overwrite = true)
        {
            string targetVolume = Path.GetPathRoot(targetDirectory);

            bool result = JunctionPoint.PathIsSupportReparsePoint(targetDirectory);
            if (!result) {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point!", frmCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show(this, $"目录 \"{targetDirectory}\" 软链接到 \"{junctionPoint}\" 成功!", frmCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_cn_";
            string targetVolume = Path.GetPathRoot(targetDirectory);
            bool result = JunctionPoint.PathIsSupportReparsePoint(targetDirectory);
            if (result) {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 支持 Reparse Point!", frmCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(this, $"卷 \"{targetVolume}\" 不支持 Reparse Point!", frmCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMountCN_Click(object sender, EventArgs e)
        {
            string junctionPoint = @"C:\Blizzard\World of Warcraft\_classic_";
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_cn_";

            MountJunctionPoint(junctionPoint, targetDirectory, true);
        }

        private void btnMountTW_Click(object sender, EventArgs e)
        {
            string junctionPoint = @"C:\Blizzard\World of Warcraft\_classic_";
            string targetDirectory = @"C:\Blizzard\World of Warcraft\_classic_tw_";

            MountJunctionPoint(junctionPoint, targetDirectory, true);
        }
    }
}
