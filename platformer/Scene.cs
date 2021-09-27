using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.Collections.Generic;

namespace platformer
{
    public class Scene
    {
        private readonly Dictionary<string, Texture> textures;
        private readonly List<Entity> entities;
        public string nextScene;
        public string currentScene;

        //Fråga help sos
        //det ska vara readonly, men vi har gjort den static så att den slutar klaga just nu.
        public Scene()
        {
            textures = new Dictionary<string, Texture>();
            entities = new List<Entity>();
        }
        public void spawn(Entity entity)
        {
            entities.Add(entity);
            entity.Create(this);
            //fråga emil
        }
        public Texture LoadTexture(string name)
        {
            if (textures.TryGetValue(name, out Texture found))
            {
                return found;
            }
            string fileName = $"assets/{name}.png";
            Texture texture = new Texture(fileName);
            textures.Add(name, texture);
            return texture;
        }
        public void UpdateAll(float deltaTime)
        {
            HandleSceneChange();
            for (int i = entities.Count - 1; i >= 0; i--)
            {
                Entity entity = entities[i];
                entity.Update(this, deltaTime);
            }
            for (int i = 0; i < entities.Count;)
            {
                Entity entity = entities[i];
                if (entity.Dead)
                {
                    entities.RemoveAt(i);
                }
                else i++;
            }
        }
        public void renderAll(RenderTarget target)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].render(target);
            }

        }
        public bool TryMove(Entity entity, Vector2f movement)
        {
            entity.Position += movement;
            bool collided = false;
            for (int i = 0; i < entities.Count; i++)
            {
                Entity other = entities[i];
                if (!other.Solid) continue;
                if (other == entity) continue;
                FloatRect boundsA = entity.Bounds;
                FloatRect boundsB = other.Bounds;
                if (Collision.RectangleRectangle(boundsA, boundsB,
                out Collision.Hit hit))
                {
                    entity.Position += hit.Normal * hit.Overlap;
                    i = -1;
                    collided = true;
                }
            }
            return collided;
        }
        public void Reload()
        {
            currentScene = nextScene;
        }
        public void Load(string next)
        {

        }
        private void HandleSceneChange()
        {

        }
    }
}
