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
        private WindowContainer _windowContainer;

        private BaseScreen _currentScreen;

        public GameScreenManager(ContentManager contentManager)
        {
            _gameContentManager = new GameContentManager(contentManager);
        }

        private void SwitchScreen(BaseScreen screen)
        {
            _currentScreen = screen;

            _currentScreen.ChangeScreen -= _currentScreen_ChangeScreen;
            _currentScreen.ChangeScreen += _currentScreen_ChangeScreen;

            _currentScreen.LoadContent(_gameContentManager, _windowContainer);
        }

        public void LoadScreen(BaseScreen screen, WindowContainer windowContainer)
        {
            _windowContainer = windowContainer;

            SwitchScreen(screen);
        }

        private void _currentScreen_ChangeScreen(object sender, BaseScreen screen)
        {
            SwitchScreen(screen);
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