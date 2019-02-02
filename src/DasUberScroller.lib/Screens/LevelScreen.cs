using DasUberScroller.lib.Common;
using DasUberScroller.lib.Containers;
using DasUberScroller.lib.Managers;
using DasUberScroller.lib.Objects;

namespace DasUberScroller.lib.Screens
{
    public class LevelScreen : BaseScreen
    {
        public override bool LoadContent(GameContentManager gameContentManager, WindowContainer windowContainer)
        {
            var player = new Player(gameContentManager, windowContainer);
            var level = new Level(Constants.DEFAULT_LEVEL_NAME, gameContentManager, windowContainer);
            
            AddObject(level);
            AddObject(player);

            return true;
        }
    }
}