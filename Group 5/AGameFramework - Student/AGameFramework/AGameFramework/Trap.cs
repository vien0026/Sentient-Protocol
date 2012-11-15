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
    public class Trap : TrapSocket
    {
        public uint Money; //**Temporary variable** represent the total cash the player currently has        
        public float playerPosX; //**Temporary variable** Where is the player currently on the X axis (if we have more than one trap with the same X axis, we require to make a Y axis check too)
        public float enemyPosX;//**Temporary variable** Where is the enemy  currently on the X axis (if we have more than one trap with the same X axis, we require to make a Y axis check too)

        #region Fields

        List<Trap> trapList = new List<Trap>(); //holds all the type of traps
        public ushort m_TrapID;      //To tell us in the list which type of trap he is
        public uint m_Power;      //gives a numerical value for how strong the trap is (can both represent damage or effects such as slow)
        public uint m_Cost;       //How much mony is needed to spent in order to aquire the trap.  Can also be use to regain money when a trap is sold
        public float m_Delay;      //How much time it takes between attacks to recharge (not always applicable "For example, slowdown traps")
        public Vector2 m_TrapPos;  //The X and Y position of the trap on screen
        public Texture2D m_TrapTex; //the texture of which ever trap is used
        public bool m_IsTrapRdy;    //toggeling when the trap can activate or not

        #endregion
       

        #region Properties

        public ushort TrapsID   //We dont need a set because the ID will not change as long as it used.
        {
            get { return m_TrapID; }
        }
        public uint Power
        {
            get { return m_Power; }

            set { m_Power = value; }
        }
        public uint Cost
        {
            get { return m_Cost; }

            set { m_Cost = value; }
        }
        public float Delay
        {
            get { return m_Delay; }

            set { m_Delay = value; }
        }

        #endregion


        #region Methods
                                                         ////////////////ADD TRAP//////////////

        public string addTrap(Trap trap) //Two part here, first we need to check if the player is near a placable trap socket and also if he has enough money
        {
            int selectedTrap = 0;   

            for (int i = 0; i < trapSockets.Count(); i++)   //Looping every trap socket to check which one the user is currently standing on (if he is actually standing on one)
            {
                if (playerPosX >= trapSockets[i].trapSocketPos.X && playerPosX <= trapSockets[i].trapSocketPos.X + trapSocketWidth && isTrapSet == false) //This check if we are currently standing on a trap socket and also which one we are standing on.  We check if we stand between the trap socket due to the vector2 trapSocketPos.X and on the other side with the lenght of the trap.
                {
                    selectedTrap = i;   //this int is simply to keep on storing i for the next if check because we still need it
                    trapList.Add(trap); //if the user has enough money, adding the trap to the list But if not, the trap will be removed *The reason why it's there it's because we need to know how much it cost for the next if
                    break;  //we leave the if statement and loop because the player is correctly standing on a trapSocket
                }
                else
                {
                    return "You are not on an empty trap socket";
                }
            }


            if (Money >= trapList.Last<Trap>().m_Cost) //Checking if the user has enouh money to buy ** WE need to make sure this is the good price for the trap**
            {
               
                trapList.Last<Trap>().m_TrapPos.Y = trapSockets[selectedTrap].trapSocketPos.Y;

                trapSockets[selectedTrap].isTrapSet = true;     //flag a bool to indicate a trap has been set and cannot be replaced until user sell the trap holding that spot
                Money = Money - trapList.Last<Trap>().m_Cost;                       //taking out the amount due
                return trap + " Was Placed Successfully";
            }
            else                            //If the user does not have enough money
            {
                trapList.Remove(trap);      //If he could not afford the trap, take it out
                return "Not enough money";
            }
        }
                                               
                                                /// /////////////////REMOVETRAP/////////////////////


        public string removeTrap()  //We only have to check if he is on an actif trap this time
        {
            for (int i = 0; i < trapSockets.Count; i++)
            {
                if (playerPosX >= trapSockets[i].trapSocketPos.X && playerPosX <= trapSockets[i].trapSocketPos.X + trapSocketWidth && isTrapSet == true) //same thing as add a trap exept we check this this if there is one
                {
                    trapSockets[i].isTrapSet = false;   //important to indicate that this socket is currently free

                    for (int I = 0; I < trapList.Count(); I++)  //looping insde the list of traps to find out which one we need to remove
                    {
                        if (playerPosX >= trapList[i].m_TrapPos.X && playerPosX <= trapList[i].m_TrapPos.X + trapSocketWidth)   //Now we are checking which trap we need to remove according to where we are standing
                        {
                            trapList.Remove(trapList[i]);       //remove trap from the list
                            Money = Money + trapList[i].m_Cost; //give back the money of the current trap sold
                            return "Trap removed successfully";
                        }
                    }
                }
            }


            return "You are not on a actif trap";       //If we where not able to find an active trap

        }

        public virtual void attack(float enemyPosX)
        {
            for (int i = 0; i < trapList.Count(); i++)
            {
                if (enemyPosX >= trapList[i].m_TrapPos.X && enemyPosX <= trapList[i].m_TrapPos.X + trapSocketWidth && m_IsTrapRdy==true) //This check if an enemy is standing on a actif trap
                {
                //TODO:: add what will happen to any enemy landing on your trap here(in your override function)
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {

        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < trapList.Count(); i++)      //Loops to all the currently actif traps
            {
                spriteBatch.Draw(trapList[i].m_TrapTex, trapList[i].m_TrapPos, Color.White);    //Draw all actif traps
            }
        }


        #endregion
    }
}
