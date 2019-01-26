using DasUberScroller.UWP.Containers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
        public void Render(SpriteBatch spriteBatch)
        {
            if (_animationFrameX < (-1 * WindowContainer.ResolutionX))
            {
                _animationFrameX = WindowContainer.ResolutionX;
            }
            else
            {
                _animationFrameX -= 1;
            }

            spriteBatch.Draw(_clouds, new Rectangle(0, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), Color.White);
            spriteBatch.Draw(_animatedClouds, new Vector2(0 + _animationFrameX, 0));

            spriteBatch.Draw(_road, new Rectangle(0, WindowContainer.ResolutionY - 184, WindowContainer.ResolutionX, 184), Color.White);
        }
    }
}