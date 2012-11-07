using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AGameFramework
{
    class NPCGameObject : RenderableGameObject
    { 
        

            public override void Update(GameTime gameTime)
            {
                base.Update(gameTime);
                position.Y += -9.81f;
            }


        
       


    }
}
