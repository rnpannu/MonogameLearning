using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameLearning.src
{
    public static class Drawing
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;


        public static int width { get; private set; }
        public static int height { get; private set; }

        public static string title = "Monogame Test Project";

        public static bool vsych { get; private set; } = true;

        public static float dt, fps;

        //dummy texture
        public static Texture2D rect;

        public static void Initialize(Game1 g)
        {
            width = 1920;
            height = 1080;
            graphics = new GraphicsDeviceManager(g);
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.SynchronizeWithVerticalRetrace = vsych;
            graphics.ApplyChanges();

            spriteBatch = new SpriteBatch(g.GraphicsDevice);


        }

        public static void Update(GameTime gameTime, Game1 g)
        {
            dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            fps = (float) (1 / dt);
        }
    }


}
