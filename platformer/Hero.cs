using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    public class Hero : Entity
    {

        private bool faceRight = false;
        public Hero() : base("characters")
        {
            sprite.TextureRect = new IntRect(0, 0, 24, 24);
            sprite.Origin = new Vector2f(12, 12);
        }
        public override void Update(Scene scene, float deltaTime)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                Position -= new Vector2f(100 * deltaTime, 0);
                faceRight = false;
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                Position += new Vector2f(100 * deltaTime, 0);
                faceRight = true;
            }
        }
        public override void render(RenderTarget target)
        {
            sprite.Scale = new Vector2f(faceRight ? -1 : 1, 1);
            base.render(target);
        }
    }
}
