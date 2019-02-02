using System;
using System.Collections.Generic;
using System.Linq;

using DasUberScroller.lib.Containers;
using DasUberScroller.lib.Managers;
using DasUberScroller.lib.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.lib.Screens
{
    public abstract class BaseScreen
    {
        private readonly List<BaseObject> _gameObjects = new List<BaseObject>();

        public event EventHandler<BaseScreen> ChangeScreen;

        protected void OnChangeScreen(object sender, BaseScreen screen)
        {
            ChangeScreen?.Invoke(sender, screen);
        }

        protected void AddObject(BaseObject obj)
        {
            _gameObjects.Add(obj);
        }

        public abstract bool LoadContent(GameContentManager gameContentManager, WindowContainer windowContainer);

        public void RenderScreen(SpriteBatch spireBatch, GameContentManager gameContentManager)
        {
            foreach (var gameObject in _gameObjects.Where(a => a.IsActive))
            {
                gameObject.Render(spireBatch, gameContentManager);
            }
        }

        public void UpdateWindow(WindowContainer windowContainer)
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.UpdateWindow(windowContainer);
            }
        }

        public virtual void UpdateScreen(KeyboardState keyboardState, GameTime gameTime)
        {
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update(keyboardState, gameTime);
            }
        }
    }
}