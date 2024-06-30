using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WoWJunction
{
    public enum LinkStatus : int
    {
        IsAFile = -5,
        FolderNotExist = -4,
        TargetNotExist = -3,
        IsEmpty = -2,
        Error = -1,
        Unknown = 0,
        Linked = 1
    };

    public enum SwitchStatus : int
    {
        Error = -1,
        Unknown = 0,
        SwitchToCN = 1,
        SwitchToTW = 2
    };

    class SymLinkChecker
    {
        private FormMain parent = null;

        private LinkStatus _linkStatus = LinkStatus.Unknown;
        private SwitchStatus _switchStatus = SwitchStatus.Unknown;

        private string _path = null;
        private string _linkToPath = null;

        private string _sourceName = "";
        private string _targetName = "";

        public SymLinkChecker(FormMain parent)
        {
            this.parent = parent;
        }

        public LinkStatus GetLinkStatus() { return _linkStatus; }

        public SwitchStatus GetSwitchStatus() { return _switchStatus; }

        public string GetPath() { return _path; }
        public void SetPath(string path) { _path = path; }

        public string GetLinkToPath() { return _linkToPath; }

        public string GetSourceName() { return _sourceName; }

        public string GetTargetName() { return _targetName; }

        public string GetLinkErrorInfo()
        {
            switch (_linkStatus) {
                case LinkStatus.IsAFile:
                    return $"指定的目标“{_path}”是一个文件！";
                case LinkStatus.FolderNotExist:
                    return $"指定的目录“{_path}”不存在！";
                case LinkStatus.TargetNotExist:
                    return $"目录“{_path}”暂未绑定任何软链接！";
                case LinkStatus.IsEmpty:
                    return "指定的目录为空或Null！";
                case LinkStatus.Error:
                    return "绑定错误！";
                case LinkStatus.Linked:
                    return "链接正常。";
                default:
                    return "<未知错误>";
            }
        }

        public string GetSimpleLinkErrorInfo()
        {
            switch (_linkStatus) {
                case LinkStatus.IsAFile:
                    return "源目标是一个文件";
                case LinkStatus.FolderNotExist:
                    return "源目录不存在";
                case LinkStatus.TargetNotExist:
                    return "暂未绑定软链接";
                case LinkStatus.IsEmpty:
                    return "源目标为空或Null";
                case LinkStatus.Error:
                    return "绑定错误";
                case LinkStatus.Linked:
                    return "链接正常";
                default:
                    return "<未知错误>";
            }
        }

        public bool CheckSymLink(string path)
        {
            string linkToPath = null;
            try {
                path.Trim();
                if (String.IsNullOrEmpty(path)) {
                    _linkStatus = LinkStatus.IsEmpty;
                }
                else {
                    if (!Directory.Exists(path)) {
                        if (File.Exists(path))
                            _linkStatus = LinkStatus.IsAFile;
                        else
                            _linkStatus = LinkStatus.FolderNotExist;
                    }
                    else {
                        linkToPath = JunctionPoint.GetTarget(path);
                        _linkStatus = LinkStatus.Linked;
                    }
                }
            }
            catch (IOException ex) {
                _linkStatus = LinkStatus.TargetNotExist;
            }
            finally {
                _path = path;
                _linkToPath = linkToPath;
            }
            if (_linkStatus == LinkStatus.Linked) {
                _sourceName = Path.DirectorySeparatorChar + PathUtils.FindLastFolder(_path);
                _targetName = Path.DirectorySeparatorChar + PathUtils.FindLastFolder(_linkToPath);

                if (parent != null) {
                    _switchStatus = parent.CheckSwitchStatus(_linkToPath);
                }
            }
            return (linkToPath != null);
        }
    }
}
