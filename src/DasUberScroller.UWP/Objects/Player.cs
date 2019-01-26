using DasUberScroller.UWP.Containers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects
{
    public class Player : BaseObject
    {
        private Texture2D _playerSheet;
        private int column;
        private int row;
        private int _xPosition;

        private double _lastMs = 0;

        private const double Delay = 34;

        public Player(Texture2D texture, WindowContainer windowContainer) : base(windowContainer)
        {
            _playerSheet = texture;

            column = 0;
            row = 1;

            _xPosition = 0;
        }

        [System.Obsolete]
        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerSheet, position: new Vector2(_xPosition, WindowContainer.ResolutionY - 300),
                sourceRectangle: new Rectangle(column * 80, row * 100, 80, 100), color: Color.White, scale: new Vector2(3.0f, 3.0f));
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
            _lastMs += gameTime.ElapsedGameTime.TotalMilliseconds;

            if (_lastMs < Delay)
            {
                return;
            }

            _lastMs = 0;

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                if (column == 5)
                {
                    column = 0;
                }
                else
                {
                    column++;
                }

                _xPosition+=10;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                if (column == 5)
                {
                    column = 0;
                }
                else
                {
                    column++;
                }

                _xPosition-=10;
            }
        }
    }
}