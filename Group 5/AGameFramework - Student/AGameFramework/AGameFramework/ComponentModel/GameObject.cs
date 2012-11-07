using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace AGameFramework
{
    public class GameObject : BaseGameObject
    {
        public Rectangle BoundingBox = Rectangle.Empty;


        public GameObject()
        {


        }
        
        public override void Update(GameTime gameTime)
        {
            // casting int to float 
            BoundingBox.X = (int)position.X;
            BoundingBox.Y = (int)position.Y;
        }


    }

   
}
