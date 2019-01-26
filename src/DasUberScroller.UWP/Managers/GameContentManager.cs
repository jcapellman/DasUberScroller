using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DasUberScroller.UWP.Managers
{
    public class GameContentManager
    {
        private Dictionary<string, Texture2D> _textures;

        private readonly ContentManager _contentManager;

        public GameContentManager(ContentManager contentManager)
        {
            _textures = new Dictionary<string, Texture2D>();

            _contentManager = contentManager;
        }

        public bool LoadTexture(string name)
        {
            if (_textures.ContainsKey(name))
            {
                return true;
            }

            _textures.Add(name, _contentManager.Load<Texture2D>(name));

            return true;
        }

        public Texture2D GetTexture(string name) => !_textures.ContainsKey(name) ? null : _textures[name];
    }
}