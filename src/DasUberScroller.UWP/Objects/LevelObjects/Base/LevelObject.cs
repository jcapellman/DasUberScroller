using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Enums;
using DasUberScroller.UWP.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects.LevelObjects.Base
{
    public abstract class LevelObject : BaseObject
    {
        protected readonly TextureContainer TextureContainer;

        public abstract LevelContentTypes ContentType { get; }

        protected LevelObject(string textureName, GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            if (string.IsNullOrEmpty(textureName))
            {
                return;
            }

            var (loaded, texture) = contentManager.LoadTexture(textureName);

            if (loaded)
            {
                TextureContainer = texture;
            }
        }
        
        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
        }
    }
}