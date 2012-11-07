using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AGameFramework
{
    public abstract class BaseGameObject : IUpdate
    {
        public string name;
        public Vector2 position;
        public float rotation;

        public abstract void Update(GameTime gameTime);




    }
}
