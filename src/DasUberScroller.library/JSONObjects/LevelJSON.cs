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
            var filePath = Path.Combine(Constants.PATH_LEVELS, $"{levelName}{Constants.FILE_EXTENSION_LEVEL}");

            var jsonText = DIContainer.GetDIService<IFileSystem>().ReadTextFromFile(filePath);
            
            return JsonConvert.DeserializeObject<LevelJSON>(jsonText);
        }
    }
}