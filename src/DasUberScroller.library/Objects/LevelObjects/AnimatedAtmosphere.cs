using DasUberScroller.lib.Containers;
using DasUberScroller.lib.Enums;
using DasUberScroller.lib.Managers;
using DasUberScroller.lib.Objects.LevelObjects.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.lib.Objects.LevelObjects
{
    public class AnimatedAtmosphere : LevelObject
    {
        private int _animationFrameX = 0;
        
        public AnimatedAtmosphere() : base(null, null, null) { }

        public AnimatedAtmosphere(string textureName, GameContentManager contentManager, WindowContainer windowContainer) : base(textureName, contentManager, windowContainer)
        {
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            Draw(TextureContainer.Name, new Rectangle(0 + _animationFrameX, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), spriteBatch, gameContentManager);
        }

        public override LevelContentTypes ContentType => LevelContentTypes.AnimatedAtmosphere;

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