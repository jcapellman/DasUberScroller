using System.Collections.Generic;

namespace DasUberScroller.UWP.JSONObjects
{
    public class LevelJSON
    {
        public string Title { get; set; }

        public List<LevelScreenContentJSON> Screens { get; set; }
    }
}