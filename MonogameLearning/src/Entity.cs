
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameLearning.src
{
    public abstract class Entity
    {
        //public Texture2D texture;
        public Vector2 position;

        //public abstract void Load(Texture2D spriteSheet);
        public Entity(ContentManager content, Vector2 position)
        {
            //this.texture = sprite;
            this.position = position;
        }
        public abstract void Update();


        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
