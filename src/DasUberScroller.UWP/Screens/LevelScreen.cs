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
            var level = new Level(gameContentManager, windowContainer);
            
            AddObject(level);
            AddObject(player);

            return true;
        }
    }
}