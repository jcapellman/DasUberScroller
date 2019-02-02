using System.Linq;

using DasUberScroller.lib.Containers;
using DasUberScroller.lib.Managers;
using DasUberScroller.lib.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.lib.Screens
{
    public class SplashScreen : BaseScreen
    {
        private const string TextureName = "Splash";

        public override bool LoadContent(GameContentManager gameContentManager, WindowContainer windowContainer)
        {
            gameContentManager.LoadTexture(TextureName);

            AddObject(new FsBillboard(TextureName, windowContainer));

            return true;
        }

        public override void UpdateScreen(KeyboardState keyboardState, GameTime gameTime)
        {
            if (!keyboardState.GetPressedKeys().Any())
            {
                return;
            }

            OnChangeScreen(null, new LevelScreen());
        }
    }
}