using Xunit;

using u3devtools.utils;

namespace utils.tests
{
    public class PathUtilsUnitTest
    {
        [Theory]
        [InlineData("path/to/parent/child", "path\\to\\parent")]
        [InlineData("path\\to\\parent\\child", "path\\to\\parent")]
        [InlineData("path/to/parent/child/", "path\\to\\parent")]
        [InlineData("path\\to\\parent\\child\\", "path\\to\\parent")]
        public void GetParentPath(string path, string expected)
        {
            var result = PathUtils.GetParentPath(path);

            Assert.Equal(expected, result);
        }
    }
}
