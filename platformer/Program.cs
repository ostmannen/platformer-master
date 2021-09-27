using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace platformer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var Window = new RenderWindow(
                new VideoMode(800, 600), "Platformer"))
            {
                Window.Closed += (o, e) => Window.Close();
                Clock clock = new Clock();

                Scene scene = new Scene();

                Background background = new Background();
                scene.spawn(background);


                scene.spawn(new Key
                {
                    Position = new Vector2f(300, 200)
                });

                scene.spawn(new Door
                {
                    Position = new Vector2f(150, 265)
                });

                scene.spawn(new Hero
                {
                    Position = new Vector2f(100, 268)
                });

                scene.spawn(new Platform{
                    Position = new Vector2f(150, 265)
                });


                for (int i = 0; i < 28; i++)
                {
                    scene.spawn(new Platform
                    {
                        Position = new Vector2f(18 + i * 18, 288)
                    });
                }

                Window.SetView(new View(
                    new Vector2f(200, 150),
                    new Vector2f(400, 300)));

                while (Window.IsOpen)
                {
                    Window.DispatchEvents();
                    float deltaTime = clock.Restart().AsSeconds();
                    Window.Clear();
                    scene.UpdateAll(deltaTime);
                    scene.renderAll(Window);
                    Window.Display();
                }
            }
        }
    }
}
