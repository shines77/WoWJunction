///
/// 以下两种方式可供选择, 都不定义代表不限制单一实例
///

///
/// 所有 WoWJunction.exe 只允许启动一个实例
///
#define RUN_ONCE

///
/// 所有同一个路径下的 WoWJunction.exe 只允许启动一个实例
///
#define SAME_FILE_RUN_ONCE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WoWJunction
{
    static class Program
    {
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_RESTORE = 0xF120;
        public const int WM_SHOWWINDOW = 0x0018;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOW = 5;

#if !RUN_ONCE
#if SAME_FILE_RUN_ONCE
        static int nUnknownExceptions = 0;
#endif
#endif
        public const int MaxUnknownExceptions = 10;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ///
            /// 本程序只允许启动一个实例, 第二次启动则激活第一个实例 exe 的窗口, 并退出
            ///
            Process current = Process.GetCurrentProcess();

            foreach (Process process in Process.GetProcesses()) {
                if (process.Id == current.Id) continue;
#if RUN_ONCE
                if (process.ProcessName == current.ProcessName) {
                    MessageBox.Show("本程序只能启动一个实例, 请勿重复启动 !", "警告...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SetForegroundWindow(process.MainWindowHandle);
                    SendMessage(process.MainWindowHandle, WM_SYSCOMMAND, SC_RESTORE, 0);
                    ShowWindow(process.MainWindowHandle, SW_SHOWNORMAL);
                    //SendMessage(process.MainWindowHandle, WM_SHOWWINDOW, 1, 0);
                    return;
                }
#else
  #if SAME_FILE_RUN_ONCE
                try {
                    if (process.MainModule.FileName == current.MainModule.FileName) {
                        MessageBox.Show("本程序只能启动一个实例, 请勿重复启动 !", "警告...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SetForegroundWindow(process.MainWindowHandle);
                        SendMessage(process.MainWindowHandle, WM_SYSCOMMAND, SC_RESTORE, 0);
                        return;
                    }
                }
                catch (NotSupportedException ex) {
                    MessageBox.Show(ex.Message.ToString(), "NotSupportedException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex) {
                    nUnknownExceptions++;
                    if (nUnknownExceptions < MaxUnknownExceptions) {
                        //MessageBox.Show(ex.Message.ToString(), "UnknownException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
  #endif // SAME_FILE_RUN_ONCE
#endif // RUN_ONCE
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
