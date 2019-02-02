using DasUberScroller.library.Common;

namespace DasUberScroller.lib.PlatformAbstractions
{
    public interface IFileSystem
    {
        ReturnSet<string> ReadTextFromFile(string fileName);
    }
}