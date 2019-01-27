﻿using System;
using System.Collections.Generic;
using System.Linq;

using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Managers;
using DasUberScroller.UWP.Objects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.UWP.Screens
{
    public abstract class BaseScreen
    {
        private List<BaseObject> _gameObjects = new List<BaseObject>();

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