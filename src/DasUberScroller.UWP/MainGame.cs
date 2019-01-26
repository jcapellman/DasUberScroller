using System.Collections.Generic;

using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Objects;

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

        private List<BaseObject> _gameObjects = new List<BaseObject>();

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
        }

        private void Window_ClientSizeChanged(object sender, System.EventArgs e)
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.UpdateWindow(WindowContainer);
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var player = new Player(Content.Load<Texture2D>("hero_spritesheet"), WindowContainer);
            var level = new Level(Content.Load<Texture2D>("road"), Content.Load<Texture2D>("clouds1"), Content.Load<Texture2D>("clouds2"), WindowContainer);

            _gameObjects.Add(level);
            _gameObjects.Add(player);
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            
            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update(state, gameTime);
            }
            
            base.Update(gameTime);
        }

        [System.Obsolete]
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            foreach (var gameObject in _gameObjects)
            {
                gameObject.Render(_spriteBatch);
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}