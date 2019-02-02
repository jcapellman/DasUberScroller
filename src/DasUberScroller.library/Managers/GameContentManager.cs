using System.Collections.Generic;

using DasUberScroller.lib.Containers;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DasUberScroller.lib.Managers
{
    public class GameContentManager
    {
        private readonly Dictionary<string, Texture2D> _textures;

        private readonly ContentManager _contentManager;

        public GameContentManager(ContentManager contentManager)
        {
            _textures = new Dictionary<string, Texture2D>();

            _contentManager = contentManager;
        }

        public (bool Loaded, TextureContainer Texture) LoadTexture(string name)
        {
            if (!_textures.ContainsKey(name))
            {
                _textures.Add(name, _contentManager.Load<Texture2D>(name));
            }
            
            return (true, new TextureContainer {
                Width = _textures[name].Width,
                Height = _textures[name].Height,
                Name = name
            });
        }

        public Texture2D GetTexture(string name) => !_textures.ContainsKey(name) ? null : _textures[name];
    }
}