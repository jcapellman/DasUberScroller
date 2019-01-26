using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Screens;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Managers
{
    public class GameScreenManager
    {
        private GameContentManager _gameContentManager;

        private BaseScreen _currentScreen;

        public GameScreenManager(ContentManager contentManager)
        {
            _gameContentManager = new GameContentManager(contentManager);
        }

        public void LoadScreen(BaseScreen screen, WindowContainer windowContainer)
        {
            _currentScreen = screen;

            _currentScreen.LoadContent(_gameContentManager, windowContainer);
        }

        public void RenderCurrentScreen(SpriteBatch spriteBatch)
        {
            _currentScreen.RenderScreen(spriteBatch, _gameContentManager);
        }

        public void UpdateCurrentScreen(KeyboardState state, GameTime gameTime)
        {
            _currentScreen.UpdateScreen(state, gameTime);
        }

        public void UpdateCurrentScreenWindow(WindowContainer windowContainer)
        {
            _currentScreen.UpdateWindow(windowContainer);
        }
    }
}