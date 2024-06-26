using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoWJunction
{
    public struct ValidateResult
    {
        public bool success { get; set; }
        public int err_no { get; set; }

        ValidateResult(bool success, int err_no)
        {
            this.success = success;
            this.err_no = err_no;
        }
    }

    public class WoWConfigManager
    {
        // ValidateError
        public const int ERR_SUCCESS = 0;

        // wow_root_path
        public const int ERR_WOW_ROOT_PATH_IS_NOT_A_ABSOLUTE_PATH = -1;
        public const int ERR_WOW_ROOT_PATH_IS_NOT_A_DIRECTORY = -2;
        public const int ERR_WOW_ROOT_PATH_NO_EXISTS = -3;
        public const int ERR_WOW_ROOT_PATH_IS_EMPTY = -4;

        // wow_classic_path
        public const int ERR_WOW_CLASSIC_PATH_IS_NOT_A_RELATIVE_PATH = -11;
        public const int ERR_WOW_CLASSIC_PATH_MUST_START_WITH_PATH_SEPARATOR = -12;
        public const int ERR_WOW_CLASSIC_PATH_IS_EMPTY = -13;

        // wow_classic_path_cn
        public const int ERR_WOW_CLASSIC_PATH_CN_MUST_START_WITH_PATH_SEPARATOR = -21;
        public const int ERR_WOW_CLASSIC_PATH_CN_NO_EXISTS = -22;
        public const int ERR_WOW_CLASSIC_PATH_CN_IS_EMPTY = -23;

        // wow_classic_path_tw
        public const int ERR_WOW_CLASSIC_PATH_TW_MUST_START_WITH_PATH_SEPARATOR = -31;
        public const int ERR_WOW_CLASSIC_PATH_TW_NO_EXISTS = -32;
        public const int ERR_WOW_CLASSIC_PATH_TW_IS_EMPTY = -33;

        public static string FormatValidateError(int err_no)
        {
            switch (err_no) {
                // wow_root_path
                case ERR_WOW_ROOT_PATH_IS_NOT_A_ABSOLUTE_PATH:
                    return "《魔兽世界》主目录必须是一个绝对路径。";
                case ERR_WOW_ROOT_PATH_IS_NOT_A_DIRECTORY:
                    return "《魔兽世界》主目录必须是一个文件夹，而不是文件。";
                case ERR_WOW_ROOT_PATH_NO_EXISTS:
                    return "指定的《魔兽世界》主目录不存在或者不是文件夹，请检查设置。";
                case ERR_WOW_ROOT_PATH_IS_EMPTY:
                    return "《魔兽世界》主目录不能为空！";

                // wow_classic_path
                case ERR_WOW_CLASSIC_PATH_IS_NOT_A_RELATIVE_PATH:
                    return "《魔兽世界》怀旧服目录必须是一个相对路径，不能使用绝对路径。";
                case ERR_WOW_CLASSIC_PATH_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服目录名必须以 '\\' 或 '/' 字符开头。";
                case ERR_WOW_CLASSIC_PATH_IS_EMPTY:
                    return "《魔兽世界》怀旧服目录名不能为空！";

                // wow_classic_path_cn
                case ERR_WOW_CLASSIC_PATH_CN_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服（国服）目录为相对路径时，必须以 '\\' 或 '/' 字符开头。";
                case ERR_WOW_CLASSIC_PATH_CN_NO_EXISTS:
                    return "《魔兽世界》怀旧服（国服）目录不存在，请检查设置。";
                case ERR_WOW_CLASSIC_PATH_CN_IS_EMPTY:
                    return "《魔兽世界》怀旧服（国服）目录名不能为空！";

                // wow_classic_path_tw
                case ERR_WOW_CLASSIC_PATH_TW_MUST_START_WITH_PATH_SEPARATOR:
                    return "《魔兽世界》怀旧服（亚服）目录为相对路径时，必须以 '\\' 或 '/' 字符开头。";
                case ERR_WOW_CLASSIC_PATH_TW_NO_EXISTS:
                    return "《魔兽世界》怀旧服（亚服）目录不存在，请检查设置。";
                case ERR_WOW_CLASSIC_PATH_TW_IS_EMPTY:
                    return "《魔兽世界》怀旧服（亚服）目录名不能为空！";

                default:
                    return "未知错误，请检查设置。";
            }
        }

        public static ValidateResult ValidateConfig(WoWConfig inWoWConfig, WoWConfig outWoWConfig, bool classicPathMustBeExists = true)
        {
            ValidateResult result = new ValidateResult();
            result.success = false;
            result.err_no = ERR_SUCCESS;

            outWoWConfig.minimize_to_taskbar_when_exiting = inWoWConfig.minimize_to_taskbar_when_exiting;

            // wow_root_path: 必须是一个绝对路径, 且必须是一个目录, 且必须存在.
            string wowRootPath = inWoWConfig.folders.wow_root_path;
            wowRootPath.Trim();
            if (String.IsNullOrEmpty(wowRootPath)) {
                result.err_no = ERR_WOW_ROOT_PATH_IS_EMPTY;
                result.success = false;
                return result;
            }
            // 转化为完整的路径(移除相对路径标识)
            wowRootPath = Path.GetFullPath(wowRootPath);
            // 不带目录分隔符的完整路径
            string wowRootPathNoSep = PathUtils.RemoveFullPathTailSeparator(wowRootPath);
            // 带目录分隔符的完整路径
            string wowRootFullPathWithSep = PathUtils.NormalizeFullPathWithSep(wowRootPath);
            string wowRootDirName = Path.GetDirectoryName(wowRootFullPathWithSep);
            if (Path.IsPathRooted(wowRootPath)) {
                if (wowRootDirName == wowRootPathNoSep) {
                    if (!Directory.Exists(wowRootPath)) {
                        if (File.Exists(wowRootPath))
                            result.err_no = ERR_WOW_ROOT_PATH_IS_NOT_A_DIRECTORY;
                        else
                            result.err_no = ERR_WOW_ROOT_PATH_NO_EXISTS;
                    }
                }
                else {
                    result.err_no = ERR_WOW_ROOT_PATH_IS_NOT_A_DIRECTORY;
                }
            }
            else {
                result.err_no = ERR_WOW_ROOT_PATH_IS_NOT_A_ABSOLUTE_PATH;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // 取不带 Separator 的完全路径
            outWoWConfig.folders.wow_root_path = wowRootPathNoSep;

            // wow_classic_path: 必须是一个相对路径, 且以"\"开头, 可以不存在.
            string wowClassicPath = inWoWConfig.folders.wow_classic_path;
            wowClassicPath.Trim();
            if (String.IsNullOrEmpty(wowClassicPath)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_IS_EMPTY;
                result.success = false;
                return result;
            }
            if (PathUtils.IsRelativePath(wowClassicPath)) {
                if (!(wowClassicPath.StartsWith("\\") | wowClassicPath.StartsWith("/"))) {
                    result.err_no = ERR_WOW_CLASSIC_PATH_MUST_START_WITH_PATH_SEPARATOR;
                }
            }
            else {
                result.err_no = ERR_WOW_CLASSIC_PATH_IS_NOT_A_RELATIVE_PATH;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // 保存合并后的 _classic_ 目录
            outWoWConfig.folders.wow_classic_path = PathUtils.CombinePath(wowRootDirName, wowClassicPath);

            // wow_classic_path_cn: 值为相对路径时, 必须以"\"开头, 该相对路径或绝对路径必须存在.
            string wowClassicPathCN = inWoWConfig.folders.wow_classic_path_cn;
            wowClassicPathCN.Trim();
            if (String.IsNullOrEmpty(wowClassicPathCN)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_CN_IS_EMPTY;
                result.success = false;
                return result;
            }
            if (PathUtils.IsRelativePath(wowClassicPathCN)) {
                if (!(wowClassicPathCN.StartsWith("\\") | wowClassicPathCN.StartsWith("/"))) {
                    result.err_no = ERR_WOW_CLASSIC_PATH_CN_MUST_START_WITH_PATH_SEPARATOR;
                }
                else {
                    // 拼接相对路径
                    wowClassicPathCN = PathUtils.CombinePath(wowRootDirName, wowClassicPathCN);
                }
            }
            if (classicPathMustBeExists && !Directory.Exists(wowClassicPathCN)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_CN_NO_EXISTS;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // 保存合并后的 _classic_cn 目录
            outWoWConfig.folders.wow_classic_path_cn = wowClassicPathCN;

            // wow_classic_path_cn: 值为相对路径时, 必须以"\"开头, 该相对路径或绝对路径必须存在.
            string wowClassicPathTW = inWoWConfig.folders.wow_classic_path_tw;
            wowClassicPathTW.Trim();
            if (String.IsNullOrEmpty(wowClassicPathTW)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_TW_IS_EMPTY;
                result.success = false;
                return result;
            }
            if (PathUtils.IsRelativePath(wowClassicPathTW)) {
                if (!(wowClassicPathTW.StartsWith("\\") | wowClassicPathTW.StartsWith("/"))) {
                    result.err_no = ERR_WOW_CLASSIC_PATH_TW_MUST_START_WITH_PATH_SEPARATOR;
                }
                else {
                    // 拼接相对路径
                    wowClassicPathTW = PathUtils.CombinePath(wowRootDirName, wowClassicPathTW);
                }
            }
            if (classicPathMustBeExists && !Directory.Exists(wowClassicPathTW)) {
                result.err_no = ERR_WOW_CLASSIC_PATH_TW_NO_EXISTS;
            }

            if (result.err_no < 0) {
                result.success = false;
                return result;
            }

            // 保存合并后的 _classic_tw 目录
            outWoWConfig.folders.wow_classic_path_tw = wowClassicPathTW;

            result.success = true;
            return result;
        }
    }
}
