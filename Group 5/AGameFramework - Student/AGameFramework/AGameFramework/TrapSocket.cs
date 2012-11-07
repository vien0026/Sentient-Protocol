using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Media;
namespace AGameFramework
{
    public class TrapSocket
    {
        public List<TrapSocket> trapSockets = new List<TrapSocket>(); // a list of trap sockets (class trap socket not currently made so replace it with int)  this will help us loop trough all the socket in game
        public Vector2 trapSocketPos; //the position of X and Y of a trap socket
        public bool isTrapSet; // We are checking if the trapSocket currently holds a trap
        public const float trapSocketWidth = 100;  // how large is the trap socket? (mostly used to check if the user is currently on a trapsocket, look at the method below public string addtrap(trap trap))

        public void Update(GameTime gameTime)
        {
            //TODO: update the trap socket
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //TODO: Draw the trap socket on screen
        }
    }
}
