using System.Linq;

using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;
using DasUberScroller.UWP.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Screens
{
    public class SplashScreen : BaseScreen
    {
        private const string TextureName = "Splash";

        public override bool LoadContent(GameContentManager gameContentManager, WindowContainer windowContainer)
        {
            gameContentManager.LoadTexture(TextureName);

            AddObject(new FSBillboard(TextureName, windowContainer));

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