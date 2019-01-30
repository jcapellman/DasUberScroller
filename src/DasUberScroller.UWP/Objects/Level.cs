using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Windows.Storage;

using DasUberScroller.UWP.Common;
using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.JSONObjects;
using DasUberScroller.UWP.Managers;
using DasUberScroller.UWP.Objects.LevelObjects.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Newtonsoft.Json;

namespace DasUberScroller.UWP.Objects
{
    public class Level : BaseObject
    {
        private readonly List<BaseObject> _levelObjects = new List<BaseObject>();

        private static LevelJSON LoadLevel(string levelName)
        {
            var filePath = Path.Combine(Constants.PATH_LEVELS, $"{levelName}{Constants.FILE_EXTENSION_LEVEL}");

            var appUri = new Uri(filePath);
            var anjFile = StorageFile.GetFileFromApplicationUriAsync(appUri).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
            var jsonText = FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<JSONObjects.LevelJSON>(jsonText);            
        }

        private static List<LevelObject> GetLevelObjects() =>
            Assembly.GetAssembly(typeof(LevelObject)).DefinedTypes
                .Where(a => !a.IsAbstract && a.BaseType == typeof(LevelObject)).Select(a => (LevelObject)Activator.CreateInstance(a)).ToList();

        public Level(string levelName, GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            var levelJson = LoadLevel(levelName);

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