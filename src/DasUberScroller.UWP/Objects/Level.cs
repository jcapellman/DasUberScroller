using System;
using System.IO;

using Windows.Storage;

using DasUberScroller.UWP.Common;
using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.JSONObjects;
using DasUberScroller.UWP.Managers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Newtonsoft.Json;

namespace DasUberScroller.UWP.Objects
{
    public class Level : BaseObject
    {
        private int _animationFrameX = 0;
        
        private readonly TextureContainer _floorTextureContainer;

        private LevelJSON _levelJson;

        private LevelJSON LoadLevel(string levelName)
        {
            var filePath = Path.Combine(Constants.PATH_LEVELS, $"{levelName}{Constants.FILE_EXTENSION_LEVEL}");

            var appUri = new Uri(filePath);
            var anjFile = StorageFile.GetFileFromApplicationUriAsync(appUri).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();
            var jsonText = FileIO.ReadTextAsync(anjFile).AsTask().ConfigureAwait(false).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject<JSONObjects.LevelJSON>(jsonText);            
        }

        public Level(string levelName, GameContentManager contentManager, WindowContainer windowContainer) : base(windowContainer)
        {
            _levelJson = LoadLevel(levelName);

            var (loaded, texture) = contentManager.LoadTexture(_levelJson.TextureFloor);

            if (loaded)
            {
                _floorTextureContainer = texture;
            }

            if (!string.IsNullOrEmpty(_levelJson.TextureAtmosphere))
            {
                contentManager.LoadTexture(_levelJson.TextureAtmosphere);
            }

            if (!string.IsNullOrEmpty(_levelJson.TextureAtmosphereOverlay))
            {
                contentManager.LoadTexture(_levelJson.TextureAtmosphereOverlay);
            }
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            Draw(_levelJson.TextureAtmosphere, new Rectangle(0, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), spriteBatch, gameContentManager);

            Draw(_levelJson.TextureAtmosphereOverlay, new Rectangle(0 + _animationFrameX, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY), spriteBatch, gameContentManager);
            
            Draw(_floorTextureContainer.Name, 
                new Rectangle(0, 0, WindowContainer.ResolutionX, _floorTextureContainer.Height), 
                new Vector2(0, WindowContainer.ResolutionY - _floorTextureContainer.Height), 
                1.0f, 
                spriteBatch, 
                gameContentManager);
        }

        public override void Update(KeyboardState keyboardState, GameTime gameTime)
        {
            if (_animationFrameX < (-1 * WindowContainer.ResolutionX))
            {
                _animationFrameX = WindowContainer.ResolutionX;
            }
            else
            {
                _animationFrameX -= 1;
            }
        }
    }
}