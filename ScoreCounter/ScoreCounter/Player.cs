using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCounter
{
    class Player
    {
        //Variables
        public string[] namesArray;
        int i;

        //constructor
        public Player()
        {
            i = 0;
        }

        //Methods
        public void SetNumPlayers(int aNum)
        {
            namesArray = new string [aNum];
        }//end SetNumPlayers

        public void AddPlayerToArray(string aName)
        {
            if (i <= namesArray.Length)
            {
                //add player to array or append namesArray
                namesArray[i] = aName;
                //increment i
                i++;
            }
           
        }//end AddPlayerToArray
    }
}
