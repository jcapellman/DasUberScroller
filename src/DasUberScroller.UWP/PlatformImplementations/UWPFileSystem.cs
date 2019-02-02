using System;

using Windows.Storage;

using DasUberScroller.lib.PlatformAbstractions;

namespace DasUberScroller.UWP.PlatformImplementations
{
    public class UWPFileSystem : IFileSystem
    {
        public string ReadTextFromFile(string fileName)
        {
            var appUri = new Uri(fileName);

            var anjFile = StorageFile.GetFileFromApplicationUriAsync(appUri).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();

            return FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}