using DasUberScroller.UWP.Containers;
using DasUberScroller.UWP.Enums;
using DasUberScroller.UWP.Managers;
using DasUberScroller.UWP.Objects.LevelObjects.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DasUberScroller.UWP.Objects.LevelObjects
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