using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects.LevelObjects.Base
{
    public abstract class LevelObject : BaseObject
    {
        protected readonly TextureContainer TextureContainer;

        protected LevelObject(string textureName, GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
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