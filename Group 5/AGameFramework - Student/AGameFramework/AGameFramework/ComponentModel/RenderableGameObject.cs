using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace AGameFramework
{
    public class RenderableGameObject: GameObject, IDraw
    {

        Texture2D texture;
        public Texture2D Texture
        {
            get { return texture; }

            set {  
            texture = value; 
            BoundingBox.Width = texture.Width;
            BoundingBox.Height = texture.Height;
            }

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(texture, position, Color.Aqua);
        }

    }
    
}
