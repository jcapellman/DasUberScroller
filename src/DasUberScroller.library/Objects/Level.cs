using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using DasUberScroller.lib.Containers;
using DasUberScroller.lib.JSONObjects;
using DasUberScroller.lib.Managers;
using DasUberScroller.lib.Objects.LevelObjects.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DasUberScroller.lib.Objects
{
    public class Level : BaseObject
    {
        private readonly List<BaseObject> _levelObjects = new List<BaseObject>();
        
        private static List<LevelObject> GetLevelObjects() =>
            Assembly.GetAssembly(typeof(LevelObject)).DefinedTypes
                .Where(a => !a.IsAbstract && a.BaseType == typeof(LevelObject)).Select(a => (LevelObject)Activator.CreateInstance(a)).ToList();

        public Level(string levelName, GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            var levelJson = LevelJSON.LoadLevel(levelName);

            var levelObjects = GetLevelObjects();

            foreach (var screen in levelJson.Screens)
            {
                foreach (var item in screen.Items)
                {
                    var baseLevelObject = levelObjects.FirstOrDefault(a => a.ContentType == item.LevelContentType);

                    if (baseLevelObject == null)
                    {
                        // TODO Log Invalid Type
                        continue;
                    }

                    var levelObject = (LevelObject) Activator.CreateInstance(baseLevelObject.GetType(), item.TextureName, contentManager, windowContainer);

                    _levelObjects.Add(levelObject);
                }
            }
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            foreach (var levelObject in _levelObjects)
            {
                levelObject.Render(spriteBatch, gameContentManager);
            }
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
        }
    }
}