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
        private Player _player;
        private Level _level;

        private WindowContainer WindowContainer => new WindowContainer
        {
            ResolutionX = Window.ClientBounds.Width,
            ResolutionY = Window.ClientBounds.Height
        };

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player = new Player(Content.Load<Texture2D>("hero_spritesheet"), WindowContainer);
            _level = new Level(Content.Load<Texture2D>("road"), Content.Load<Texture2D>("clouds1"), Content.Load<Texture2D>("clouds2"), WindowContainer);
        }

        protected override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();
            
            // If they hit esc, exit
            if (state.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _player.Update(state, gameTime);

            base.Update(gameTime);
        }

        [System.Obsolete]
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _level.Render(_spriteBatch);

            _player.Render(_spriteBatch);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}