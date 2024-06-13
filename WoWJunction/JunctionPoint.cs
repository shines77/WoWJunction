using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

//
// From: https://www.codeproject.com/Articles/15633/Manipulating-NTFS-Junction-Points-in-NET
// From: https://cloud.tencent.com/developer/article/2348956
//

//
// Reference (ZH-CN): https://learn.microsoft.com/zh-cn/windows/win32/fileio/reparse-point-operations?redirectedfrom=MSDN
// Reference (EN-US): https://learn.microsoft.com/en-us/windows/win32/fileio/reparse-points
//

namespace WoWJunction
{
    /// <summary>
    /// 为 NTFS 磁盘提供基于 .NET 实现的目录联接（mklink /J）。
    /// </summary>
    public static class JunctionPoint
    {
        /// <summary>
        /// The file or directory is not a reparse point.
        /// </summary>
        private const int ERROR_NOT_A_REPARSE_POINT = 4390;

        /// <summary>
        /// The reparse point attribute cannot be set because it conflicts with an existing attribute.
        /// </summary>
        private const int ERROR_REPARSE_ATTRIBUTE_CONFLICT = 4391;

        /// <summary>
        /// The data present in the reparse point buffer is invalid.
        /// </summary>
        private const int ERROR_INVALID_REPARSE_DATA = 4392;

        /// <summary>
        /// The tag present in the reparse point buffer is invalid.
        /// </summary>
        private const int ERROR_REPARSE_TAG_INVALID = 4393;

        /// <summary>
        /// There is a mismatch between the tag specified in the request and the tag present in the reparse point.
        /// </summary>
        private const int ERROR_REPARSE_TAG_MISMATCH = 4394;

        /// <summary>
        /// Command to set the reparse point data block.
        /// </summary>
        private const int FSCTL_SET_REPARSE_POINT = 0x000900A4;

        /// <summary>
        /// Command to get the reparse point data block.
        /// </summary>
        private const int FSCTL_GET_REPARSE_POINT = 0x000900A8;

        /// <summary>
        /// Command to delete the reparse point data base.
        /// </summary>
        private const int FSCTL_DELETE_REPARSE_POINT = 0x000900AC;

        /// <summary>
        /// Reparse point tag used to identify mount points and junction points.
        /// </summary>
        private const uint IO_REPARSE_TAG_MOUNT_POINT = 0xA0000003;

        /// <summary>
        /// This prefix indicates to NTFS that the path is to be treated as a non-interpreted
        /// path in the virtual file system.
        /// </summary>
        private const string NonInterpretedPathPrefix = @"\??\";

        public struct PathUtils
        {
            public const int MAX_PATH = 260;
        };

        [Flags]
        private enum EFileSystemFlags : uint
        {
            FILE_CASE_SENSITIVE_SEARCH          = 0x00000001,
            FILE_CASE_PRESERVED_NAMES           = 0x00000002,
            FILE_UNICODE_ON_DISK                = 0x00000004,
            FILE_PERSISTENT_ACLS                = 0x00000008,

            FILE_FILE_COMPRESSION               = 0x00000010,
            FILE_VOLUME_QUOTAS                  = 0x00000020,
            FILE_SUPPORTS_SPARSE_FILES          = 0x00000040,
            FILE_SUPPORTS_REPARSE_POINTS        = 0x00000080,

            FILE_SUPPORTS_REMOTE_STORAGE        = 0x00000100,
            FILE_RETURNS_CLEANUP_RESULT_INFO    = 0x00000200,
            FILE_SUPPORTS_POSIX_UNLINK_RENAME   = 0x00000400,
            FILE_VOLUME_IS_COMPRESSED           = 0x00008000,

            FILE_SUPPORTS_OBJECT_IDS            = 0x00010000,
            FILE_SUPPORTS_ENCRYPTION            = 0x00020000,
            FILE_NAMED_STREAMS                  = 0x00040000,
            FILE_READ_ONLY_VOLUME               = 0x00080000,

            FILE_SEQUENTIAL_WRITE_ONCE          = 0x00100000,
            FILE_SUPPORTS_TRANSACTIONS          = 0x00200000,
            FILE_SUPPORTS_HARD_LINKS            = 0x00400000,
            FILE_SUPPORTS_EXTENDED_ATTRIBUTES   = 0x00800000,

            FILE_SUPPORTS_OPEN_BY_FILE_ID       = 0x01000000,
            FILE_SUPPORTS_USN_JOURNAL           = 0x02000000,
            FILE_SUPPORTS_INTEGRITY_STREAMS     = 0x04000000,
            FILE_SUPPORTS_BLOCK_REFCOUNTING     = 0x08000000,

            FILE_SUPPORTS_SPARSE_VDL            = 0x10000000,
            FILE_DAX_VOLUME                     = 0x20000000,
            FILE_SUPPORTS_GHOSTING              = 0x40000000,
        }

