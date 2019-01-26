using DasUberScroller.UWP.Containers;

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

        public abstract void Render(SpriteBatch spriteBatch);
        
        public abstract void Update(KeyboardState keyboardState, GameTime gameTime);
    }
}