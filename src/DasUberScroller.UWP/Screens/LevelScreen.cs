using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;
using DasUberScroller.UWP.Objects;

namespace DasUberScroller.UWP.Screens
{
    public class LevelScreen : BaseScreen
    {
        public override bool LoadContent(GameContentManager gameContentManager, WindowContainer windowContainer)
        {
            var player = new Player(gameContentManager, windowContainer);
            var level = new Level(Common.Constants.DEFAULT_LEVEL_NAME, gameContentManager, windowContainer);
            
            AddObject(level);
            AddObject(player);

            return true;
        }
    }
}