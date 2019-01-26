using DasUberScroller.UWP.Containers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects
{
    public class Level : BaseObject
    {
        private Texture2D _road;
        private Texture2D _clouds;
        private Texture2D _animatedClouds;
        private int _animationFrameX = 0;

        public Level(Texture2D road, Texture2D clouds, Texture2D animatedClouds, WindowContainer windowContainer) : base(windowContainer)
        {
            _road = road;
            _clouds = clouds;
            _animatedClouds = animatedClouds;
        }

        [System.Obsolete]
        public override void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_clouds, new Rectangle(0, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), Color.White);
            spriteBatch.Draw(_animatedClouds, new Vector2(0 + _animationFrameX, 0), scale: new Vector2(WindowContainer.ScaleResolutionX, WindowContainer.ScaleResolutionY));

            spriteBatch.Draw(_road, new Rectangle(0, WindowContainer.ResolutionY - _road.Height, WindowContainer.ResolutionX, _road.Height), Color.White);
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
            if (_animationFrameX < (-1 * WindowContainer.ResolutionX))
            {
                _animationFrameX = WindowContainer.ResolutionX;
            }
            else
            {
                _animationFrameX -= 1;
            }
        }
    }
}