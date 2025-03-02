

using System.Reflection;
using Microsoft.Xna.Framework;

namespace MonogameLearning.src
{
    public class FollowCamera
    {
        public Vector2 position;
        public Matrix transform;
        public float delay = 3.0f;
        public FollowCamera(Vector2 position)
        {
            this.position = position;
        }

        public void Follow(Vector2 target)
        {
            //float d = delay * (float) dt.ElapsedGameTime.TotalMilliseconds;
            float d = delay * Drawing.dt;

            position.X += ((target.X - position.X) - Drawing.width / 2) * d;
            position.Y += ((target.Y - position.Y) - Drawing.height / 2) * d;
            
            transform = Matrix.CreateTranslation((int) -position.X, (int) -position.Y, 0);

            //position = new Vector2(

            //    -target.X + (screenSize.X / 2 - target.Width / 2),
            //    -target.Y + (screenSize.Y / 2 - target.Height / 2)
            //);

        }
    }
}
