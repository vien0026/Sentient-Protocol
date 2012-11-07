using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AGameFramework
{
    interface IDraw
    {
        Texture2D Texture
        {
            get;
            set;
        }



        void Draw(GameTime gameTime, SpriteBatch sb);
    }
}
