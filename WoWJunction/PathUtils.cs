using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoWJunction
{
    public static class PathUtils
    {
        /// <summary>
        /// 判断路径是否是一个相对路径?
        /// 跟 C# 自带的 Path.IsPathRooted() 函数的区别是:
        /// 当值为 "\documents" 格式时, 也会被认为是一个 "相对路径", 其他相同.
        /// </summary>
        /// <param name="path">Input path or file name</param>
        /// <returns></returns>
        public static bool IsRelativePath(string path)
        {
            path.Trim();
            if (!String.IsNullOrEmpty(path)) {
                if (path.StartsWith("\\") | path.StartsWith("/")) {
                    if (!(path.StartsWith("\\\\") | path.StartsWith("//"))) {
                        return true;
                    }
                }
                return !Path.IsPathRooted(path);
            }

            return true;
        }

        /// <summary>
        /// 判断路径是否是一个绝对路径?
        /// 跟 C# 自带的 Path.IsPathRooted() 函数的区别是:
        /// 当值为 "\documents" 格式时, 也会被认为是一个 "相对路径", 其他相同.
        /// </summary>
        /// <param name="path">Input path or file name</param>
        /// <returns></returns>
        public static bool IsAbsolutePath(string path)
        {
            path.Trim();
            if (!String.IsNullOrEmpty(path)) {
                if (path.StartsWith("\\") | path.StartsWith("/")) {
                    if (!(path.StartsWith("\\\\") | path.StartsWith("//"))) {
                        return false;
                    }
                }
                return Path.IsPathRooted(path);
            }

            return false;
        }

        /// <summary>
        /// 移除文件路径末尾的 "\" 或 "/" 字符.
        /// </summary>
        /// <param name="path">Input path or file name</param>
        /// <returns></returns>
        public static string RemovePathTailSeparator(string path)
        {
            path.Trim();
            if (!String.IsNullOrEmpty(path)) {
                if (path.EndsWith("\\") | path.EndsWith("/")) {
                    path = path.Substring(0, path.Length - 1);
                }
            }
            return path;
        }

        /// <summary>
        /// 移除文件路径末尾的 "\" 或 "/" 字符, 并转化为完整路径 FullPath.
        /// </summary>
        /// <param name="path">Input path or file name</param>
        /// <returns></returns>
        public static string RemoveFullPathTailSeparator(string path)
        {
            path.Trim();
            if (!String.IsNullOrEmpty(path)) {
                path = Path.GetFullPath(path);
                if (path.EndsWith("\\") | path.EndsWith("/")) {
                    path = path.Substring(0, path.Length - 1);
                }
            }
            return path;
        }

        /// <summary>
        /// 输出规范化的文件路径, 末尾不包含 "\" 或 "/" 字符.
        /// </summary>
        /// <param name="path">Input path or file name</param>
        /// <returns></returns>
        public static string NormalizeFullPath(string path)
        {
            path.Trim();
            if (!String.IsNullOrEmpty(path)) {
                path = Path.GetFullPath(path);
                if (path.EndsWith("\\") | path.EndsWith("/")) {
                    path = path.Substring(0, path.Length - 1);
                }
            }
            return path;
        }

        /// <summary>
        /// 输出规范化的文件路径, 末尾包含 "\" 或 "/" 字符.
        /// </summary>
        /// <param name="path">Input path or file name</param>
        /// <returns></returns>
        public static string NormalizeFullPathWithSep(string path)
        {
            path.Trim();
            if (!String.IsNullOrEmpty(path)) {
                path = Path.GetFullPath(path);
                if (!(path.EndsWith("\\") | path.EndsWith("/"))) {
                    path = path + Path.DirectorySeparatorChar;
                }
            }
            return path;
        }

        /// <summary>
        /// 合并两个路径, 与 C# 自带的 Path.Combine() 不同的地方是:
        /// 当然 path2 以 "\\" 或 "/" 开头时, path2 也会被认为是相对路径来合并.
        /// </summary>
        /// <param name="path">Input path or file name</param>
        /// <returns></returns>
        public static string CombinePath(string path1, string path2)
        {
            string separatorChar1 = "";
            string separatorChar2;
            separatorChar1 += Path.DirectorySeparatorChar;
            if (Path.DirectorySeparatorChar == '\\')
                separatorChar2 = "/";
            else
                separatorChar2 = "\\";

            path1.Trim();
            if (path1.EndsWith(separatorChar1)) {
                // Do nothing !!
            }
            else if (path1.EndsWith(separatorChar2)) {
                // 当 path1 以非当前系统的 DirectorySeparatorChar 分隔符结尾时, 先移除结尾的 DirectorySeparatorChar
                path1 = path1.Substring(0, path1.Length - 1);
            }

            // 当 path2 以 "\\" 或 "/" 开头时, 先移除开头的 DirectorySeparatorChar.
            path2.Trim();
            if (path2.StartsWith(separatorChar1) | path2.StartsWith(separatorChar2)) {
                if (path2.Length > 0)
                    path2 = path2.Substring(1, path2.Length - 1);
            }

            string path = Path.Combine(path1, path2);
            return path;
        }

        public static string FindLastFolder(string path)
        {
            char[] DirectorySeparators = new char[] { '\\', '/' };
            string lastFolder = "";

            // Remove the end of '\\' or '/' char
            path = NormalizeFullPath(path);

            // Find the first position of lastIndexOf('\\' or '/')
            int last = path.LastIndexOfAny(DirectorySeparators);
            if (last != -1) {
                lastFolder = path.Substring(last, path.Length - last);
            }
            return lastFolder;
        }

        public static string ExtractWoWRootPath(string path)
        {
            string[] WoWSubPath = new string[]
            {
                "_classic_",
                "_classic_era_",
                "_retail_",
                "_classic_ptr_",
                "_ptr_",
            };

            string wowRootPath = "";
            string wowPath = path.Trim();
            if (!Directory.Exists(wowPath)) {
                wowPath = Path.GetDirectoryName(wowPath);
            }
            wowPath = PathUtils.NormalizeFullPath(wowPath);

            foreach (string subPath in WoWSubPath) {
                if (!string.IsNullOrEmpty(subPath)) {
                    if (wowPath.EndsWith(subPath) && (wowPath.Length >= (subPath.Length + 1))) {
                        wowRootPath = wowPath.Substring(0, wowPath.Length - (subPath.Length + 1));
                        break;
                    }
                }
            }
            return wowRootPath;
        }
    }
}
