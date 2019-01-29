using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects
{
    public class Floor : BaseObject
    {
        private readonly TextureContainer _floorTextureContainer;

        public Floor(string textureName, GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            var (loaded, texture) = contentManager.LoadTexture(textureName);

            if (loaded)
            {
                _floorTextureContainer = texture;
            }
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            Draw(_floorTextureContainer.Name,
                new Rectangle(0, 0, WindowContainer.ResolutionX, _floorTextureContainer.Height),
                new Vector2(0, WindowContainer.ResolutionY - _floorTextureContainer.Height),
                1.0f,
                spriteBatch,
                gameContentManager);
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
        }
    }
}