using DasUberScroller.library.Common;

namespace DasUberScroller.lib.PlatformAbstractions
{
    public interface IFileSystem
    {
        string LevelPath { get; }

        ReturnSet<string> ReadTextFromFile(string fileName);
    }
}