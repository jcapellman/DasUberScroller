using System.Collections.Generic;
using System.IO;

using DasUberScroller.lib.Common;
using DasUberScroller.lib.DI;
using DasUberScroller.lib.PlatformAbstractions;

using Newtonsoft.Json;

namespace DasUberScroller.lib.JSONObjects
{
    public class LevelJSON
    {
        public string Title { get; set; }

        public List<LevelScreenContentJSON> Screens { get; set; }

        public static LevelJSON LoadLevel(string levelName)
        {
            var filePath = Path.Combine(DIContainer.GetDIService<IFileSystem>().LevelPath, $"{levelName}{Constants.FILE_EXTENSION_LEVEL}");

            var jsonTextResult = DIContainer.GetDIService<IFileSystem>().ReadTextFromFile(filePath);

            if (jsonTextResult.HasErrorOrNull)
            {
                throw jsonTextResult.Error;
            }

            return JsonConvert.DeserializeObject<LevelJSON>(jsonTextResult.Value);
        }
    }
}