using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace WoWJunction
{
    public class BrowserId
    {
        public const int Default = 0;
        public const int InterExplorer = 1;
        public const int FireFox = 2;
        public const int GoogleChrome = 3;
        public const int MicrosoftEdge = 4;
        public const int Maxinum = 5;
    };

    public class BrowserHelper
    {
        public static string ParseShellCommandExePath(string commandStr)
        {
            string exePath = string.Empty;
            if (!string.IsNullOrEmpty(commandStr)) {
                string[] splitArr = new string[] { };
                string iCommandStr = commandStr.ToLower();

                // 格式: "C:\Program Files\Internet Explorer\iexplore.exe" %1
                var exePos = iCommandStr.IndexOf(".exe", StringComparison.Ordinal);
                if (exePos != -1) {
                    splitArr = commandStr.Split('\"');
                }
                if (splitArr.Length > 1) {
                    // 格式: "DefaultBrowser_Exe" %1
                    exePath = splitArr[1];
                }
                else if (splitArr.Length > 0) {
                    // 格式: DefaultBrowser_Exe
                    exePath = splitArr[0];
                }
                else if (splitArr.Length == 0 && exePos != -1) {
                    // 没有双引号, 但有 ".exe" 的情况
                    exePath = commandStr;
                }
            }
            return exePath;
        }

        /// <summary>
        /// 使用系统默认浏览器打开网址
        /// </summary>
        /// <param name="url"></param>
        /// <param name="isHttps"></param>
        public static bool OpenUrlByDefaultBrowser(string url, bool showErrors = true, bool isHttps = false)
        {
            if (string.IsNullOrEmpty(url)) return false;

            bool isOpened = true;
            try {
                // 从注册表中读取默认浏览器的可执行文件路径
                string httpMode = (isHttps) ? "https" : "http";
                string httpShellOpenKey = $"{httpMode}\\shell\\open\\command";
                RegistryKey commandKey = Registry.ClassesRoot.OpenSubKey(httpShellOpenKey);
                if (commandKey != null) {
                    // 默认值为: "C:\Program Files\Internet Explorer\iexplore.exe" %1
                    // 不同的浏览器不一样, 例如: "C:\Program Files (x86)\Google\chrome.exe" -- "%1"
                    string defaultBrowser = (string)commandKey.GetValue("", null);
                    if (!string.IsNullOrEmpty(defaultBrowser)) {
                        // 从 command 格式中获取 ExePath
                        string browserExePath = ParseShellCommandExePath(defaultBrowser);

                        // 使用 Process 类打开浏览器
                        if (!string.IsNullOrEmpty(browserExePath) && File.Exists(browserExePath)) {
                            var result = Process.Start(browserExePath, url);
                        }
                        else {
                            isOpened = false;
                            if (showErrors) {
                                MessageBox.Show("默认浏览器的可执行文件不存在！", "BrowserHelper", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                else {
                    isOpened = false;
                }
            }
            catch {
                isOpened = false;
            }
            return isOpened;
        }

        /// <summary>
        /// 使用浏览器打开网址 (通过 Clients/StartMenuInternet)
        /// </summary>
        /// <param name="browserId">浏览器的Id, 可选的值参考 BrowserId 类</param>
        /// <param name="url"></param>
        /// <param name="showErrors"></param>
        public static bool OpenUrl_FromClientInternet(int broswerId, string url, bool showErrors = true)
        {
            if (broswerId <= BrowserId.Default && broswerId >= BrowserId.Maxinum) return false;
            if (string.IsNullOrEmpty(url)) return false;

            string[] BrowserAppKeys = new string[]
            {
                "",
                "IEXPLORE.EXE",
                "FIREFOX.EXE",
                "Google Chrome",
                "Microsoft Edge"
            };

            string[] BrowserAppNames = new string[]
            {
                "默认",
                "Internet Explorer",
                "FireFox",
                "Google Chrome",
                "Microsoft Edge"
            };

            string browserAppKey = BrowserAppKeys[broswerId];
            string browserAppName = BrowserAppNames[broswerId];

            bool isOpened = true;
            try {
                // 通过注册表找到 [相应浏览器] 的安装路径
                string clientCommandKey = $@"Software\Clients\StartMenuInternet\{browserAppKey}\shell\open\command";
                RegistryKey commandKey = Registry.LocalMachine.OpenSubKey(clientCommandKey);
                if (commandKey == null) {
                    commandKey = Registry.CurrentUser.OpenSubKey(clientCommandKey);
                }
                if (commandKey != null) {
                    string browserCommand = (string)commandKey.GetValue("", null);
                    if (!string.IsNullOrEmpty(browserCommand)) {
                        // 从 command 格式中获取 ExePath
                        string browserAppPath = ParseShellCommandExePath(browserCommand);

                        // 使用 Process 类打开 [相应的浏览器]
                        if (!string.IsNullOrEmpty(browserAppPath) && File.Exists(browserAppPath)) {
                            var result = Process.Start(browserAppPath, url);
                        }
                        else {
                            isOpened = false;
                            if (showErrors) {
                                MessageBox.Show($"{browserAppName}浏览器的可执行文件不存在！", "BrowserHelper", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    else {
                        isOpened = false;
                    }
                }
                else {
                    isOpened = false;
                }
            }
            catch {
                isOpened = false;
            }
            return isOpened;
        }

        /// <summary>
        /// 使用Chrome浏览器打开网址 (通过 ChromeHTML)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="showErrors"></param>
        public static bool OpenUrlByChrome_FromChromeHTML(string url, bool showErrors = true)
        {
            if (string.IsNullOrEmpty(url)) return false;

            bool isOpened = true;
            try {
                // 通过注册表找到 Chrome 浏览器的安装路径
                string chromeHTMLKey = @"Software\Classes\ChromeHTML\shell\open\command";
                RegistryKey chromeKey = Registry.LocalMachine.OpenSubKey(chromeHTMLKey);
                if (chromeKey == null) {
                    chromeKey = Registry.CurrentUser.OpenSubKey(chromeHTMLKey);
                }
                if (chromeKey != null) {
                    string chromeCommand = (string)chromeKey.GetValue("", null);
                    if (!string.IsNullOrEmpty(chromeCommand)) {
                        // 从 command 格式中获取 ExePath
                        string chromeAppPath = ParseShellCommandExePath(chromeCommand);

                        // 使用 Process 类打开 Chrome 浏览器
                        if (!string.IsNullOrEmpty(chromeAppPath) && File.Exists(chromeAppPath)) {
                            var result = Process.Start(chromeAppPath, url);
                        }
                        else {
                            isOpened = false;
                            if (showErrors) {
                                MessageBox.Show("Chrome 浏览器的可执行文件不存在！", "BrowserHelper", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    else {
                        isOpened = false;
                    }
                }
                else {
                    isOpened = false;
                }
            }
            catch {
                isOpened = false;
            }
            return isOpened;
        }

        /// <summary>
        /// 使用Chrome浏览器打开网址 (通过 AppPaths)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="showErrors"></param>
        public static bool OpenUrlByChrome_FromAppPaths(string url, bool showErrors = true)
        {
            if (string.IsNullOrEmpty(url)) return false;

            bool isOpened = true;
            try {
                // 通过注册表找到 Chrome 浏览器的安装路径
                string chromeAppPathKey = @"\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe";
                RegistryKey chromeKey = Registry.LocalMachine.OpenSubKey(chromeAppPathKey);
                if (chromeKey == null) {
                    chromeKey = Registry.CurrentUser.OpenSubKey(chromeAppPathKey);
                }
                if (chromeKey != null) {
                    string chromeAppPath = (string)chromeKey.GetValue("", null);

                    // 使用 Process 类打开 Chrome 浏览器
                    if (!string.IsNullOrEmpty(chromeAppPath) && File.Exists(chromeAppPath)) {
                        var result = Process.Start(chromeAppPath, url);
                    }
                    else {
                        isOpened = false;
                        if (showErrors) {
                            MessageBox.Show("Chrome 浏览器的可执行文件不存在！", "BrowserHelper", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else {
                    isOpened = false;
                }
            }
            catch {
                isOpened = false;
            }
            return isOpened;
        }

        public static bool OpenUrl(string url)
        {
            bool isOpened = BrowserHelper.OpenUrl_FromClientInternet(BrowserId.GoogleChrome, url, false);
            if (!isOpened) {
                isOpened = BrowserHelper.OpenUrlByChrome_FromChromeHTML(url, false);
            }
            if (!isOpened) {
                isOpened = BrowserHelper.OpenUrl_FromClientInternet(BrowserId.MicrosoftEdge, url, false);
            }
            if (!isOpened) {
                isOpened = BrowserHelper.OpenUrl_FromClientInternet(BrowserId.FireFox, url, false);
            }
            if (!isOpened) {
                isOpened = BrowserHelper.OpenUrl_FromClientInternet(BrowserId.InterExplorer, url, true);
            }
            return isOpened;
        }
    }
}
