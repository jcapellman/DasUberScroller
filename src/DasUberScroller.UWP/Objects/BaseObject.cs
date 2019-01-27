using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Objects
{
    public abstract class BaseObject
    {
        protected WindowContainer WindowContainer;

        protected BaseObject(WindowContainer windowContainer)
        {
            WindowContainer = windowContainer;
        }

        public void UpdateWindow(WindowContainer windowContainer)
        {
            WindowContainer = windowContainer;
        }

        public abstract void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager);
        
        public abstract void Update(KeyboardState keyboardState, GameTime gameTime);

        protected void Draw(string textureName, Rectangle source, SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            spriteBatch.Draw(
                gameContentManager.GetTexture(textureName), 
                Vector2.Zero, 
                source, 
                Color.White, 
                0.0f, 
                Vector2.Zero, 
                new Vector2(WindowContainer.ScaleResolutionX, WindowContainer.ScaleResolutionY), 
                SpriteEffects.None, 
                1.0f);
        }
    }
}