using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DasUberScroller.UWP.Objects
{
    public class Level
    {
        private Texture2D _road;
        private int _yResolution;
        private Texture2D _clouds;
        private Texture2D _animatedClouds;
        private int _animationFrameX = 0;

        public Level(Texture2D road, Texture2D clouds, Texture2D animatedClouds, int yResolution)
        {
            _road = road;
            _clouds = clouds;
            _animatedClouds = animatedClouds;
            _yResolution = yResolution;
        }

        [System.Obsolete]
        public void Render(SpriteBatch spriteBatch)
        {
            if (_animationFrameX < -1920)
            {
                _animationFrameX = 0;
            }
            else
            {
                _animationFrameX -= 1;
            }

            spriteBatch.Draw(_clouds, new Rectangle(0, 0, 1920, 1080), Color.White);
            spriteBatch.Draw(_animatedClouds, new Vector2(0 + _animationFrameX, 0));

            spriteBatch.Draw(_road, new Rectangle(0, _yResolution - 184, 1920, 184), Color.White);
        }
    }
}