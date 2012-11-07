using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AGameFramework
{
    public class PlayerGameObject : RenderableGameObject{

        public PlayerGameObject()
        {


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            GamePadState gameState= GamePad.GetState(PlayerIndex.One);
            if (gameState.ThumbSticks.Left.X > 0)
            {
                position.X += 0.5f;

            }

            if (gameState.ThumbSticks.Left.X < 0)
            {
                position.X -= 0.5f;

            }
        }


    }
   
}
