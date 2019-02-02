using DasUberScroller.lib.Containers;
using DasUberScroller.lib.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.lib.Objects
{
    public class Bullet : BaseObject
    {
        private const string TextureName = "bullet";

        public Bullet(GameContentManager gameContentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            gameContentManager.LoadTexture(TextureName);
        }
        
        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {

        }
    }
}