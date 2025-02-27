
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameLearning.src
{
    public class Player : Entity
    {

        // Want to use property for Rect as it is dependent on position
        // Using a normal field would not update the rectangle when the position changes
        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 115, 100);
            }
        }

        public Vector2 velocity;
        public bool idle = true;
        private Animation currentAnimation;

        private Texture2D idleSprite;
        private Animation idleAnimation;

        private Texture2D movingSprite;
        private Animation movingAnimation;

        // public Animation walkAnimation;

        // Load spritesheets into memory
        // Injecting sprite and position into base constructor, then subclass implementation 
        public Player(ContentManager content, Vector2 position) : base(content, position)
        {
            
            velocity = new Vector2(10, 10);

            idleSprite = content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)");
            idleAnimation = new Animation(idleSprite);

            movingSprite = content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)");
            movingAnimation = new Animation(movingSprite);


            currentAnimation = idleAnimation;
            // movingSprite = Content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)");
            // movingAnimation = new Animation(mnovingSprite);
        }

        //public override void Load(Texture2D spriteSheet)
        //{  

        //}
        public override void Update()
        {
            try
            {
                KeyboardState keyboard = Keyboard.GetState();
                bool idle = true;
                if (keyboard.IsKeyDown(Keys.W))
                {
                    Console.WriteLine("W key pressed");
                    position.Y -= velocity.Y;
                    currentAnimation.YReverse = true;
                    idle = false;
                    currentAnimation = movingAnimation;
                }
                if (keyboard.IsKeyDown(Keys.S))
                {
                    Console.WriteLine("S key pressed");
                    position.Y += velocity.Y;
                    currentAnimation.YReverse = false;
                    idle = false;
                    currentAnimation = movingAnimation;
                }
                if (keyboard.IsKeyDown(Keys.A))
                {
                    position.X -= velocity.X;
                    idle = false;
                    currentAnimation.XReverse = true;
                    currentAnimation = movingAnimation;
                }
                if (keyboard.IsKeyDown(Keys.D))
                {
                    position.X += velocity.X;
                    idle = false;
                    currentAnimation.XReverse = false;
                    currentAnimation = movingAnimation;
                }
                if (idle)
                {
                    currentAnimation = idleAnimation;
                }
                currentAnimation.Update();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Update: {ex.Message}");
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch, this.Rect);
            //spriteBatch.Draw(texture, this.Rect, Microsoft.Xna.Framework.Color.White);
        }


    }
}
