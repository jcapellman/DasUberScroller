using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects
{
    public class Atmosphere : BaseObject
    {
        private string _textureName;

        public Atmosphere(string textureName, GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            _textureName = textureName;

            contentManager.LoadTexture(textureName);
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            Draw(_textureName, new Rectangle(0, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), spriteBatch, gameContentManager);
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
        }
    }
}