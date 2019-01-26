using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;
using DasUberScroller.UWP.Screens;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly GameScreenManager _gameScreenManager;
        
        private WindowContainer WindowContainer => new WindowContainer
        {
            ResolutionX = Window.ClientBounds.Width,
            ResolutionY = Window.ClientBounds.Height
        };

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Window.ClientSizeChanged += Window_ClientSizeChanged;

            _gameScreenManager = new GameScreenManager(Content);
        }

        private void Window_ClientSizeChanged(object sender, System.EventArgs e)
        {
            _gameScreenManager.UpdateCurrentScreenWindow(WindowContainer);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _gameScreenManager.LoadScreen(new LevelScreen(), WindowContainer);
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            
            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _gameScreenManager.UpdateCurrentScreen(state, gameTime);
            
            base.Update(gameTime);
        }

        [System.Obsolete]
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _gameScreenManager.RenderCurrentScreen(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}