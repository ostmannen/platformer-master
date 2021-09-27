using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    public class Hero : Entity
    {
        public Hero() : base("tileset"){
            sprite.TextureRect = new IntRect(0, 0, 18, 18);
            sprite.Origin = new Vector2f(9, 9);
            
         }
    }
}
