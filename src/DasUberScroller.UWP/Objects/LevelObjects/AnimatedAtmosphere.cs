using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;
using DasUberScroller.UWP.Objects.LevelObjects.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects.LevelObjects
{
    public class AnimatedAtmosphere : LevelObject
    {
        private int _animationFrameX = 0;
        
        public AnimatedAtmosphere(string textureName, GameContentManager contentManager, WindowContainer windowContainer) : base(textureName, contentManager, windowContainer)
        {
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            Draw(TextureContainer.Name, new Rectangle(0 + _animationFrameX, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), spriteBatch, gameContentManager);
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