
using System;
using System.Collections.Generic;
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

        public Vector2 velocities
        {
            
            get { return velocity; }
            set { velocity = value; }
        }

        public Vector2 velocity;
        public bool idle = true;
        private currentAnimation playerAnimationController;


        private bool animationXReverse = false;
        private bool animationYReverse = false;

        private Dictionary<string, Animation> animations;

        public Player(ContentManager content, Vector2 position) : base(content, position)
        {
            
            velocity = new Vector2(10, 10);

            animations = new Dictionary<string, Animation>();

            animations["idle"] = new Animation(content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Idle (32 x 32)"));
            
            animations["moving"] = new Animation(content.Load<Texture2D>("Sprite Pack 4\\1 - Agent_Mike_Running (32 x 32)"));



            playerAnimationController = currentAnimation.Idle;
            
        }

        //public override void Load(Texture2D spriteSheet)
        //{  

        //}
        public override void Update(GameTime gameTime)
        {
            try
            {
                KeyboardState keyboard = Keyboard.GetState();
                bool idle = true;
                if (keyboard.IsKeyDown(Keys.W))
                {

                    //position.Y -= velocity.Y;
                    animationYReverse = true;
                    idle = false;
                    playerAnimationController = currentAnimation.Moving;
                }
                if (keyboard.IsKeyDown(Keys.S))
                {
                    //position.Y += velocity.Y;
                    animationYReverse = false;
                    idle = false;
                    playerAnimationController = currentAnimation.Moving;
                }
                if (keyboard.IsKeyDown(Keys.A))
                {
                    //position.X -= velocity.X;
                    idle = false;
                    animationXReverse = true;
                    playerAnimationController = currentAnimation.Moving;
                }
                if (keyboard.IsKeyDown(Keys.D))
                {
                    //position.X += velocity.X;
                    idle = false;
                    animationXReverse = false;
                    playerAnimationController = currentAnimation.Moving;
                }
                if (idle)
                {
                    playerAnimationController = currentAnimation.Idle;
                }

                switch (playerAnimationController)
                {
                    case currentAnimation.Idle:
                        animations["idle"].XReverse = animationXReverse;
                        animations["idle"].YReverse = animationYReverse;
                        animations["idle"].Update(gameTime);
                        break;
                    case currentAnimation.Moving:
                        animations["moving"].XReverse = animationXReverse;
                        animations["moving"].YReverse = animationYReverse;
                        animations["moving"].Update(gameTime);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Update: {ex.Message}");
            }
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            //Rectangle rect = this.Rect;
            //rect.X += (int)position.X;
            //rect.Y += (int)position.Y;

            Rectangle drect = new Rectangle(Rect.X + (int)position.X, Rect.Y + (int)position.Y, Rect.Width, Rect.Height);

            switch (playerAnimationController)
            {
                case currentAnimation.Idle:
                    animations["idle"].Draw(spriteBatch, drect);
                    break;
                case currentAnimation.Moving:
                    animations["moving"].Draw(spriteBatch, drect);
                    break;
            }
        }


    }
}
