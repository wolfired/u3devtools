using System.IO;

namespace u3devtools.utils
{
    public class PathUtils
    {
        /// <summary>获取指定路径的父路径</summary>
        /// <param name="path">文件/文件夹路径</param>
        /// <example>
        /// <code>
        ///     string parent_path = PathUtils.GetParentPath("/home/user/parent/child");
        /// </code>
        /// </example>
        public static string GetParentPath(string path)
        {
            return Path.GetDirectoryName(path.TrimEnd(new char[]{Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar}));
        }
    }
}
