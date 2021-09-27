using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    public class Key : Entity
    {
        public Key() : base("tileset")
        {
            sprite.TextureRect = new IntRect(126, 18, 18, 18);
            sprite.Origin = new Vector2f(9, 9);

        }
    }
}
