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

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _player = new Player(Content.Load<Texture2D>("hero_spritesheet"), Window.ClientBounds.Height);
            _level = new Level(Content.Load<Texture2D>("road"), Content.Load<Texture2D>("clouds1"), Content.Load<Texture2D>("clouds2"), Window.ClientBounds.Height);
        }
        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
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