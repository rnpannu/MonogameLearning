
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameLearning.src
{
    public class Animation
    {
        Texture2D spriteSheet;
        private int frames = 0;
        private int rows = 0;
        private int counter = 0;
        private int activeFrame = 0;

        private int frameWidth;
        private int frameHeight;

        private bool Xreverse = false;
        private bool Yeverse = false;
        public bool XReverse
        {
            get { return Xreverse; }
            set { Xreverse = value; }
        }
        public bool YReverse
        {
            get { return Yeverse; }
            set { Yeverse = value; }
        }


        public Animation(Texture2D spriteSheet, int frameWidth = 32, int frameHeight = 32)
        { // also speed and timer if necessary
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.spriteSheet = spriteSheet;
            this.frames = //(int)
                (spriteSheet.Width / frameWidth);
            this.rows = //(int)
                (spriteSheet.Height / frameHeight);
            this.counter = 0;
            Texture2D[,] animFrames = new Texture2D[rows, frames];
            
        }

        public void Update()
        {
            counter++;
     
            if (counter > 29)
            {
                counter = 0;
                activeFrame++;
                activeFrame = activeFrame % frames;
            }

        }
        public void Draw(SpriteBatch spriteBatch, Rectangle rect)
        {
            if (Xreverse)
            {
                spriteBatch.Draw(spriteSheet,
                    rect,
                    new Rectangle(activeFrame * frameWidth, rows - 1, frameWidth, frameHeight),
                    Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0
                    );
                return;
            } //else if (Yeverse)
            //{
            //    spriteBatch.Draw(spriteSheet,
            //        rect,
            //        new Rectangle(activeFrame * frameWidth, rows - 1, frameWidth, frameHeight),
            //        Color.White, 0, Vector2.Zero, SpriteEffects.FlipVertically, 0
            //        );
            //    return;
            //}
            else
            {
                spriteBatch.Draw(spriteSheet,
                    rect,
                    new Rectangle(activeFrame * frameWidth, rows - 1, frameWidth, frameHeight),
                    Color.White
                    );
            }
            //Rectangle rect = new Rectangle(32 * counter, 0, 32, 32);
            //spriteBatch.Draw(spriteSheet,
            //    rect,
            //    new Rectangle(activeFrame * frameWidth, rows - 1, frameWidth, frameHeight),
            //    Color.White
            //    );
            //spriteBatch.Draw(spriteSheet,
            //    rect,
            //    new Rectangle(activeFrame * frameWidth, rows - 1, frameWidth, frameHeight),
            //    Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0
            //    );
        }
    }


}