        [Flags]
        private enum EFileAccess : uint
        {
            GenericRead = 0x80000000,
            GenericWrite = 0x40000000,
            GenericExecute = 0x20000000,
            GenericAll = 0x10000000,
        }

        [Flags]
        private enum EFileShare : uint
        {
            None = 0x00000000,
            Read = 0x00000001,
            Write = 0x00000002,
            Delete = 0x00000004,
        }

        private enum ECreationDisposition : uint
        {
            New = 1,
            CreateAlways = 2,
            OpenExisting = 3,
            OpenAlways = 4,
            TruncateExisting = 5,
        }

        [Flags]
        private enum EFileAttributes : uint
        {
            Readonly = 0x00000001,
            Hidden = 0x00000002,
            System = 0x00000004,
            Directory = 0x00000010,
            Archive = 0x00000020,
            Device = 0x00000040,
            Normal = 0x00000080,
            Temporary = 0x00000100,
            SparseFile = 0x00000200,
            ReparsePoint = 0x00000400,
            Compressed = 0x00000800,
            Offline = 0x00001000,
            NotContentIndexed = 0x00002000,
            Encrypted = 0x00004000,
            Write_Through = 0x80000000,
            Overlapped = 0x40000000,
            NoBuffering = 0x20000000,
            RandomAccess = 0x10000000,
            SequentialScan = 0x08000000,
            DeleteOnClose = 0x04000000,
            BackupSemantics = 0x02000000,
            PosixSemantics = 0x01000000,
            OpenReparsePoint = 0x00200000,
            OpenNoRecall = 0x00100000,
            FirstPipeInstance = 0x00080000
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct REPARSE_DATA_BUFFER
        {
            /// <summary>
            /// Reparse point tag. Must be a Microsoft reparse point tag.
            /// </summary>
            public uint ReparseTag;

            /// <summary>
            /// Size, in bytes, of the data after the Reserved member. This can be calculated by:
            /// (4 * sizeof(ushort)) + SubstituteNameLength + PrintNameLength +
            /// (namesAreNullTerminated ? 2 * sizeof(char) : 0);
            /// </summary>
            public ushort ReparseDataLength;

            /// <summary>
            /// Reserved; do not use.
            /// </summary>
            public ushort Reserved;

            /// <summary>
            /// Offset, in bytes, of the substitute name string in the PathBuffer array.
            /// </summary>
            public ushort SubstituteNameOffset;

            /// <summary>
            /// Length, in bytes, of the substitute name string. If this string is null-terminated,
            /// SubstituteNameLength does not include space for the null character.
            /// </summary>
            public ushort SubstituteNameLength;

            /// <summary>
            /// Offset, in bytes, of the print name string in the PathBuffer array.
            /// </summary>
            public ushort PrintNameOffset;

            /// <summary>
            /// Length, in bytes, of the print name string. If this string is null-terminated,
            /// PrintNameLength does not include space for the null character.
            /// </summary>
            public ushort PrintNameLength;

            /// <summary>
            /// A buffer containing the unicode-encoded path string. The path string contains
            /// the substitute name string and print name string.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x3FF0)]
            public byte[] PathBuffer;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetVolumeInformation(
            string lpRootPathName,
            StringBuilder lpVolumeNameBuffer,
            int nVolumeNameSize,
            ref int lpVolumeSerialNumber,
            out int lpMaximumComponentLength,
            out EFileSystemFlags lpFileSystemFlags,
            StringBuilder lpFileSystemNameBuffer,
            int nFileSystemNameSize
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool DeviceIoControl(
            IntPtr hDevice, uint dwIoControlCode,
            IntPtr InBuffer, int nInBufferSize,
            IntPtr OutBuffer, int nOutBufferSize,
            out int pBytesReturned, IntPtr lpOverlapped
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreateFile(
            string lpFileName,
            EFileAccess dwDesiredAccess,
            EFileShare dwShareMode,
            IntPtr lpSecurityAttributes,
            ECreationDisposition dwCreationDisposition,
            EFileAttributes dwFlagsAndAttributes,
            IntPtr hTemplateFile
        );

        public static bool PathIsSupportReparsePoint(string targetDirectory)
        {
            targetDirectory = Path.GetFullPath(targetDirectory);
            /*
            if (!Directory.Exists(targetDirectory)) {
                throw new IOException($"{nameof(targetDirectory)} 指定的目标目录“{targetDirectory}”不存在");
            }
            //*/

            string rootPathName = Path.GetPathRoot(targetDirectory);
            if (!String.IsNullOrEmpty(rootPathName)) {
                return VolumeIsSupportReparsePoint(rootPathName);
            }
            else {
                throw new IOException($"{nameof(targetDirectory)} 指定的目标目录“{targetDirectory}”不存在根路径，请使用绝对路径");
            }
        }

        public static bool VolumeIsSupportReparsePoint(string targetVolume)
        {
            StringBuilder volumeName = new StringBuilder(PathUtils.MAX_PATH);
            int volumeSerialNumber = 0;
            int maxComponentLength = 0;
            StringBuilder fileSystemName = new StringBuilder(PathUtils.MAX_PATH);
            EFileSystemFlags fileSystemFlags = 0;
            bool result = GetVolumeInformation(
                targetVolume,
                volumeName, volumeName.Capacity,
                ref volumeSerialNumber,
                out maxComponentLength,
                out fileSystemFlags,
                fileSystemName, fileSystemName.Capacity
            );
            if (result) {
                return fileSystemFlags.HasFlag(EFileSystemFlags.FILE_SUPPORTS_REPARSE_POINTS);
            }
            else {
                ThrowLastWin32Error($"无法获取目标卷“{targetVolume}”的信息");
                return false;
            }
        }

        /// <summary>
        /// 为目标目录创建一个指向目标目录的目录联接。
        /// </summary>
        /// <remarks>
        /// 注意，此方法仅在 NTFS 分区上才会生效。
        /// </remarks>
        /// <param name="junctionPoint">目录联接的路径。</param>
        /// <param name="targetDirectory">要联接的目标目录。</param>
        /// <param name="overwrite">If true overwrites an existing reparse point or empty directory</param>
        /// <exception cref="IOException">
        /// 如果无法创建目录联接则抛出异常。或者 <paramref name="overwrite" /> 为 false 时，当前目录联接路径已经存在。
        /// </exception>
        public static void Create(string junctionPoint, string targetDirectory, bool overwrite)
        {
            targetDirectory = Path.GetFullPath(targetDirectory);

            if (!Directory.Exists(targetDirectory)) {
                throw new IOException($"{nameof(targetDirectory)} 指定的目标目录“{targetDirectory}”不存在");
            }

            if (Directory.Exists(junctionPoint)) {
                if (!overwrite) {
                    throw new IOException($"软链接：“{junctionPoint}”已经存在，如果需要替换，请设置 {nameof(overwrite)} 为 true");
                }
            }
            else {
                Directory.CreateDirectory(junctionPoint);
            }

            using (SafeFileHandle handle = OpenReparsePoint(junctionPoint, EFileAccess.GenericWrite)) {
                var targetDirectoryBytes = Encoding.Unicode.GetBytes(NonInterpretedPathPrefix + Path.GetFullPath(targetDirectory));

                var reparseDataBuffer = new REPARSE_DATA_BUFFER
                {
                    ReparseTag = IO_REPARSE_TAG_MOUNT_POINT,
                    ReparseDataLength = (ushort)(targetDirectoryBytes.Length + 12),
                    SubstituteNameOffset = 0,
                    SubstituteNameLength = (ushort)targetDirectoryBytes.Length,
                    PrintNameOffset = (ushort)(targetDirectoryBytes.Length + 2),
                    PrintNameLength = 0,
                    PathBuffer = new byte[0x3ff0]
                };
                Array.Copy(targetDirectoryBytes, reparseDataBuffer.PathBuffer, targetDirectoryBytes.Length);

                var inBufferSize = Marshal.SizeOf(reparseDataBuffer);
                var inBuffer = Marshal.AllocHGlobal(inBufferSize);
                var bytesReturned = 0;

                try {
                    Marshal.StructureToPtr(reparseDataBuffer, inBuffer, false);

                    var result = DeviceIoControl(handle.DangerousGetHandle(), FSCTL_SET_REPARSE_POINT,
                        inBuffer, targetDirectoryBytes.Length + 20, IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);

                    if (!result) {
                        ThrowLastWin32Error("无法创建软链接。");
                    }
                }
                finally {
                    Marshal.FreeHGlobal(inBuffer);
                }
            }
        }

        /// <summary>
        /// Deletes a junction point at the specified source directory along with the directory itself.
        /// Does nothing if the junction point does not exist.
        /// </summary>
        /// <remarks>
        /// Only works on NTFS.
        /// </remarks>
        /// <param name="junctionPoint">The junction point path</param>
        public static void Delete(string junctionPoint)
        {
            if (!Directory.Exists(junctionPoint)) {
                if (File.Exists(junctionPoint)) {
                    throw new IOException($"指定的路径: “{junctionPoint}”不是一个 junction point");
                }

                return;
            }

            using (SafeFileHandle handle = OpenReparsePoint(junctionPoint, EFileAccess.GenericWrite)) {
                var reparseDataBuffer = new REPARSE_DATA_BUFFER
                {
                    ReparseTag = IO_REPARSE_TAG_MOUNT_POINT,
                    ReparseDataLength = 0,
                    PathBuffer = new byte[0x3ff0]
                };

                var inBufferSize = Marshal.SizeOf(reparseDataBuffer);
                var inBuffer = Marshal.AllocHGlobal(inBufferSize);
                var bytesReturned = 0;
                try {
                    Marshal.StructureToPtr(reparseDataBuffer, inBuffer, false);

                    var result = DeviceIoControl(handle.DangerousGetHandle(), FSCTL_DELETE_REPARSE_POINT,
                        inBuffer, 8, IntPtr.Zero, 0, out bytesReturned, IntPtr.Zero);

                    if (!result) {
                        ThrowLastWin32Error($"无法删除 junction point，路径为：“{junctionPoint}”");
                    }
                }
                finally {
                    Marshal.FreeHGlobal(inBuffer);
                }

                try {
                    Directory.Delete(junctionPoint);
                }
                catch (IOException ex) {
                    throw new IOException($"无法删除 junction point，路径为：“{junctionPoint}”", ex);
                }
            }
        }

        /// <summary>
        /// Determines whether the specified path exists and refers to a junction point.
        /// </summary>
        /// <param name="path">The junction point path</param>
        /// <returns>True if the specified path represents a junction point</returns>
        /// <exception cref="IOException">Thrown if the specified path is invalid
        /// or some other error occurs</exception>
        public static bool Exists(string path)
        {
            if (!Directory.Exists(path)) {
                return false;
            }

            using (SafeFileHandle handle = OpenReparsePoint(path, EFileAccess.GenericRead)) {
                var target = InternalGetTarget(handle);
                return target != null;
            }
        }

        /// <summary>
        /// Gets the target of the specified junction point.
        /// </summary>
        /// <remarks>
        /// Only works on NTFS.
        /// </remarks>
        /// <param name="junctionPoint">The junction point path</param>
        /// <returns>The target of the junction point</returns>
        /// <exception cref="IOException">Thrown when the specified path does not
        /// exist, is invalid, is not a junction point, or some other error occurs</exception>
        public static string GetTarget(string junctionPoint)
        {
            using (SafeFileHandle handle = OpenReparsePoint(junctionPoint, EFileAccess.GenericRead)) {
                var target = InternalGetTarget(handle);
                if (target == null) {
                    throw new IOException($"指定的路径: {junctionPoint} 不是一个 junction point");
                }

                return target;
            }
        }

        private static string InternalGetTarget(SafeFileHandle handle)
        {
            var outBufferSize = Marshal.SizeOf(typeof(REPARSE_DATA_BUFFER));
            var outBuffer = Marshal.AllocHGlobal(outBufferSize);
            var bytesReturned = 0;

            try {
                var result = DeviceIoControl(handle.DangerousGetHandle(), FSCTL_GET_REPARSE_POINT,
                    IntPtr.Zero, 0, outBuffer, outBufferSize, out bytesReturned, IntPtr.Zero);

                if (!result) {
                    var error = Marshal.GetLastWin32Error();
                    if (error == ERROR_NOT_A_REPARSE_POINT) {
                        return null;
                    }

                    ThrowLastWin32Error("无法获取 junction point 的信息。");
                }

                var reparseDataBuffer = (REPARSE_DATA_BUFFER)
                    Marshal.PtrToStructure(outBuffer, typeof(REPARSE_DATA_BUFFER));

                if (reparseDataBuffer.ReparseTag != IO_REPARSE_TAG_MOUNT_POINT) {
                    return null;
                }

                var targetDir = Encoding.Unicode.GetString(reparseDataBuffer.PathBuffer,
                    reparseDataBuffer.SubstituteNameOffset, reparseDataBuffer.SubstituteNameLength);

                if (targetDir.StartsWith(NonInterpretedPathPrefix)) {
                    targetDir = targetDir.Substring(NonInterpretedPathPrefix.Length);
                }

                return targetDir;
            }
            finally {
                Marshal.FreeHGlobal(outBuffer);
            }
        }

        private static SafeFileHandle OpenReparsePoint(string reparsePoint, EFileAccess accessMode)
        {
            var reparsePointHandle = new SafeFileHandle(CreateFile(reparsePoint, accessMode,
                EFileShare.Read | EFileShare.Write | EFileShare.Delete,
                IntPtr.Zero, ECreationDisposition.OpenExisting,
                EFileAttributes.BackupSemantics | EFileAttributes.OpenReparsePoint, IntPtr.Zero), true);

            if (Marshal.GetLastWin32Error() != 0) {
                ThrowLastWin32Error("无法打开 reparse point。");
            }

            return reparsePointHandle;
        }

        private static void ThrowLastWin32Error(string message)
        {
            throw new IOException(message, Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()));
        }
    }
}