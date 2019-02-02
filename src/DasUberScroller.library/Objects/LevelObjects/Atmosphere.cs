using DasUberScroller.lib.Containers;
using DasUberScroller.lib.Enums;
using DasUberScroller.lib.Managers;
using DasUberScroller.lib.Objects.LevelObjects.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DasUberScroller.lib.Objects.LevelObjects
{
    public class Atmosphere : LevelObject
    {
        public Atmosphere() : base(null, null, null) { }

        public Atmosphere(string textureName, GameContentManager contentManager, WindowContainer windowContainer) : base(textureName, contentManager, windowContainer)
        {
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            Draw(TextureContainer.Name, new Rectangle(0, 0, WindowContainer.ResolutionX, WindowContainer.ResolutionY),
                spriteBatch, gameContentManager);
        }

        public override LevelContentTypes ContentType => LevelContentTypes.Atmosphere;
    }
}