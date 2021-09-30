using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    public class Door : Entity
    {
        public string NextRoom;
        public bool Inlocked;
        public Door() : base("tileset")
        {
            sprite.TextureRect = new IntRect(180, 103, 18, 23);
            sprite.Origin = new Vector2f(9, 9);
            NextRoom = 

        }
    }
}
