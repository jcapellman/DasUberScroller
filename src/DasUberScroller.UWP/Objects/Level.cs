using System;
using System.Collections.Generic;
using System.IO;

using Windows.Storage;

using DasUberScroller.UWP.Common;
using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.JSONObjects;
using DasUberScroller.UWP.Managers;
using DasUberScroller.UWP.Objects.LevelObjects;
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

        public Level(string levelName, GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            var levelJson = LoadLevel(levelName);

            if (!string.IsNullOrEmpty(levelJson.TextureFloor))
            {
                _levelObjects.Add(new Floor(levelJson.TextureFloor, contentManager, windowContainer));
            }

            if (!string.IsNullOrEmpty(levelJson.TextureAtmosphere))
            {
                _levelObjects.Add(new Atmosphere(levelJson.TextureAtmosphere, contentManager, windowContainer));
            }

            if (!string.IsNullOrEmpty(levelJson.TextureAtmosphereOverlay))
            {
                _levelObjects.Add(new AnimatedAtmosphere(levelJson.TextureAtmosphereOverlay, contentManager, windowContainer));
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