using System;
using System.Collections.Generic;
using System.IO;

using Windows.Storage;

using DasUberScroller.UWP.Common;

using Newtonsoft.Json;

namespace DasUberScroller.UWP.JSONObjects
{
    public class LevelJSON
    {
        public string Title { get; set; }

        public List<LevelScreenContentJSON> Screens { get; set; }

        public static LevelJSON LoadLevel(string levelName)
        {
            var filePath = Path.Combine(Constants.PATH_LEVELS, $"{levelName}{Constants.FILE_EXTENSION_LEVEL}");

            var appUri = new Uri(filePath);
            var anjFile = StorageFile.GetFileFromApplicationUriAsync(appUri).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
            var jsonText = FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<JSONObjects.LevelJSON>(jsonText);
        }
    }
}