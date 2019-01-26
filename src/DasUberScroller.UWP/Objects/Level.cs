using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DasUberScroller.UWP.Objects
{
    public class Level
    {
        private Texture2D _road;

        public Level(Texture2D road)
        {
            _road = road;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_road, new Vector2(0, 10), new Rectangle(0, 0, 1920, 100), Color.White);
        }
    }
}