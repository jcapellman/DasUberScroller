using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects
{
    public class Level : BaseObject
    {
        private int _animationFrameX = 0;

        private const string TextureFloor = "road";
        private const string TextureClouds = "clouds1";
        private const string TextureAnimatedClouds = "clouds2";

        public Level(GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            contentManager.LoadTexture(TextureFloor);
            contentManager.LoadTexture(TextureClouds);
            contentManager.LoadTexture(TextureAnimatedClouds);
        }

        [System.Obsolete]
        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            spriteBatch.Draw(gameContentManager.GetTexture(TextureClouds), new Rectangle(0, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), Color.White);
            spriteBatch.Draw(gameContentManager.GetTexture(TextureClouds), new Vector2(0 + _animationFrameX, 0), scale: new Vector2(WindowContainer.ScaleResolutionX, WindowContainer.ScaleResolutionY));

            var floorTexture = gameContentManager.GetTexture(TextureFloor);

            spriteBatch.Draw(floorTexture, new Rectangle(0, WindowContainer.ResolutionY - floorTexture.Height, WindowContainer.ResolutionX, floorTexture.Height), Color.White);
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