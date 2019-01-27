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

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            Draw(TextureClouds, new Rectangle(0, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), spriteBatch, gameContentManager);

            Draw(TextureAnimatedClouds, new Rectangle(0 + _animationFrameX, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), spriteBatch, gameContentManager);
            
            var floorTexture = gameContentManager.GetTexture(TextureFloor);

            Draw(TextureFloor, new Rectangle(0, 0, WindowContainer.ResolutionX, floorTexture.Height), new Vector2(0, WindowContainer.ResolutionY - floorTexture.Height), 1.0f, spriteBatch, gameContentManager);
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