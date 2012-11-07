using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AGameFramework
{

    public class AnimatedGameObject : PlayerGameObject
    {

        public override void Draw(GameTime gameTime, SpriteBatch sb)
        {
            sb.Draw(Texture, position, Color.Black);
        }












    }
}
