using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects
{
    public class FsBillboard : BaseObject
    {
        private readonly string _textureName;

        public FsBillboard(string textureName, WindowContainer windowContainer) : base(windowContainer)
        {
            _textureName = textureName;
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            spriteBatch.Draw(gameContentManager.GetTexture(_textureName), Vector2.Zero, sourceRectangle: new Rectangle(0,0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), scale: new Vector2(WindowContainer.ScaleResolutionX, WindowContainer.ScaleResolutionY), color: Color.White);
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
        }
    }
}