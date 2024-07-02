using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WoWJunction
{
    public class ExplorerUtils
    {
        public static void OpenFolder(string folderPath)
        {
            if (string.IsNullOrEmpty(folderPath)) return;
            if (!Directory.Exists(folderPath)) return;

            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("explorer.exe");
            psi.Arguments = folderPath;
            process.StartInfo = psi;

            try {
                process.Start();
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                process?.Close();
            }
        }

        public static void OpenFolderAndSelectFile(string filePathName)
        {
            if (string.IsNullOrEmpty(filePathName)) return;
            if (!File.Exists(filePathName)) return;

            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo("explorer.exe");
            psi.Arguments = "/e,/select," + filePathName;
            process.StartInfo = psi;

            try {
                process.Start();
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                process?.Close();
            }
        }

        public static void OpenFile(string filePathName, bool waitForClose = true)
        {
            if (string.IsNullOrEmpty(filePathName)) return;
            if (!File.Exists(filePathName)) return;

            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(filePathName);
            psi.UseShellExecute = true;
            process.StartInfo = psi;

            try {
                process.Start();
                if (waitForClose) {
                    process.WaitForExit();
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
                process?.Close();
            }
        }
    }
}
