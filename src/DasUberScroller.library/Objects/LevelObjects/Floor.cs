using DasUberScroller.lib.Containers;
using DasUberScroller.lib.Enums;
using DasUberScroller.lib.Managers;
using DasUberScroller.lib.Objects.LevelObjects.Base;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DasUberScroller.lib.Objects.LevelObjects
{
    public class Floor : LevelObject
    {
        public Floor() : base(null, null, null) { }

        public Floor(string textureName, GameContentManager contentManager, WindowContainer windowContainer) : base(textureName, contentManager, windowContainer)
        {
        }

        public override void Render(SpriteBatch spriteBatch, GameContentManager gameContentManager)
        {
            Draw(TextureContainer.Name,
                new Rectangle(0, 0, WindowContainer.ResolutionX, TextureContainer.Height),
                new Vector2(0, WindowContainer.ResolutionY - TextureContainer.Height),
                1.0f,
                spriteBatch,
                gameContentManager);
        }

        public override LevelContentTypes ContentType => LevelContentTypes.Floor;
    }
}