using System;
using System.IO;

using Windows.Storage;

using DasUberScroller.lib.PlatformAbstractions;
using DasUberScroller.library.Common;

namespace DasUberScroller.UWP.PlatformImplementations
{
    public class UWPFileSystem : IFileSystem
    {
        public string LevelPath => "ms-appx:///Assets/Levels/";

        public ReturnSet<string> ReadTextFromFile(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new ArgumentNullException(fileName);
                }

                var appUri = new Uri(fileName);
                
                var anjFile = StorageFile.GetFileFromApplicationUriAsync(appUri).AsTask().ConfigureAwait(false)
                    .GetAwaiter().GetResult();

                if (anjFile == null)
                {
                    throw new FileNotFoundException(fileName);
                }

                return new ReturnSet<string>(FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult());
            }
            catch (ArgumentNullException argumentNullException)
            {
                return new ReturnSet<string>(argumentNullException);
            }
            catch (FileNotFoundException fileNotFoundException)
            {
                return new ReturnSet<string>(fileNotFoundException);
            }
        }
    }
}